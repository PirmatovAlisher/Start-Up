using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.HomePageVM;
using EntityLayer.WebApplication.ViewModels.ServiceVM;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Exceptions.WebApplication;
using ServiceLayer.Messages.WebApplication;
using ServiceLayer.Services.WebApplication.Abstract;

namespace ServiceLayer.Services.WebApplication.Concrete
{
    public class ServiceService : IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Service> _repository;
        private readonly IToastNotification _toasty;
        private const string Section = "Service ";

        public ServiceService(IUnitOfWork unitOfWork, IMapper mapper, IToastNotification toasty)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<Service>();
            _toasty = toasty;
        }




        public async Task<List<ServiceListVM>> GetAllListAsync()
        {
            //var serviceListVM = await _repository.GetAllEntityList().
            //                                    ProjectTo<ServiceListVM>(_mapper.ConfigurationProvider).
            //                                    ToListAsync();

            var serviceList = await _repository.GetAllEntityList().ToListAsync();

            var serviceListVM = _mapper.Map<List<ServiceListVM>>(serviceList);

            return serviceListVM;
        }

        public async Task AddServiceAsync(ServiceAddVM request)
        {
            var service = _mapper.Map<Service>(request);
            await _repository.AddEntityAsync(service);
            await _unitOfWork.CommitAsync();
            _toasty.AddSuccessToastMessage(NotificationMessagesWebApplication.AddMessage(Section),
                new ToastrOptions { Title = NotificationMessagesWebApplication.SucceededTitle });
        }

        public async Task DeleteServiceAsync(int id)
        {
            var service = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(service);
            await _unitOfWork.CommitAsync();
            _toasty.AddWarningToastMessage(NotificationMessagesWebApplication.DeleteMessage(Section),
                new ToastrOptions { Title = NotificationMessagesWebApplication.SucceededTitle });
        }

        public async Task<ServiceUpdateVM> GetServiceById(int id)
        {
            var service = await _repository.Where(x => x.Id == id).
                                          ProjectTo<ServiceUpdateVM>(_mapper.ConfigurationProvider).
                                          SingleAsync();
            return service;
        }

        public async Task UpdateServiceAsync(ServiceUpdateVM request)
        {
            var service = _mapper.Map<Service>(request);

            _repository.UpdateEntity(service);
            var result = await _unitOfWork.CommitAsync();
            if (!result)
            {
                throw new ClientSideExceptions(ExceptionMessages.ConcurrencyException);
            }
            _toasty.AddInfoToastMessage(NotificationMessagesWebApplication.UpdateMessage(Section),
                new ToastrOptions { Title = NotificationMessagesWebApplication.SucceededTitle });
        }

        // UI side methods

        public async Task<List<ServiceListForUI>> GetAllListForUIAsync()
        {
            var uiList = await _repository.GetAllEntityList().ToListAsync();

            var serviceListVMForUI = _mapper.Map<List<ServiceListForUI>>(uiList);

            return serviceListVMForUI;
        }
    }
}
