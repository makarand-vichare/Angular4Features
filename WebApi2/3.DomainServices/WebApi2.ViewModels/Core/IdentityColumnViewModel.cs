using System;

namespace WebApi2.ViewModels.Core
{
    [Serializable]
    public abstract class IdentityColumnViewModel : BaseViewModel
    {
        public long Id { get; set; }
    }
}
