using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.SocialMediaVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.AutoMapper.WebApplication
{
    public class SocialMediaMapper : Profile
    {
        public SocialMediaMapper()
        {
            CreateMap<SocialMediaListVM, SocialMedia>().ReverseMap();
            CreateMap<SocialMediaAddVM, SocialMedia>().ReverseMap();
            CreateMap<SocialMediaUpdateVM, SocialMedia>().ReverseMap();
        }
    }
}
