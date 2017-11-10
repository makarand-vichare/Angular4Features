using WebApi2.ViewModels.Core;
using Microsoft.AspNet.Identity;
using System;

namespace WebApi2.ViewModels.Identity.WebApi
{
    public class IdentityRoleViewModel : BaseViewModel, IRole<long>
    {

        public IdentityRoleViewModel(string name)
        {
            this.Name = name;
        }

        public IdentityRoleViewModel(string name, long id)
        {
            this.Name = name;
            this.Id = id;
        }

        public long Id { get; set; }
        public string Name { get; set; }
    }
}
