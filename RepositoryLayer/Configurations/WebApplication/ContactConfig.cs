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
    public class ContactConfig : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.Property(x => x.Location).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Call).IsRequired().HasMaxLength(17);
            builder.Property(x => x.Map).IsRequired();

            builder.HasData(new Contact
            {
                Id = 1,
                Call = "+998-94-361-99-25",
                Email = "pirmatovalisher000@gmail.com",
                Location = "Tarraqiyot 35, 37-Xamza MFY, Chirchiq shaxri, Toshkent v., Uzb",
                Map = "Location Link here",

            });
        }
    }
}
