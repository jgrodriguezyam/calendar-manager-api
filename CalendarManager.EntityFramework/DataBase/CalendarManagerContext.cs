using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CalendarManager.Model;

namespace CalendarManager.EntityFramework.DataBase
{
    [DbConfigurationType(typeof(DbContextConfiguration))]
    public class CalendarManagerContext : DbContext
    {
        public CalendarManagerContext() : base("name=ConnectionStringCalendarManager")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CalendarManagerContext>());
        }

        public DbSet<User> User { get; set; }
        public DbSet<Location> Location { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}