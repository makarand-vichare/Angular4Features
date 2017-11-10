using WebApi2.EntityModels.Identity;
using WebApi2.IDomainServices.Core;
using WebApi2.ViewModels.Identity.WebApi;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi2.IDomainServices.IdentityStores
{
    public interface IRefreshTokenService : IBaseService<RefreshToken, RefreshTokenViewModel>
    {
        Task<bool> AddRefreshToken(RefreshTokenViewModel token);
        Task<bool> RemoveRefreshToken(string refreshTokenId);
        Task<bool> RemoveRefreshToken(RefreshTokenViewModel refreshToken);
        Task<RefreshTokenViewModel> FindRefreshToken(string refreshTokenId);
        List<RefreshTokenViewModel> GetAllRefreshTokens();
    }
}
