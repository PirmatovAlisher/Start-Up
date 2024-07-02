namespace ServiceLayer.Services.WebApplication.Abstract
{
    public interface IDashboardService
    {
        Task<int> GetAllServicesCountAsync();
        Task<int> GetAllTeamsCountAsync();
        Task<int> GetAllTestimonialsCountAsync();
        Task<int> GetAllCategoriesCountAsync();
        Task<int> GetAllPortfoliosCountAsync();
        Task<int> GetAllUsersCountAsync();
    }
}