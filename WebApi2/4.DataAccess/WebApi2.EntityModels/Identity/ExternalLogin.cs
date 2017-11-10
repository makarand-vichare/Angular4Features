using WebApi2.EntityModels.Core;
using System;

namespace WebApi2.EntityModels.Identity
{
    public class ExternalLogin : BaseEntity
    {
        private User _user;

        #region Scalar Properties
        public virtual string LoginProvider { get; set; }
        public virtual string ProviderKey { get; set; }
        public virtual Guid UserId { get; set; }
        #endregion

        #region Navigation Properties
        public virtual User User
        {
            get { return _user; }
            set
            {
                _user = value;
                UserId = value.UserId;
            }
        }
        #endregion
    }
}
