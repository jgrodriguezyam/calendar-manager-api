using FluentMigrator;

namespace CalendarManager.Migrations.Sprint_01
{
    [Migration(1)]
    public class _1_Seed : Migration
    {
        public override void Up()
        {
            #region User

            Create.Table("User").InSchema("dbo")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("FirstName").AsString(250).NotNullable()
                .WithColumn("LastName").AsString(250).NotNullable()
                .WithColumn("GenderType").AsInt32().NotNullable()
                .WithColumn("Email").AsString(250).Unique().NotNullable()
                .WithColumn("CellNumber").AsInt64().Unique().NotNullable()
                .WithColumn("UserName").AsString(250).Unique().NotNullable()
                .WithColumn("Password").AsString(250).NotNullable()
                .WithColumn("PublicKey").AsString(250).Nullable()
                .WithColumn("Badge").AsString(250).Unique().NotNullable()
                .WithColumn("DeviceId").AsString(250).Nullable()

                .WithColumn("CreatedBy").AsInt32().NotNullable()
                .WithColumn("ModifiedBy").AsInt32().NotNullable()
                .WithColumn("CreatedOn").AsDateTime().NotNullable()
                .WithColumn("ModifiedOn").AsDateTime().NotNullable()
                .WithColumn("IsActive").AsBoolean();

            #endregion

            #region Location

            Create.Table("Location").InSchema("dbo")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString(250).NotNullable()
                .WithColumn("Latitude").AsDouble().NotNullable()
                .WithColumn("Longitude").AsDouble().NotNullable()
                .WithColumn("Radius").AsDouble().NotNullable()
                .WithColumn("Type").AsInt32().NotNullable()
                .WithColumn("UserId").AsInt32().NotNullable()

                .WithColumn("CreatedBy").AsInt32().NotNullable()
                .WithColumn("ModifiedBy").AsInt32().NotNullable()
                .WithColumn("CreatedOn").AsDateTime().NotNullable()
                .WithColumn("ModifiedOn").AsDateTime().NotNullable()
                .WithColumn("IsActive").AsBoolean();

            Create.ForeignKey("FK_Location_User").FromTable("Location").InSchema("dbo").ForeignColumn("UserId")
                 .ToTable("User").InSchema("dbo").PrimaryColumn("Id");

            Create.Index("IX_User").OnTable("Location").InSchema("dbo").OnColumn("UserId").Ascending();

            #endregion

            #region UserLocation

            Create.Table("UserLocation").InSchema("dbo")
                .WithColumn("UserId").AsInt32().NotNullable()
                .WithColumn("LocationId").AsInt32().NotNullable();

            Create.ForeignKey("FK_UserLocation_User").FromTable("UserLocation").InSchema("dbo").ForeignColumn("UserId")
                 .ToTable("User").InSchema("dbo").PrimaryColumn("Id");
            Create.ForeignKey("FK_UserLocation_Location").FromTable("UserLocation").InSchema("dbo").ForeignColumn("LocationId")
                 .ToTable("Location").InSchema("dbo").PrimaryColumn("Id");

            Create.Index("IX_User").OnTable("UserLocation").InSchema("dbo").OnColumn("UserId").Ascending();
            Create.Index("IX_Location").OnTable("UserLocation").InSchema("dbo").OnColumn("LocationId").Ascending();

            #endregion

            //Execute.Sql("alter database CalendarManager set allow_snapshot_isolation on");
        }

        public override void Down()
        {
            #region UserLocation

            Delete.ForeignKey("FK_UserLocation_User").OnTable("UserLocation").InSchema("dbo");
            Delete.ForeignKey("FK_UserLocation_Location").OnTable("UserLocation").InSchema("dbo");
            Delete.Table("UserLocation").InSchema("dbo");

            #endregion

            #region Location

            Delete.Table("Location").InSchema("dbo");

            #endregion

            #region User

            Delete.Table("User").InSchema("dbo");

            #endregion
        }
    }
}