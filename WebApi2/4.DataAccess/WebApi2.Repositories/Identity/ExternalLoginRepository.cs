using WebApi2.Repositories.Core;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Entity;
using WebApi2.EntityModels.Identity;
using WebApi2.IRepositories.Identity;

namespace WebApi2.Repositories.Identity
{
    public class ExternalLoginRepository : IdentityBaseRepository<ExternalLogin>, IExternalLoginRepository
    {
        public ExternalLoginRepository()
        {

        }
        //public ExternalLoginRepository(DataContext dataContext)
        //    : base(dataContext)
        //{
        //}

        public ExternalLogin GetByProviderAndKey(string loginProvider, string providerKey)
        {
            return DbSet.FirstOrDefault(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey);
        }

        public Task<ExternalLogin> GetByProviderAndKeyAsync(string loginProvider, string providerKey)
        {
            return DbSet.FirstOrDefaultAsync(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey);
        }

        public Task<ExternalLogin> GetByProviderAndKeyAsync(CancellationToken cancellationToken, string loginProvider, string providerKey)
        {
            return DbSet.FirstOrDefaultAsync(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey, cancellationToken);
        }
    }
}
