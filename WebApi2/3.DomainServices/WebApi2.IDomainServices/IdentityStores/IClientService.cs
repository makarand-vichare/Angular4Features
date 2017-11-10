using WebApi2.EntityModels.Identity;
using WebApi2.IDomainServices.Core;
using WebApi2.ViewModels.Identity.WebApi;

namespace WebApi2.IDomainServices.IdentityStores
{
    public interface IClientService : IBaseService<Client, ClientViewModel>
    {
        ClientViewModel FindClient(string clientId);
        
    }
}
