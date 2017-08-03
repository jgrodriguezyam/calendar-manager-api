/* Using Database sqlserver2008 and Connection String Server=mssql5.gear.host; Database=CalendarManager; User Id=calendarmanager; Password=********; */
/* 1: _1_Seed reverting ====================================================== */

/* Beginning Transaction */
/* DeleteForeignKey FK_CheckIn_User CheckIn ()  () */
ALTER TABLE [dbo].[CheckIn] DROP CONSTRAINT [FK_CheckIn_User]

/* DeleteForeignKey FK_CheckIn_Location CheckIn ()  () */
ALTER TABLE [dbo].[CheckIn] DROP CONSTRAINT [FK_CheckIn_Location]

/* DeleteTable CheckIn */
DROP TABLE [dbo].[CheckIn]

/* DeleteForeignKey FK_SharedLocation_User SharedLocation ()  () */
ALTER TABLE [dbo].[SharedLocation] DROP CONSTRAINT [FK_SharedLocation_User]

/* DeleteForeignKey FK_SharedLocation_Location SharedLocation ()  () */
ALTER TABLE [dbo].[SharedLocation] DROP CONSTRAINT [FK_SharedLocation_Location]

/* DeleteTable SharedLocation */
DROP TABLE [dbo].[SharedLocation]

/* DeleteTable Location */
DROP TABLE [dbo].[Location]

/* DeleteTable User */
DROP TABLE [dbo].[User]

DELETE FROM [dbo].[VersionInfo] WHERE [Version] = 1
/* Committing Transaction */
/* 1: _1_Seed reverted */

DROP TABLE [dbo].[VersionInfo]
/* Task completed. */
