using WebApi2.EntityModels.Core;

namespace WebApi2.EntityModels.Location
{
    public class City : IdentityColumnEntity
    {
        #region Scalar Properties
        public long CountryId { get; set; }
        public string CityName { get; set; }
        public bool IsActive { get; set; }
        #endregion

        public virtual Country Country { get; set; }
    }
}
