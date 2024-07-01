using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.CategortVM;
using EntityLayer.WebApplication.ViewModels.ContactVM;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Exceptions.WebApplication;
using ServiceLayer.Messages.WebApplication;
using ServiceLayer.Services.WebApplication.Abstract;

namespace ServiceLayer.Services.WebApplication.Concrete
{
	public class ContactService : IContactService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IGenericRepositories<Contact> _repository;
		private readonly IToastNotification _toasty;
		private const string Section = "Contact ";

		public ContactService(IUnitOfWork unitOfWork, IMapper mapper, IToastNotification toasty)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_repository = _unitOfWork.GetGenericRepository<Contact>();
			_toasty = toasty;
		}




		public async Task<List<ContactListVM>> GetAllListAsync()
		{
			//var contactListVM = await _repository.GetAllEntityList().
			//                                    ProjectTo<ContactListVM>(_mapper.ConfigurationProvider).
			//                                    ToListAsync();

			var contactList = await _repository.GetAllEntityList().ToListAsync();

			var contactListVM = _mapper.Map<List<ContactListVM>>(contactList);

			return contactListVM;
		}

		public async Task AddContactAsync(ContactAddVM request)
		{
			var contact = _mapper.Map<Contact>(request);
			await _repository.AddEntityAsync(contact);
			await _unitOfWork.CommitAsync();
			_toasty.AddSuccessToastMessage(NotificationMessagesWebApplication.AddMessage(Section),
				new ToastrOptions { Title = NotificationMessagesWebApplication.SucceededTitle });
		}

		public async Task DeleteContactAsync(int id)
		{
			var contact = await _repository.GetEntityByIdAsync(id);
			_repository.DeleteEntity(contact);
			await _unitOfWork.CommitAsync();
			_toasty.AddWarningToastMessage(NotificationMessagesWebApplication.DeleteMessage(Section),
				new ToastrOptions { Title = NotificationMessagesWebApplication.SucceededTitle });
		}

		public async Task<ContactUpdateVM> GetContactById(int id)
		{
			var contact = await _repository.Where(x => x.Id == id).
										  ProjectTo<ContactUpdateVM>(_mapper.ConfigurationProvider).
										  SingleAsync();
			return contact;
		}

		public async Task UpdateContactAsync(ContactUpdateVM request)
		{
			var contact = _mapper.Map<Contact>(request);

			_repository.UpdateEntity(contact);
			var result = await _unitOfWork.CommitAsync();
			if (!result)
			{
				throw new ClientSideExceptions(ExceptionMessages.ConcurrencyException);
			}
			_toasty.AddInfoToastMessage(NotificationMessagesWebApplication.UpdateMessage(Section),
				new ToastrOptions { Title = NotificationMessagesWebApplication.SucceededTitle });
		}

		//Side methods for UI

		public async Task<List<ContactListForUI>> GetAllListForUIAsync()
		{
			var uiList = await _repository.GetAllEntityList().ToListAsync();

			var contactListVMForUI = _mapper.Map<List<ContactListForUI>>(uiList);

			return contactListVMForUI;
		}
	}
}
