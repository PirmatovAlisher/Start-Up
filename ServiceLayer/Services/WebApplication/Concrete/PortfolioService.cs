using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoreLayer.Enumerators;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.HomePageVM;
using EntityLayer.WebApplication.ViewModels.PortfolioVM;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Helpers.Generic.Image;
using ServiceLayer.Services.WebApplication.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.WebApplication.Concrete
{
	public class PortfolioService : IPortfolioService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IGenericRepositories<Portfolio> _repository;
		private readonly IImageHelper _imageHelper;

		public PortfolioService(IUnitOfWork unitOfWork, IMapper mapper, IImageHelper imageHelper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_repository = _unitOfWork.GetGenericRepository<Portfolio>();
			_imageHelper = imageHelper;
		}




		public async Task<List<PortfolioListVM>> GetAllListAsync()
		{
			//var portfolioListVM = await _repository.GetAllEntityList().
			//                                    ProjectTo<PortfolioListVM>(_mapper.ConfigurationProvider).
			//                                    ToListAsync();

			var portfolioList = await _repository.GetAllEntityList().ToListAsync();

			var portfolioListVM = _mapper.Map<List<PortfolioListVM>>(portfolioList);

			return portfolioListVM;
		}

		public async Task AddPortfolioAsync(PortfolioAddVM request)
		{
			var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.portfolio, null);

			if (imageResult.Error != null)
			{
				return;
			}

			request.FileName = imageResult.FileName!;
			request.FileType = imageResult.FileType!;


			var portfolio = _mapper.Map<Portfolio>(request);
			await _repository.AddEntityAsync(portfolio);
			await _unitOfWork.CommitAsync();
		}

		public async Task DeletePortfolioAsync(int id)
		{
			var portfolio = await _repository.GetEntityByIdAsync(id);
			_repository.DeleteEntity(portfolio);
			await _unitOfWork.CommitAsync();
			_imageHelper.DeleteImage(portfolio.FileName);
		}

		public async Task<PortfolioUpdateVM> GetPortfolioById(int id)
		{
			var portfolio = await _repository.Where(x => x.Id == id).
										  ProjectTo<PortfolioUpdateVM>(_mapper.ConfigurationProvider).
										  SingleAsync();
			return portfolio;
		}

		public async Task UpdatePortfolioAsync(PortfolioUpdateVM request)
		{
			var oldPortfolio = await _repository.Where(x => x.Id == request.Id).AsNoTracking().FirstAsync();

			if (request.Photo != null)
			{
				var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.portfolio, null);

				if (imageResult.Error != null)
					return;

				request.FileName = imageResult.FileName!;
				request.FileType = imageResult.FileType!;
			}


			var portfolio = _mapper.Map<Portfolio>(request);

			_repository.UpdateEntity(portfolio);
			await _unitOfWork.CommitAsync();

			if (request.Photo != null)
			{
				_imageHelper.DeleteImage(oldPortfolio.FileName);
			}
		}
	}
}
