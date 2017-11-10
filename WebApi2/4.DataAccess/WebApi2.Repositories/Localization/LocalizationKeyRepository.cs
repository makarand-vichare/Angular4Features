using WebApi2.Repositories.Core;
using System.Collections.Generic;
using System.Linq;
using WebApi2.EntityModels.Localization;
using WebApi2.IRepositories.Localization;

namespace WebApi2.Repositories.Localization
{
    public class LocalizationKeyRepository : IdentityBaseRepository<LocalizationKey>, ILocalizationKeyRepository
    {

        public List<LocalizationKey> GetResourceByKeys(List<string> resourceKeys)
        {
            if (resourceKeys != null && resourceKeys.Count > 0)
            {
                return DbSet.Where(o => o.IsActive == true && resourceKeys.Contains(o.LocalizationKeyCode)).ToList();
            }
            else
            {
                return new List<LocalizationKey>();
            }
        }
    }
}
