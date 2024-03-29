/*
   15. november 200920:59:57
   User: 
   Server: .\SQLEXPRESS
   Database: 
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Sprint ADD
	Archived bit NOT NULL CONSTRAINT DF_Sprint_Archived DEFAULT 0
GO
ALTER TABLE dbo.Sprint SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
