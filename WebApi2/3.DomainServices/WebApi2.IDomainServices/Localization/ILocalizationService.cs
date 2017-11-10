using WebApi2.EntityModels.Localization;
using WebApi2.IDomainServices.Core;
using WebApi2.ViewModels;
using System.Collections.Generic;

namespace WebApi2.IDomainServices.Services
{
    public interface ILocalizationService : IBaseService<LocalizationKey, LocalizationKeyViewModel>
    {
        Dictionary<string, string> GetLocalizations(string keyGroup, string languageCode);
    }
}
