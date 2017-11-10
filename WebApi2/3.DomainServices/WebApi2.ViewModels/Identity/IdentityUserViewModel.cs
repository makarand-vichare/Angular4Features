using WebApi2.ViewModels.Core;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;

namespace WebApi2.ViewModels.Identity.WebApi
{

    public class IdentityUserViewModel : BaseViewModel, IUser<long>
    {
        public long Id { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long CountryId { get; set; }
        public long CityId { get; set; }
        public string AboutInfo { get; set; }

        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
        public string InputPassword { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

    }
}
