/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO [dbo].[Training] ([Id], [TrainingName], [StartDate], [EndDate], [Description])
VALUES
	('C12C49AB-1BD0-4EC6-AB35-1DE1566C670D','Modern JavaScript','2015-09-01','2015-09-25','First training description'),
	('0E1257D6-9661-4D54-9C30-E924B4CF1B72','Modern JavaScript','2016-04-05','2016-04-29', NULL)
INSERT INTO [dbo].[Employee] ([Id],[Email],[Name],[Surname])
VALUES
	('C12C49AB-1BD0-4EC6-AB35-1DE1566C6700', 'neznaika@issoft.by', 'nez', 'naika'),
	('C12C49AB-1BD0-4EC6-AB35-1DE1566C6701', 'vlad@issoft.by', 'vl', 'ad')
GO
