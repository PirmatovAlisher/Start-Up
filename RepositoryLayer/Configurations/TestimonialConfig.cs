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
    public class TestimonialConfig : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.Property(x => x.Comment).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.FileName).IsRequired();
            builder.Property(x => x.FileType).IsRequired();

            builder.HasData(
                new Testimonial
                {
                    Id = 1,
                    Comment = "Vitae suscipit tellus mauris a diam maecenas sed.",
                    FullName = "Massa Lobortis",
                    Title = "At elementum eu facilisis",
                    FileName = "Hendrerit gravida",
                    FileType = ".jpeg"
                },
                new Testimonial
                {
                    Id = 2,
                    Comment = "Nulla posuere sollicitudin",
                    FullName = "Vitae Eget",
                    Title = "Faucibus a pellentesque",
                    FileName = "Proin sed libero enim",
                    FileType = ".cs"
                },
                new Testimonial
                {
                    Id = 3,
                    Comment = "Rutrum tellus pellentesque eu tincidunt.",
                    FullName = "Rutrum Cursus",
                    Title = " Sodales ut eu sem",
                    FileName = "Donec adipiscing",
                    FileType = ".cshtml"
                });
        }
    }
}
