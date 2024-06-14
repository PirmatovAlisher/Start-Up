﻿using CoreLayer.Enumerators;
using CoreLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Helpers.Generic.Image
{
	public class ImageHelper : IImageHelper
	{
		private readonly IHostEnvironment _hostEnvironment;
		private readonly string wwwRoot;
		private readonly string imageFolder = "Images";
		private readonly string identityFolder = "User";
		private readonly string aboutFolder = "AboutUs";
		private readonly string portfolioFolder = "Portfolios";
		private readonly string teamFolder = "Team";
		private readonly string testimonialFolder = "Testimonials";

		public ImageHelper(IHostEnvironment hostEnvironment)
		{
			_hostEnvironment = hostEnvironment;
			wwwRoot = _hostEnvironment.ContentRootPath + "wwwroot/";
		}


		public async Task<ImageUploadModel> ImageUpload(string name, IFormFile imageFile, ImageType imageType, string? folderName)
		{
			if (folderName == null)
			{
				switch (imageType)
				{
					case ImageType.about:
						folderName = $"{aboutFolder}";
						break;
					case ImageType.identity:
						folderName = $"{identityFolder}";
						break;
					case ImageType.portfolio:
						folderName = $"{portfolioFolder}";
						break;
					case ImageType.team:
						folderName = $"{teamFolder}";
						break;
					case ImageType.testimonial:
						folderName = $"{testimonialFolder}";
						break;
				}
			}

			if (!Directory.Exists($"{wwwRoot}/{imageFolder}/{folderName}"))
			{
				Directory.CreateDirectory($"{wwwRoot}/{imageFolder}/{folderName}");
			}

			string fileExtension = Path.GetExtension(imageFile.Name).ToLower();
			if (fileExtension != "jpg" || fileExtension != "jpeg")
			{
				return new ImageUploadModel { Error = "Please upload file only in .jpg or .jpeg format" };
			}

			var dateTime = DateTime.Now;

			var newFileName = folderName + "_" + dateTime.Microsecond.ToString();

			string path = Path.Combine($"{wwwRoot}/{imageFolder}/{folderName}", newFileName);

			await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, false);

			await imageFile.CopyToAsync(stream);
			await stream.FlushAsync();

			return new ImageUploadModel { FileName = $"{folderName}/{newFileName}", FileType = imageFile.ContentType };

		}

		public string DeleteImage(string imageName)
		{
			var fileToDelete = Path.Combine($"{wwwRoot}/{imageFolder}/{imageName}");
			if (File.Exists(fileToDelete))
			{
				File.Delete(fileToDelete);
			}
			return "Image is deleted";
		}


	}
}
