using System.Data.Entity;
using AngularJsDemoAppWithDb.Database.Entities;

namespace AngularJsDemoAppWithDb.Database.Context
{
    public class DemoAppContext : DbContext
    {
        public virtual DbSet<PersonEntity> Person { get; set; }

        public DemoAppContext()
            : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
    }
}
