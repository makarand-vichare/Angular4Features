using WebApi2.EntityModels.Queues;
using WebApi2.IDomainServices.Core;
using WebApi2.ViewModels;
using System.Collections.Generic;

namespace WebApi2.IDomainServices.Queues
{
    public interface IRequestQueueService : IBaseService<RequestQueue, RequestQueueViewModel>
    {
        List<RequestQueueViewModel> GetPendingRequestQueue();
        bool ProcessPendingRequests();
    }
}
