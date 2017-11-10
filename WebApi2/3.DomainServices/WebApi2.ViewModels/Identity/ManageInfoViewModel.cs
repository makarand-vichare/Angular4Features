using WebApi2.ViewModels.Core;
using System.Collections.Generic;

namespace WebApi2.ViewModels.Identity.WebApi
{
    public class ManageInfoViewModel : BaseViewModel
    {
        public string LocalLoginProvider { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
    }

}
