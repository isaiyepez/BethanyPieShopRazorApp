using BethanysPieShopHRM.Shared.Domain;

namespace BethanyPieShopRazor.App.Services
{
    public interface ICountryDataService
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<Country> GetCountryById(int countryId);
    }
}
