using WebApi2.EntityModels.Core;
using System;
using System.Collections.Generic;

namespace WebApi2.EntityModels.Identity
{
    public class User : BaseEntity
    {
        #region Fields
        private ICollection<Claim> _claims;
        private ICollection<ExternalLogin> _externalLogins;
        private ICollection<Role> _roles;
        #endregion

        #region Scalar Properties
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; }
        public string ProfilePicturePath { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public int UserStatus { get; set; }

        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
        #endregion

        #region Navigation Properties
        public virtual ICollection<Claim> Claims
        {
            get { return _claims ?? (_claims = new List<Claim>()); }
            set { _claims = value; }
        }

        public virtual ICollection<ExternalLogin> Logins
        {
            get
            {
                return _externalLogins ??
                    (_externalLogins = new List<ExternalLogin>());
            }
            set { _externalLogins = value; }
        }

        public virtual ICollection<Role> Roles
        {
            get { return _roles ?? (_roles = new List<Role>()); }
            set { _roles = value; }
        }

        #endregion
    }
}
