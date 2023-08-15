using BethanysPieShopHRM.Shared.Domain;

namespace BethanyPieShopRazor.App.Services
{
    public interface IJobCategoryDataService
    {
        Task<IEnumerable<JobCategory>> GetAllJobCategories();
        Task<JobCategory> GetJobCategoryById(int jobCategoryId);
    }
}
