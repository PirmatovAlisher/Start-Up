using CoreLayer.BaseEntities;
using Microsoft.AspNetCore.Mvc.Filters;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Exceptions.WebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Filter.WebApplication
{
	public class GenericNotFoundFilter<T> : IAsyncActionFilter where T : class, IBaseEntity, new()
	{
		private readonly IUnitOfWork _unitOfWork;

		public GenericNotFoundFilter(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			var value = context.ActionArguments.FirstOrDefault().Value;

			if (value == null)
			{
				throw new ClientSideExceptions("Input is invalid. Please use valid id.");
			}

			var id = (int)value!;
			var entity = await _unitOfWork.GetGenericRepository<T>().GetEntityByIdAsync(id);

			if (entity == null)
			{
				throw new ClientSideExceptions("Id does not exist, please try to use existing one.");
			}

			await next.Invoke();
			return;

		}
	}
}
