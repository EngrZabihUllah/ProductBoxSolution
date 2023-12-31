USE [PB_ExerciseSolution]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 22-08-2023 8:13:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CustomerTypeId] [int] NOT NULL,
	[Description] [nvarchar](1024) NULL,
	[Address] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[State] [nvarchar](2) NOT NULL,
	[Zip] [nvarchar](10) NOT NULL,
	[LastUpdated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerType]    Script Date: 22-08-2023 8:13:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CustomerType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Name], [CustomerTypeId], [Description], [Address], [City], [State], [Zip], [LastUpdated]) VALUES (1004, N'Zabih Ullah Khan', 3, N'Customer Updated via IP', N'Warsak Road Peshawar', N'Peshawar', N'1', N'25000', CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Customer] ([Id], [Name], [CustomerTypeId], [Description], [Address], [City], [State], [Zip], [LastUpdated]) VALUES (1005, N'Muhammad Yousaf', 3, N'Customer Created via IP', N'Warsak Road', N'Peshawar', N'1', N'25000', CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Customer] ([Id], [Name], [CustomerTypeId], [Description], [Address], [City], [State], [Zip], [LastUpdated]) VALUES (1006, N'Shams UR Rehman', 3, N'Customer Created via IP', N'Warsak Road', N'Peshawar', N'1', N'25000', CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Customer] ([Id], [Name], [CustomerTypeId], [Description], [Address], [City], [State], [Zip], [LastUpdated]) VALUES (1009, N'Kamran Ali', 3, N'Customer Created via IP', N'Warsak Road', N'Peshawar', N'1', N'25000', CAST(N'2023-08-22T15:30:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerType] ON 

INSERT [dbo].[CustomerType] ([Id], [Name]) VALUES (2, N'Monthly')
INSERT [dbo].[CustomerType] ([Id], [Name]) VALUES (3, N'Yearly')
SET IDENTITY_INSERT [dbo].[CustomerType] OFF
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_LastUpdated]  DEFAULT (getdate()) FOR [LastUpdated]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_CustomerType] FOREIGN KEY([CustomerTypeId])
REFERENCES [dbo].[CustomerType] ([Id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_CustomerType]
GO
