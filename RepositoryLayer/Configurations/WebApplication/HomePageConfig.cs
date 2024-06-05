using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Configurations.WebApplication
{
    public class HomePageConfig : IEntityTypeConfiguration<HomePage>
    {
        public void Configure(EntityTypeBuilder<HomePage> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.Property(x => x.Header).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.VideoLink).IsRequired();

            builder.HasData(new HomePage
            {
                Id = 1,
                Header = "Rutrum tellus pellentesque eu tincidunt.",
                Description = "Urna porttitor rhoncus dolor purus non enim praesent elementum facilisis. Nec nam aliquam sem et tortor. Est pellentesque elit ullamcorper dignissim cras tincidunt lobortis. Diam in arcu cursus euismod quis viverra nibh cras. Velit sed ullamcorper morbi tincidunt ornare. ",
                VideoLink = "Video Link here"
            });

        }
    }
}
