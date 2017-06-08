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
                .WithColumn("ImagePath").AsString(250).Nullable()

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
                .WithColumn("StartDate").AsDate().NotNullable()
                .WithColumn("EndDate").AsDate().NotNullable()
                .WithColumn("Comment").AsString(250).Nullable()
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

            #region SharedLocation

            Create.Table("SharedLocation").InSchema("dbo")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("UserId").AsInt32().NotNullable()
                .WithColumn("LocationId").AsInt32().NotNullable()

                .WithColumn("CreatedBy").AsInt32().NotNullable()
                .WithColumn("ModifiedBy").AsInt32().NotNullable()
                .WithColumn("CreatedOn").AsDateTime().NotNullable()
                .WithColumn("ModifiedOn").AsDateTime().NotNullable()
                .WithColumn("IsActive").AsBoolean();

            Create.ForeignKey("FK_SharedLocation_User").FromTable("SharedLocation").InSchema("dbo").ForeignColumn("UserId")
                 .ToTable("User").InSchema("dbo").PrimaryColumn("Id");
            Create.ForeignKey("FK_SharedLocation_Location").FromTable("SharedLocation").InSchema("dbo").ForeignColumn("LocationId")
                 .ToTable("Location").InSchema("dbo").PrimaryColumn("Id");

            Create.Index("IX_User").OnTable("SharedLocation").InSchema("dbo").OnColumn("UserId").Ascending();
            Create.Index("IX_Location").OnTable("SharedLocation").InSchema("dbo").OnColumn("LocationId").Ascending();

            #endregion

            #region CheckIn

            Create.Table("CheckIn").InSchema("dbo")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Type").AsInt32().NotNullable()
                .WithColumn("UserId").AsInt32().NotNullable()
                .WithColumn("LocationId").AsInt32().NotNullable()

                .WithColumn("CreatedBy").AsInt32().NotNullable()
                .WithColumn("ModifiedBy").AsInt32().NotNullable()
                .WithColumn("CreatedOn").AsDateTime().NotNullable()
                .WithColumn("ModifiedOn").AsDateTime().NotNullable()
                .WithColumn("IsActive").AsBoolean();

            Create.ForeignKey("FK_CheckIn_User").FromTable("CheckIn").InSchema("dbo").ForeignColumn("UserId")
                 .ToTable("User").InSchema("dbo").PrimaryColumn("Id");
            Create.ForeignKey("FK_CheckIn_Location").FromTable("CheckIn").InSchema("dbo").ForeignColumn("LocationId")
                 .ToTable("Location").InSchema("dbo").PrimaryColumn("Id");

            Create.Index("IX_User").OnTable("CheckIn").InSchema("dbo").OnColumn("UserId").Ascending();
            Create.Index("IX_Location").OnTable("CheckIn").InSchema("dbo").OnColumn("LocationId").Ascending();

            #endregion

            //Execute.Sql("alter database CalendarManager set allow_snapshot_isolation on");
        }

        public override void Down()
        {
            #region CheckIn

            Delete.ForeignKey("FK_CheckIn_User").OnTable("CheckIn").InSchema("dbo");
            Delete.ForeignKey("FK_CheckIn_Location").OnTable("CheckIn").InSchema("dbo");
            Delete.Table("CheckIn").InSchema("dbo");

            #endregion

            #region SharedLocation

            Delete.ForeignKey("FK_SharedLocation_User").OnTable("SharedLocation").InSchema("dbo");
            Delete.ForeignKey("FK_SharedLocation_Location").OnTable("SharedLocation").InSchema("dbo");
            Delete.Table("SharedLocation").InSchema("dbo");

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