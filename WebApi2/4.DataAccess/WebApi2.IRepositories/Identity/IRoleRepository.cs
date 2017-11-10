using WebApi2.EntityModels.Identity;
using WebApi2.IRepositories.Core;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi2.IRepositories.Identity
{
    public interface IRoleRepository : IIdentityBaseRepository<Role>
    {
        Role FindByName(string roleName);
        Task<Role> FindByNameAsync(string roleName);
        Task<Role> FindByNameAsync(CancellationToken cancellationToken, string roleName);
    }
}
