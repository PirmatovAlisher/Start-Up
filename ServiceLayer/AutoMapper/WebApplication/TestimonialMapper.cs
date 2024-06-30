using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.TeamVM;
using EntityLayer.WebApplication.ViewModels.TestimonialVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.AutoMapper.WebApplication
{
    public class TestimonialMapper : Profile
    {
        public TestimonialMapper()
        {
            CreateMap<Testimonial, TestimonialAddVM>().ReverseMap();
            CreateMap<Testimonial, TestimonialUpdateVM>().ReverseMap();
            CreateMap<Testimonial, TestimonialListVM>().ReverseMap();
            CreateMap<Testimonial, TestimonialListForUI>().ReverseMap();
        }
    }
}
