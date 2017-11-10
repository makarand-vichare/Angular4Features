using WebApi2.Repositories.Core;
using System.Threading.Tasks;
using System.Data.Entity;
using WebApi2.EntityModels.Identity;
using WebApi2.IRepositories.Identity;

namespace WebApi2.Repositories.Identity
{
    public class RefreshTokenRepository : IdentityBaseRepository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository()
        {

        }
        public Task<RefreshToken> FindByTokenIdAsync(string tokenId)
        {
            return DbSet.FirstOrDefaultAsync(x => x.TokenId == tokenId);
        }
    }
}
