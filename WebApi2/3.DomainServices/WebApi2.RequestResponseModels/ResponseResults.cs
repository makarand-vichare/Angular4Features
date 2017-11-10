using WebApi2.ViewModels.Core;
using System.Collections.Generic;

namespace WebApi2.ServiceResponse
{
    public class ResponseResults<VM> : BaseResponseResult  where VM: BaseViewModel
    {
        public List<VM> ViewModels { get; set; } 
    }
}
