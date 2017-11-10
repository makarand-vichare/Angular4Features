using WebApi2.EntityModels.Core;
using WebApi2.IRepositories.Identity;
using WebApi2.IRepositories.Queues;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebApi2.IRepositories.Localization;
using WebApi2.IRepositories.Location;

namespace WebApi2.IRepositories.Core
{
    public interface IUnitOfWork : IDisposable
    {
        #region Methods
        int Commit();
        Task<int> CommitAsync();
        Task<int> CommitAsync(CancellationToken cancellationToken);
        #endregion
        IExternalLoginRepository ExternalLoginRepository { get; set; }
        IRoleRepository RoleRepository { get; set; }
        IUserRepository UserRepository { get; set; }
        IRefreshTokenRepository RefreshTokenRepository { get; set; }
        IKeyGroupRepository KeyGroupRepository { get; set; }
        ILocalizationKeyRepository LocalizationKeyRepository { get; set; }
        ICountryRepository CountryRepository { get; set; }
        ICityRepository CityRepository { get; set; }

        IEmailQueueRepository EmailQueueRepository { get; set; }
        IPdfQueueRepository PdfQueueRepository { get; set; }
        IRequestQueueRepository RequestQueueRepository { get; set; }
        IClientRepository ClientRepository { get; set; }
        IBaseRepository<T> SetDbContext<T>(IBaseRepository<T> repository) where T : IdentityColumnEntity;

    }
}
