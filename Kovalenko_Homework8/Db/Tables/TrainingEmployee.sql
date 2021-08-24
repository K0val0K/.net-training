CREATE TABLE [dbo].[TrainingEmployee]
(
	[TrainingId] UNIQUEIDENTIFIER CONSTRAINT [FK_dbo_BookAuthor_dbo_Book] FOREIGN KEY REFERENCES [dbo].[Training]([Id]) ON DELETE CASCADE NOT NULL,
    [EmployeeId] UNIQUEIDENTIFIER CONSTRAINT [FK_dbo_BookAuthor_dbo_Author] FOREIGN KEY REFERENCES [dbo].[Employee]([Id]) ON DELETE CASCADE NOT NULL,
    CONSTRAINT [PK_dbo_TrainingsEmployees] PRIMARY KEY ([TrainingId], [EmployeeId]),
);
GO

CREATE INDEX [IX_dbo_TrainingsEmployees_TrainingId] ON [dbo].[TrainingEmployee]([TrainingId]);
GO

CREATE INDEX [IX_dbo_TrainingsEmployees_EmployeeId] ON [dbo].[TrainingEmployee]([EmployeeId]);
GO
