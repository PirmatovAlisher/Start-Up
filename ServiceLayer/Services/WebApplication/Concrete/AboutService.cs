using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.AboutVM;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Services.WebApplication.Abstract;

namespace ServiceLayer.Services.WebApplication.Concrete
{
    public class AboutService : IAboutService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<About> _repository;

        public AboutService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<About>();
        }




        public async Task<List<AboutListVM>> GetAllListAsync()
        {
            //var aboutListVM = await _repository.GetAllEntityList().
            //                                    ProjectTo<AboutListVM>(_mapper.ConfigurationProvider).
            //                                    ToListAsync();

            var aboutList = await _repository.GetAllEntityList().Include(x => x.SocialMedia).ToListAsync();

            var aboutListVM = _mapper.Map<List<AboutListVM>>(aboutList);

            return aboutListVM;
        }

        public async Task AddAboutAsync(AboutAddVM request)
        {
            var about = _mapper.Map<About>(request);
            await _repository.AddEntityAsync(about);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAboutAsync(int id)
        {
            var about = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(about);
            await _unitOfWork.CommitAsync();
        }

        public async Task<AboutUpdateVM> GetAboutById(int id)
        {
            var about = await _repository.Where(x => x.Id == id).
                                          ProjectTo<AboutUpdateVM>(_mapper.ConfigurationProvider).
                                          SingleAsync();
            return about;
        }

        public async Task UpdateAboutAsync(AboutUpdateVM request)
        {
            var about = _mapper.Map<About>(request);

            _repository.UpdateEntity(about);
            await _unitOfWork.CommitAsync();
        }
    }
}
