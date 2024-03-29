/*
   12. november 200923:25:09
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
ALTER TABLE dbo.[User] SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Task SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Sprint SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Assignment
	(
	AssignmentID int NOT NULL IDENTITY (1, 1),
	TaskID int NOT NULL,
	SprintID int NOT NULL,
	UserID int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Assignment SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Assignment ON
GO
IF EXISTS(SELECT * FROM dbo.Assignment)
	 EXEC('INSERT INTO dbo.Tmp_Assignment (AssignmentID, TaskID, SprintID, UserID)
		SELECT AssignmentID, TaskID, SprintID, UserID FROM dbo.Assignment WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Assignment OFF
GO
DROP TABLE dbo.Assignment
GO
EXECUTE sp_rename N'dbo.Tmp_Assignment', N'Assignment', 'OBJECT' 
GO
ALTER TABLE dbo.Assignment ADD CONSTRAINT
	PK_Assignment PRIMARY KEY CLUSTERED 
	(
	AssignmentID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Assignment ADD CONSTRAINT
	FK_Assignment_Sprint FOREIGN KEY
	(
	SprintID
	) REFERENCES dbo.Sprint
	(
	SprintID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Assignment ADD CONSTRAINT
	FK_Assignment_Task FOREIGN KEY
	(
	TaskID
	) REFERENCES dbo.Task
	(
	TaskID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Assignment ADD CONSTRAINT
	FK_Assignment_User FOREIGN KEY
	(
	UserID
	) REFERENCES dbo.[User]
	(
	UserID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
