using WebApi2.DomainServices;
using WebApi2.DomainServices.IdentityStores;
using WebApi2.IDomainServices.Queues;
using WebApi2.IRepositories.Core;
using WebApi2.IRepositories.Identity;
using WebApi2.IRepositories.Queues;
using WebApi2.Repositories.Core;
using WebApi2.Repositories.Identity;
using WebApi2.Repositories.Queues;
using WebApi2.ViewModels.Identity.WebApi;
using Microsoft.AspNet.Identity;
using StructureMap;
using System;

namespace WebApi2.IOCRegistry
{
    public class StructureMapRegistry : Registry
    {
        public StructureMapRegistry()
        {
            For<IUnitOfWork>().Use<UnitOfWork>();

            For<IEmailQueueService>().Use<EmailQueueService>();
            For<IUserStore<IdentityUserViewModel, long>>().Use<CustomUserStore>();
            For<IRoleStore<IdentityRoleViewModel, long>>().Use<CustomRoleStore>(); 
            For<IPdfQueueService>().Use<PdfQueueService>();
            For<IRequestQueueService>().Use<RequestQueueService>();

            For<IEmailQueueRepository>().Use<EmailQueueRepository>();
            For<IUserRepository>().Use<UserRepository>();
            For<IRoleRepository>().Use<RoleRepository>();
            For<IExternalLoginRepository>().Use<ExternalLoginRepository>();

            For<IPdfQueueRepository>().Use<PdfQueueRepository>();
            For<IRequestQueueRepository>().Use<RequestQueueRepository>();

        }

    }
}
