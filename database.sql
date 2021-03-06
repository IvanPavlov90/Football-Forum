USE [master]
GO
/****** Object:  Database [FootballForum]    Script Date: 18.07.2021 10:04:36 ******/
CREATE DATABASE [FootballForum]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FootballForum', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\FootballForum.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FootballForum_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\FootballForum_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FootballForum] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FootballForum].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FootballForum] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FootballForum] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FootballForum] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FootballForum] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FootballForum] SET ARITHABORT OFF 
GO
ALTER DATABASE [FootballForum] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FootballForum] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FootballForum] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FootballForum] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FootballForum] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FootballForum] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FootballForum] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FootballForum] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FootballForum] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FootballForum] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FootballForum] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FootballForum] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FootballForum] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FootballForum] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FootballForum] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FootballForum] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FootballForum] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FootballForum] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FootballForum] SET  MULTI_USER 
GO
ALTER DATABASE [FootballForum] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FootballForum] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FootballForum] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FootballForum] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FootballForum] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FootballForum] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [FootballForum] SET QUERY_STORE = OFF
GO
USE [FootballForum]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 18.07.2021 10:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Topic_id] [int] NOT NULL,
	[Creator_id] [int] NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[Created_At] [datetime] NOT NULL,
	[Update_At] [datetime] NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topics]    Script Date: 18.07.2021 10:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topics](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Creator_id] [int] NOT NULL,
	[Text] [nvarchar](500) NOT NULL,
	[Created_At] [datetime] NOT NULL,
	[Update_At] [datetime] NOT NULL,
 CONSTRAINT [PK_Topics] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 18.07.2021 10:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Age] [int] NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[CreatedAt] [nvarchar](100) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
	[SecondRole] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users2] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Topics] FOREIGN KEY([Topic_id])
