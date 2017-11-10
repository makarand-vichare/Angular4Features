using WebApi2.DomainServices.Core;
using WebApi2.EntityModels.Queues;
using WebApi2.IDomainServices.AutoMapper;
using WebApi2.IDomainServices.Queues;
using WebApi2.Utility;
using WebApi2.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WebApi2.DomainServices
{
    public class PdfQueueService : BaseService<PdfQueue, PdfQueueViewModel>, IPdfQueueService
    {

        public List<PdfQueueViewModel> GetPendingPdfQueue()
        {
            var result = new List<PdfQueueViewModel>();

            var entityList = UnitOfWork.PdfQueueRepository.GetPendingPdfQueue().ToList();

            if (entityList != null && entityList.Count > 0)
            {
                result = entityList.ToViewModel<PdfQueue, PdfQueueViewModel>().ToList();
            }

            return result;
        }

        public bool ProcessPendingPdfs()
        {
            var pendingpdfs = GetPendingPdfQueue();
            var result = false;
            foreach (PdfQueueViewModel pdfQueueViewModel in pendingpdfs)
            {
                try
                {
                    if (!string.IsNullOrEmpty(pdfQueueViewModel.GeneratedHtml))
                    {
                        GeneratePdf(pdfQueueViewModel);
                        UpdatePdfQueue(pdfQueueViewModel, true);
                        UnitOfWork.Commit();
                    }
                    result = true;
                }
                catch (ApplicationException ex)
                {
                    pdfQueueViewModel.ErrorMessage = ex.Message;
                    UpdatePdfQueue(pdfQueueViewModel, false);
                    UnitOfWork.Commit();
                }
            }

            return result;
        }

        private void GeneratePdf(PdfQueueViewModel pdfQueueViewModel)
        {
            try
            {
                var outPutFileName = pdfQueueViewModel.CriminalId.ToString() + ".pdf";

                if (File.Exists(AppProperties.BasePhysicalPath + AppConstants.GenerateFileAt + outPutFileName))
                  {
                    File.Delete(AppProperties.BasePhysicalPath + AppConstants.GenerateFileAt + outPutFileName);
                  }

                 AppMethods.HtmlStringToPdfFile(pdfOutputLocation: AppConstants.GenerateFileAt, outputFilename: outPutFileName,
                                htmlData: pdfQueueViewModel.GeneratedHtml, pdfHtmlToPdfExePath: AppConstants.PdfConvertorPath);
            }
            catch (ApplicationException ex)
            {
            }
        }

        private void UpdatePdfQueue(PdfQueueViewModel pdfQueueViewModel, bool isSucceed)
        {
            var pdfQueueEntity = UnitOfWork.PdfQueueRepository.FindById(pdfQueueViewModel.Id);
            pdfQueueEntity.IsPdfGenerationSucceed = isSucceed;
            pdfQueueEntity.ReGenerationRequired = !isSucceed;
            UnitOfWork.PdfQueueRepository.Update(pdfQueueEntity);
        }
    }
}
