using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.TestimonialVM;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Services.Abstract;

namespace ServiceLayer.Services.Concrete
{
    public class TestimonialService : ITestimonialService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Testimonial> _repository;

        public TestimonialService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<Testimonial>();
        }




        public async Task<List<TestimonialListVM>> GetAllListAsync()
        {
            var testimonialListVM = await _repository.GetAllEntityList().
                                                ProjectTo<TestimonialListVM>(_mapper.ConfigurationProvider).
                                                ToListAsync();
            return testimonialListVM;
        }

        public async Task AddTestimonialAsync(TestimonialAddVM request)
        {
            var testimonial = _mapper.Map<Testimonial>(request);
            await _repository.AddEntityAsync(testimonial);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteTestimonialAsync(int id)
        {
            var testimonial = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(testimonial);
            await _unitOfWork.CommitAsync();
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
            var testimonial = _mapper.Map<Testimonial>(request);

            _repository.UpdateEntity(testimonial);
            await _unitOfWork.CommitAsync();
        }
    }
}
