using WebApi2.EntityModels.Identity;
using WebApi2.IRepositories.Core;
using System.Threading.Tasks;

namespace WebApi2.IRepositories.Identity
{
    public interface IRefreshTokenRepository : IIdentityBaseRepository<RefreshToken>
    {
        Task<RefreshToken> FindByTokenIdAsync(string tokenId);
    }
}
