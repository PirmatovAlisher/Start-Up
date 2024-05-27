using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.ServiceVM;
using EntityLayer.WebApplication.ViewModels.TeamVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.AutoMapper
{
    public class TeamMapper : Profile
    {
        public TeamMapper()
        {
            CreateMap<Team, TeamAddVM>().ReverseMap();
            CreateMap<Team, TeamUpdateVM>().ReverseMap();
            CreateMap<Team, TeamListVM>().ReverseMap();
        }
    }
}
