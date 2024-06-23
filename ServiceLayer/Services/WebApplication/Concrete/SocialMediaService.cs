using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.SocialMediaVM;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Messages.WebApplication;
using ServiceLayer.Services.WebApplication.Abstract;

namespace ServiceLayer.Services.WebApplication.Concrete
{
	public class SocialMediaService : ISocialMediaService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IGenericRepositories<SocialMedia> _repository;
		private readonly IToastNotification _toasty;
		private const string Section = "Social Media ";

		public SocialMediaService(IUnitOfWork unitOfWork, IMapper mapper, IToastNotification toasty)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_repository = _unitOfWork.GetGenericRepository<SocialMedia>();
			_toasty = toasty;
		}




		public async Task<List<SocialMediaListVM>> GetAllListAsync()
		{
			//var socialMediaListVM = await _repository.GetAllEntityList().
			//                                    ProjectTo<SocialMediaListVM>(_mapper.ConfigurationProvider).
			//                                    ToListAsync();

			var socialMediaList = await _repository.GetAllEntityList().ToListAsync();

			var socialMediaListVM = _mapper.Map<List<SocialMediaListVM>>(socialMediaList);

			return socialMediaListVM;
		}

		public async Task AddSocialMediaAsync(SocialMediaAddVM request)
		{
			var socialMedia = _mapper.Map<SocialMedia>(request);
			await _repository.AddEntityAsync(socialMedia);
			await _unitOfWork.CommitAsync();
			_toasty.AddSuccessToastMessage(NotificationMessages.AddMessage(Section),
				new ToastrOptions { Title = NotificationMessages.SucceededTitle });
		}

		public async Task DeleteSocialMediaAsync(int id)
		{
			var socialMedia = await _repository.GetEntityByIdAsync(id);
			_repository.DeleteEntity(socialMedia);
			await _unitOfWork.CommitAsync();
			_toasty.AddWarningToastMessage(NotificationMessages.DeleteMessage(Section),
				new ToastrOptions { Title = NotificationMessages.SucceededTitle });
		}

		public async Task<SocialMediaUpdateVM> GetSocialMediaById(int id)
		{
			var socialMedia = await _repository.Where(x => x.Id == id).
										  ProjectTo<SocialMediaUpdateVM>(_mapper.ConfigurationProvider).
										  SingleAsync();
			return socialMedia;
		}

		public async Task UpdateSocialMediaAsync(SocialMediaUpdateVM request)
		{
			var socialMedia = _mapper.Map<SocialMedia>(request);

			_repository.UpdateEntity(socialMedia);
			await _unitOfWork.CommitAsync();
			_toasty.AddInfoToastMessage(NotificationMessages.UpdateMessage(Section),
				new ToastrOptions { Title = NotificationMessages.SucceededTitle });
		}
	}
}
