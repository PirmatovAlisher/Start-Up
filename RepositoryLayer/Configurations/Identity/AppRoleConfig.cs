using EntityLayer.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Configurations.Identity
{
	public class AppRoleConfig : IEntityTypeConfiguration<AppRole>
	{
		public void Configure(EntityTypeBuilder<AppRole> builder)
		{
			builder.HasData(new AppRole
			{
				Id = Guid.Parse("DE820986-A707-4CC5-8306-776812617837").ToString(),
				Name = "SuperAdmin",
				NormalizedName = "SUPERADMIN",
				ConcurrencyStamp = Guid.NewGuid().ToString()

			});

			builder.HasData(new AppRole
			{
				Id = Guid.Parse("D140EB54-ED6E-4FF2-9199-71FCBE722EF7").ToString(),
				Name = "Member",
				NormalizedName = "MEMBER",
				ConcurrencyStamp = Guid.NewGuid().ToString()

			});
		}
	}
}
