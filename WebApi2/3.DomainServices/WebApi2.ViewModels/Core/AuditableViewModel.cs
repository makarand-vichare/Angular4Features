using WebApi2.ViewModels.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi2.ViewModels
{
    [Serializable]
    public abstract class AuditableViewModel : IdentityColumnViewModel
    {

        [Display(Name = "Updated On")]
        public DateTime UpdatedOn { get; set; }

        [Display(Name = "Updated By")]
        public long UpdatedBy { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

    }
}
