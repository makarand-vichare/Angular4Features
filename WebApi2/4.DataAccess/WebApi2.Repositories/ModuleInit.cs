using System.ComponentModel.Composition;
using WebApi2.Common.MEF;
using WebApi2.Repositories.Core;
using WebApi2.IRepositories.Core;
using WebApi2.Repositories.Identity;
using WebApi2.IRepositories.Identity;
using WebApi2.Repositories.Queues;
using WebApi2.IRepositories.Queues;
using WebApi2.IRepositories.Location;
using WebApi2.Repositories.Location;
using WebApi2.IRepositories.Localization;
using WebApi2.Repositories.Localization;

namespace WebApi2.Repositories
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {
            registrar.RegisterType<IUnitOfWork, UnitOfWork>();
            registrar.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            registrar.RegisterType<IEmailQueueRepository, EmailQueueRepository>();
            registrar.RegisterType<IPdfQueueRepository, PdfQueueRepository>();
            registrar.RegisterType<IRequestQueueRepository, RequestQueueRepository>();
            registrar.RegisterType<IUserRepository, UserRepository>();
            registrar.RegisterType<IRoleRepository, RoleRepository>();
            registrar.RegisterType<IExternalLoginRepository, ExternalLoginRepository>();
            registrar.RegisterType<IRefreshTokenRepository, RefreshTokenRepository>();
            registrar.RegisterType<IClientRepository, ClientRepository>();

            registrar.RegisterType<ICityRepository, CityRepository>();
            registrar.RegisterType<ICountryRepository, CountryRepository>();

            registrar.RegisterType<IKeyGroupRepository, KeyGroupRepository>();
            registrar.RegisterType<ILocalizationKeyRepository, LocalizationKeyRepository>();

        }
    }
}
