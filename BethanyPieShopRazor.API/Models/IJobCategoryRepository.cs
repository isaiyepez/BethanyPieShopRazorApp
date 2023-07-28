using BethanysPieShopHRM.Shared.Domain;

namespace BethanyPieShopRazor.API.Models
{
    public interface IJobCategoryRepository
    {
        IEnumerable<JobCategory> GetAllJobCategories();
        JobCategory GetJobCategoryById(int jobCategoryId);
    }
}