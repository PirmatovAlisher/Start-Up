﻿using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Filter.WebApplication;

namespace ServiceLayer.Extensions.WebApplication
{
	public static class WebApplicationExtensions
	{
		public static IServiceCollection LoadWebApplicationExtensions(this IServiceCollection services)
		{
			services.AddScoped(typeof(AddAboutPreventationFilter));

			return services;
		}
	}
}
