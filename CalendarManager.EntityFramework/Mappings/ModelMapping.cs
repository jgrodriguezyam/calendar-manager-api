using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CalendarManager.Model;

namespace CalendarManager.EntityFramework.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User").HasKey(user => user.Id);
            Property(user => user.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }

    public class LocationMap : EntityTypeConfiguration<Location>
    {
        public LocationMap()
        {
            ToTable("Location").HasKey(location => location.Id);
            Property(location => location.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(location => location.User).WithMany(user => user.Locations).HasForeignKey(location => location.UserId);
        }
    }

    public class SharedLocationMap : EntityTypeConfiguration<SharedLocation>
    {
        public SharedLocationMap()
        {
            ToTable("SharedLocation").HasKey(sharedLocation => sharedLocation.Id);
            Property(sharedLocation => sharedLocation.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(sharedLocation => sharedLocation.User).WithMany(user => user.SharedLocations).HasForeignKey(sharedLocation => sharedLocation.UserId);
            HasRequired(sharedLocation => sharedLocation.Location).WithMany(location => location.SharedLocations).HasForeignKey(sharedLocation => sharedLocation.LocationId);
        }
    }

    public class CheckInMap : EntityTypeConfiguration<CheckIn>
    {
        public CheckInMap()
        {
            ToTable("CheckIn").HasKey(checkIn => checkIn.Id);
            Property(checkIn => checkIn.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(checkIn => checkIn.User).WithMany(user => user.CheckIns).HasForeignKey(checkIn => checkIn.UserId);
            HasRequired(checkIn => checkIn.Location).WithMany(location => location.CheckIns).HasForeignKey(checkIn => checkIn.LocationId);
        }
    }

    public class FriendshipMap : EntityTypeConfiguration<Friendship>
    {
        public FriendshipMap()
        {
            ToTable("Friendship").HasKey(friendship => friendship.Id);
            Property(friendship => friendship.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}