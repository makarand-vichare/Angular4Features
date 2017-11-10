using WebApi2.EntityModels.Localization;
using WebApi2.IRepositories.Core;
using System.Collections.Generic;

namespace WebApi2.IRepositories.Localization
{
    public interface ILocalizationKeyRepository : IIdentityBaseRepository<LocalizationKey>
    {
        List<LocalizationKey> GetResourceByKeys(List<string> resourceKeys);
    }
}
