using WebApi2.Repositories.Core;
using System.Collections.Generic;
using System.Linq;
using WebApi2.EntityModels.Localization;
using WebApi2.IRepositories.Localization;

namespace WebApi2.Repositories.Localization
{
    public class KeyGroupRepository : IdentityBaseRepository<KeyGroup>, IKeyGroupRepository
    {

        public KeyGroup GetResourceKeysByGroup(string groupId)
        {
            if (!string.IsNullOrWhiteSpace(groupId))
            {

                return DbSet.FirstOrDefault(o => o.KeyGroupCode.ToLower().Trim() == groupId.ToLower().Trim());
            }
            else
            {
                return null;
            }
        }

        public List<KeyGroup> GetResourceKeysByGroups(List<string> groupIds)
        {
            if (groupIds != null && groupIds.Count > 0)
            {
                return DbSet.Where(o => groupIds.Contains(o.KeyGroupCode.ToLower().Trim())).ToList();
            }
            else
            {
                return new List<KeyGroup>();
            }
        }
    }
}
