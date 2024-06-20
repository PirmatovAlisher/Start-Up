using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoreLayer.Enumerators;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.TestimonialVM;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Helpers.Generic.Image;
using ServiceLayer.Services.WebApplication.Abstract;

namespace ServiceLayer.Services.WebApplication.Concrete
{
	public class TestimonialService : ITestimonialService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IGenericRepositories<Testimonial> _repository;
		private readonly IImageHelper _imageHelper;

		public TestimonialService(IUnitOfWork unitOfWork, IMapper mapper, IImageHelper imageHelper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_repository = _unitOfWork.GetGenericRepository<Testimonial>();
			_imageHelper = imageHelper;
		}




		public async Task<List<TestimonialListVM>> GetAllListAsync()
		{
			//var testimonialListVM = await _repository.GetAllEntityList().
			//                                    ProjectTo<TestimonialListVM>(_mapper.ConfigurationProvider).
			//                                    ToListAsync();

			var testimonialList = await _repository.GetAllEntityList().ToListAsync();

			var testimonialListVM = _mapper.Map<List<TestimonialListVM>>(testimonialList);

			return testimonialListVM;
		}

		public async Task AddTestimonialAsync(TestimonialAddVM request)
		{
			var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.testimonial, null);

			if (imageResult.Error != null)
			{
				return;
			}

			request.FileName = imageResult.FileName!;
			request.FileType = imageResult.FileType!;

			var testimonial = _mapper.Map<Testimonial>(request);
			await _repository.AddEntityAsync(testimonial);
			await _unitOfWork.CommitAsync();
		}

		public async Task DeleteTestimonialAsync(int id)
		{
			var testimonial = await _repository.GetEntityByIdAsync(id);
			_repository.DeleteEntity(testimonial);
			await _unitOfWork.CommitAsync();
			_imageHelper.DeleteImage(testimonial.FileName);
		}

		public async Task<TestimonialUpdateVM> GetTestimonialById(int id)
		{
			var testimonial = await _repository.Where(x => x.Id == id).
										  ProjectTo<TestimonialUpdateVM>(_mapper.ConfigurationProvider).
										  SingleAsync();
			return testimonial;
		}

		public async Task UpdateTestimonialAsync(TestimonialUpdateVM request)
		{
			var oldTestimonial = await _repository.Where(x => x.Id == request.Id).AsNoTracking().FirstAsync();

			if (request.Photo != null)
			{
				var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.testimonial, null);

				if (imageResult.Error != null)
					return;

				request.FileName = imageResult.FileName!;
				request.FileType = imageResult.FileType!;
			}

			var testimonial = _mapper.Map<Testimonial>(request);

			_repository.UpdateEntity(testimonial);
			await _unitOfWork.CommitAsync();

			if (request.Photo != null)
			{
				_imageHelper.DeleteImage(oldTestimonial.FileName);
			}
		}
	}
}
