using WebApi2.EntityModels.Core;

namespace WebApi2.EntityModels.Localization
{
    public class KeyGroup : IdentityColumnEntity
    {

        #region Scalar Properties
        public string KeyGroupCode { get; set; }
        public string LocalizationKeys { get; set; }

        #endregion
    }
}
