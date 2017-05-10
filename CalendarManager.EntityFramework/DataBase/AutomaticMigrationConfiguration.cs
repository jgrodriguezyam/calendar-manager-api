using System.Data.Entity.Migrations;

namespace CalendarManager.EntityFramework.DataBase
{
    public class AutomaticMigrationConfiguration : DbMigrationsConfiguration<CalendarManagerContext>
    {
        public AutomaticMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}