CREATE TABLE [dbo].[Vacation]
(
	[Id] UNIQUEIDENTIFIER CONSTRAINT [PK_dbo_Vacation] PRIMARY KEY, 
    [EmployeeId] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [FK_dbo_Vacation_dbo_Employee] FOREIGN KEY REFERENCES [dbo].[Employee] ([Id]) ON DELETE CASCADE, 
    [StartDate] DATE NOT NULL CONSTRAINT DC_dbo_Vacation_StartDate_Check CHECK ([StartDate] >= '2001-01-01'), 
    [EndDate] DATE NOT NULL CONSTRAINT DC_dbo_Vacation_EndDate_Check CHECK ([EndDate] >= [StartDate]) 
);
GO

CREATE INDEX [IX_dbo_Vacation_EmployeeId] ON [dbo].[Vacation] ([Id])
GO