﻿using WebApi2.EntityModels.Queues;
using WebApi2.IRepositories.Core;
using System.Collections.Generic;

namespace WebApi2.IRepositories.Queues
{
    public interface IPdfQueueRepository : IBaseRepository<PdfQueue>
    {
        IEnumerable<PdfQueue> GetPendingPdfQueue();
    }
}