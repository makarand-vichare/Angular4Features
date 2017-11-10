using WebApi2.Repositories.Core;
using System.Collections.Generic;
using System;
using WebApi2.IRepositories.Queues;
using WebApi2.EntityModels.Queues;

namespace WebApi2.Repositories.Queues
{
    public class EmailQueueRepository : BaseRepository<EmailQueue>, IEmailQueueRepository
    {

        //public EmailQueueRepository(DataContext dataContext)
        //    : base(dataContext) {
        //}

        public IEnumerable<EmailQueue> GetPendingEmailQueue()
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<EmailQueueEntityModel> GetPendingEmailQueue()
        //{
        //    var entityList = this.DataContext.EmailQueues.Where(o => o.IsSucceedEmailSent == false);
        //    return entityList;

        //}
    }
 
}
