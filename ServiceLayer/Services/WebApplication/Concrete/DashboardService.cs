﻿using EntityLayer.Identity.Entities;
using EntityLayer.WebApplication.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Services.WebApplication.Abstract;

namespace ServiceLayer.Services.WebApplication.Concrete
{
	public class DashboardService : IDashboardService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly UserManager<AppUser> _userManager;

		public DashboardService(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
		{
			_unitOfWork = unitOfWork;
			_userManager = userManager;
		}

		public async Task<int> GetAllCategoriesCountAsync()
		{
			var categoryCount = await _unitOfWork.GetGenericRepository<Category>().GetAllCount();
			return categoryCount;
		}

		public async Task<int> GetAllPortfoliosCountAsync()
		{
			var portfolioCount = await _unitOfWork.GetGenericRepository<Portfolio>().GetAllCount();
			return portfolioCount;
		}

		public async Task<int> GetAllServicesCountAsync()
		{
			var serviceCount = await _unitOfWork.GetGenericRepository<Service>().GetAllCount();
			return serviceCount;
		}

		public async Task<int> GetAllTeamsCountAsync()
		{
			var teamCount = await _unitOfWork.GetGenericRepository<Team>().GetAllCount();
			return teamCount;
		}

		public async Task<int> GetAllTestimonialsCountAsync()
		{
			var testimonialCount = await _unitOfWork.GetGenericRepository<Testimonial>().GetAllCount();
			return testimonialCount;
		}

		public async Task<int> GetAllUsersCountAsync()
		{
			var categoryCount = await _userManager.Users.CountAsync();
			return categoryCount;
		}
	}
}
