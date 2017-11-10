using WebApi2.Repositories.Core;
using System.Linq;
using System.Data.Entity;
using WebApi2.EntityModels.Identity;
using WebApi2.IRepositories.Identity;

namespace WebApi2.Repositories.Identity
{
    public class ClientRepository : IdentityBaseRepository<Client>, IClientRepository
    {
        public ClientRepository()
        {

        }

        public Client FindByClientId(string clientId)
        {
            return DbSet.FirstOrDefault(x => x.ClientId == clientId);
        }
    }
}
