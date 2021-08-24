CREATE TABLE [dbo].[Training]
(
	[Id] UNIQUEIDENTIFIER CONSTRAINT [PK_dbo_Training] PRIMARY KEY, 
    [TrainingName] NVARCHAR(64) NOT NULL, 
    [StartDate] DATE NOT NULL CONSTRAINT DC_dbo_Training_StartDate_Check CHECK ([StartDate] >= '2001-01-01'),
    [EndDate] DATE NOT NULL CONSTRAINT DC_dbo_Training_EndDate_Check CHECK ([EndDate] >= [StartDate]), 
    [Description] NVARCHAR(MAX) NULL
);
