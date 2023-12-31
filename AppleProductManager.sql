USE [master]
GO
/****** Object:  Database [AppleProductManager]    Script Date: 10/21/2023 8:34:30 PM ******/
CREATE DATABASE [AppleProductManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AppleProductManager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\AppleProductManager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AppleProductManager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\AppleProductManager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [AppleProductManager] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AppleProductManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AppleProductManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AppleProductManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AppleProductManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AppleProductManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AppleProductManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [AppleProductManager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AppleProductManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AppleProductManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AppleProductManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AppleProductManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AppleProductManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AppleProductManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AppleProductManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AppleProductManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AppleProductManager] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AppleProductManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AppleProductManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AppleProductManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AppleProductManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AppleProductManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AppleProductManager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AppleProductManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AppleProductManager] SET RECOVERY FULL 
GO
ALTER DATABASE [AppleProductManager] SET  MULTI_USER 
GO
ALTER DATABASE [AppleProductManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AppleProductManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AppleProductManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AppleProductManager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AppleProductManager] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AppleProductManager] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'AppleProductManager', N'ON'
GO
ALTER DATABASE [AppleProductManager] SET QUERY_STORE = ON
GO
ALTER DATABASE [AppleProductManager] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [AppleProductManager]
GO
/****** Object:  Table [dbo].[account_type]    Script Date: 10/21/2023 8:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account_type](
	[type_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_account_type] PRIMARY KEY CLUSTERED 
(
	[type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[accounts]    Script Date: 10/21/2023 8:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accounts](
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[fullname] [nvarchar](100) NOT NULL,
	[phone] [nvarchar](20) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[address] [nvarchar](100) NOT NULL,
	[type] [int] NOT NULL,
 CONSTRAINT [PK_accounts] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cart]    Script Date: 10/21/2023 8:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cart](
	[cart_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[product_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[totalprice] [money] NOT NULL,
 CONSTRAINT [PK_cart] PRIMARY KEY CLUSTERED 
(
	[cart_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order]    Script Date: 10/21/2023 8:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[order_date] [date] NOT NULL,
	[required_date] [date] NOT NULL,
	[shipped_date] [date] NOT NULL,
	[ship_address] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order_detail]    Script Date: 10/21/2023 8:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_detail](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NOT NULL,
	[price] [money] NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_order_detail] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC,
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product]    Script Date: 10/21/2023 8:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](500) NOT NULL,
	[description] [nvarchar](1000) NOT NULL,
	[quantity] [int] NOT NULL,
	[type] [int] NOT NULL,
	[price] [money] NOT NULL,
	[image] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_type]    Script Date: 10/21/2023 8:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_type](
	[type_id] [int] IDENTITY(1,1) NOT NULL,
	[type_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_product_type] PRIMARY KEY CLUSTERED 
(
	[type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[account_type] ON 

INSERT [dbo].[account_type] ([type_id], [name]) VALUES (1, N'admin')
INSERT [dbo].[account_type] ([type_id], [name]) VALUES (2, N'staff')
INSERT [dbo].[account_type] ([type_id], [name]) VALUES (3, N'customer')
SET IDENTITY_INSERT [dbo].[account_type] OFF
GO
INSERT [dbo].[accounts] ([username], [password], [fullname], [phone], [email], [address], [type]) VALUES (N'hai', N'123', N'Huỳnh Hải', N'0123321123', N'hai@gmail.com', N'Đồng Tháp', 1)
INSERT [dbo].[accounts] ([username], [password], [fullname], [phone], [email], [address], [type]) VALUES (N'hai1', N'123', N'Huỳnh Hải', N'0123321123', N'hai1@gmail.com', N'Đồng Tháp', 2)
INSERT [dbo].[accounts] ([username], [password], [fullname], [phone], [email], [address], [type]) VALUES (N'hai2', N'123', N'Huỳnh Hải', N'0123321123', N'hai2@gmail.com', N'Đồng Tháp', 3)
GO
SET IDENTITY_INSERT [dbo].[product] ON 

INSERT [dbo].[product] ([product_id], [name], [description], [quantity], [type], [price], [image]) VALUES (1, N'iPhone 15 Pro Max', N'256GB VN/A', 10, 1, 2000.0000, N'https://cdn.viettelstore.vn/Images/Product/ProductImage/291703442.jpeg')
SET IDENTITY_INSERT [dbo].[product] OFF
GO
SET IDENTITY_INSERT [dbo].[product_type] ON 

INSERT [dbo].[product_type] ([type_id], [type_name]) VALUES (1, N'iPhone')
INSERT [dbo].[product_type] ([type_id], [type_name]) VALUES (2, N'Macbook')
INSERT [dbo].[product_type] ([type_id], [type_name]) VALUES (3, N'iMac')
SET IDENTITY_INSERT [dbo].[product_type] OFF
GO
ALTER TABLE [dbo].[accounts]  WITH CHECK ADD  CONSTRAINT [FK_accounts_account_type] FOREIGN KEY([type])
REFERENCES [dbo].[account_type] ([type_id])
GO
ALTER TABLE [dbo].[accounts] CHECK CONSTRAINT [FK_accounts_account_type]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_accounts] FOREIGN KEY([username])
REFERENCES [dbo].[accounts] ([username])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_accounts]
GO
ALTER TABLE [dbo].[order_detail]  WITH CHECK ADD  CONSTRAINT [FK_order_detail_order] FOREIGN KEY([order_id])
REFERENCES [dbo].[order] ([order_id])
GO
ALTER TABLE [dbo].[order_detail] CHECK CONSTRAINT [FK_order_detail_order]
GO
ALTER TABLE [dbo].[order_detail]  WITH CHECK ADD  CONSTRAINT [FK_order_detail_product] FOREIGN KEY([product_id])
REFERENCES [dbo].[product] ([product_id])
GO
ALTER TABLE [dbo].[order_detail] CHECK CONSTRAINT [FK_order_detail_product]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_product_type] FOREIGN KEY([type])
REFERENCES [dbo].[product_type] ([type_id])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK_product_product_type]
GO
USE [master]
GO
ALTER DATABASE [AppleProductManager] SET  READ_WRITE 
GO
