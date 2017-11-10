using WebApi2.ViewModels.Core;

namespace WebApi2.ViewModels.Identity.WebApi
{
    public class UserLoginInfoViewModel : BaseViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }


    }

}
