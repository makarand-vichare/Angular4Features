using WebApi2.EntityModels.Core;

namespace WebApi2.EntityModels.Location
{
    public class Country : IdentityColumnEntity
    {
        #region Scalar Properties
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public bool IsActive { get; set; }
        #endregion
    }
}
