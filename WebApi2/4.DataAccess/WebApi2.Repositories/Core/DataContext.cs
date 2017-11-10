using WebApi2.EntityModels.Core;
using WebApi2.EntityModels.Identity;
using WebApi2.EntityModels.Queues;
using WebApi2.IRepositories.Core;
using WebApi2.Repositories.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using WebApi2.EntityModels.Localization;
using WebApi2.EntityModels.Location;

namespace WebApi2.Repositories.Core
{
    public class DataContext : DbContext,IDataContext
    {
        //public DataContext(string nameOrConnectionString)
        //    : base(nameOrConnectionString)
        //{
        //}

        public IDbSet<User> Users { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<ExternalLogin> Logins { get; set; }
        public IDbSet<Claim> Claims { get; set; }

        public IDbSet<Client> Clients { get; set; }
        public IDbSet<RefreshToken> RefreshTokens { get; set; }

        public IDbSet<KeyGroup> KeyGroups { get; set; }
        public IDbSet<LocalizationKey> LocalizationKeys { get; set; }

        public IDbSet<Country> Countries { get; set; }
        public IDbSet<City> Cities { get; set; }

        public IDbSet<RequestQueue> RequestQueues { get; set; }
        public IDbSet<PdfQueue> PdfQueues { get; set; }
        public IDbSet<EmailQueue> EmailQueues { get; set; }

        public DataContext()
        : base("DefaultConnection")
        {
        }

        public virtual IDbSet<T> DbSet<T>() where T : BaseEntity
        {
            return Set<T>();
        }

        public new DbEntityEntry Entry<T>(T entity) where T : BaseEntity
        {
            return base.Entry(entity);
        }

        public virtual int Commit()
        {
           return base.SaveChanges();
        }

        public virtual Task<int> CommitAsync()
        {
            return base.SaveChangesAsync();
        }

        public virtual Task<int> CommitAsync(System.Threading.CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new ExternalLoginConfiguration());
            modelBuilder.Configurations.Add(new ClaimConfiguration());

            modelBuilder.Configurations.Add(new ClientConfiguration());
            modelBuilder.Configurations.Add(new RefreshTokenConfiguration());

            modelBuilder.Configurations.Add(new CityConfiguration());
            modelBuilder.Configurations.Add(new CountryConfiguration());

            modelBuilder.Configurations.Add(new KeyGroupConfiguration());
            modelBuilder.Configurations.Add(new LocalizationKeyConfiguration());

            modelBuilder.Configurations.Add(new EmailQueueConfiguration());
            modelBuilder.Configurations.Add(new RequestQueueConfiguration());
            modelBuilder.Configurations.Add(new PdfQueueConfiguration());

            Database.SetInitializer<DataContext>(new DataSeeder());

        }
    }
}
