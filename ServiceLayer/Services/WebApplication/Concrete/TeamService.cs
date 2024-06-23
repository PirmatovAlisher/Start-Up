﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoreLayer.Enumerators;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.TeamVM;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Helpers.Generic.Image;
using ServiceLayer.Messages.WebApplication;
using ServiceLayer.Services.WebApplication.Abstract;

namespace ServiceLayer.Services.WebApplication.Concrete
{
	public class TeamService : ITeamService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IGenericRepositories<Team> _repository;
		private readonly IImageHelper _imageHelper;
		private readonly IToastNotification _toasty;
		private const string Section = "Team ";

		public TeamService(IUnitOfWork unitOfWork, IMapper mapper, IImageHelper imageHelper, IToastNotification toasty)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_repository = _unitOfWork.GetGenericRepository<Team>();
			_imageHelper = imageHelper;
			_toasty = toasty;
		}




		public async Task<List<TeamListVM>> GetAllListAsync()
		{
			//var teamListVM = await _repository.GetAllEntityList().
			//                                    ProjectTo<TeamListVM>(_mapper.ConfigurationProvider).
			//                                    ToListAsync();

			var teamMediaList = await _repository.GetAllEntityList().ToListAsync();

			var teamListVM = _mapper.Map<List<TeamListVM>>(teamMediaList);

			return teamListVM;
		}

		public async Task AddTeamAsync(TeamAddVM request)
		{
			var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.team, null);

			if (imageResult.Error != null)
			{
				_toasty.AddErrorToastMessage(imageResult.Error,
					new ToastrOptions { Title = NotificationMessagesWebApplication.FailedTitle });
				return;
			}

			request.FileName = imageResult.FileName!;
			request.FileType = imageResult.FileType!;

			var team = _mapper.Map<Team>(request);
			await _repository.AddEntityAsync(team);
			await _unitOfWork.CommitAsync();
			_toasty.AddSuccessToastMessage(NotificationMessagesWebApplication.AddMessage(Section),
				new ToastrOptions { Title = NotificationMessagesWebApplication.SucceededTitle });
		}

		public async Task DeleteTeamAsync(int id)
		{
			var team = await _repository.GetEntityByIdAsync(id);
			_repository.DeleteEntity(team);
			await _unitOfWork.CommitAsync();
			_imageHelper.DeleteImage(team.FileName);
			_toasty.AddWarningToastMessage(NotificationMessagesWebApplication.DeleteMessage(Section),
				new ToastrOptions { Title = NotificationMessagesWebApplication.SucceededTitle });
		}

		public async Task<TeamUpdateVM> GetTeamById(int id)
		{
			var team = await _repository.Where(x => x.Id == id).
										  ProjectTo<TeamUpdateVM>(_mapper.ConfigurationProvider).
										  SingleAsync();
			return team;
		}

		public async Task UpdateTeamAsync(TeamUpdateVM request)
		{
			var oldTeam = await _repository.Where(x => x.Id == request.Id).AsNoTracking().FirstAsync();

			if (request.Photo != null)
			{
				var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.team, null);

				if (imageResult.Error != null)
				{
					_toasty.AddErrorToastMessage(imageResult.Error, new ToastrOptions { Title = NotificationMessagesWebApplication.FailedTitle });
					return;
				}

				request.FileName = imageResult.FileName!;
				request.FileType = imageResult.FileType!;
			}

			var team = _mapper.Map<Team>(request);

			_repository.UpdateEntity(team);
			await _unitOfWork.CommitAsync();

			if (request.Photo != null)
			{
				_imageHelper.DeleteImage(oldTeam.FileName);
			}
			_toasty.AddInfoToastMessage(NotificationMessagesWebApplication.UpdateMessage(Section),
				new ToastrOptions { Title = NotificationMessagesWebApplication.SucceededTitle });
		}
	}
}
