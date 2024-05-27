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
    public class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.Icon).IsRequired().HasMaxLength(100);

            builder.HasData(new Service
            {
                Id = 1,
                Name = "Tristique",
                Description = "Augue interdum velit euismod in. Egestas dui id ornare arcu. Duis at tellus at urna condimentum mattis pellentesque id nibh. ",
                Icon = "bi bi-service1"
            },
            new Service
            {
                Id = 2,
                Name = "Faucibus",
                Description = "Donec adipiscing tristique risus nec feugiat in fermentum posuere.",
                Icon = "bi bi-service2"
            },
            new Service
            {
                Id = 3,
                Name = "Porttitor",
                Description = "Neque egestas congue quisque egestas diam in.",
                Icon = "bi bi-service3"
            }
            );
        }
    }
}
