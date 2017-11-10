using WebApi2.ViewModels.Core;
using System;

namespace WebApi2.ViewModels
{
    [Serializable]
    public class CityViewModel : IdentityColumnViewModel
    {
        public long CountryId { get; set; }
        public string CityName { get; set; }
        public bool IsActive { get; set; }
    }
}
