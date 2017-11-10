using WebApi2.Repositories.Core;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Threading;
using WebApi2.EntityModels.Identity;
using WebApi2.IRepositories.Identity;

namespace WebApi2.Repositories.Identity
{
    public class UserRepository : IdentityBaseRepository<User>, IUserRepository
    {
        public UserRepository()
        { }

        //public UserRepository(DataContext dataContext)
        //    : base(dataContext)
        //{
        //}

        public User FindByEmail(string email)
        {
            return DbSet.FirstOrDefault(x => x.Email == email);
        }

        public Task<User> FindByEmailAsync(string email)
        {
            return DbSet.FirstOrDefaultAsync(x => x.Email == email);
        }

        public Task<User> FindByEmailAsync(CancellationToken cancellationToken, string email)
        {
            return DbSet.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }

        public User FindByUserName(string username)
        {
            return DbSet.FirstOrDefault(x => x.UserName == username);
        }

        public Task<User> FindByUserNameAsync(string username)
        {
            return DbSet.FirstOrDefaultAsync(x => x.UserName == username);
        }

        public Task<User> FindByUserNameAsync(CancellationToken cancellationToken, string username)
        {
            return DbSet.FirstOrDefaultAsync(x => x.UserName == username, cancellationToken);
        }
    }
}
