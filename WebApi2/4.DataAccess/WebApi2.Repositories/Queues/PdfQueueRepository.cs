using WebApi2.Repositories.Core;
using System.Collections.Generic;
using System;
using WebApi2.IRepositories.Queues;
using WebApi2.EntityModels.Queues;

namespace WebApi2.Repositories.Queues
{
    public class PdfQueueRepository : BaseRepository<PdfQueue>, IPdfQueueRepository
    {

        //public PdfQueueRepository(DataContext dataContext)
        //    : base(dataContext)
        //{
        //}

        public IEnumerable<PdfQueue> GetPendingPdfQueue()
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<PdfQueueEntityModel> GetPendingPdfQueue()
        //{
        //    var entityList = this.DbSet.PdfQueues.Where(o => o.IsPdfGenerationSucceed == false);
        //    return entityList;
        //}
    }
 
}
