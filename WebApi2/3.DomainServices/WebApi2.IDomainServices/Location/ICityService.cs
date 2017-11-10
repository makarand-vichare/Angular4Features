using WebApi2.EntityModels.Location;
using WebApi2.IDomainServices.Core;
using WebApi2.ServiceResponse;
using WebApi2.ViewModels;

namespace WebApi2.IDomainServices.Services
{
    public interface ICityService : IBaseService<City, CityViewModel>
    {
        ResponseResults<LookUpViewModel> GetLookup(long countryId);
    }
}
