using WebApi2.ViewModels.Core;

namespace WebApi2.ServiceResponse
{
    public class ResponseResult<VM> : BaseResponseResult
        where VM: BaseViewModel
    {
        public VM ViewModel { get; set; }
    }
}
