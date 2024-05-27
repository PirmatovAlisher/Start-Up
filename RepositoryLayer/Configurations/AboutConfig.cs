using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Configurations
{
    public class AboutConfig : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.Property(x => x.Header).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(5000);
            builder.Property(x => x.Clients).IsRequired().HasMaxLength(5);
            builder.Property(x => x.Projects).IsRequired().HasMaxLength(5);
            builder.Property(x => x.HoursOfSupport).IsRequired().HasMaxLength(5);
            builder.Property(x => x.HardWorkers).IsRequired().HasMaxLength(5);

            builder.HasData(new About
            {
                Id = 1,
                Header = "Euismod lacinia at quis risus",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. In ante metus dictum at tempor commodo ullamcorper a lacus. Suspendisse in est ante in nibh mauris. Lorem ipsum dolor sit amet consectetur adipiscing elit. Erat imperdiet sed euismod nisi. Sed blandit libero volutpat sed cras ornare arcu dui vivamus. Ut morbi tincidunt augue interdum velit euismod in pellentesque massa.",
                Clients = 5,
                Projects = 5,
                HoursOfSupport = 150,
                HardWorkers = 3,
                FileName = "Test",
                FileType = "Test",
                SocialMediaId = 1,

            });
        }
    }
}
