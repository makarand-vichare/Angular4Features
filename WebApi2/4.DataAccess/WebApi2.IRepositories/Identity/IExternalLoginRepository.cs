using WebApi2.EntityModels.Identity;
using WebApi2.IRepositories.Core;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi2.IRepositories.Identity
{
    public interface IExternalLoginRepository : IIdentityBaseRepository<ExternalLogin>
    {
        ExternalLogin GetByProviderAndKey(string loginProvider, string providerKey);
        Task<ExternalLogin> GetByProviderAndKeyAsync(string loginProvider, string providerKey);
        Task<ExternalLogin> GetByProviderAndKeyAsync(CancellationToken cancellationToken, string loginProvider, string providerKey);
    }
}
