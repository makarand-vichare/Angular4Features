using WebApi2.ViewModels.Core;
using System;

namespace WebApi2.ViewModels
{
    [Serializable]
    public class CountryViewModel : IdentityColumnViewModel
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public bool IsActive { get; set; }
    }
}
