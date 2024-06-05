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
    public class PortfolioConfig : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.FileName).IsRequired();
            builder.Property(x => x.FileType).IsRequired();

            builder.HasData(
                new Portfolio
                {
                    Id = 1,
                    Title = "Sed velit dignissim sodales ut eu sem integer vitae justo.",
                    FileName = "Fames ac turpis",
                    FileType = ".blend",
                    CategoryId = 1
                },
                new Portfolio
                {
                    Id = 2,
                    Title = "Arcu bibendum at varius vel.",
                    FileName = " Sed id interdum",
                    FileType = ".DXF",
                    CategoryId = 2
                },
                new Portfolio
                {
                    Id = 3,
                    Title = "Mattis pellentesque id nibh",
                    FileName = "Mattis ac turpis",
                    FileType = ".blend",
                    CategoryId = 1
                },
                new Portfolio
                {
                    Id = 4,
                    Title = "Nec ullamcorper sit amet risus nullam eget felis eget.",
                    FileName = " Tellus id interdum",
                    FileType = ".DXF",
                    CategoryId = 2
                });

        }
    }
}
