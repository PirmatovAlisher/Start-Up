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
	public class AppUserClaimConfig : IEntityTypeConfiguration<AppUserClaim>
	{
		public void Configure(EntityTypeBuilder<AppUserClaim> builder)
		{
			builder.HasData(new AppUserClaim
			{
				Id = 1,
				UserId  = Guid.Parse("DCE8CFD5-D290-4353-B50D-58707ED8DA4D").ToString(),
				ClaimType = "AdminObserverExpireDate",
				ClaimValue = DateTime.Now.AddDays(6).ToString(),
			});
		}
	}
}
