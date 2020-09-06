USE [Penalty]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/6/2020 4:32:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 9/6/2020 4:32:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Currency] [nvarchar](max) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OffDayOfWeek]    Script Date: 9/6/2020 4:32:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OffDayOfWeek](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NOT NULL,
	[DayOfWeek] [int] NOT NULL,
 CONSTRAINT [PK_OffDayOfWeek] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 9/6/2020 4:32:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Setting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_Setting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpecialDay]    Script Date: 9/6/2020 4:32:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpecialDay](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NOT NULL,
	[SpecialDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_SpecialDay] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200906130525_Initial', N'3.1.7')
GO
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([Id], [Name], [Currency]) VALUES (1, N'Turkey', N'TL')
INSERT [dbo].[Country] ([Id], [Name], [Currency]) VALUES (2, N'Dubai', N'DH')
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
SET IDENTITY_INSERT [dbo].[OffDayOfWeek] ON 

INSERT [dbo].[OffDayOfWeek] ([Id], [CountryId], [DayOfWeek]) VALUES (1, 1, 6)
INSERT [dbo].[OffDayOfWeek] ([Id], [CountryId], [DayOfWeek]) VALUES (2, 1, 0)
INSERT [dbo].[OffDayOfWeek] ([Id], [CountryId], [DayOfWeek]) VALUES (3, 2, 5)
INSERT [dbo].[OffDayOfWeek] ([Id], [CountryId], [DayOfWeek]) VALUES (4, 2, 6)
SET IDENTITY_INSERT [dbo].[OffDayOfWeek] OFF
GO
SET IDENTITY_INSERT [dbo].[Setting] ON 

INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (1, N'ReservationLimitOfAnyBook', N'10')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (3, N'PenaltyFee', N'5')
SET IDENTITY_INSERT [dbo].[Setting] OFF
GO
SET IDENTITY_INSERT [dbo].[SpecialDay] ON 

INSERT [dbo].[SpecialDay] ([Id], [CountryId], [SpecialDate]) VALUES (1, 1, CAST(N'2020-01-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[SpecialDay] ([Id], [CountryId], [SpecialDate]) VALUES (2, 1, CAST(N'2020-01-17T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[SpecialDay] OFF
GO
ALTER TABLE [dbo].[OffDayOfWeek]  WITH CHECK ADD  CONSTRAINT [FK_OffDayOfWeek_Country_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OffDayOfWeek] CHECK CONSTRAINT [FK_OffDayOfWeek_Country_CountryId]
GO
ALTER TABLE [dbo].[SpecialDay]  WITH CHECK ADD  CONSTRAINT [FK_SpecialDay_Country_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SpecialDay] CHECK CONSTRAINT [FK_SpecialDay_Country_CountryId]
GO
