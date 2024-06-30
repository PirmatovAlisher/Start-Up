using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.AboutVM;
using EntityLayer.WebApplication.ViewModels.CategortVM;
using EntityLayer.WebApplication.ViewModels.PortfolioVM;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Exceptions.WebApplication;
using ServiceLayer.Messages.WebApplication;
using ServiceLayer.Services.WebApplication.Abstract;

namespace ServiceLayer.Services.WebApplication.Concrete
{
	public class CategoryService : ICategoryService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IGenericRepositories<Category> _repository;
		private readonly IToastNotification _toasty;
		private const string Section = "Category ";

		public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IToastNotification toasty)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_repository = _unitOfWork.GetGenericRepository<Category>();
			_toasty = toasty;
		}




		public async Task<List<CategoryListVM>> GetAllListAsync()
		{
			//var categoryListVM = await _repository.GetAllEntityList().
			//                                    ProjectTo<CategoryListVM>(_mapper.ConfigurationProvider).
			//                                    ToListAsync();

			var categoryList = await _repository.GetAllEntityList().ToListAsync();

			var categoryListVM = _mapper.Map<List<CategoryListVM>>(categoryList);

			return categoryListVM;
		}

		public async Task AddCategoryAsync(CategoryAddVM request)
		{
			var category = _mapper.Map<Category>(request);
			await _repository.AddEntityAsync(category);
			await _unitOfWork.CommitAsync();
			_toasty.AddSuccessToastMessage(NotificationMessagesWebApplication.AddMessage(Section),
				new ToastrOptions { Title = NotificationMessagesWebApplication.SucceededTitle });

		}

		public async Task DeleteCategoryAsync(int id)
		{
			var category = await _repository.GetEntityByIdAsync(id);
			_repository.DeleteEntity(category);
			await _unitOfWork.CommitAsync();
			_toasty.AddWarningToastMessage(NotificationMessagesWebApplication.DeleteMessage(Section),
				new ToastrOptions { Title = NotificationMessagesWebApplication.SucceededTitle });

		}

		public async Task<CategoryUpdateVM> GetCategoryById(int id)
		{
			var category = await _repository.Where(x => x.Id == id).
										  ProjectTo<CategoryUpdateVM>(_mapper.ConfigurationProvider).
										  SingleAsync();
			return category;
		}

		public async Task UpdateCategoryAsync(CategoryUpdateVM request)
		{
			var category = _mapper.Map<Category>(request);

			_repository.UpdateEntity(category);
			var result = await _unitOfWork.CommitAsync();
			if (!result)
			{
				throw new ClientSideExceptions(ExceptionMessages.ConcurrencyException);
			}
			_toasty.AddInfoToastMessage(NotificationMessagesWebApplication.UpdateMessage(Section),
				new ToastrOptions { Title = NotificationMessagesWebApplication.SucceededTitle });

		}

		//UI Side Methods
		public async Task<List<CategoryListForUI>> GetAllListForUIAsync()
		{
			var uiList = await _repository.GetAllEntityList().ToListAsync();

			var categoryListVMForUI = _mapper.Map<List<CategoryListForUI>>(uiList);

			return categoryListVMForUI;
		}
	}
}
