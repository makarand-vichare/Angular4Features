using WebApi2.ViewModels.Core;
using System;

namespace WebApi2.ViewModels
{
    [Serializable]
    public class LookUpViewModel : IdentityColumnViewModel
    {
        public string Value { get; set; }
    }
}
