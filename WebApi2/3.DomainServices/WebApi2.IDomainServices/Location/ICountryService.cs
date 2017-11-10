using WebApi2.EntityModels.Location;
using WebApi2.IDomainServices.Core;
using WebApi2.ServiceResponse;
using WebApi2.ViewModels;

namespace WebApi2.IDomainServices.Services
{
    public interface ICountryService : IBaseService<Country, CountryViewModel>
    {
        ResponseResults<LookUpViewModel> GetLookup();
    }
}
