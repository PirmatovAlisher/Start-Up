using EntityLayer.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Configurations.Identity
{
	public class AppUserConfig : IEntityTypeConfiguration<AppUser>
	{
		public void Configure(EntityTypeBuilder<AppUser> builder)
		{
			var admin = new AppUser
			{
				Id = Guid.Parse("256AC0CC-C4B0-458D-957D-24CBFD49225B").ToString(),
				Email = "pirmatovalisher000@gmail.com",
				NormalizedEmail = "PIRMATOVALISHER000@GMAIL.COM",
				UserName = "TestAdmin",
				NormalizedUserName = "TESTADMIN",
				ConcurrencyStamp = Guid.NewGuid().ToString(),
				SecurityStamp = Guid.NewGuid().ToString()
			};

			var adminPasswordHash = PasswordHash(admin, "Pirmatov_123");
			admin.PasswordHash = adminPasswordHash;
			builder.HasData(admin);

			var member = new AppUser
			{
				Id = Guid.Parse("DCE8CFD5-D290-4353-B50D-58707ED8DA4D").ToString(),
				Email = "pirmatovalisher0000@gmail.com",
				NormalizedEmail = "PIRMATOVALISHER0000@GMAIL.COM",
				UserName = "TestMember",
				NormalizedUserName = "TESTMEMBER",
				ConcurrencyStamp = Guid.NewGuid().ToString(),
				SecurityStamp = Guid.NewGuid().ToString()
			};

			var memberPasswordHash = PasswordHash(member, "Pirmatov_123");
			member.PasswordHash = memberPasswordHash;
			builder.HasData(member);


		}

		private string PasswordHash(AppUser user, string password)
		{
			var passwordHasher = new PasswordHasher<AppUser>();
			return passwordHasher.HashPassword(user, password);
		}

	}
}
