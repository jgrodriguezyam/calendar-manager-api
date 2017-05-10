/* Using Database sqlserver2008 and Connection String Server=JRODRIGUEZ-PC\SQLEXPRESS; Database=CalendarManager; User Id=sa; Password=********; */
/* VersionMigration migrating ================================================ */

/* Beginning Transaction */
/* CreateTable VersionInfo */
CREATE TABLE [dbo].[VersionInfo] ([Version] BIGINT NOT NULL)

/* Committing Transaction */
/* VersionMigration migrated */

/* VersionUniqueMigration migrating ========================================== */

/* Beginning Transaction */
/* CreateIndex VersionInfo (Version) */
CREATE UNIQUE CLUSTERED INDEX [UC_Version] ON [dbo].[VersionInfo] ([Version] ASC)

/* AlterTable VersionInfo */
/* No SQL statement executed. */

/* CreateColumn VersionInfo AppliedOn DateTime */
ALTER TABLE [dbo].[VersionInfo] ADD [AppliedOn] DATETIME

/* Committing Transaction */
/* VersionUniqueMigration migrated */

/* VersionDescriptionMigration migrating ===================================== */

/* Beginning Transaction */
/* AlterTable VersionInfo */
/* No SQL statement executed. */

/* CreateColumn VersionInfo Description String */
ALTER TABLE [dbo].[VersionInfo] ADD [Description] NVARCHAR(1024)

/* Committing Transaction */
/* VersionDescriptionMigration migrated */

/* 1: _1_Seed migrating ====================================================== */

/* Beginning Transaction */
/* CreateTable User */
CREATE TABLE [dbo].[User] ([Id] INT NOT NULL IDENTITY(1,1), [FirstName] NVARCHAR(250) NOT NULL, [LastName] NVARCHAR(250) NOT NULL, [GenderType] INT NOT NULL, [Email] NVARCHAR(250) NOT NULL, [CellNumber] BIGINT NOT NULL, [UserName] NVARCHAR(250) NOT NULL, [Password] NVARCHAR(250) NOT NULL, [PublicKey] NVARCHAR(250), [Badge] NVARCHAR(250) NOT NULL, [DeviceId] NVARCHAR(250), [CreatedBy] INT NOT NULL, [ModifiedBy] INT NOT NULL, [CreatedOn] DATETIME NOT NULL, [ModifiedOn] DATETIME NOT NULL, [IsActive] BIT NOT NULL, CONSTRAINT [PK_User] PRIMARY KEY ([Id]))

/* CreateIndex User (Email) */
CREATE UNIQUE INDEX [IX_User_Email] ON [dbo].[User] ([Email] ASC)

/* CreateIndex User (CellNumber) */
CREATE UNIQUE INDEX [IX_User_CellNumber] ON [dbo].[User] ([CellNumber] ASC)

/* CreateIndex User (UserName) */
CREATE UNIQUE INDEX [IX_User_UserName] ON [dbo].[User] ([UserName] ASC)

/* CreateIndex User (Badge) */
CREATE UNIQUE INDEX [IX_User_Badge] ON [dbo].[User] ([Badge] ASC)

/* CreateTable Location */
CREATE TABLE [dbo].[Location] ([Id] INT NOT NULL IDENTITY(1,1), [Name] NVARCHAR(250) NOT NULL, [Latitude] DOUBLE PRECISION NOT NULL, [Longitude] DOUBLE PRECISION NOT NULL, [Radius] DOUBLE PRECISION NOT NULL, [Type] INT NOT NULL, [UserId] INT NOT NULL, [CreatedBy] INT NOT NULL, [ModifiedBy] INT NOT NULL, [CreatedOn] DATETIME NOT NULL, [ModifiedOn] DATETIME NOT NULL, [IsActive] BIT NOT NULL, CONSTRAINT [PK_Location] PRIMARY KEY ([Id]))

/* CreateForeignKey FK_Location_User Location(UserId) User(Id) */
ALTER TABLE [dbo].[Location] ADD CONSTRAINT [FK_Location_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])

/* CreateIndex Location (UserId) */
CREATE INDEX [IX_User] ON [dbo].[Location] ([UserId] ASC)

/* CreateTable UserLocation */
CREATE TABLE [dbo].[UserLocation] ([UserId] INT NOT NULL, [LocationId] INT NOT NULL)

/* CreateForeignKey FK_UserLocation_User UserLocation(UserId) User(Id) */
ALTER TABLE [dbo].[UserLocation] ADD CONSTRAINT [FK_UserLocation_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])

/* CreateForeignKey FK_UserLocation_Location UserLocation(LocationId) Location(Id) */
ALTER TABLE [dbo].[UserLocation] ADD CONSTRAINT [FK_UserLocation_Location] FOREIGN KEY ([LocationId]) REFERENCES [dbo].[Location] ([Id])

/* CreateIndex UserLocation (UserId) */
CREATE INDEX [IX_User] ON [dbo].[UserLocation] ([UserId] ASC)

/* CreateIndex UserLocation (LocationId) */
CREATE INDEX [IX_Location] ON [dbo].[UserLocation] ([LocationId] ASC)

INSERT INTO [dbo].[VersionInfo] ([Version], [AppliedOn], [Description]) VALUES (1, '2017-05-10T20:46:53', '_1_Seed')
/* Committing Transaction */
/* 1: _1_Seed migrated */

/* Task completed. */
