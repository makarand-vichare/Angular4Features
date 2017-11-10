using WebApi2.DomainServices.Core;
using WebApi2.ViewModels;
using WebApi2.IDomainServices.AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System;
using WebApi2.EntityModels.Queues;
using WebApi2.IDomainServices.Queues;

namespace WebApi2.DomainServices
{
    public class RequestQueueService : BaseService<RequestQueue, RequestQueueViewModel>, IRequestQueueService
    {

        public List<RequestQueueViewModel> GetPendingRequestQueue()
        {
            var result = new List<RequestQueueViewModel>();

            var entityList = UnitOfWork.RequestQueueRepository.GetPendingRequestQueue().ToList();

            if (entityList != null && entityList.Count > 0)
            {
                result = entityList.ToViewModel<RequestQueue, RequestQueueViewModel>().ToList();
            }

            return result;
        }

        private void UpdateRequestQueue(RequestQueueViewModel requestViewModel,bool isSucceed)
        {
           var existingEntity = UnitOfWork.RequestQueueRepository.FindById(requestViewModel.Id);
                existingEntity.IsRequestSucceed = isSucceed;
            UnitOfWork.RequestQueueRepository.Update(existingEntity);
        }

        public bool ProcessPendingRequests()
        {
            throw new NotImplementedException();
        }
    }
}
