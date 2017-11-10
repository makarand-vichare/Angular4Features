using System;
using System.Linq;
using WebApi2.DomainServices.Core;
using WebApi2.EntityModels.Location;
using WebApi2.IDomainServices.Services;
using WebApi2.InfraStructure.Logging;
using WebApi2.ServiceResponse;
using WebApi2.Utility;
using WebApi2.ViewModels;

namespace WebApi2.DomainServices
{
    public class CountryService : BaseService<Country, CountryViewModel>, ICountryService
    {
        public ResponseResults<LookUpViewModel> GetLookup()
        {
            var response = new ResponseResults<LookUpViewModel> { IsSucceed = true, Message = AppMessages.Retrieved_Details_Successfully };
            try
            {
                var entities =  UnitOfWork.CountryRepository.GetAll();
                if (entities != null && entities.Count > 0)
                {
                    response.ViewModels = entities.Select(o=> new LookUpViewModel { Id = o.Id , Value = o.CountryName }).ToList();
                }

                if (entities != null && entities.Count <= 0)
                {
                    response.Message = AppMessages.No_Record_Found;
                }
            }
            catch (Exception ex)
            {
                NLogLogger.Instance.Log(ex.Message);
            }
            return response;
        }
    }
}
