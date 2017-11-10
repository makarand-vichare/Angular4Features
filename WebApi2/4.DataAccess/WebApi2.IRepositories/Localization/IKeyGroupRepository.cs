using WebApi2.EntityModels.Localization;
using WebApi2.IRepositories.Core;
using System.Collections.Generic;

namespace WebApi2.IRepositories.Localization
{
    public interface IKeyGroupRepository : IIdentityBaseRepository<KeyGroup>
    {
        KeyGroup GetResourceKeysByGroup(string groupId);
        List<KeyGroup> GetResourceKeysByGroups(List<string> groupIds);
    }
}
