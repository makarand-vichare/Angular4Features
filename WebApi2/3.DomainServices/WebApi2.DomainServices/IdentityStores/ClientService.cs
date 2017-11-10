using WebApi2.DomainServices.Core;
using WebApi2.EntityModels.Identity;
using WebApi2.IDomainServices.AutoMapper;
using WebApi2.ViewModels.Identity.WebApi;
using System.Threading.Tasks;
using WebApi2.IDomainServices.IdentityStores;

namespace WebApi2.DomainServices.IdentityStores
{
    public class ClientService : BaseService<Client, ClientViewModel> , IClientService
    {
        public async Task<RefreshTokenViewModel> FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = await UnitOfWork.RefreshTokenRepository.FindByTokenIdAsync(refreshTokenId);
            var tokenViewModel = refreshToken.ToViewModel<RefreshToken, RefreshTokenViewModel>();
            return tokenViewModel;
        }

        public ClientViewModel FindClient(string clientId)
        {
            var clientEntity = UnitOfWork.ClientRepository.FindByClientId(clientId);
            var clientViewModel = clientEntity.ToViewModel<Client, ClientViewModel>();

            return clientViewModel;
        }

    }
}
