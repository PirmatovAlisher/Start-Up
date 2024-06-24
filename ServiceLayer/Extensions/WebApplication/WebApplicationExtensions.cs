using EntityLayer.WebApplication.Entities;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Filter.WebApplication;

namespace ServiceLayer.Extensions.WebApplication
{
	public static class WebApplicationExtensions
	{
		public static IServiceCollection LoadWebApplicationExtensions(this IServiceCollection services)
		{
			services.AddScoped(typeof(GenericAddPreventationFilter<About>));
			services.AddScoped(typeof(GenericAddPreventationFilter<Contact>));
			services.AddScoped(typeof(GenericAddPreventationFilter<HomePage>));

			services.AddScoped(typeof(GenericNotFoundFilter<About>));
			services.AddScoped(typeof(GenericNotFoundFilter<Category>));
			services.AddScoped(typeof(GenericNotFoundFilter<Contact>));
			services.AddScoped(typeof(GenericNotFoundFilter<HomePage>));
			services.AddScoped(typeof(GenericNotFoundFilter<Portfolio>));
			services.AddScoped(typeof(GenericNotFoundFilter<Service>));
			services.AddScoped(typeof(GenericNotFoundFilter<Team>));
			services.AddScoped(typeof(GenericNotFoundFilter<Testimonial>));

			return services;
		}
	}
}