REFERENCES [dbo].[Topics] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Topics]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Users] FOREIGN KEY([Creator_id])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Users]
GO
ALTER TABLE [dbo].[Topics]  WITH CHECK ADD  CONSTRAINT [FK_Topics_Users] FOREIGN KEY([Creator_id])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Topics] CHECK CONSTRAINT [FK_Topics_Users]
GO
/****** Object:  StoredProcedure [dbo].[AddMessage]    Script Date: 18.07.2021 10:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddMessage]
	@Topic_id int,
	@Creator_id int,
	@Text nvarchar(MAX),
	@Created_At datetime,
	@Update_At datetime
AS
BEGIN
	SET NOCOUNT OFF;

	INSERT INTO dbo.Messages VALUES (@Topic_id, @Creator_id, @Text, @Created_At, @Update_At)
	UPDATE dbo.Topics SET Update_At = @Created_At WHERE [id] = @Topic_id
END
GO
/****** Object:  StoredProcedure [dbo].[AddTopic]    Script Date: 18.07.2021 10:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddTopic]
	@Creator_id int,
	@Text nvarchar(500),
	@Created_At datetime,
	@Update_At datetime
AS
BEGIN
	SET NOCOUNT OFF;

	INSERT INTO dbo.Topics VALUES (@Creator_id, @Text, @Created_At, @Update_At)
END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 18.07.2021 10:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUser]
	@Login nvarchar(50),
	@Email nvarchar(100),
	@Age tinyint,
	@Password nvarchar(100),
	@CreatedAt nvarchar(100),
	@Role nvarchar(50),
	@SecondRole nvarchar(50)
AS
BEGIN
	SET NOCOUNT OFF;

	INSERT INTO dbo.Users VALUES (@Login, @Email, @Age, @Password, @CreatedAt, @Role, @SecondRole)
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteMessage]    Script Date: 18.07.2021 10:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteMessage]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.Messages WHERE [id] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteTopic]    Script Date: 18.07.2021 10:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteTopic]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.Messages WHERE [Topic_id] = @id
    DELETE FROM dbo.Topics WHERE [id] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 18.07.2021 10:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteUser] 
	@id int
AS
BEGIN

	SET NOCOUNT ON;

    DELETE FROM dbo.Messages WHERE [Creator_id] = @id
    DELETE FROM dbo.Topics WHERE [Creator_id] = @id
	DELETE FROM dbo.Users Where [id] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllTopics]    Script Date: 18.07.2021 10:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllTopics]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT Topics.[id], [Creator_id], Topics.[Text], [Update_At], Users.[Login] FROM dbo.Topics JOIN dbo.Users ON dbo.Topics.Creator_id = dbo.Users.id
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 18.07.2021 10:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllUsers] 

AS
BEGIN
	SET NOCOUNT ON;

	SELECT [id], [Login], [Email], [Age], [CreatedAt] FROM dbo.Users
END
GO
/****** Object:  StoredProcedure [dbo].[GetMessages]    Script Date: 18.07.2021 10:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetMessages] 
	@Topic_id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Messages.[id], Messages.[Text], Messages.[Created_At], Users.[Login] FROM dbo.Messages JOIN dbo.Users ON dbo.Messages.Creator_id = dbo.Users.id WHERE Messages.[Topic_id] = @Topic_id
END
GO
/****** Object:  StoredProcedure [dbo].[GetRole]    Script Date: 18.07.2021 10:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetRole]
	@Login nvarchar(50)
AS
BEGIN
	SET NOCOUNT OFF;

	SELECT [Role], [SecondRole] FROM dbo.Users WHERE [Login] = @Login
END
GO
/****** Object:  StoredProcedure [dbo].[GetTopicById]    Script Date: 18.07.2021 10:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetTopicById]
	@id int
AS
BEGIN
	SET NOCOUNT OFF;

	SELECT [Creator_id], Topics.[Text], [Created_At], Users.[Login] FROM dbo.Topics JOIN dbo.Users ON dbo.Topics.Creator_id = dbo.Users.id WHERE Topics.[id] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[GetTopicsByCreatorID]    Script Date: 18.07.2021 10:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetTopicsByCreatorID]
	@Creator_id int
AS
BEGIN
	SET NOCOUNT OFF;

	SELECT [id], [Text] FROM dbo.Topics WHERE [Creator_id] = @Creator_id
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 18.07.2021 10:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserById]
	@id int
AS
BEGIN
	SET NOCOUNT OFF;

	SELECT [id], [Login], [Email], [Age], [CreatedAt] FROM dbo.Users WHERE [id] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserByLogin]    Script Date: 18.07.2021 10:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserByLogin]
	@Login nvarchar(50)
AS
BEGIN
	SET NOCOUNT OFF;

	SELECT [id], [Login], [Email], [Age], [CreatedAt] FROM dbo.Users WHERE [Login] = @Login
END
GO
/****** Object:  StoredProcedure [dbo].[SearchAuthData]    Script Date: 18.07.2021 10:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SearchAuthData]
	@Login nvarchar(50),
	@Email nvarchar(100)
AS
BEGIN
	SET NOCOUNT OFF;

	SELECT [Login],[Email] FROM dbo.Users WHERE [Login] = @Login OR [Email] = @Email
END
GO
/****** Object:  StoredProcedure [dbo].[SearchEmail]    Script Date: 18.07.2021 10:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchEmail]
	@Email nvarchar(100)
AS
BEGIN
	SET NOCOUNT OFF;

	SELECT [Email] FROM dbo.Users WHERE [Email] = @Email
END
GO
/****** Object:  StoredProcedure [dbo].[SearchLogin]    Script Date: 18.07.2021 10:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchLogin] 
	@Login nvarchar(50)
AS
BEGIN
	SET NOCOUNT OFF;

    SELECT [Login] FROM dbo.Users WHERE [Login] = @Login
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 18.07.2021 10:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateUser]
	@id int,
	@Login nvarchar(50),
	@Email nvarchar(100),
	@Age int,
	@SecondRole nvarchar(50)
AS
BEGIN
	SET NOCOUNT OFF;

	UPDATE dbo.Users SET [Login] = @Login, [Email] = @Email, [Age] = @Age, [SecondRole] = @SecondRole WHERE [id] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[ValidateAuthData]    Script Date: 18.07.2021 10:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ValidateAuthData]
	@Login nvarchar(50),
	@Password nvarchar(100)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Login],[Password] FROM dbo.Users WHERE [Login] = @Login AND [Password] = @Password
END
GO
USE [master]
GO
ALTER DATABASE [FootballForum] SET  READ_WRITE 
GO
