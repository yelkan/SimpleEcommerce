CREATE DATABASE [InveonDB];
GO

USE [InveonDB]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 17.01.2021 19:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Barcode] [nvarchar](100) NOT NULL,
	[Price] [decimal](18, 5) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Quantity] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[Creator] [int]  NULL,
	[CreatedDate] [datetimeoffset](7)  NULL,
	[Modifier] [int] NULL,
	[ModifiedDate] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImage]    Script Date: 17.01.2021 19:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImage](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[Path] [nvarchar](255) NOT NULL,
	[Creator] [int] NULL,
	[CreatedDate] [datetimeoffset](7) NULL,
	[Modifier] [int] NULL,
	[ModifiedDate] [datetimeoffset](7) NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_ProductImage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 17.01.2021 19:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
	[Creator] [int] NULL,
	[CreatedDate] [datetimeoffset](7) NULL,
	[Modifier] [int] NULL,
	[ModifiedDate] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 17.01.2021 19:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](25) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[NameSurname] [nvarchar](100) NULL,
	[EmailAddress] [nvarchar](50) NULL,
	[Creator] [int] NULL,
	[CreatedDate] [datetimeoffset](7) NULL,
	[Modifier] [int] NULL,
	[ModifiedDate] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 17.01.2021 19:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserId] [bigint] NOT NULL,
	[RoleId] [smallint] NOT NULL,
	[Creator] [int] NULL,
	[CreatedDate] [datetimeoffset](7) NULL,
	[Modifier] [int] NULL,
	[ModifiedDate] [datetimeoffset](7) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProductImage]  WITH CHECK ADD  CONSTRAINT [FK_ProductImage_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductImage] CHECK CONSTRAINT [FK_ProductImage_Product]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO


INSERT INTO [dbo].[Role]([Name],[Creator],[CreatedDate])
     VALUES('Admin',0,SYSDATETIMEOFFSET())

INSERT INTO [dbo].[Role]([Name],[Creator],[CreatedDate])
     VALUES('SuperAdmin',0,SYSDATETIMEOFFSET())

INSERT INTO [dbo].[Role]([Name],[Creator],[CreatedDate])
     VALUES('Custormer',0,SYSDATETIMEOFFSET())

INSERT INTO [dbo].[Role]([Name],[Creator],[CreatedDate])
     VALUES('Standard',0,SYSDATETIMEOFFSET())
	 
INSERT INTO [dbo].[User]([UserName],[Password],[NameSurname],[EmailAddress],[Creator],[CreatedDate])
     VALUES('admin','admin','John Doe','admin@admin.com',0,SYSDATETIMEOFFSET())

INSERT INTO dbo.UserRole(UserId,RoleId,Creator,CreatedDate)
VALUES(@@IDENTITY,1,0,SYSDATETIMEOFFSET())