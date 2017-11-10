using WebApi2.EntityModels.Identity;
using WebApi2.IRepositories.Core;

namespace WebApi2.IRepositories.Identity
{
    public interface IClientRepository : IIdentityBaseRepository<Client>
    {
        Client FindByClientId(string clientId);

    }
}
