using EntityLayer.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Configurations.Identity
{
	public class AppUserRoleConfig : IEntityTypeConfiguration<AppUserRole>
	{

		public void Configure(EntityTypeBuilder<AppUserRole> builder)
		{
			builder.HasData(
				new AppUserRole
				{
					UserId = Guid.Parse("256AC0CC-C4B0-458D-957D-24CBFD49225B").ToString(),
					RoleId = Guid.Parse("DE820986-A707-4CC5-8306-776812617837").ToString()
				},

			new AppUserRole
			{
				UserId = Guid.Parse("DCE8CFD5-D290-4353-B50D-58707ED8DA4D").ToString(),
				RoleId = Guid.Parse("D140EB54-ED6E-4FF2-9199-71FCBE722EF7").ToString()
			});
		}
	}
}
