using AutoMapper;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.AutoMapper.Identity
{
	public class UserEditMapper : Profile
	{
		public UserEditMapper()
		{
			CreateMap<UserEditVM, AppUser>().ReverseMap();
			CreateMap<AppUser, UserVM>().ReverseMap();
		}
	}
}
