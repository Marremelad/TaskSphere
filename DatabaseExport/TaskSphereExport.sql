USE [master]
GO
/****** Object:  Database [TaskSphere]    Script Date: 2024-12-04 09:45:18 ******/
CREATE DATABASE [TaskSphere]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TaskSphere', FILENAME = N'C:\Users\Corte\TaskSphere.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TaskSphere_log', FILENAME = N'C:\Users\Corte\TaskSphere_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TaskSphere] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TaskSphere].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TaskSphere] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TaskSphere] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TaskSphere] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TaskSphere] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TaskSphere] SET ARITHABORT OFF 
GO
ALTER DATABASE [TaskSphere] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TaskSphere] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TaskSphere] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TaskSphere] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TaskSphere] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TaskSphere] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TaskSphere] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TaskSphere] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TaskSphere] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TaskSphere] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TaskSphere] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TaskSphere] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TaskSphere] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TaskSphere] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TaskSphere] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TaskSphere] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TaskSphere] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TaskSphere] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TaskSphere] SET  MULTI_USER 
GO
ALTER DATABASE [TaskSphere] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TaskSphere] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TaskSphere] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TaskSphere] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TaskSphere] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TaskSphere] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TaskSphere] SET QUERY_STORE = OFF
GO
USE [TaskSphere]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 2024-12-04 09:45:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](35) NOT NULL,
	[CategoryDescription] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 2024-12-04 09:45:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[TaskID] [int] IDENTITY(1,1) NOT NULL,
	[TaskName] [nvarchar](35) NOT NULL,
	[TaskStatus] [bit] NULL,
	[TaskDeadline] [date] NULL,
	[TaskDescription] [nvarchar](255) NULL,
	[CategoryID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (1, N'Home', N'Things to do at home')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (2, N'Work', N'Things to do at work')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (3, N'Other', N'Other things to do')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Tasks] ON 

INSERT [dbo].[Tasks] ([TaskID], [TaskName], [TaskStatus], [TaskDeadline], [TaskDescription], [CategoryID]) VALUES (1, N'New task', 1, CAST(N'2024-12-03' AS Date), N'Use the new soap', 1)
INSERT [dbo].[Tasks] ([TaskID], [TaskName], [TaskStatus], [TaskDeadline], [TaskDescription], [CategoryID]) VALUES (2, N'Fix bug', 0, CAST(N'2024-12-10' AS Date), N'Use the debugger this time', 2)
INSERT [dbo].[Tasks] ([TaskID], [TaskName], [TaskStatus], [TaskDeadline], [TaskDescription], [CategoryID]) VALUES (3, N'Go for a run', 0, CAST(N'2024-12-03' AS Date), N'Run ten miles', 3)
INSERT [dbo].[Tasks] ([TaskID], [TaskName], [TaskStatus], [TaskDeadline], [TaskDescription], [CategoryID]) VALUES (4, N'Make bed', 0, CAST(N'2024-12-03' AS Date), N'Use the good sheets', 1)
INSERT [dbo].[Tasks] ([TaskID], [TaskName], [TaskStatus], [TaskDeadline], [TaskDescription], [CategoryID]) VALUES (5, N'Call customer', 0, CAST(N'2024-12-10' AS Date), N'Talk about bussiness', 2)
INSERT [dbo].[Tasks] ([TaskID], [TaskName], [TaskStatus], [TaskDeadline], [TaskDescription], [CategoryID]) VALUES (6, N'Walk the dog', 0, CAST(N'2024-12-03' AS Date), N'Give treats', 3)
INSERT [dbo].[Tasks] ([TaskID], [TaskName], [TaskStatus], [TaskDeadline], [TaskDescription], [CategoryID]) VALUES (9, N'New Task', 0, NULL, N'This is a new task', 3)
INSERT [dbo].[Tasks] ([TaskID], [TaskName], [TaskStatus], [TaskDeadline], [TaskDescription], [CategoryID]) VALUES (1002, N'new task', 0, CAST(N'2024-12-04' AS Date), N'This is a new task', 3)
SET IDENTITY_INSERT [dbo].[Tasks] OFF
GO
ALTER TABLE [dbo].[Tasks] ADD  DEFAULT ((0)) FOR [TaskStatus]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
USE [master]
GO
ALTER DATABASE [TaskSphere] SET  READ_WRITE 
GO
