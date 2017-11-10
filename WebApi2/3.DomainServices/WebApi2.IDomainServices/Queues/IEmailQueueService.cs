using WebApi2.EntityModels.Queues;
using WebApi2.IDomainServices.Core;
using WebApi2.ServiceResponse;
using WebApi2.ViewModels;
using WebApi2.ViewModels.Identity.WebApi;
using System.Collections.Generic;

namespace WebApi2.IDomainServices.Queues
{
    public interface IEmailQueueService : IBaseService<EmailQueue, EmailQueueViewModel>
    {
        BaseResponseResult SendUserRegistrationMail(IdentityUserViewModel viewModel);
        List<EmailQueueViewModel> GetEmailsFromQueue();
    }
}
