using WebApi2.EntityModels.Queues;
using WebApi2.IDomainServices.Core;
using WebApi2.ViewModels;
using System.Collections.Generic;

namespace WebApi2.IDomainServices.Queues
{
    public interface IPdfQueueService : IBaseService<PdfQueue, PdfQueueViewModel>
    {
        List<PdfQueueViewModel> GetPendingPdfQueue();
        bool ProcessPendingPdfs();
        //List<PdfResultViewModel> GetRequestsForEmailQueue();
    }
}
