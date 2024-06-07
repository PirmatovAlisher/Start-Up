﻿using EntityLayer.Identity.Entities;
using EntityLayer.WebApplication.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace RepositoryLayer.Context
{
	public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
	{
		public AppDbContext()
		{

		}

		public AppDbContext(DbContextOptions options) : base(options)
		{
		}


		public DbSet<About> Abouts { get; set; }

		public DbSet<Category> Categories { get; set; }

		public DbSet<Contact> Contacts { get; set; }

		public DbSet<HomePage> HomePages { get; set; }

		public DbSet<Portfolio> Portfolios { get; set; }

		public DbSet<Service> Services { get; set; }

		public DbSet<SocialMedia> SocialMedias { get; set; }

		public DbSet<Team> Teams { get; set; }

		public DbSet<Testimonial> Testimonials { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			base.OnModelCreating(modelBuilder);
		}

	}
}
