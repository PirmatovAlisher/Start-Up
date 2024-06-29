using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace StartUp.Components
{
    public class ServiceViewComponent : ViewComponent
    {
        private readonly IServiceService _service;

        public ServiceViewComponent(IServiceService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var serviceListForUI = await _service.GetAllListForUIAsync();

            return View(serviceListForUI);
        }
    }
}
