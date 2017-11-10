using WebApi2.ViewModels.Core;

namespace WebApi2.ViewModels.Identity.WebApi
{
    public class UserInfoViewModel : BaseViewModel
    {
        public string Email { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }

    }

}
