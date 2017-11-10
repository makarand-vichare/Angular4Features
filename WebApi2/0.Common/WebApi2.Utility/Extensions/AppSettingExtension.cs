using System.Collections.Specialized;
using System.Configuration;
using System.Dynamic;

namespace WebApi2.Utility
{
    // extension Method for ConfigurationManager.AppSettings
    public class AppSettingsWrapper : DynamicObject
    {
        private NameValueCollection _items;

        public AppSettingsWrapper()
        {
            _items = ConfigurationManager.AppSettings;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = _items[binder.Name];
            return result != null;
        }
    }
}
