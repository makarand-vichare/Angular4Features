using WebApi2.EntityModels.Location;
using WebApi2.IRepositories.Core;

namespace WebApi2.IRepositories.Location
{
    public interface ICountryRepository : IIdentityBaseRepository<Country>
    {
        //IEnumerable<CountryEntityModel> GetCountries();
    }
}
