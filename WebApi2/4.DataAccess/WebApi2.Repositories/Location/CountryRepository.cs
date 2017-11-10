using WebApi2.EntityModels.Location;
using WebApi2.IRepositories.Location;
using WebApi2.Repositories.Core;

namespace WebApi2.Repositories.Location
{
    public class CountryRepository : IdentityBaseRepository<Country>, ICountryRepository
    {
        //public IEnumerable<CountryEntityModel> GetCountries()
        //{
        //    return DbSet.ToList();
        //}
    }
}
