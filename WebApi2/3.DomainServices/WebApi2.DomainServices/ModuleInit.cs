using WebApi2.Common.MEF;
using WebApi2.DomainServices.IdentityStores;
using WebApi2.IDomainServices.IdentityStores;
using WebApi2.IDomainServices.Queues;
using WebApi2.ViewModels.Identity.WebApi;

using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.Composition;
using WebApi2.IDomainServices.Services;

namespace WebApi2.DomainServices
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {
            registrar.RegisterType(typeof(IUserStore<IdentityUserViewModel, long>), typeof(CustomUserStore));
            registrar.RegisterType(typeof(IRoleStore<IdentityRoleViewModel, long>), typeof(CustomRoleStore));

            registrar.RegisterType<IEmailQueueService, EmailQueueService>();
            registrar.RegisterType<IPdfQueueService, PdfQueueService>();
            registrar.RegisterType<IRequestQueueService, RequestQueueService>();

            registrar.RegisterType<IClientService, ClientService>();
            registrar.RegisterType<IRefreshTokenService, RefreshTokenService>();

            registrar.RegisterType<ICityService, CityService>();
            registrar.RegisterType<ICountryService, CountryService>();

            registrar.RegisterType<ILocalizationService, LocalizationService>();
        }
    }
}
