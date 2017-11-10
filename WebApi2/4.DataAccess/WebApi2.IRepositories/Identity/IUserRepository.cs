using WebApi2.EntityModels.Identity;
using WebApi2.IRepositories.Core;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi2.IRepositories.Identity
{
    public interface IUserRepository  : IIdentityBaseRepository<User>
    {
        User FindByUserName(string username);
        Task<User> FindByUserNameAsync(string username);
        Task<User> FindByUserNameAsync(CancellationToken cancellationToken, string username);

        User FindByEmail(string email);
        Task<User> FindByEmailAsync(string email);
        Task<User> FindByEmailAsync(CancellationToken cancellationToken, string email);
    }
}
