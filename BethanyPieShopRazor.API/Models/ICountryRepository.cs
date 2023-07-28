using BethanysPieShopHRM.Shared.Domain;

namespace BethanyPieShopRazor.API.Models
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();
        Country GetCountryById(int countryId);
    }
}