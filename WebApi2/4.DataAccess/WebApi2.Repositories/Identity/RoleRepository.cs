using WebApi2.Repositories.Core;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using WebApi2.EntityModels.Identity;
using WebApi2.IRepositories.Identity;

namespace WebApi2.Repositories.Identity
{
    public class RoleRepository : IdentityBaseRepository<Role>, IRoleRepository
    {
        public RoleRepository()
        {

        }
        //public RoleRepository(DataContext dataContext)
        //    : base(dataContext)
        //{
        //}

        public Role FindByName(string roleName)
        {
            return DbSet.FirstOrDefault(x => x.Name == roleName);
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            return DbSet.FirstOrDefaultAsync(x => x.Name == roleName);
        }

        public Task<Role> FindByNameAsync(System.Threading.CancellationToken cancellationToken, string roleName)
        {
            return DbSet.FirstOrDefaultAsync(x => x.Name == roleName, cancellationToken);
        }
    }
}
