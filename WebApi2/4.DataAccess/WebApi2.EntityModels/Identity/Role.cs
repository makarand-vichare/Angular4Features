using WebApi2.EntityModels.Core;
using System;
using System.Collections.Generic;

namespace WebApi2.EntityModels.Identity
{
    public class Role : BaseEntity
    {
        #region Fields
        private ICollection<User> _users;
        #endregion

        #region Scalar Properties
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        #endregion

        #region Navigation Properties
        public ICollection<User> Users
        {
            get { return _users ?? (_users = new List<User>()); }
            set { _users = value; }
        }
        #endregion
    }
}
