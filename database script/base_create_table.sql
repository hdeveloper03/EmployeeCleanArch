IF NOT EXISTS (SELECT 1 FROM sysobjects where id = object_id(N'employees') and OBJECTPROPERTY(id, N'IsTable') = 1)
BEGIN
	CREATE TABLE [dbo].[Employees](
		[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
		[FirstName] [varchar](100) NULL,
		[LastName] [varchar](100) NULL,
		[DateOfBirth] [datetime] NULL,
		[PhoneNumber] [varchar](20) NULL,
		[Email] [varchar](255) NULL,
		[CreatedDate] [datetime] NULL,
		[LastModifiedDate] [datetime] NULL,
	 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
	(
		[EmployeeId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
GO
END

IF NOT EXISTS(SELECT * FROM  sys.indexes i 
INNER JOIN  sys.objects t ON (i.[object_id] = t.[object_id])
WHERE t.[object_id] = OBJECT_ID(N'[dbo].[Employees]')
AND i.[name] = 'Employees_orderby')
BEGIN

CREATE NONCLUSTERED INDEX [Employees_orderby] ON [dbo].[Employees]
(
	[CreatedDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
END
GO