using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace CalendarManager.EntityFramework.DataBase
{
    public class DbContextConfiguration : DbConfiguration
    {
        public DbContextConfiguration()
        {
            SetDatabaseInitializer(new CreateDatabaseIfNotExists<CalendarManagerContext>());
            SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
    }
}