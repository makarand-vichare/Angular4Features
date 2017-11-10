using WebApi2.Repositories.Core;
using System.Collections.Generic;
using System;
using WebApi2.IRepositories.Queues;
using WebApi2.EntityModels.Queues;

namespace WebApi2.Repositories.Queues
{
    public class RequestQueueRepository : BaseRepository<RequestQueue>, IRequestQueueRepository
    {

        //public RequestQueueRepository(DataContext dataContext)
        //    : base(dataContext)
        //{
        //}

        public IEnumerable<RequestQueue> GetPendingRequestQueue()
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<RequestQueueEntityModel> GetPendingRequestQueue()
        //{
        //   var entityList = this.DataContext.RequestQueues.Where(o => o.IsRequestSucceed == false);
        //    return entityList;
        //}
    }
 
}
