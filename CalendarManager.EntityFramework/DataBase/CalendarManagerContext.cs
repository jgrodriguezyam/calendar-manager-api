using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CalendarManager.EntityFramework.Mappings;
using CalendarManager.Model;

namespace CalendarManager.EntityFramework.DataBase
{
    [DbConfigurationType(typeof(DbContextConfiguration))]
    public class CalendarManagerContext : DbContext
    {
        public CalendarManagerContext() : base("name=ConnectionStringCalendarManager")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CalendarManagerContext>());
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> User { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<SharedLocation> SharedLocation { get; set; }
        public DbSet<CheckIn> CheckIn { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new LocationMap());
            modelBuilder.Configurations.Add(new SharedLocationMap());
            modelBuilder.Configurations.Add(new CheckInMap());
        }
    }
}