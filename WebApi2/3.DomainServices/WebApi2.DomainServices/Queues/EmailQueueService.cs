using WebApi2.DomainServices.Core;
using WebApi2.ServiceResponse;
using WebApi2.ViewModels;
using System;
using WebApi2.IDomainServices.AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebApi2.Utility;
using WebApi2.Mails;
using WebApi2.EntityModels.Queues;
using WebApi2.ViewModels.Identity.WebApi;
using WebApi2.IDomainServices.Queues;

namespace WebApi2.DomainServices
{
    public class EmailQueueService : BaseService<EmailQueue, EmailQueueViewModel>, IEmailQueueService
    {

        private bool AddEmailIntoQueue(EmailQueue entity)
        {
            bool result = false;
            try
            {

                if (entity != null)
                {
                    UnitOfWork.EmailQueueRepository.Add(entity);
                    UnitOfWork.Commit();
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public List<EmailQueueViewModel> GetEmailsFromQueue()
        {
            var result = new List<EmailQueueViewModel>();

            var entityList = UnitOfWork.EmailQueueRepository.GetPendingEmailQueue().ToList();

            if (entityList != null && entityList.Count > 0)
            {
                result = entityList.ToViewModel<EmailQueue, EmailQueueViewModel>().ToList();
            }

            return result;
        }

        public BaseResponseResult SendUserRegistrationMail(IdentityUserViewModel viewModel)
        {
            BaseResponseResult result = new BaseResponseResult();

            try
            {
                if (string.IsNullOrEmpty(viewModel.Email) == false)
                {
                    var maiTemplate = new UserRegistrationMail(viewModel.Email, viewModel.InputPassword);
                    var queueViewModel = maiTemplate.CreateEmailQueueViewModel(viewModel.Email);
                    var entity = queueViewModel.ToEntityModel<EmailQueue, EmailQueueViewModel>();
                    result.IsSucceed = AddEmailIntoQueue(entity); 

                    if (result.IsSucceed)
                    {
                        result.Message = AppMessages.Email_Succeed_Message;
                    }
                    else
                    {
                        result.Message = AppMessages.Email_Failed_Message;
                    }
                }
            }
            catch (ApplicationException)
            {
                result.IsSucceed = false;
                result.Message = AppMessages.Email_Failed_Message;
            }

            return result;
        }
    }

}
