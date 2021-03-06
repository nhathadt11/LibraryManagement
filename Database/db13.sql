drop database [LibraryManagementV2]
USE [master]
GO
/****** Object:  Database [LibraryManagementV2]    Script Date: 3/16/2017 12:47:03 PM ******/
CREATE DATABASE [LibraryManagementV2]

ALTER DATABASE [LibraryManagementV2] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryManagementV2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibraryManagementV2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibraryManagementV2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibraryManagementV2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibraryManagementV2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibraryManagementV2] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibraryManagementV2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LibraryManagementV2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibraryManagementV2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryManagementV2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibraryManagementV2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibraryManagementV2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibraryManagementV2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibraryManagementV2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibraryManagementV2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibraryManagementV2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LibraryManagementV2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibraryManagementV2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibraryManagementV2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibraryManagementV2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibraryManagementV2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibraryManagementV2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibraryManagementV2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibraryManagementV2] SET RECOVERY FULL 
GO
ALTER DATABASE [LibraryManagementV2] SET  MULTI_USER 
GO
ALTER DATABASE [LibraryManagementV2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibraryManagementV2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibraryManagementV2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibraryManagementV2] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [LibraryManagementV2] SET DELAYED_DURABILITY = DISABLED 
GO
USE [LibraryManagementV2]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 3/16/2017 12:47:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](300) NOT NULL,
	[Contact] [nvarchar](1000) NULL DEFAULT (N'N/A'),
	[Address] [nvarchar](300) NULL DEFAULT (N'N/A'),
	[Bio] [nvarchar](max) NULL DEFAULT (N'N/A'),
PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Books]    Script Date: 3/16/2017 12:47:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Isbn] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL CONSTRAINT [DF__Books__Descripti__2E1BDC42]  DEFAULT (N'N/A'),
	[CoverImageUrl] [nvarchar](max) NULL CONSTRAINT [DF__Books__CoverImag__2F10007B]  DEFAULT (N'DefaultCover.jpg'),
	[PageNumber] [int] NULL,
	[PublishedDate] [date] NULL,
	[AuthorId] [int] NULL,
	[CategoryId] [int] NULL,
	[PublisherId] [int] NULL,
	[Discontinued] [bit] NULL CONSTRAINT [DF__Books__Discontin__32E0915F]  DEFAULT ((0)),
 CONSTRAINT [PK__Books__3DE0C207F3D8E107] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](300) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Copies]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Copies](
	[CopyId] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NULL,
	[IsAvailable] [bit] NULL DEFAULT ((1)),
PRIMARY KEY CLUSTERED 
(
	[CopyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoanDetails]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanDetails](
	[CopyId] [int] NULL,
	[LoanId] [int] NULL,
	[ReturnDate] [date] NULL DEFAULT (NULL)
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Loans]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loans](
	[LoanId] [int] IDENTITY(1,1) NOT NULL,
	[IssueDate] [datetime] NULL DEFAULT (getdate()),
	[LimitDay] [int] NULL DEFAULT ((5)),
	[MemberId] [int] NOT NULL,
	[LibrarianId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LoanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Publishers]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publishers](
	[PublisherId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](300) NOT NULL,
	[Contact] [nvarchar](1000) NULL DEFAULT (N'N/A'),
	[Address] [nvarchar](300) NULL DEFAULT (N'N/A'),
	[Description] [nvarchar](max) NULL DEFAULT (N'N/A'),
PRIMARY KEY CLUSTERED 
(
	[PublisherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](300) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](300) NOT NULL,
	[Password] [nvarchar](60) NULL,
	[FullName] [nvarchar](100) NULL,
	[PhoneNumber] [nvarchar](11) NULL CONSTRAINT [DF__Users__PhoneNumb__276EDEB3]  DEFAULT (N'N/A'),
	[Address] [nvarchar](600) NULL CONSTRAINT [DF__Users__Address__286302EC]  DEFAULT (N'N/A'),
	[Email] [nvarchar](50) NULL CONSTRAINT [DF__Users__Email__29572725]  DEFAULT (N'N/A'),
	[RoleId] [int] NULL,
 CONSTRAINT [PK__Users__1788CC4CAF8054B0] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[vBooks]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vBooks] as
select 
	b.BookId as Id, b.Title as Title, b.Isbn as ISBN, (select count(CopyId) from Copies) as Copies,b.PageNumber as NumOfPage, b.PublishedDate as PublishDate, 
	c.Name as Category, a.FullName as Author, p.Name as Publisher,
	b.Discontinued as Discontinued, b.Description as Description, b.CoverImageUrl as Cover
from
	Books b,
	Categories c,
	Authors a,
	Publishers p
where 
	b.CategoryId = c.CategoryId and
	b.AuthorId = a.AuthorId and
	b.PublisherId = p.PublisherId


GO
/****** Object:  View [dbo].[vCopies]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vCopies] as
select * 
from Copies c, vBooks b
where c.BookId = b.Id


GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (11, N'Nhiều tác giả', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (12, N'Kim Định', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (13, N'Vương Bằng', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (14, N'Tô Hồng Vân', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (15, N'Hồ Đắc Thiếu Anh, Nguyễn Hồ Tiếu Anh', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (16, N'Tam Thái', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (17, N'Trần Lê Sáng chủ biên', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (18, N'Tuệ An - Lý Minh Phúc', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (19, N'Phan Kế Bính', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (20, N'GS Vũ Ngọc Khánh', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (21, N'Xuân Nguyễn tuyển chọn', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (22, N'Chris Van Allsburg', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (23, N'RUSSELL PUNTER', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (24, N'Jason F. Wright', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (25, N'Charles Dickens', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (26, N'Lizzie Mary Cullen', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (27, N'Richard Paul Evans', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (28, N'George Oshawa', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (29, N'Ngô Ánh Tuyết', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (30, N'Anh Minh Ngô Thành Nhân', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (31, N'Lima Ohsawa - Diệu Hạnh', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (32, N'Anh Minh Ngô Thanh Nhân - Ngô Ánh Tuyết', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (33, N'J. Krishnamurti', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (34, N'Krishnamurti', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (35, N'Swami Sivananda', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (36, N'Hòa Thượng Quảng Khâm', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (37, N'Pháp sư Thánh Nghiêm', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (38, N'Tenzin Gyatso', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (39, N'Lama Anagarika Govinda', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (40, N'Nguyễn Văn Hầu', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (41, N'Dật Danh', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (42, N'Thạch Kiều Thanh', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (43, N'Nguyễn Anh Vũ', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (44, N'Lê Mạnh Thát', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (45, N'Lê Anh Minh', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (46, N'Trần Đức Thảo', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (47, N'Jana Mohr Lone', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (48, N'Jacques Monod', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (49, N'Claude Lévi - Strauss', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (50, N'Francis Bacon', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (51, N'Hellen Dukas - Banesh Hoffmann', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (52, N'Immanuel Kant', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (53, N'Dr. Mortimer J. Adler', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (54, N'Plato', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (55, N'Bùi Văn Nam Sơn', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (56, N'Jocelyn Benoist - Michel Espagne chủ biên', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (57, N'Nguyễn Thạch Giang, Ca Văn Thỉnh, Nguyễn Sỹ Lâm', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (58, N'Trang Xtd', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (59, N'Tô Hải Vân', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (60, N'Ái Duy', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (61, N'Nhật Chiêu', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (62, N'Nguyễn Duy', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (63, N'Minh Cúc', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (64, N'Trần Thị Thùy Trang', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (65, N'Nguyễn Nguyên Phước', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (66, N'Tony Buổi Sáng', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (67, N'Emma Donoghue', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (68, N'Michael Sandel', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (69, N'Krasznahorkal László', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (70, N'Pierre Lemaitre', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (71, N'Bram Stoker', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (72, N'Guillaume Musso', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (73, N'Mario Puzo', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (74, N'J.K.Rowling', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (75, N'Edmondo De Amicis', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (76, N'Cecelia Ahern', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (77, N'M. Heidegger - Hoelderlin', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (78, N'Ngô Gia Văn Phái', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (79, N'Phan Phương Thảo', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (80, N'Thomas L. Friedman', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (81, N'Phan Khoang', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (82, N'TS. Hoàng Quốc', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (83, N'Tư Mã Thiên', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (84, N'', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (85, N'Trường An', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (86, N'Charles B. Maybon', NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FullName], [Contact], [Address], [Bio]) VALUES (87, N'Tạ Chí Đại Trường', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Authors] OFF
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (25, N'00000000000000', N'CHUYÊN ĐỀ CARO - VUI NHƯ TẾT', N'Cố nhạc sĩ Văn Cao trong bài “Mùa xuân đầu tiên” có câu: "Mừa bình thường, mùa vui nay đã về”. Đã rất lâu kể từ mùa xuân đầu tiên ấy, vậy mà khi Tết đến, ta vẫn bồi hồi những cảm xúc vẹn nguyên, đẹp đẽ. Ta nôn nao ngóng Tết. Khi sắc hoa thắm ươm trên cành xuân, cũng là lúc sự phấn khởi đầy lên trong lòng người. Mùa đất trời thay đổi bình thường như lẽ tự nhiên, từ lúc nào trờ thành mùa vui của những tiếng lòng cồn cào được đoàn viên, sum họp. Ta rộn rã đón Tết. Khi quây quần bên những người ta yêu quý, mùa vui bỗng chốc hóa "bình thường”, giản đơn. Khi bản thân dù lớn thêm một tuổi vẫn thấy mình đi đủ xa để lại được về nhà. Ta hân hoan mơ Tết. Như con diều no gió dệt lên bầu trời những bức tranh đầy cảm hứng, ta cũng vẽ giấc mơ cho tương lai bằng sắc màu, phong vị mùa xuân. Cứ thế, mùa bỗng vui bởi những điều bình thường ý nghĩa và niềm vui còn mãi bởi cách ta trân quý, giữ gìn các giá trị cốt lõi trong cuộc sống bình thường. Đó cũng là tâm ý mà CARO đặt vào những trang sách này với hy vọng khi gấp lại, các bạn sẽ thấy cả một mùa vui tràn đầy và nguyên vị tuổi thơ.', N'vui-nhu-tet.278x404.w.b.jpg', 500, CAST(N'2017-02-25' AS Date), 11, 15, 10, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (26, N'00000000000000', N'TRIẾT LÝ CÁI ĐÌNH', N'Triết Lý Cái Đình đưa ra định nghĩa huyền sử như là nền minh triết được biểu lộ bằng những mảnh vụn của lịch sử. Đã gọi là mảnh vụn lịch sử thì nó không còn tuân theo niên kỷ và địa dư nhưng chỉ nêu lên như những bức hoạ kỷ niệm. Tuy nhiên ta vẫn còn thấy được bầu không khí của nó qua các lễ lạt, Tết nhất như Tết nguyên đán, Tết Đoan ngọ, Tết Trung thu …. Đó là bấy nhiêu ấn tích của một nền văn hoá dân tộc trong lúc sơ khai, mà nếu được tra cứu cặn kẽ thì chúng sẽ chiếu khá nhiều tia sáng vào nền văn hoá nước nhà, làm nổi bật lên những đức tính rất ơn ích…. Chúng tôi mượn cái Đình làm nơi quy tụ cho “bốn chặng huyền sử nước Nam”.', N'triet_ly_cai_dinh_final_sua-cs3-02.u547.d20170106.t132425.959568_1.jpg', 500, CAST(N'2017-02-25' AS Date), 12, 15, 11, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (27, N'00000000000000', N'Phong Tục Miền Nam', N'Phong tục là các thói quen từ lâu đời của đại đa số cá nhân trong một xã hội hay một quốc gia được đúc kết thành những mẫu mực lưu truyền từ đời này qua đời khác, có khả năng ràng buộc ảnh hưởng đến đời sống các nhân trong xã hội hay quốc gia đó, và cũng bị thay đổi theo nhiều thời gian. Phong tục Việt Nam được nhiều tác giả sách báo Pháp - Việt đề cập như G.Coulet, Maurice Durand, Phan Kế Bính, Nguyễn Đổng Chi...Nhưng chỉ chú trọng đến miền Trung, miền Bắc; miền Nam nếu có các tác giả chỉ phác họa đôi nét. Với sự đề cập thiếu sót về phong tục Miền Nam nhiều như vậy, tác giả Vương Bằng đã dày công nghiên cứu đề tài về phong tục miền Nam để mang đến cho chúng ta một cái nhìn tổng thể đến chi tiết về phong tục miền Nam. Cuốn sách được chia làm 3 phần: Phần I: Phần nhập đề Nội dung của phần này nêu lên tầm quan trọng của đề tài nghiên cứu, giải thích, định nghĩa về phong tục, tập quán. Bản tính của người Nam trong các giai đoạn lịch sử Phần II: Phong tục ngoài xã hội Đề cập về cơ cấu tổ chức xã hội dưới các thời kỳ lịch sử, về cảnh trang trí làng xã, lệ làng, tết Nguyên đán.... Phần III: Phong tục trong gia đình Phần này bao gồm các phong tục về gia tộc, nhà cửa, thực phẩm, phục sức, dinh dưỡng, bệnh hoạn, sinh kế, cưới hỏi, ma chay... Có thể khẳng định, cuốn sách là một công trình khá hoàn chỉnh về phong tục miền Nam.', N'phong-tuc-mien-nam.jpg', 500, CAST(N'2017-02-25' AS Date), 13, 15, 12, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (28, N'00000000000000', N'Đặc khảo về phong tục Tết Việt Nam và các lân bang', N'Đặc khảo về phong tục Tết Việt Nam và các lân bang - Lá thư tòa soạn - Vũ trụ âm dương - Nguyễn Đăng Thục - Nhìn qua các nghi lễ Triều đình Huế - Bửu Kế - Lễ tiến xuân, nghênh xuân dưới triều Nguyễn - Phan Khoang - Giai thoại về câu đối Tết - Tô Nam Nguyễn Đình Diệm - Cảm tưởng về Tết trong Nam - Vương Hồng Sển - Tục thưởng xuân của đồng bào Chàm Hồi Giáo - Dorohiem - Bài chòi ở Bình Định - Tạ Chí Đại Trường - Cổ nhân và các tục lệ về ngày xuân - Phạm Văn Sơn - Tết Lào ở.... xứ Lào - Phạm Trọng Nhân - Lễ Tết của người Quảng Đông tại Trung Hoa và Việt Nam - Tăng Hậu, Thôi Tiêu Nhiên, Lê Thọ Xuân - Lễ Tết Nguyên Đán Chôi Chnăm Thmây của đồng bào Miên - Châu Giang Tử - Mùa lễ Tết trên cao nguyên - Nguyễn Văn Nghiêm Xuân qua các nẻo đường Sơn Cước - Đỗ Văn Tú - Thưởng xuân trên cao nguyên với rượu cần của đồng bào Thượng - Nguyễn Trắc Dĩ - Bói đầu năm - Hồ Hữu Tường - Giai thoại về thơ khai bút - Bảng Sơn - Những lễ hội ở Hà Tiên trong ba tháng mùa xuân - Đông Hồ - Quan Thượng thưởng xuân - Phù Lang Trương Bá Phát - Tranh Tết - Nguyễn Bá Lăng - Lễ kị ông bà ngày Tết của người Chàm Bà La Môn ở Bình Tuy - Nguyễn Bạt Tụy', N'14793812_729551663866866_1270668729_n.jpg', 500, CAST(N'2017-02-25' AS Date), 11, 15, 13, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (29, N'00000000000000', N'THIẾU NIÊN THỜI ĐẠI MỚI - NHỮNG NGÀY TẾT TÂY', N'Bộ cẩm nang Thiếu Niên Thời Đại Mới là một bộ sách thú vị và bổ ích vì: - Thông tin các bạn được tiếp cận ngoài xã hội rất nhiều, và thường "rất thú vị" theo cảm nhận của các bạn, nhưng cũng thường không rõ nguồn gốc "và khó kiểm soát" (đối với Ba Mẹ) - Những lời dặn dò của Ba Mẹ và những thông tin "chính quy" thì lại hay được nhìn nhận là "ở bên kia chiến tuyến" khô cứng và ít vui, khó "thẩm thấu" hơn. Không trực tiếp cạnh tranh với những nguồn thông tin khác, cẩm nang Thiếu Niên Thời Đại Mới sẽ như một "bộ lọc", giúp các bạn "xác nhận" lại những thông tin đúng nhất, trang bị thêm những mẹo nho những kỹ năng cần thiết để tự tin vững bước trong thời đại mới. Được lấy ý tưởng và xây dựng như một Bách-khoa-toàn-thư-mini, bộ sách mang tính tổng hợp, đúc kết với tiêu chí thông tin ngắn gọn để dễ nhớ, hài hước để có thể vui đọc. Với các bạn nhỏ, bộ sách sẽ như một người bạn cùng trang lứa. Với Ba Mẹ, bộ sách sẽ là một tài liệu tham khảo, là "checklist" nhắc Ba Mẹ những thông tin và kỹ năng cần trang bị cho con.', N'thieunienthoi-sachkhaitam.jpg', 500, CAST(N'2017-02-25' AS Date), 14, 15, 14, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (30, N'00000000000000', N'MỨT VIỆT - VỊ NGỌT TẾT XƯA', N'Với người Việt Nam, ngày Tết là dịp đoàn viên, sum vầy, tưởng kính tổ tiên. Dù đi lập nghiệp nơi đâu thì dịp này ai ai cũng mong muốn trở về cùng gia đình. Trong câu chuyện đầu xuân, vị ngọt của mứt là điều không thể thiếu. Từ lâu, mứt không chỉ đại diện cho hương xuân ngọt ngào mà còn là đại diện cho một nền văn hoá với những phong tục tập quán nhiều ý nghĩa tâm linh linh thiêng. Mứt Việt - Vị Ngọt Tết Xưa với 21 món mứt là đại diện ngọt ngào hương xuân của những trái, củ, hạt rất đặc trưng của ba miền đất nước. Từ miếng mứt bí ngọt lịm giòn giòn, miếng mứt gừng cay nồng ấm áp, miếng mứt me có vị chua chua dịu dịu, mứt đậu ngự bùi bùi thơm thơm, mứt nghệ mật ong không chỉ làm đậm đà thêm câu chuyện đầu xuân mà còn là vị thuốc tốt cho dạ dày… Mỗi món mứt đi liền với một câu chuyện, một nét văn hoá mộc mạc mà chan chứa ân tình. Nằm nghe từng giọt mưa đêm  Mà thương ây khế ướt thêm nỗi buồn  Nằm nghe từng giọt mưa tuôn  Mà thương cây khế cũng buồn như ta nghe man mác một nỗi nhớ quê hương với hình ảnh chùm khế ngọt trong thơ Đỗ Trung Quân. Để khi cầm miếng mứt khế trên tay, ta cảm nhận được cả tâm hồn mình trong đó.', N'mutvietvi-sachkhaitam.jpg', 500, CAST(N'2017-02-25' AS Date), 15, 15, 15, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (31, N'00000000000000', N'THIẾU NIÊN THỜI ĐẠI MỚI - NHỮNG NGÀY TẾT TA', N'Bộ cẩm nang Thiếu Niên Thời Đại Mới là một bộ sách thú vị và bổ ích vì: - Thông tin các bạn được tiếp cận ngoài xã hội rất nhiều, và thường "rất thú vị" theo cảm nhận của các bạn, nhưng cũng thường không rõ nguồn gốc "và khó kiểm soát" (đối với Ba Mẹ) - Những lời dặn dò của Ba Mẹ và những thông tin "chính quy" thì lại hay được nhìn nhận là "ở bên kia chiến tuyến" khô cứng và ít vui, khó "thẩm thấu" hơn. Không trực tiếp cạnh tranh với những nguồn thông tin khác, cẩm nang Thiếu Niên Thời Đại Mới sẽ như một "bộ lọc", giúp các bạn "xác nhận" lại những thông tin đúng nhất, trang bị thêm những mẹo nho những kỹ năng cần thiết để tự tin vững bước trong thời đại mới. Được lấy ý tưởng và xây dựng như một Bách-khoa-toàn-thư-mini, bộ sách mang tính tổng hợp, đúc kết với tiêu chí thông tin ngắn gọn để dễ nhớ, hài hước để có thể vui đọc. Với các bạn nhỏ, bộ sách sẽ như một người bạn cùng trang lứa. Với Ba Mẹ, bộ sách sẽ là một tài liệu tham khảo, là "checklist" nhắc Ba Mẹ những thông tin và kỹ năng cần trang bị cho con.', N'thieunienthoi-sachkhaitam.jpg', 500, CAST(N'2017-02-25' AS Date), 14, 15, 14, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (32, N'00000000000000', N'Tết Sài Gòn', N'Tập bút ký và hình ảnh về Tết Sài Gòn của tác giả Tam Thái, thắm đậm tình xuân, là món quà xuân đặc sắc thích hợp cho mọi người. Với 300 bức ảnh xuân Sài Gòn xưa và nay, kèm theo những ghi chép sâu lắng của tác giả Tam Thái, tập sách gợi lại những khung trời kỷ niệm cho mọi người dân Sài Gòn, cũng như mang đến cho khách phương xa một hình ảnh đẹp về thành phố này. Sách dày 176 trang, được trình bày và in ấn nghệ thuật trên giấy couchée.', N'tet-sai-gon.jpg', 500, CAST(N'2017-02-25' AS Date), 16, 15, 16, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (33, N'00000000000000', N'5000 Hoành Phi Câu Đối Hán Nôm', N'Hoành phi – câu đối là chuẩn mực đánh giá một cách tao nhã gia phong của người Việt xưa. Hoành phi vốn là bức thư họa (tranh chữ), có khi còn gọi là Hoành, Biển, hoặc gọi là Biển ngạch, Bài biển... dùng để treo phía trên bình phong trong phòng sách, sách, hoặc ở nhà mát trong vườn hoa. Sau này, Hoành phi được dùng rộng rãi hơn. Câu đối, còn được gọi là Doanh thiếp, Doanh liên, Đối liên. Nhân dân ta rất thích chơi câu đối. Câu đối hòa hợp một cách sâu sắc nhất, hài hòa nhất giữa văn chương kinh viện với văn học bình dân. Cuốn 5000 Hoành Phi Câu Đối Hán Nôm giúp các bạn tìm được một cách nhanh chóng hoành phi, câu đối thông dụng. Mỗi câu, có in đầy đủ cả nguyên văn chữ Hán, chữ Nôm, phiên âm và dịch nghĩa. Cuốn sách được bố cục một cách khoa học, trình bày dễ hiểu: - Phần I: Hoành phi (350 bức viết bằng chữ Hán) - Phần II: Câu đối chữ Nôm (hơn 400 câu) - Phần III: Câu đối chữ Hán (hơn 4000 câu) Cuối sách có thêm phần Sách dẫn tra cứu tiện lợi, giúp bạn đọc tiết kiệm thời gian, nhất với việc tìm hoành phi, câu đối theo nhu cầu của mình.', N'5000-hoanh-phi-cau-doi-han-nom.jpg', 500, CAST(N'2017-02-25' AS Date), 17, 15, 17, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (34, N'00000000000000', N'Lễ Tết quê hương - Bộ 5 quyển', N'Bộ sách thiếu nhi về các ngày Tết truyền thống dân tộc "Lễ Tết quê hương" nói về sự tích, phong tục những ngày Tết Nguyên đán, Tết Đoan ngọ, Tết Trung thu... Bộ sách gồm năm cuốn Ông trẳng ông trăng, Mí đi xông đất, Bánh trắng bánh tròn, Con sâu kỳ lạ, Tạm biệt chép vàng, kể về những ngày Tết truyền thống dân tộc ta, gồm Tết Nguyên đán, Tết Trung thu, Tết Bánh trôi bánh chay, Tết Ông Táo, Tết Đoan Ngọ. Bộ ấn phẩm được nhà xuất bản Kim Đồng thực hiện và phát hành nhân dịp Tết Ất Mùi. Bộ sách viết cho thiếu nhi, cách kể gần gũi với cuộc sống ngày hôm nay. Các câu chuyện đều là những tập tục tốt đẹp, hiện hữu trong sinh hoạt, lời ăn, tiếng nói, cách hành xử trong các dịp Tết. Như chuyện cô bé Mí cùng bạn mèo Mun được ăn Tết cùng các trò chơi như rước đèn, khảo cây, đi xông đất, thả cá chép, nặn bánh trôi... Thông qua các nhân vật đáng yêu, hai tác giả Tuệ An và Lý Minh Phúc đã mang tới những câu chuyện vui, hình ảnh tươi tắn, sinh động. Ở cuối mỗi cuốn sách đều đăng lại trọn vẹn sự tích của các ngày lễ Tết truyền thống. - Y Nguyên Theo Vnexpress.net', N'le-tet-que-huong.jpg', 500, CAST(N'2017-02-25' AS Date), 18, 15, 14, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (35, N'00000000000000', N'Việt Nam Phong Tục', N'Từ Phong tục trong gia tộc, Phong tục xóm làng (hương đảng) đến các phong tục ngoài xã hội, Việt Nam Phong Tục của học giả Phan Kế Bính là một bộ biên khảo tương đối đầy đủ về các phong tục tập quán cũ của nước Việt. Là một nhà Nho uyên bác mang tư tưởng tân tiến, tác giả không chỉ mô tả từng tập tục, mà còn về gốc tích, nguyên ủy cái tục ấy, nhìn nhận, đánh giá để xem nó hay hay dở, từ đó "xét điều gì quá tệ mà bỏ bớt đi, rồi lâu lâu mới đem cái tục hay mà bổ hết cho cái tục dở. Còn tục gì hay mà là quốc túy của ta thì cứ giữ lấy". Đến nay, tập sách gần một trăm năm tuổi này vẫn là một trong những công trình khảo cứu có giá trị bậc nhất về các phong tục tập quán trên đất nước ta và nhiều vấn đề được Phan Kế Bính nhắc tới vẫn nóng hổi tính thời đại.', N'viet-nam-phong-tuc.jpg', 500, CAST(N'2017-02-25' AS Date), 19, 15, 13, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (36, N'00000000000000', N'Việt Nam Phong Tục Toàn Biên', N'“Việt Nam phong tục toàn biên” là công trình tổng hợp, sưu tầm và khảo cứu công phu của Giáo sư Vũ Ngọc Khánh về tập tục, lễ nghi, tâm linh, tín ngưỡng, nếp sống của con người, làng xóm,… những điểm mấu chốt trong các nét đẹp phong tục Việt Nam. Sách được chia làm hai phần chính: Phần I: Tổng quan phong tục Việt Nam Phần II: Diễn xướng dân gian Việt Nam Ở phần  “Tổng quan phong tục Việt Nam”, tác giả dành nhiều trang phân tích  phong tục với chủ đề con người và cuộc sống, từ chuyện ăn-mặc-ở, các lễ tục trong vòng đời như: quan hôn, tang tế, chuyện cưới hỏi, ma chay, tín ngưỡng thờ cúng, đời sống tâm linh…cho tới các bình diện: phép vua lệ làng, sưu thuế, hương ước, chuyện vua quan, đạo thầy trò, việc học tập thi cử,…Phần “Diễn xướng dân gian Việt Nam” lại giới thiệu rất nhiều các điệu hát, điệu hò, các trò diễn xướng, các lễ hội lớn của dân tộc. Cuốn sách đã phác vẽ lên một bức tranh về đời sống tinh thần và các phong tục Việt Nam vô cùng phong phú, mang đậm bản sắc dân tộc và không thể lẫn với bất kỳ  quốc gia nào khác./.', N'viet-nam-phong-tuc-toan-bien.jpg', 500, CAST(N'2017-02-25' AS Date), 20, 15, 18, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (49, N'00000000000000', N'CHÚC GIÁNG SINH AN LÀNH', N'Tuyển chọn các câu chuyện kể về những kỷ niệm Giáng sinh đã làm cho con người lớn lên với trái tim yêu thương. Có những ký ức hồi hộp thuở thiếu thời, được bà chỉ cho thấy ông già Noel ở đâu trong đời thường. Có những ký ức sáng bừng lên giữa một tuổi thơ bất hạnh, khi món quà bất ngờ từ đâu không biết đem đến chỉ một bản nhạc Giáng sinh vang lên một lần trong đời mà theo mãi đến lúc lớn khôn… Cuối sách là phần điểm 9 bộ phim Giáng sinh hay nhất mọi thời đại.   "Tối hôm đó, bà giúp tôi gói chiếc áo bằng giấy gói quà Giáng sinh, thắt nơ lên trên và viết bên ngoài: "Tặng Bobbie bé nhỏ. Từ: Ông già Noel". Rồi bà dặn tôi rằng ông già Noel luôn luôn giữ bí mật tất cả những việc mình làm. Sau khi gói quà xong, bà lái xe đưa tôi đến nhà Bobbie Decker và giải thích với tôi kể từ bây giờ và mãi về sau, tôi chính là phụ tá chính thức của ông già Noel. Bà dừng xe ngoài lề đường cạnh nhà Bobbie. Hai bà cháu di chuyển cẩn thận để không tạo ra tiếng động nào, sau đó núp vào bụi cây cạnh lối đi. Bất chợt bà huých khuỷu tay vào người tôi thì thầm: "Được rồi, ông già Noel, đi làm việc thôi".', N'nxbtre_full_05442016_084444.jpg', 500, CAST(N'2017-02-25' AS Date), 21, 16, 16, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (50, N'00000000000000', N'Tàu Tốc Hành Bắc Cực', N'Hai mươi lăm năm về trước, một con tàu bí ẩn xuất hiện trước cửa nhà một cậu bé, cuốn cậu vào một chuyến đi mà suốt đời cậu thể nào không quên. Còn câu chuyện về cuộc hành trình đêm Giáng sinh của cậu đã trở thành một tác phẩm kinh điển được hàng triệu độc giả trên toàn thế giới yêu thích. Từ khi xuất bản, Tàu Tốc hành Bắc Cực đã nhận được rất nhiều giải thưởng, trong đó có Huân chương Caldecott cao quý dành cho tác phẩm văn học thiếu nhi xuất sắc. Cuốn sách đã truyền cảm hứng cho rất nhiều chuyến tàu Giáng sinh dọc chiều dài nước Mỹ, cũng như vô số cuộc diễu hành tại trường tiểu học. Năm 2003, câu chuyện được chuyển thể thành phim.  Cuốn sách là món quà hoàn hảo cho tất thảy những ai, ở bất cứ bất độ tuổi nào, tin rằng mình cũng sẽ nghe được tiếng chuông du dương từ cỗ xe tuần lộc trong đêm Giáng sinh.', N'tautochanh-sachkhaitam.jpg', 500, CAST(N'2017-02-25' AS Date), 22, 16, 11, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (51, N'00000000000000', N'NHỮNG CÂU CHUYỆN GIÁNG SINH VUI NHỘN DÀNH CHO TRẺ EM', N'Giáng sinh luôn mở ra trước mắt trẻ em - và cả người lớn - một thế giới diệu kỳ với ông già Noel đôn hậu, những chú yêu tinh chăm chỉ sản xuất đồ chơi, cây thông lấp lánh sắc màu, các chú người tuyết, và trên hết là một tinh thần Giáng sinh nhiệm màu với tình người ấm áp và sẻ chia… Cuốn sách này mở ra cho các em một mùa Noel đáng yêu như thế, qua sáu câu chuyện Giáng sinh thú vị. Mỗi câu chuyện được minh họa bằng các tranh vẽ tuyệt đẹp để mỗi đứa trẻ ở xứ nhiệt đới cũng có thể cảm nhận một Noel rộn ràng như các xứ đang ngập trong tuyết trắng. Mỗi trang sách cũng được phân bố số chữ hợp lý để các em nhỏ có thể đọc dễ dàng, hoặc cả nhà cùng ngồi bên nhau để thư giãn trong các buổi tối mùa đông ấm áp.', N'nhungcauchuyen-sachkhaiatam.jpg', 500, CAST(N'2017-02-25' AS Date), 23, 16, 16, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (52, N'00000000000000', N'Chiếc Lọ Giáng Sinh Diệu Kỳ', N'Chiếc lọ Giáng Sinh diệu kỳ gửi đến người đọc một thông điệp giản dị: Sự cảm thông, chia sẻ của mỗi người có thể mang lại phúc lành, niềm tin, hy vọng cho biết bao người xung quanh. Qua câu chuyện của Jason F. Wright,  bạn sẽ biết thêm rằng Giáng Sinh không chỉ gắn liền với ông già Noel, những cây thông được trang hoàng lộng lẫy, những bản thánh ca, những điều nguyện ước, tâm trạng háo hức mong chờ được nhận quà của bầy trẻ nhỏ…, mà còn có một truyền thống rất ý nghĩa gắn liền với những chiếc lọ chứa đầy những đồng xu lẻ. Mỗi chiếc lọ như một lời chúc phúc cho người đón nhận nó. Để rồi chúng ta thêm hiểu ý nghĩa sâu sắc, cao đẹp của bài học Cho – Nhận. Để chúng ta thêm vững tin rằng dẫu có chia ly, nước mắt, cuộc sống này vẫn đẹp. Bạn có tin vào điều kỳ diệu đêm Giáng Sinh? Bạn có tin những điều ước, những món quà mà bạn hằng mong mỏi sẽ được gửi tới bạn theo một cách bí mật nào đó? Câu chuyện thật dễ thương và xúc động của Jason F. Wright cho chúng ta thấy tình yêu và sự diệu kỳ vẫn lan tỏa trong những đêm đông lạnh giá. Sự kỳ diệu không ở đâu xa xôi mà sự kỳ diệu chính ở sự quan tâm chân thành, lòng tốt của con người dành cho nhau trong cuộc đời này.', N'chiec-lo-giang-sinh-dieu-ky.jpg', 500, CAST(N'2017-02-25' AS Date), 24, 16, 19, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (53, N'00000000000000', N'NOEL MIỀN NHIỆT ĐỚI', N'Khi nghĩ đến Noel, bé sẽ tưởng tượng ra thật nhiều tuyết với rừng thông trắng xóa và ông già Noel cưỡi trên cỗ xe tuần lộc phải không nào? Nhưng đó là khung cảnh Giáng sinh thật đẹp nơi xứ lạnh. Còn những mẩu chuyện trong cuốn sách này sẽ đưa bé lên chuyến xe đến miền nhiệt đới, khám phá những điều đặc biệt của Noel xứ nóng. Đó là cây sồi ước một lần trong đời được treo đèn, kết hoa như cây thông. Là bố bạn ngựa thay đoàn tuần lộc kéo xe cho ông già Noel đến tối mịt chưa về làm bạn ấy lo lắng. Là bạn cừu dù cố gắng chăm ngoan cả năm để được kéo cỗ xe đi phát quà mà phút cuối vẫn vô tình mắc lỗi... Noel Miền Nhiệt Đới sẽ đưa bé băng qua khu rừng đầy những điều tuyệt diệu để nhận ra rằng trên thế giới có rất nhiều điều độc đáo và khác biệt đáng khám phá.', N'noelmiennhiet-sachkhaitam.jpg', 500, CAST(N'2017-02-25' AS Date), 11, 16, 14, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (54, N'00000000000000', N'GIÁNG SINH YÊU THƯƠNG', N'Dù là một tác phẩm ra đời cách nay hơn một thế kỷ, song những triết lý sống được đại văn hào người Anh Charles Dickens gửi gắm qua tác phẩm Giáng Sinh Yêu Thương (A Christmas Carol) vẫn vẹn nguyên giá trị cho đến thời đại ngày nay – khi những giá trị vật chất lấn át những giá trị tinh thần cao đẹp. Câu chuyện khắc họa sống động nhân vật Ebenezer Scrooge keo kiệt, ưa gắt gỏng; tuy nhiên đã có những chuyển biến lớn về tư tưởng, tình cảm và nhận thức về giá trị nhân bản sau cuộc ghé thăm của những “vị khách siêu nhiên” là Hồn ma vất vưởng Jacob Marley, Hồn ma Giáng sinh Quá khứ, Hiện tại và Tương lai.  Giáng Sinh Yêu Thương là một câu chuyện kể, một “khúc ca” cất lên từ trải nghiệm cuộc đời của tác giả, từ những quan sát trong cuộc sống, từ những ước vọng đẹp cho tương lai. Cũng chính vì thế, A Christmas Carol đã được xuất bản 2583 lần và dịch ra 50 ngôn ngữ. Không chỉ vậy, đây cũng là tác phẩm được chuyển thể rất nhiều: với kịch là 23 vở, điện ảnh: 51 phim. Gần đây nhất, A Chirstmas Carol với phiên bản phim hoạt hình 3D vào năm 2009 đã được khán giả Việt Nam vô cùng yêu mến. Từng tạo nên làn sóng ảnh hưởng lớn trong việc làm sống lại những truyền thống Giáng sinh xưa của Anh quốc, tác phẩm vừa mang đến cho độc giả những hình ảnh tươi sáng, vui vẻ, ấm áp và đầy sức sống, tuy nhiên cũng gợi nhắc lại hình ảnh không thể nào quên của một thời kỳ tăm tối, vô cảm, con người ngoi ngóp vươn lên trong nỗi tuyệt vọng và buồn đau – một bản cáo trạng đối với chủ nghĩa tư bản công nghiệp thế kỷ 19. Bản thân Ebenezer Scrooge là hiện thân của mùa đông khắc nghiệt. Song mùa đông nào rồi cũng phải qua đi để mùa xuân vui tươi rộn ràng lan tràn khắp muôn nơi. Vì vậy trái tim của Scrooge dù thật băng giá, hà khắc nhưng trong thâm sâu vẫn le lói ngọn lửa thiện ý đầy ấm áp, mỗi lúc càng bùng lên mạnh mẽ, làm tan chảy những lớp ký ức chai lạnh khi những Hồn ma giúp ông lần giở từng trang đời của mình. Giáng Sinh Yêu Thươngđã vượt khỏi khuôn khổ là một quyển sách dành riêng cho mùa lễ trọng hàng năm, nó là lời nhắc nhở, hướng con người quay về những giá trị tinh thần cao đẹp, sống đúng theo quy luật cuộc đời, quy luật của tình người. Với mong muốn gửi đến quý độc giả một món quà tinh thần vô cùng giá trị như thế, First News hân hạnh giới thiệu tác phẩm Giáng Sinh Yêu Thương được trình bày dưới dạng song ngữ. Dịch thuật một tác phẩm văn học cổ điển vốn đã khó, song lại càng khó hơn với hình thức song ngữ. Tuy nhiên, chúng tôi vẫn quyết định thực hiện ý tưởng này như là một món quà tri ân đến quý độc giả; vừa có cơ hội thưởng lãm bút pháp tài hoa, lối “nói ít nhưng khiến người đọc phải suy nghiệm nhiều” của người xưa, vừa thấy mối giao hòa giữa văn phong, ngôn ngữ tiếng Anh và tiếng Việt, để rồi nhận ra tất cả chỉ là ngôn ngữ của trái tim, cũng giống như Giáng sinh giờ đây thuộc về mọi người, không còn là dịp dành riêng cho bất kỳ ai theo như lời của Fred, người cháu trai duy nhất của Scrooge bày tỏ: “Giáng sinh là thời gian để ngừng lại, để tâm hồn chìm lắng trong bình yên, thư thả… là một thời khắc tốt lành, không chỉ vì tên gọi và câu chuyện thiêng liêng của nó. Đó là lúc mở lòng ra mà vui vẻ, mà từ tâm, mà tử tế và bao dung; là dịp duy nhất trong suốt cả năm dài để đàn ông và đàn bà mở rộng trái tim đóng kín của mình, xem những người thấp kém như anh em với mình chứ không phải là một sinh vật khác loài.”.', N'giangsinhyeu-sachkhaitam.jpg', 500, CAST(N'2017-02-25' AS Date), 25, 16, 19, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (55, N'00000000000000', N'Giáng Sinh Diệu Kỳ', N'"Giáng sinh là dịp để tình yêu, sự vị tha và những điều tốt đẹp trong thế giới diệu kỳ này lên ngôi. Dù tôn giáo của bạn là gì, dù bạn đến từ đâu, tất cả chúng ta đều có thể tận dụng cơ hội này để mang một chút yêu thương đến với cuộc sống vốn dĩ  luôn ngập tràn khó khăn và thử thách…” Những lời mở đầu của tác giả Lizzie Marie Cullen trong cuốn sách Giáng sinh diệu kỳ (Magical Chirstmas) đã thể hiện thông điệp mà cuốn sách muốn truyền tải. Bước vào thế giới ấy, ta choáng ngợp với những màu sắc trong trí óc chợt hiện ra và háo hức muốn thể hiện nó. Thế giới ta vẫn quen thuộc nay được thay thế bởi những món quà thơ ấu, những sinh vật huyền thoại trong giấc mơ của trẻ nhỏ, những cây thông và ông già Noel trong tiết trời gió tuyết, những góc phố, kỉ niệm cũng trở nên đặc biệt hơn... tất cả gói gọn trong cuốn sách 96 trang Giáng sinh diệu kỳ. Những sắc màu trong tâm trí khi được thể hiện ra trong cuốn sách cũng mang đi theo những căng thẳng, mệt mỏi, giúp chúng ta cảm nhận tình yêu thương từ những trang giấy tô cùng bạn bè và người thân. Trong khoảnh khắc đó ta chợt nhận ra rằng đôi mắt chúng ta biết cảm thông hơn và tâm hồn ta phong phú hơn. Cuốn sách là món quà hoàn hảo, là nơi để ta có những giây phút thoải mái trong ngày lễ Giáng sinh với những người yêu thương. Ngoài phiên bản sách còn có bản postcard rất đáng yêu để các bạn tự tô màu và dành tặng người thân thay cho những tấm thiệp như thường lệ. Hãy cùng đón chờ Giáng sinh diệu kỳ nhé!', N'giangsinhdieu-sachkhaitam.jpg', 500, CAST(N'2017-02-25' AS Date), 26, 16, 20, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (56, N'00000000000000', N'Giáng Sinh Nhiệm Mầu', N'Noel - Giáng sinh. Chỉ là một đêm lạnh. Thế nhưng, ... Gần như tất cả trẻ thơ đều ngong ngóng đợi. Đợi ông già Noel. Đợi một niềm vui bất ngờ. Đợi một điều kỳ diệu. Giáng sinh là một ngày ngày lành để chúng ta học cách vượt qua khó khăn, trân trọng từng niềm vui và trao tặng niềm vui cho một ai đó đang cần sự sẻ chia. Trân trọng giới thiệu đến bạn đọc quyển "Giáng sinh nhiệm mầu" với hy vọng được góp thêm tinh thần nồng ấm cho đêm giáng sinh của bạn và người thân. "Giáng sinh nhiệm mầu" - món quà ý nghĩa dành cho những người thân yêu của bạn trong đêm giáng sinh!', N'giang-sinh-nhiem-mau.jpg', 500, CAST(N'2017-02-25' AS Date), 11, 16, 16, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (57, N'00000000000000', N'Bài Ca Mừng Giáng Sinh', N'Giáng sinh đã đến, khơi đượm thêm ngọn lửa trong lò sưởi mỗi nhà và sưởi ấm thêm tim mỗi người. Trừ lão Scrooge keo kiệt, xấu tính. Tâm hồn lạnh lẽo hơn cả băng giá tháng Mười hai của lão chỉ chực chờ cơ hội để tống cổ lễ Giáng sinh ra khỏi cửa.   Cho tới khi những Hồn ma viếng thăm lão…   Một câu chuyện ma hẳn sẽ thích hợp hơn để kể vào dịp Halloween. Nhưng Bài ca mừng Giáng sinh là một câu chuyện ma đặc biệt, và chẳng có dịp nào phù hợp hơn Giáng sinh để kể nó. Một câu chuyện ma của Ngài Dickens!', N'bai-ca-mung-giang-sinh.jpg', 500, CAST(N'2017-02-25' AS Date), 25, 16, 13, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (58, N'00000000000000', N'Chiếc Hộp Giáng Sinh', N'Giáng sinh đã về trên thành phố. Những cơn gió tháng Mười hai buốt giá, tuyết rơi dày và ngọn lửa trong lò sưởi đã rực lên ấm nóng. Trong căn áp mái một ngôi biệt thự trên khu Đại Lộ thành phố Salk Lake, những bức thư ngả vàng nằm đó mấy chục năm, chờ được đọc lên lần nữa. Những lá thư bí ẩn khiến người ta rơi lệ, bởi nỗi đau song hành cùng tình yêu tha thiết của một người mẹ mất con. Và nhờ đó, ý nghĩa của Chiếc hộp Giáng sinh đựng những bức thư, của ngày Giáng sinh thiêng liêng đã hé lộ. Một cuốn sách như lời ngợi ca tình yêu bất tử mà Thượng đế dành cho loài người, khi Người gửi con trai mình ra đi, dẫu biết con đường nào chờ đợi phía trước… Kể từ lần xuất bản đầu tiên, hơn bảy triệu người đã bị lay động bởi Chiếc hộp Giáng sinh, cuốn sách kinh điển về ngày Giáng sinh của thời đại chúng ta, thường được xếp cạnh Bài Ca Mừng Giáng Sinh của Charles Dicken. Richard Paul Evans đã viết Chiếc Hộp Giáng Sinh như một sự bày tỏ tình yêu ông dành cho hai con gái nhỏ của mình, Jenna và Allyson, nhưng câu chuyện rồi đã trở thành một thông điệp đầy sức mạnh, vượt qua nhiều biên giới, không chỉ dành riêng ngày Giáng sinh, gieo những nốt nhạc cảm động trong tâm hồn người nhận. ------------------ “Cuốn sách là về những sức mạnh bao bọc chúng ta, như gió, vô hình nhưng mãnh liệt khiến ta bàng hoàng chấn động. Và câu chuyện Giáng sinh nhỏ mà tôi viết ra là kết quả của những sức mạnh đó. Một vài người có thể coi đó là sự linh thiêng, một số khác gọi là sự trùng hợp. Còn có những người mà với họ, đó chính là phép màu.” - Richard Evans', N'chiec-hop-giang-sinh.jpg', 500, CAST(N'2017-02-25' AS Date), 27, 16, 17, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (59, N'00000000000000', N'Đêm Giáng Sinh Kỳ Diệu', N'Bạn có tin vào điều kỳ diệu của đêm Giáng Sinh? Bạn có tin những món quà mong ước sẽ được gửi tới mình bằng một cách thức bí mật nào đó, hay những điều ước sẽ trở thành hiện thực vào đêm Thiên Chúa giáng thế làm người này? Điều thứ nhất, đừng bao giờ khép cửa nhà mình vào đêm Giáng Sinh bạn nhé! Nếu bạn bè không đến kịp để chia vui, thì ít nhất bạn cũng sẽ nhận được những giai điệu an hòa, tiếng chuông nhà thờ mơ hồ giữa mộng và thật. Giữa không gian se sắt lạnh, sự bình yên của niềm tin và chờ đợi sẽ theo gió luồn qua khe cửa nhà bạn, làm ấm lên không gian, và cũng làm bạn ấm lòng hơn. Hãy thắp lên một ngọn nến bên ô cửa sổ. Ngọn lửa ấm áp sẽ làm lòng bạn ấm lại. Và những ký ức sẽ tràn về, nhảy múa cùng ánh nến lung linh. Sự mỏng manh của ngọn nến sẽ buộc bạn phải suy tư, và sự dịu dàng của nó sẽ làm bạn thêm sáng suốt. Ngọn nến ấy sẽ làm cho mọi người nhìn ra bạn, nhận ra tín hiệu chào đón và tình yêu lan tỏa từ ngôi nhà của bạn. Và như thế, những người đơn côi, không bạn bè, không người thân sẽ không còn cảm thấy lẻ loi nữa. Dù chẳng có thật nhiều tiền, bạn vẫn phải chuẩn bị quà cho tất cả mọi người! Hãy ôm hôn những em bé đi ngang qua nha. Hãy thăm hỏi những người mà bạn gặp, và hãy tự tặng cho mình một buổi tối yên lành, không lo lắng, âu sầu, không ganh ghét, đua chen. Những món quà ấy mới chính là ý nghĩa thật sự của đêm Giáng sinh. Và hãy mơ mộng bạn ạ! Vì mơ mộng chính là biểu hiện của việc bạn đang hé mở lòng mình và chờ đợi những điều diệu kỳ. Các thiên thần đã sửa soạn đôi cánh của mình chờ khoảnh khắc xuống trần gian. Họ sẽ gõ cửa và đặt chiếc hôn bình an lên trán bạn đấy. Đó là lý do mà giấc mơ nào trong đêm Giáng Sinh cũng lung linh, lung linh... Còn bây giờ, hãy để lòng mình lắng xuống, bạn nhé! Bạn chỉ có thể nghe và thấy những điều kỳ diệu khi không còn những hỉ, nộ, ái, ố của đời thường. Hãy cùng đọc và chia sẻ những điều diệu kỳ mà đêm Giáng sinh an lành mang đến cho bạn. Chúc bạn và gia đình một mùa Giáng sinh an lành và hạnh phúc!', N'dem-giang-sinh-ky-dieu.jpg', 500, CAST(N'2017-02-25' AS Date), 11, 16, 19, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (60, N'00000000000000', N'Ca Khúc Giáng Sinh', N'Học tiếng Anh qua các tác phẩm văn học kinh điển của thế giới Sách + 1CD', N'ca-khuc-giang-sinh.jpg', 500, CAST(N'2017-02-25' AS Date), 25, 16, 21, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (73, N'00000000000000', N'Thực Dưỡng Macrobiotics Hồi Xuân và Sống Thọ', N'Thuật trường sinh, cải lão hoàn đồng là thực tiễn, nghĩa là dựa vào kinh nghiệm, đặc biệt kinh nghiệm của chính bạn hoặc kinh nghiệm mà tôi kể lại. Chúng ta có đủ khả năng điều chế từ trong cơ thể những gì cần thiết cho sức khỏe. Nếu cứ dựa vào những chất đặc chế hoặc thuốc men, khả năng này sẽ bị cùn nhụt, suy yếu vì không được dùng đến. Do đó, lại càng phải thường xuyên tiêu thụ các chất ngoại tạo vì cơ thể đã bỏ lơ chức năng tự nhiên của mình. Cơ thể bỏ lơ nội lực vì đã trở nên quen, thích những chất nhân tạo ngoại lai. Do đó, chúng ta đâm ra lệ thuộc những nguồn cung cấp (viện trợ) cho cơ thể những gì mà chúng ta bị bắt buộc tin là cần thiết. Thay vì lệ thuộc, chúng ta phải phục hồi khả năng sáng tạo từ . trong chính bản thân, vì cơ thể con người là một môi trường chuyển hóa. Không nên vì mê muội mà biến môi trường này thành một vũng lầy ô nhiễm.', N'thuc-dung-macrobiotics-hoi-xuan-va-song-.jpg', 500, CAST(N'2017-02-25' AS Date), 28, 17, 22, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (74, N'00000000000000', N'Kinh nghiệm chữa bệnh ung thư của các bác sĩ theo phương pháp Thực Dưỡng', N'Đến nay, đường lối chăm sóc sức khỏe toàn cầu đã chuyển hướng. Những cơ quan y tế hàng đầu trên thế giới kể cả Tổ Chức Y Tế Thế Giới W.H.O của Liên Hiệp Quốc đã phát hành những văn bản chính thức hướng dẫn chấn chỉnh cách ăn ở tương tự PHƯƠNG PHÁP THỰC DƯỠNG OHSAWA -MACROBIOTICS để phòng ngừa và chữa trị bệnh tật. Đồng thời, công chúng biết tự lo cho sức khỏe mình hơn, thay vì phó mặc hoàn toàn vào tay thầy thuốc. Ăn uống lành sạch, tập luyện thân thể, lắng yên tâm trí đã trở thành một phần nổi bật trong xu hướng này. Hơn nữa, càng ngày càng có nhiều y bác sĩ và chuyên viên y tế nghiên cứu thực hành PHƯƠNG PHÁP THỰC DƯỠNG và đưa ra nhữngđề nghị hữu ích. Trong số đó có những ngưòi đã áp dụng phương pháp này chữa bệnh ung thư cho chính mình hoặc cho người khác với kết quả khả quan. Những trang sách sau đây sẽ trình bày lời tâm tình và kinh nghiệm của một số y bác sĩ tiêu biểu.', N'kinh-nghiem-chua-benh-ung-thu-cua-cac-ba.jpg', 500, CAST(N'2017-02-25' AS Date), 29, 17, 23, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (75, N'00000000000000', N'Vui Khỏe Đường Tu', N'Chuyện đáng kể là khi Hòa Thượng Thích Nhất Hạnh về nước thuyết giảng tại Tu viện Bát Nhã, Bảo Lộc, đến giờ thọ thực, bữa ăn được bày ra với hai loại cơm gạo trắng và cơm gạo lứt. Phần đông tín đồ trong nước chọn cơm gạo trắng, trong khi các đệ tử phương Tây theo Hòa Thượng về Việt Nam đều ăn cơm gạo lứt. Chính Hòa Thượng cũng khuyến khích các tín đồ ăn uống thiên nhiên, đơn giản và nhai thật kỹ như một cách hành thiền. Theo Thiền tông, con người sở dĩ khổ đau phiền lụy là do “tâm vọng tưởng”, tham lam, giả dối; do đó muốn được sướng vui thanh thản thì dứt bỏ những buộc ràng hư huyễn, trở lại “tâm bình thường”, sống thật lòng an nhiên tự tại. Cách sống đó thể hiện rõ ở nhà thơ Bùi Giáng, bạn thân của Thầy Anh Minh Ngô Thành Nhân. Bởi vậy, có người gọi nhà thơ là “Thiền Sư”. Ông ăn gạo lứt muối mè từ thời còn dạy học ở Viện Đại Học Vạn Hanh Sài gòn trước 1975 và có bài thơ tự sự: Kể từ gạo lứt muối mè Dưa chua cải muối đi về kỷ nguyên Mở đầu cách mệnh cường kiên Ohsawa chữa bệnh điên thật tài Tôi từ tiếp nhận lai rai Thuần thanh cảnh giới quai nhai dị thường Biến hình biến thể phi dương Xuân hương xuân sắc xuân hường bốc cao A đầu tỳ tử hoàng mao Du dương tài điệu thơ dào dạt dâng Đôi lời ngỏ với lý lân Mừng Xuân muôn dặm tử phần tái sinh. Giáo sư Ohsawa cho biết phương pháp Thực Dưỡng chẳng qua là hình thức phục hồi giá trị các thuật dưỡng sinh cổ truyền và cách ăn uống của phương pháp này vốn đã có trong các tôn giáo nhưng bị người thời nay quên lãng. Ông viết: “Đây là cách thực hiện quan niệm biện chứng về vũ trụ và nhân sinh đã có hàng ngàn năm nay và chỉ rõ con đường hanh phúc do nơi sức khoẻ. Con đường này luôn mở rộng cho mọi người, bất kể giàu hay nghèo, khôn hay ngu, một con đường rất đơn giản mà bất kỳ ai thật lòng muốn giải thoát tất cả các nỗi khổ đau thể xác lẫn tinh thần đều có thể áp dụng trong cuộc sống hàng ngày”.  (trích “Ngân Trong Thinh Lặng'' do Anh Minh Ngô Thành Nhân & Ngô Anh Tuyết dịch).', N'vui-khoe-duong-tu.jpg', 500, CAST(N'2017-02-25' AS Date), 29, 17, 22, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (76, N'00000000000000', N'Ăn Gạo Lứt Muối Mè', N'“Bệnh tật không do vi trùng gây nến, mà do cơ thể đã mỏi mệt, yếu kém, năng lượng (khí) mất quân bình vì phẩm chất máu (huyết) suy thoái do ăn uống bất thường, do đó vi trùng mới xâm nhập được”. Trích Luận án Tiến sĩ y khoa “TRỊ LIỆU BẰNG DINH DƯỠNG” của Bác sĩ Nguyễn Văn Thụy (1972). Từ nhiều năm nay trên thế giới, PHƯƠNG PHÁP THỰC DƯỠNG - MACROBIOTICS đã được công nhận là một nhánh không thể thiếu của y học chính thống hiện đại và được nhiều y bác sĩ thực hành sau những công trình nghiên cứu nghiêm túc của các nhà khoa học về mối liên hệ mật thiết giữa ăn uống và sức khỏe hoặc bệnh tật của con người, cũng như nhờ những kết quả cụ thể mà phương pháp này thu được trong lĩnh vực dưỡng sinh và trị liệu. Riêng tôi từ thời còn đi học đã bắt đầu biết đến PHƯƠNG PHÁP THỰC DƯỠNG qua anh tôi, một bác sĩ, nhất là khi đọc quyển “ĂN CƠM GẠO LỨT” của ông Ngô Thành Nhân, người khởi phát phong trào Thực Dưỡng ở Việt Nam, và sau đó là quyển “PHƯƠNG PHÁP TÂN DƯỠNG SINH” của Giáo sư Ohsawa, người chủ xướng phương pháp (Ngô Thành Nhân và Nguyễn Hữu Tấn dịch, Anh Minh xuất bản năm 1965 tại Huế). Lúc đầu tôi nghi ngờ giá trị của phương pháp này vì thấy cách ăn uống đơn giản quá, tầm thường quá trái với những gì tôi đang học tại trường và qua sách vở của Tây Y. Làm sao chỉ với gạo lứt muối mè và đôi chút rau củ lại có thể nuôi dưỡng cơ thể và trị được bệnh? Trong khi y học hiện đại, với cả một hệ thống gồm nhiều ngành chuyên môn được trang bị nhiều dụng cụ càng ngày càng tinh vi, và có vô vàn loại thuốc đặc trị được sản xuất trong các phòng bào chế tân tiến, thì chưa ngăn chận được cơn dịch bệnh càng ngày càng phát triển về lượng cũng như về phẩm? Dù sao, phương pháp này cũng có đôi điều khiến tôi suy nghĩ khi liên tưởng đến cách ăn uống truyền thống mà người dân quê tôi còn giữ, tuy đơn sơ, đạm bạc nhưng từng giúp các thế hệ tiền nhân sống lâu ít bệnh, cũng như giúp dân tộc ta trường tồn và phát triển cho đến ngày nay. Để rõ trắng đen, với sự gợi ý của anh tôi vả với bản lĩnh của một người theo khoa học, tôi quyết định thử nghiệm trên bản thân tôi. Quả thật, tôi thấy người khỏe ra, những yếu đau lặt vặt không còn. Nhưng vì bị ám ảnh bởi nỗi lo “thiếu chất”, tôi chỉ thực hiện trong thời gian ngắn rồi ngưng, về sau, khi được xem luận án y khoa “TRỊ LIỆU BẰNG DINH DƯỠNG” của Bác sĩ Nguyễn Văn Thụy với phần thực chứng lâm sàng chữa lành một bệnh nhân ung thư máu bằng GẠO LỨT MUỐI MÈ, và được tiếp xúc thường xuyên với Ông bà Ngô Thành Nhân, cũng như gặp gỡ nhiều người khỏi nhiều loại bệnh khác nhau nhờ ăn uốnq như thế, tôi mới thật sự tin vào hiệu lực của PHƯƠNG PHÁP THỰC DƯỠNG. Từ đó, tôi dốc tâm nghiên cứu phương pháp này và càng ngày càng khám phá ru nhiều điều thú vị làm phong phú thêm cuộc sông và công việc của tôi. Ở đây, điều đáng ghi nhớ nhất vẫn là tấm lòng của Ông bà Ngô Thành Nhân và các cộng sự viên bất chấp một phương pháp dưỡng sinh và trị liệu thiết thực. Tồi cũng cảm anh Ngô Ánh Tuyết, học trò và là thư ký của ông Ngô Thành Nhân, đã cho tôi xem bản thảo của tập sách này. Đây chính là quyển “ĂN CƠM GẠO LỨT” (hiện là lần tái bản thứ mười sáu, có hiệu đính và bổ sung) đã đưa tôi vào con đường Thực Dưỡng. Tôi hân hạnh được trân trọng giới thiệu tập sách - một cuốn cẩm nang đúc kết nhiều kinh nghiệm quý báu - với tất cả những ai đang bênh hoạn thống khổ muốn có một phương tiện điều dưỡng trị liệu đơn giản, ít tốn kém nhưng hiệu quả cao. Đồng thời, tôi nghĩ rằng các nhà làm công tác y tế, xã hội thường ưu tư trước số phận của đồng loại cũng có thể rút ra từ đây những điều bổ ích cho công việc. Bác sĩ NGUYỄN VĂN KHUÊ Nguyên Trưởng Trung tâm Y tế - Giáo dục Thành phố Hồ Chí Minh.', N'an-gao-lut-muoi-me.jpg', 500, CAST(N'2017-02-25' AS Date), 30, 17, 13, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (77, N'00000000000000', N'Xem Tướng Biết Sức Khỏe Theo Phương Pháp Thực Dưỡng Oshawa', N'Tướng số và thể chất bẩm sinh không phải la “định mệnh” hoặc “định nghiệp” vì chúng ta có thể tự mình cải đổi bản thân qua cách ăn uống sinh hoạt và xử sự hằng ngày. Vả lại, thực tế cho thấy có tướng tốt và sức khỏe sung mãn nhiều khi là vận “xui” vì ỷ lại mà ăn ở buông tuồng để phải mắc tai ương, bệnh hoạn. Trong khi tướng xấu và thể chất yếu kém có thể là “duyên may”; bởi biết dự phòng cố gắng ăn ở cẩn thận mà sống được an lành thanh thản. Giáo sư Oshawa cho biết: “Tính nết hoặc hành vi xấu chỉ là hiện tượng bên ngoài; nếu chỉ dựa vào đó để nhận xét thì chưa thấy hết chân tướng con người. Tâm tính xấu xa đáng ghét chẳng phải là cố tật nguyên thủy của con người, mà chỉ là kết quả của cách ăn ở sai lầm. Bạn phải chịu trách nhiệm về hình dạng của mũi, má, mắt và da dả của chính mình: nói cách khác, chính bạn là người sáng tạo tướng hình của bạn. Do đó, dù mọi cái có thể bị biến dạng, méo mó, hư hỏng hoặc yếu kém do thiếu hiểu biết, bạn vẫn có thể sửa đổi, cải thiện tất cả nhờ nắm vững nguyên lý Âm Dương và áp dụng đúng đắn Trất Tự Vũ Trụ (luật thiên nhiên, Chánh Pháp, Thiên Đạo) trong đời sống hằng ngày nhất là trong dinh dưỡng.', N'xem-tuong-biet-suc-khoe-theo-phuong-phap.jpg', 500, CAST(N'2017-02-25' AS Date), 29, 17, 21, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (78, N'00000000000000', N'Âm Dương & Nguyên Lý Vô Song Của Triết Lý và Khoa Học Phương Đông', N'Ở phương Đông, khoa học bị triết lý chi phối hoàn toàn từ căn nguyên. Bậc Thánh nhân, Chân nhân là người đã đạt tới sự hiểu biết trọn toàn về Nguyên Lý Vô Song (tức “Luật Vũ Trụ”, “Thiên Đạo”, “Mệnh Trời”, “Chánh Pháp”), cái nguyên lý chí phối luật nhân quả của mọi hiện tượng trong vũ trụ. Khoa học cổ truyền phương Đông giải thích hệ thống vũ trụ và tất cả mọi hiện tượng phát sinh trong hệ thống này theo luật hoặc lý Âm Dương. Lý Âm Dương là triết lý thực tiễn nhất của phương Đông. Triết lý này bao hàm mọi ngành khoa học. Tôi rằng Lý Âm Dương giúp người phương Tây hiểu rõ hơn về Phật giáo cũng như tất cả các giáo lý uyên thâm của Á Đông, trong lý thuyết đó có tất cả các ngành khoa học thực nghiệm về đời sống, chẳng hạn như y học, sinh vật học, kinh tế học, xã hội học được tổng hợp một cách kỳ diệu và hài hòa.', N'amduongva.jpg', 500, CAST(N'2017-02-25' AS Date), 28, 17, 24, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (79, N'00000000000000', N'Chơi Giữa Vô Thường', N'CHƠI GIỮA  VÔ THƯỜNG – Cuộc đời George Ohsawa “Tinh thần của chúng ta có thể di chuyển tự do thỏa thích trong không gian vô biên và thời gian vô hạn, mặc dù thân xác bị ràng buộc bởi xiềng xích chặt chẽ của thời gian và bị vây hãm trong khung lồng cố định của không gian. Tinh thần là toàn thể, còn xác thân chỉ là mộ bộ phận cực nhỏ rung động hòa nhịp với Trời Đất Thiên Nhiên. Cơ thể con người giống như một máy vô tuyến truyền hình có thể thu nhận được mọi làn sóng điện trong toàn vũ trụ. Điều kỳ diệu hơn, cơ thể còn là một đài phát sóng. Chúng ta có thể thu và phát mọi thông tin từ hoặc đến bất cứ nơi đâu, vào bất cứ lúc nào nếu không bị vật chất xác thân gây trở ngại. Khi chúng ta hoàn toàn định tâm hoặc tâm linh trở nên thuần khiết, nghĩa là mọi giới hạn vướng bận tinh thần được khai phóng thì sẽ có được năng lực phi thường vi diệu. Nếu hòa mình vào cõi tâm linh để cảm thông rộng khắp và có thể sử dụng xác thân như đài dẫn sóng, đồng thời sống được an lành hạnh phúc thì cuộc đời thú vị biết bao.” George Ohsawa', N'choi-giua-vo-thuong.jpg', 500, CAST(N'2017-02-25' AS Date), 28, 17, 22, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (80, N'00000000000000', N'Nghệ Thuật Nấu Ăn Vui Khỏe Theo Phương Pháp Thực Dưỡng', N'Tại nước ta, trong những năm gần đây, càng ngày càng có nhiều người - cá trong giới y học, báo, đài - nói đến PHƯƠNG PHÁP THỰC DƯỠNG do Giáo sư OHSAWA đề xướng. Phương pháp nầy - ăn gạo lức muối mè với thực phẩm thiên nhiên và sinh hoạt đúng đắn - đã đem lại những kết quả đáng ngạc nhiên trong việc giữ gìn sức khỏe và trị bệnh. Hiện nay, Phương Pháp Thực Dưỡng MACROBIOTICS đã phổ biến toàn cầu và được Tổ Chức Y Tế Thế Giới WHO nhìn nhận. Theo Phương Pháp Thực Dưỡng, không những phải biết ăn uống thế nào cho đúng đắn hợp lý, mà thái độ tinh thần của người làm bếp cũng kỹ thuật nấu ăn cũng rất quan trọng. Trên quan điểm đó, để đáp ứng yêu cầu của những người áp dụng Thực  Dưỡng, Nhà Ohsawa tham khảo hiểu biết của nhiều người, đặc biệt là của Bà Diệu Hạnh với kinh nghiệm hơn 40 năm cùng chồng là Ông Ngô Thành Nhân nghiên cứu và thực hành, để soạn ra tập sách nầy. Tôi từng có dịp thưởng thức những bữa ăn do Bà Diệu Hạnh và Nhà Ohsawa sửa soạn; phải nói  rằng đó là những bừa ăn hấp dẫn, ngon lành và sau khi ăn cảm thấy người khỏe khoắn. Ngoài phần lý thuyết về NGHỆ THUẬT NẤU ĂN dựa trên phép biện chứng Âm Dương và nguyên lý Vũ Trụ Thống Nhất của Á Đông, các món ăn thức uống trong sách dù hình thức đơn giản hay phức tạp đều dễ thực hiên với nguyên liệu và phương tiện dễ tìm. Theo tôi, đây là tập sách nên có trong gia đình, các trung tâm y tế, bệnh viện, viện điều dưỡng, các nhà nuôi dạy trẻ, các nhà ăn tập thể, các câu lạc bộ y học và dưỡng sinh. Bác sĩ NGUYỄN VĂN KHUÊ Nguyên Trưởng Trung tâm Y Tế-Giáo dục TP.HCM.', N'nghe-thuat-nau-an-vui-khoe-theo-phuong-p.jpg', 500, CAST(N'2017-02-25' AS Date), 31, 17, 23, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (81, N'00000000000000', N'Phòng Và Trị Bệnh Theo Phương Pháp Thực Dưỡng Oshawa', N'MACROBIOTICS hiểu theo từ Hy Lạp (Makrobiotos) hoặc THỰC DƯỠNG hiểu theo ngữ nghĩa Hán Việt là phương pháp hoặc nghệ thuật dưỡng sinh sống vui sống khỏe dựa vào một tri thức sâu xa về sự sống trong vũ vụ mà Giáo sư Ohsawa gọi là NGUYÊN LÝ VÔ SONG của TRẬT TỰ VŨTRỤ phát xuất từ học thuyết “Vũ Trụ Thống Nhất” và “Ầm Dương Biện Chứng” của Á Đông. Sau nhiều năm hoạt động, Giáo sư OhsaWAa và những người theo ông đã gây dựng một phong trào Thực Dưỡng rộng lớn trên thế giới. Ở nhiều nước kể cả những nước có nền y học hiện đại tiên tiến như Mỹ, Nga, Anh, Đức, Pháp, Nhật, v.v... đã có những tổ chức nghiên cứu, ứng dụng và truyền bá phương pháp này cả ở cấp chính phủ và liên chính phủ. Cách phòng và trị bệnh bằng THỰC DƯỠNG hiện đã dược Tổ chức Y Tế Thế Giới WHO nhìn nhận, và thuật ngữ Macrobiotics được sử dụng càng ngày càng phổ biến trên các diễn đàn quốc tế về y học và xã hội học như là một biện pháp tích cực để giải quyết những vướng mắc trong công tác chăm sóc sức khỏe và phục vụ đời sống con người.', N'phong-va-tri-benh-theo-phuong-phap-thuc-.jpg', 500, CAST(N'2017-02-25' AS Date), 30, 17, 23, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (82, N'00000000000000', N'Làm Thế Nào Để Sống Vui', N'Buổi trưa, anh bạn đến trả bản thảo “Làm Thế Nào Để Sống Vui” mà tôi cho mượn cách đó mấy hôm. [“Làm Thế Nào Đề Sống Vui” dịch từ nguyên tác Pháp ngữ “La Vie Macrobiotique” (có tham khảo bản Anh ngữ “Macrobiotic Guiđebook For Living” và Nhật ngữ “Thực Dưỡng Nhân Sinh Độc Bản”) của Giáo Sư Ohsawa, tôi nghĩ rằng tập sách này sẽ trả lòi rốt ráo những thắc mắc của giới trẻ mọi thời.] Chúng tôi ngồi dưới tán cây trong sân vườn Nhà Ohsawa uống trà và nói chuyện đời. Một chiếc lá vàng rơi, cắm thẳng vào tách nước. Anh bạn lên tiếng: “Mình tiếc những năm tháng học trò và cho đến bây giờ vẫn ân hận. Miệt mài học tập, chúi mũi vào sách vở, để rồi ra trường cũng chẳng thực hiện được những gì đã thu thập bởi sức khỏe suy sụp đột ngột. Thật ra, một phần do mình ham học, nhưng phần lớn do bố mẹ mình kềm cặp. Có thể nói mình không biết ngày nghỉ, không biết mùa hè là gì, chỉ có học và học. Tuổi thơ rồi tuổi trẻ mà như ông cụ, chạy nhảy vui đùa gần như là diều cấm kỵ. Tình trạng thiếu vận động, thiếu giải trí, đầu óc căng thẳng suốt nhiều năm đã đốn gục mình với chứng suy nhược thần kinh trầm trọng, may mà mình gặp được phương pháp Thực Dưỡng. Lá trên cao lao xao, một bên gương mặt trắng xanh của bạn ngòi lên ánh nắng… Cầm tách trà lên nhắp một ngụm, vị chát thấm vào lưỡi nghe ngòn ngọt. Bỗng anh bạn lên tiếng: “Quân bình là đúng nhất!”; tôi bật nói như mơ: “Vâng, mọi điều phải quân bình, không nên có gì thái quá!” NGÔ ÁNH TUYẾT', N'lam-the-nao-de-song-vui.jpg', 500, CAST(N'2017-02-25' AS Date), 32, 17, 22, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (83, N'00000000000000', N'Hoa Đạo', N'ANH MINH, SONG ANH & NGÔ ÁNH TUYẾT dịch Trong thiên nhiên, tất cả đều đẹp, tất cả đều tốt lành hoàn hảo... Chỉ tại những tật xấu đáng ghét của con người làm tất cả hư hỏng, suy đồi còn thiên nhiên vẫn là nguồn thanh khiết; mà hoa là những gì được thiên nhiên chắt chiu bảo dưỡng thì làm sao không thể yêu hoa? Phải yêu hoa nếu muốn tỏ lòng biết ơn Trời Đất. Có yêu hoa, ta mới thấy mình hòa hợp với thế gian. Một trái táo rơi đã tạo cơ hội cho Nhà khoa học người Anh Newton tìm ra các nguyên lý về lực hấp dẫn. Nhưng đối với người Nhật, chỉ cần một chiếc lá rơi giữa những sắc màu diễm lệ của mùa thu cũng đủ cho thấy sự hư ảo của mọi vật, sự chóng qua của tất cả những gì mà kẻ điên rồ muốn giữ mãi, cùng nỗi chán chường do vật chất hữu hình gây ra. Dù trải bao thế kỷ, ngưòi không được thừa hưởng lòng quý chuộng những gì tâm linh, vô hình, vô thể, thì một sự kiện nhỏ nhoi đó cũng đủ gợi sáng trong tâm. Thế giới hữu hình là một tổng thể, không thể phân chia để chỉ chọn lấy những điều tiện lợi mà khước từ những điều phiền toái. Cơ năng tâm trí của con người tiếp thụ những khoái cảm vật chất, khiến ta biết ăn ngon, mặc đẹp và hưởng thụ những tiện nghi sang trọng, nhưng đồng thời giúp ta cảm nhận được sự mong manh của đời sống vật chất. Điều mà chúng ta tưởng có lợi cho mình một trầm phần trăm thật ra chỉ là sự đổi chác. Vật chất ban cho ta, mà vật chất cũng lấy lại của ta. NHÀ OHSAWA MACROBIOTICS', N'hoa-dao.jpg', 500, CAST(N'2017-02-25' AS Date), 28, 17, 22, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (84, N'00000000000000', N'NHÂN SINH LUẬN - BỘ 2 TẬP', N'... Không phải bờ bên kia quan trọng, mà con sông, cái bờ bên này nơi bạn đang đứng mới là quan trọng. Con sông là cuộc đời, là sự sống thường nhật với vẻ đẹp kỳ diệu của nó, niềm vui, lạc thú, sự xấu xa, đau đớn và khổ sầu của nó. Cuộc đời là một phức thể lớn rộng gồm tất cả những thứ ấy, nó không chỉ là một đoạn đường cần phải băng qua một cách quấy phá cho xong. Bạn phải hiểu điều ấy chứ chứ không phải để mắt dán vào bờ bên kia. Chính bạn là cuộc đời này, một cuộc đời của ganh tị, bạo động, tình yêu qua đường, tham vọng, bất mãn và sợ hãi. Bạn lại vừa là lòng khát khao thoát khỏi tất cả những thứ ấy để đạt đến cái trường cửu, linh hồn, đại ngã, Thượng đế, v.v... Nếu không hiểu cuộc đời này, không thoát ra khỏi lòng ganh tị với những lạc thú và khổ sầu của nó thì bờ bên kia chỉ là một huyền thoại, một ảo tưởng, một lý tưởng bày đặt bởi một tâm thức sợ hãi đi tìm kiếm bình an. Cần phải đặt nền tảng cho đúng, nếu không, ngôi nhà dù cao quý tới đâu cũng không đứng vững...', N'14813509_727378967417469_1782969689_n.jpg', 500, CAST(N'2017-02-25' AS Date), 33, 18, 25, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (85, N'00000000000000', N'Trò chuyện với hiện thể', N'Cuốn sách trò chuyện với hiện thể này là duy nhất, bởi nó là một ấn phẩm của J. Krishnamurti được ông nói trực tiếp vào máy ghi âm những khi hoàn toàn cô độc. Lúc đó, tay ông phần nào bị run (ông đã 87 tuổi), vậy thay vì viết, ông ghi âm lời nói của mình. Sau khi từ Ấn Độ về lại California vào tháng 2 năm 1983, ông bắt đầu “Trò chuyện với hiện thể”. Tất cả các bài, ngoại trừ một bài, đều được thực hiện tại nhà ông ở Pine Cottage thuộc Ojai Valley, cách Los Angeles tám mươi dặm về phía bắc. Nhiều lúc giọng nói của ông trở nên xa xôi nhưng những ý tưởng lại rất gần Krishnamurti trong tinh thần của chính ông.    Mỗi ngày đối với ông là hoàn toàn mới,nhà sách online hoàn toàn tự do tự tại thoát khỏi tất cả gánh nặng ký ức. Đoạn kết, có lẽ là đoạn kỳ diệu nhất, nói về sự chết. Đây cũng là lần cuối cùng, chúng ta được nghe Krishnamurti trò chuyện. Hai năm sau, ông từ trần cũng tại nơi này.', N'trochuyenvoihienthe.jpg', 500, CAST(N'2017-02-25' AS Date), 33, 18, 13, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (86, N'00000000000000', N'Sống Thiền 365 Ngày', N'“Tại sao bạn muốn làm học trò của sách thay vì làm học trò của chính cuộc sống? Hãy khám phá cái thực và ảo trong cuộc sống quanh bạn cùng với những khống chế và bạo tàn chứa chấp trong đó, bấy giờ bạn mới thấy cái gì là chân thực.” Krishnamurti thường nhắc nhở và chỉ ra rằng “pho sách sống” ấy bao giờ cũng chuyển lưu luôn, không thể cầm giữ cái sống ấy trong tư tưởng, đó là pho sách “có giá trị duy nhất đáng phải đọc”, còn mọi sách vở kinh điển khác đều tràn ngập loại thông tin thứ yếu. “Câu chuyện hay sự tích của nhân loại nằm ngay trong chính bạn, cái kinh nghiệm mênh mông, những sợ hãi, âu lo, phiền não, khoái lạc thâm căn cố đế cùng mọi niềm tin mà con người đã tích tập qua hàng triệu triệu năm. Bạn là pho sách sống đó.” Sống Thiền 365 Ngày là quyển sách phản ánh vô cùng trung thực cung cách nói chuyện của Krishnamurti. Cái nhìn của ông là một cách quan sát thống nhất bao quát toàn cảnh sống của con người, trong đó, từng phương diện liên hệ mật thiết với nhau. Sách trình bày những đoạn trích đề cập các chủ đề một cách xuyên suốt chủ yếu làm rõ một chủ đề nền tảng: bất cứ ai cũng có thể khám phá sự thật, không cần phải dựa dẫm vào bất kỳ thế lực nào, vì chân lý hay sự thật tựa như sự sống bao giờ cũng ở trong hiện tại, trong từng khoảnh khắc hiện tại.', N'songthien-sachkhaitam.jpg', 500, CAST(N'2017-02-25' AS Date), 33, 18, 22, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (87, N'00000000000000', N'Tự do đầu tiên và cuối cùng', N'"Khi được hỏi “Ông không đang hành động như vị đạo sư của chúng tôi hay sao?”, Krishnamurti trả lời, “Chắc chắn tôi không đang hành động như vị đạo sư của bạn, bởi vì trước hết, tôi không mang lại cho bạn bất kỳ sự thỏa mãn nào. Tôi không đang chỉ dẫn điều gì bạn nên làm từ khoảnh khắc này sang khoảnh khắc khác hay từ ngày này sang ngày khác, mà tôi chỉ vạch rõ cái gì đó cho bạn, bạn có thể thâu nhận hay khước từ nó, phụ thuộc vào bạn, không phải vào tôi. Tôi chỉ nói, “Đây là sự thật; hãy thâu nhận nó hay khước từ nó”. - Aldous Huxley                         "Người ta thường gọi ông là “Bậc đạo sư của thế gian”. Nếu có người nào xứng đáng với danh hiệu như thế thì người ấy chính là Krishnamurti. Đối với tôi, điều quan trọng nhất trong thái độ tâm linh của Krishnamurti là ông không bao giờ muốn chúng ta coi ông như một bậc đạo sư, như một bậc thầy, mà ông chỉ muốn là một con người, với tất cả ý nghĩa đơn giản thông thường của hiện thể." - Henry Miller', N'wp_20160611_14_39_29_pro.jpg', 500, CAST(N'2017-02-25' AS Date), 33, 18, 13, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (88, N'00000000000000', N'Đối Diện Cuộc Đời', N'Tác phẩm bạn đọc đang cầm trên tay là tập hợp một số đoạn nhật ký và bài nói chuyện của Krishnamurti trong gần 60 năm cuộc đời diễn giảng của ông. Trong số các vị đạo sư tâm linh xưa nay thì ta có thể xem Krishnamurti là con người quyết liệt nhất khi nói về điều được mệnh danh là chân lý, là sự thật. Nghe tiếng ông là một người minh triết và giác ngộ, nhiều người tìm đến đế xin nghe giảng thuyết về chân lý, nhưng không ít người bị thất vọng. Lý do giản đơn là, Krishnamurti không bao giờ chịu nhượng bộ, không bao giờ giảng những lời đạo lý chung chung, không bao giờ cho những an ủi khích lệ thông thường, kể cả đối với người bệnh đang nằm chờ chết hay với cha mẹ đang đau khổ mất con. Vì đối với ông, một nửa mẩu bánh mì còn là bánh mì nhưng một nửa sự thật không phải là sự thật. Và sự thật thì lại “không có con đường nào dẫn đến”. Những người đến nghe ông giảng thường được ông giải thích một cách rạch ròi rằng, tất cả những tầm cầu tưởng chừng như rất đạo đức của họ chẳng qua đều là biến hiện của một tâm thức thèm khát thành tích, mong chờ ân sủng, tìm kiếm sự an toàn và tiện nghi nội tâm. Tất cả những thứ đó đều là biểu hiện của một cái “tôi” ranh mãnh đang chờ...', N'doidiencuoc-sachkhaitam.jpg', 500, CAST(N'2017-02-25' AS Date), 34, 18, 10, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (89, N'00000000000000', N'Quyển Sách Của Cuộc Đời', N'Krishnamurti không theo bất kỳ một tôn giáo nào, không phụ thuộc bất kỳ một tổ chức chính trị nào, ông dành cả đời mình chu du khắp thế giới nhằm rao giảng, rao giảng không vụ lợi, không vì bản thân, mà vì tất cả mọi người, mọi sắc tộc, mọi sinh linh trên thế giới. Đọc sách của Krishnamurti ta cảm nhận được một thế giới mới thật bao la, thật sâu rộng, thật thiêng liêng: một cái gì đó vượt khỏi phạm vi không gian và thời gian, một tư tưởng kết tinh giá trị văn hóa cao siêu sâu sắc. Ông chỉ ra con đường cho mọi người biết tự giải thoát tâm hồn mình khỏi mọi bế tắc trong cuộc sống, khỏi mọi buồn phiền và đau khổ của đời sống thường ngày. Giúp chúng ta tìm thấy nhiều niềm vui, sự bình yên và hạnh phúc. Mỗi ngày trong năm bạn sẽ được cùng Krishnamurti chiêm nghiệm sâu sắc về những đối tượng quanh mình, những ngọn cỏ, những bông hoa, những áng mây, những buổi chiều vàng... Đương nhiên, đối với những gì thiêng liêng thì không ai có thể trao tận tay cho bạn. Bạn, chính bạn, sẽ là người tự cảm nhận được nó, qua tâm hồn của mình, qua linh cảm của mình, qua khả năng cảm nhận siêu nhiên của con người... Đây là một cuốn sách đáng đọc, một cuốn sách gối đầu giường dành cho những ai muốn tìm kiếm một cái gì đó vượt ra khỏi giới hạn của đời sống vật chất tầm thưởng, một cái gì đó nằm trong khả năng của con người mà con người vẫn chưa phát huy được.', N'quyensachcua-sachkhaitam.jpg', 500, CAST(N'2017-02-25' AS Date), 33, 18, 13, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (90, N'00000000000000', N'Hướng Đi Cho Cuộc Đời', N'Tình yêu là nhân tố duy nhất có thể giải quyết tất cả mọi khó khăn của chúng ta... Đôi khi, trong trạng thái cô độc một mình, nếu bạn may mắn nó sẽ đến với bạn, trên chiếc lá vàng rơi, hoặc từ cái cây đơn độc xa xa kia trong cánh đồng bao la hiu quạnh. Trong cuốn cẩm nang này, quyển sách trích dẫn những đoạn ghi sâu sắc nhất, ý nghĩa nhất từ những bài giảng của Krishnamurti, người đã trình bày rõ những suy nghĩ mới mẻ về tình yêu, chính trị, xã hội, cái chết, sự khắc kỷ, mối quan hệ, trạng thái cô độc, thiền định, sự phát triển tâm linh, và hơn thế nữa. Qua quá trình chiêm nghiệm thiền định, Krishnamurti cho chúng ta câu trả lời đối với những câu hỏi: - Thiền định là gì? - Tình yêu và sự cô độc là gì? - Mối quan hệ của chúng ta dưới sự tác động của sức mạnh uy quyền là gì? Nội dung cuốn sách này được trích dẫn từ những Tập san cơ bản của Krishamurti. Hầu hết các đoạn trích này đã được xuất bản lần đầu tiên trong Tập san Triết lý niềm tin cơ bản của Krishnamurti, có vài đoạn trích xuất hiện trong các Tập san được phát hành tại Mỹ và Ấn Độ và sau đó được in lại trên Tập san được phát hành tại Anh quốc. Các con số Tập san được giới thiệu ở đây là những Tập san được phát hành tại Anh Quốc. Sách này được chia làm ba phần: Phần 1: gồm 16 mẫu truyện ngắn do Krishnamrti đọc Phần 2: là những câu trả lời của Krishnamuti trước các câu hỏi của khán thính giả đặt ra sau những buổi thảo luận của người hoặc tại các buổi thảo luận nhỏ. Phần 3: gồm những cuộc trò chuyện trao đổi của Krishnamuri tại Thuỵ Sĩ, Ấn Độ, Anh Quốc và California.', N'huong-di-cho-cuoc-doi.jpg', 500, CAST(N'2017-02-25' AS Date), 34, 18, 13, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (91, N'00000000000000', N'Giáp Mặt Cuộc Đời', N'Một trí não bị kiềm chế trong kỷ luật không bao giờ là một trí não tự do giải thoát, cũng không bao giờ có thể là một trí não tự do khi dục vọng của nó bị dồn ép. Chỉ bằng cách thấu hiểu toàn bộ tiến trình của dục vọng, trí não mới có thể tự do. Kỷ luật, giới luật luôn luôn hạn chế trí não vào một chuyển động ngục tù, trong khuôn khổ của một hệ thông tư tưởng hay tin tưởng đặc biệt nào đó, phải không? Cho nên, một trí não như thế không bao giờ tự do để thông minh hay trí tuệ được. Kỷ luật khiến sinh thái độ qui phục vào quyền lực. Kỷ luật tập cho ta có khả năng vận động đúng với chức năng của mình theo yêu cầu của một mô hình xã hội, nhưng kỷ luật không đánh thức được trí thông minh vốn có khả năng riêng của nó. Một trí não không biết đào luyện gì ngoài cái khả năng dựa vào ký ức, giống như một máy tính điện tử hiện đại, tuy vận hành với một khả năng lạ lùng và độ chính xác cực cao, nó vẫn chỉ là một chiếc máy. Uy lực, quyền lực có thể thuyết phục trí não tư duy theo một phương hướng đặc biệt nào đó. Nhưng bị hướng dẫn tư tưởng theo một đường hướng nào đó, hay dựa vào một kết luận có sẵn, không phải là tư tưởng chi cả, mà chỉ vận hành như người máy, khiến sinh bất mãn một cách mù quáng, thất vọng và nhiều nỗi phiền muộn khác. Vấn đề quan trọng ta quan tâm là sự phát triển toàn diện của từng con người, giúp con người hiểu rõ cái khả năng cao tột nhất và đầy đủ nhất của chính mình - chứ không phải cái khả năng giả tạo nào đó mà nhà giáo dục nghĩ ra như một quan niệm hay một lý tưởng. So sánh - bất kỳ với thái độ nào - cũng đều ngăn chặn sự phát triển toàn diện của cá nhân, dù bất luận là người làm vườn hay là nhà khoa học. Khả năng đầy đủ nhất của người làm vườn vốn đồng hóa với khả năng đầy đủ nhất của nhà khoa học khi ta không đem họ ra so sánh với nhau; nhưng khi sự so sánh xen vào, thì liền có lòng khinh thị và những phản ứng ganh tị làm dây lên xung đột giữa người và người. Cũng tương tự thế, đau khổ, tình yêu không thể đem ra so sánh; không thể so sánh cái này tốt hơn, cái kia nhỏ hơn. Đau khổ là đau khổ, như tình yêu là tình yêu, nơi kẻ giàu cũng như kẻ nghèo. Sự phát triển trọn vẹn của mỗi cá nhân tạo ra một xã hội bình đẳng. Cuộc đâu tranh xã hội hiện tại nhằm tạo nên một sự bình đẳng về kinh tế hay tinh thần, ở bình diện nào đó, không có nghĩa lý chi cả. Các cuộc cải cách xã hội lấy bình đẳng làm mục đích, dấy sinh thêm nhiều hình thức hoạt động phản nghịch xã hội mới khác; nhưng với một nền giáo dục chân chính, không cần phải tìm kiếm sự bình đẳng bằng các cuộc cải cách xã hội hay nhiều hình thức cải cách khác; bởi vì lòng ghen tị do so sánh các khả năng đã ngưng dứt.', N'giap-mat-cuoc-doi.jpg', 500, CAST(N'2017-02-25' AS Date), 34, 18, 13, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (92, N'00000000000000', N'Chấm Dứt Thời Gian', N'1. Gốc rễ của sự xung đột tâm lý 2. Tẩy sạch trí não mọi sự tích tập thời gian 3. Tại sao con người đã gắn cho tư tưởng một tầm quan trọng tối thượng ? 4. Phá vỡ mô hình hoạt động tập trung vào ngã 5. Nền tảng của sự sống và trí não con người 6. Tuệ giác có thể chuyển hóa tế bào não không ? 7. Cái chết có rất ý nghĩa 8. Có thể đánh thức tuệ giác nơi người khác không? 9. Lão suy và tế bào não 10. Trật tự vũ trụ 11. Chấm dứt kiến thức tâm lý 12. Trí não trong vạn vật vũ trụ 13. Liệu các vấn đề của từng người có thể giải quyết và sự phân chia manh mún có chấm dứt ?', N'cham-dut-thoi-gian.jpg', 500, CAST(N'2017-02-25' AS Date), 34, 18, 22, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (93, N'00000000000000', N'Lửa Giác Ngộ', N'Lời nói đầu Phần I: - Sự mở rộng của giáo lý - Thức là gì ? - Tâm Krisnamurti - Năng lượng và chú tâm - Nguyên nhân gốc rễ của sợ hãi - Một cuộc đối thoại về cái chết - Bản chất của Thượng đế - Não có thể tự đổi mới ? - Chấm ứt sợ hãi - Cuốn truyện kể về nhân loại - Khám phá cội nguồn - Não, trí, không - Văn hóa là gì ? - Tôi bất đầu tử đâu ? - Cái không động có thời gian không ? Phần II: - Tồn tại và trí tuệ - Trí và tâm - Từ bi là năng lượng hoàn toàn giải thoát - Nào có thể thoát khỏi giới hạn của chính nó không ? - Trí tuệ, máy tính và trí óc máy móc.', N'lua-giac-ngo.jpg', 500, CAST(N'2017-02-25' AS Date), 34, 18, 22, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (94, N'00000000000000', N'Nhật Ký Cuối Cùng', N'Trong tất cả tác phẩm của Krishnamurti, sách này đặc biệt nhất vì được ghi lại từ máy ghi âm do ngài đọc lên lúc ở một mình. Sau khi thành công rực rỡ với tác phẩm Journal xuất bản năm 1982, Krishnamurti được mọi người khuyến khích viết tiếp. Lúc ấy ngài đã 87 tuổi, tay đã yếu, nên ngài vui vẻ nghe theo sự gợi ý là ghi âm những gì cần viết. Tuy thế ngài chưa thể khởi sự được vì sắp đi Ấn, ở đấy ngài sẽ không có thì giờ yên ổn dành cho việc này. Về đến Californie tháng 2 năm 1983, ngài đọc những bài đầu tiên trong tập này vào một máy thu băng Sony. Tất cả những bài này đều được thu băng tại tư thất ở Pine Cottage nằm trong thung lũng Ojai khoảng 80 km bắc Los Angeles. Ngài ghi âm vào buổi sáng trong căn phòng yên tịnh sau buổi điểm tâm, thời gian ngài không bị quấy rầy. Năm 1922 cũng chính tại nơi này, Pine Cottage (lúc ấy thuộc về một người bạn), Krishnamurti đã sống với người em trai Nitya và cũng vào năm ấy ngài đã trải qua một kinh nghiệm tâm linh làm chao đảo cuộc đời ngài. Ít lâu sau, một hiệp hội được lập nên để quyên góp tiền mua lại trang trại và đất đai rộng khoảng 20.000 mét vuông. Năm 1978, một tòa nhà lộng lẫy được xây cất cạnh gian lều trong đó Krishnamurti giữ nguyên phòng nghỉ của ngài với bộ xa-lông xưa cũ. Những bài đọc không được gọt dũa như những bài viết, và thỉnh thoảng giọng ngài mất hút. Trái với các quyển Carnets và Journal, người ta phải nhuận sắc lại tập sách này cho nó được sáng sủa. Khi đọc những bài này, ta cảm thấy rất gần gũi với Krishnamurti và có cảm tưởng thấu triệt được tư tưởng ngài. Ở một vài đoạn, ngài trả lời câu hỏi của một nhân vật tưởng tượng. Đây là cốt tủy lời dạy của ngài. Những người xem ngài không những là một triết gia mà còn là một thi sĩ, sẽ tìm thấy - qua những đoạn tả cảnh bắt đầu mỗi bài - sự thanh thoát tâm hồn khiến họ dễ cảm nhận được những gì được nói sau đó. Nhiều chỗ lặp lại dường như cốt nhấn mạnh ý nghĩa những lời ngài nói, và để chứng tỏ mỗi ngày đốì với ngài là một kinh nghiệm mới mẻ, hoàn toàn thoát khỏi gánh nặng quá khứ. Điều lạ lùng là bài cuối cùng, có lẽ hay nhất trong tập, đề cập cái chết. Đây là lần cuối cùng chúng ta nghe Krishnamurti nói với chính mình. Hai năm sau cũng trong căn phòng này, ngài đã từ trần.', N'nhat-ky-cuoi-cung.jpg', 500, CAST(N'2017-02-25' AS Date), 33, 18, 10, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (95, N'00000000000000', N'Đánh Thức Trí Thông Minh', N'Phần I: Hai cuộc chuyện trò - J. Krishnamurti & Giáo sư J. Needleman 1- Vai trò của vị Thầy 2- Về không gian bên trong Phần II: Ba cuộc nói chuyện ở thành phố New York 1- Cuộc cách mạng bên trong 2- Tương quan 3- Kinh nghiệm Tôn giáo - Thiền định Phần III: Hai cuộc trò chuyện - J. Krishnamurti & Alain Naude 1- Rạp xiếc tranh đấu của con người 2- Về Tốt và Xấu Phần IV: Ba cuộc nói chuyện ở Madras 1- Nghệ thuật thấy 2- Tự do 3- Cái thiêng liêng Phần V: Ba cuộc đối thoại ở Madras 1- Xung đột 2- Thời gian, Không gian và cái Trung tâm 3- Một câu hỏi nền tảng Phần VI: Bảy cuộc nói chuyện ở Saanen, Thụy Sĩ 1- Cái gì là sự quan tâm hơn hết của bạn? 2- Trật tự 3- Chúng ta có thể tự hiểu mình? 4- Cô độc 5- Tư tưởng và cái không thể đo lường 6- Hành động của ý chí và năng lượng cần cho một thay đổi tận gốc 7- Tư tưởng, Trí thông minh và Cái vô lượng Phần VII: Hai buổi nói chuyện ở Brockwood 1- Sự tương quan với tỉnh giác về tư tưởng và hình ảnh 2- Tâm thiền định và câu hỏi không thể đáp Phần VIII: Một thảo luận với một nhóm nhỏ ở Brockwood - Bạo lực và cái tôi Phần IX: Nói chuyện giữa J, Krishnamurti và Giáo sư David Bohm - Về trí thông minh', N'danh-thuc-tri-thong-minh.jpg', 500, CAST(N'2017-02-25' AS Date), 34, 18, 21, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (108, N'00000000000000', N'PHÚC LẠC THÁNH THIỆN', N'Đời sống có tính Thiêng Liêng trong nguồn gốc, nội dung và ý nghĩa của nó. Sự Thánh Thiện nằm ở bên trong mỗi người. Phúc Lạc thật sự là bản chất của tạo hóa. Nhưng trở ngại để đạt được bản chất Phúc Lac và Thánh Thiện nằm trong tâm trí. Làm nô lệ của tâm trí là sự vô minh. Cho nên, không có điều gì có thể mang lại sự phúc lạc cho bạn ngoại trừ việc chinh phục tâm trí. Sống một Đời Thánh Thiện trở về với bản chất Thánh Thiện bẩm sinh trong chính bạn. Khi đó bạn sẽ có được niềm phúc lạc. Cuốn sách PHÚC LẠC THÁNH THIỆN dành cho những ai đang tìm kiếm một con đường rõ ràng và đúng đắn, không bí ẩn hay mơ hồ. Những bài luận thuyết này đầy sức mạnh với những lập luận vững vàng và lực cải hóa từ Kiến Thức Tâm Linh. Đối với thầy Swami Sivananda, mỗi hành động trong đời sống đều có thể được biến đổi thành Yoga của sự Thánh Thiện, bằng cách thu thập những kiến thức cần thiết qua nghiên cứu và chiêm nghiệm. Sự hiểu biết về những bài viết này sẽ truyền cảm hứng và năng cao tâm hồn của người đọc, và thánh hóa linh hồn. Một sự suy ngẫm sâu sắc sẽ vén bức màn bí mật của bản chất Phúc Lạc và Thánh Thiện trong tâm hồn. Cuốn sách này sẽ thành một bàn tay dẫn lối vô giá cho tất cả những ai tìm kiếm chân lý và những người tu tập.     ', N'8935209630777.jpg', 500, CAST(N'2017-02-25' AS Date), 35, 19, 26, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (109, N'00000000000000', N'Cẩm nang tu đạo', N'Tập Cẩm nang tu đạo, đúc kết tinh hoa những lời dạy của bậc Thánh tăng thời cận đại, Hoà thượng Quảng Khâm ( 1892- 1986 ). Là bậc đã giác ngộ, mỗi lời dạy của Ngài trực tiếp phá vỡ vô minh, khiến ta giác ngộ. Dù là bậc xuất gia hay là cư sĩ tại gia.', N'16790441_795803793908319_783483692_n.jpg', 500, CAST(N'2017-02-25' AS Date), 36, 19, 24, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (110, N'00000000000000', N'TÔN GIÁO HỌC SO SÁNH', N'Để hiểu rõ về một tôn giáo đã khó, nắm được tinh hoa của tôn giáo ấy để viết ra cho mọi người đọc lại càng khó hơn, huống gì là hiểu và viết về các tôn giáo lớn trên thế giới. Việc này không phải ai cũng có khả năng làm được. Đọc qua tác phẩm Tôn Giáo Học So Sánh của Pháp sư Thánh Nghiêm, chúng ta mới thấy được kiến thức uyên bác về các tôn giáo của Ngài. Có lẽ, chúng tôi không cần giới thiệu ra đây làm gì, sau khi xem xong độc giả sẽ tự cảm nhận điều đó. Tuy nhiên, sách viết bằng Hoa ngữ nên việc đọc và hiểu thấu được nghĩa lý của nó cũng có phần hạn chế. Vì muốn góp sức mình cho lợi ích của mọi người, giúp cho Tăng Ni sinh các trường Phật học Việt Nam và các sinh viên chuyên ngành khoa học xã hội có thêm tài liệu tham khảo khi học về môn tôn giáo học, nên tôi đã cố gắng đem hết khả năng của mình dịch ra Việt ngữ. Vì mỗi tôn giáo đều có những thuật ngữ riêng, cho nên bản dịch này không sao tránh khỏi những khiếm khuyết. Kính mong các bậc cao minh, các vị chức sắc tôn giáo bạn góp ý để cho bản dịch được hoàn thiện hơn. Bản dịch hoàn thành tháng 10 năm 1995. Xuất bản lần đầu năm 1996. Tái bản lần này (2015) có sự bổ khuyết của chư Tăng chùa Hoằng Pháp. Xin tri ân mọi nhân duyên giúp cho cuốn sách được tiếp tục ra mắt quý độc giả. Thích Chân Tính', N'16808719_795793707242661_1564999097_n.jpg', 500, CAST(N'2017-02-25' AS Date), 37, 19, 13, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (111, N'00000000000000', N'Sống từ bi yêu thương', N'"Thực chất trong cuốn sách nhỏ đơn giản này, đức Dalai Latma đã dâng tặng cho đời những điều tốt đẹp tự đáy lòng của ngài và trí tuệ của một đời tu tập và hoằng pháp. Ở đây, tất cả mọi thứ diễn ra trong đời sống hằng ngày của chúng ta, ngay cả khi chúng ta cố gắng nhất, nếu chúng ta nhận ra được cái đẹp của trong ta và người khác, thì khả năng hạnh phúc và an lạc thực sự hiện hữu trong cuộc đời này, ngay bây giờ và ở đây. Phương thuốc khân khiết chan hòa và thương yêu cho thế giới đơn giản đến bất ngờ và cũng quan trọng đến bất ngờ - vì vậy sự thực hành tu tập của chúng ta chắc chắn sẽ mang lại một giá trị lợi ích" Jon Kabat - Zinn', N'16790742_795786330576732_579605814_n.jpg', 500, CAST(N'2017-02-25' AS Date), 38, 19, 13, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (112, N'00000000000000', N'HỎI ĐƯỜNG MÂY TRẮNG QUA', N'Cuốn sách này không phải là một ký sự lữ hành, mà miêu tả thể nghiệm riêng về cuộc hành hương theo nghĩa tính chuyên nhất của nó, bởi hành hương khác cuộc hành trình thông thường ở chỗ hành hương không đi theo một lộ trình sắp sẵn, hay một giờ giấc định trước, hành hương không phải để đi tìm một mục tiêu xác định hay một đích đến giới hạn, ý nghĩa của hành hương nằm ngay trong từng bước đi do nội tâm dẫn dắt trên hai bình diện: thể xác và tâm linh. - Lama Anagarika Govinda Cuốn sách ghi lại kỳ tích của một tác giả người Đức, ông Govinda (1898 - 1985), đã giã từ phương Tây, hành hương về phương Đông để "hỏi Đường Mây Trắng qua". Không chỉ truyền cảm hứng cho người đọc bởi bút lực tài tình, cuốn sách còn là một tài liệu nhân chủng học để ta học hỏi phương pháp nghiên cứu thực địa, một sử liệu giá trị về văn hóa và lịch sử Tây Tạng. Những dấu tích ấy, theo lẽ sinh diệt hồn nhiên, nay không còn nguyên! Tuy vậy, những người có trực quan mạnh mẽ hay tín tâm kiền thành vẫn có thể "thấy" nó qua những trang sách đẫm màu tươi rói. - Hồ Đắc Túc', N'may-trang-version-final-of-final_new_4nov_2016-bia-1.jpg', 500, CAST(N'2017-02-25' AS Date), 39, 19, 13, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (113, N'00000000000000', N'Nhận thức Phật giáo Hòa Hảo - Bìa cứng', N'Từ huyết thống, sinh hoạt gia đình, nhân cách, thần cách Đức Huỳnh Giáo Chủ cho đến các phẩm Sấm Kinh do Ngài viết, các diễn tiến của Đạo do Ngài điều hành, cộng với hoàn cảnh của một xã hội… lòng tin của người tín đồ… chúng tôi đều gắng gổ biết qua.   Tuy nhiên, vấn đề quá bao la và phức tạp, lại thêm việc tìm Đạo xưa nay đã có lối vạch rồi “Đạo chỉ tại tâm đắc, nếu dùng lời giảng Đạo, chỉ kẹt Đạo trong lời”. Hai yếu tố nầy đã đủ khiến tôi hiểu rằng: Chúng tôi không nói hết được những gì mình muốn nói.   Vậy nếu mục tiêu cần đạt đến là mặt trăng của Phật Tổ, là con thỏ của Trang Chu, thì ngón tay chỉ trăng, cái dò săn thỏ chỉ là những phương tiện để hiểu được Đạo mà thôi.   Chúng tôi không dám mộng ước gì hơn là những dòng chữ trong sách nầy chỉ là một phương tiện nhỏ nhoi để đưa độc giả đến chỗ hiểu được phần nào cái Đạo.   Xin hãy quên đi tất cả, những gì coi là phương tiện…', N'bia-moi-pghh-vang-nau-final-15-12-426x600.png', 500, CAST(N'2017-02-25' AS Date), 40, 19, 26, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (114, N'00000000000000', N'Nhận thức Phật giáo Hòa Hảo - Bìa mềm', N'Từ huyết thống, sinh hoạt gia đình, nhân cách, thần cách Đức Huỳnh Giáo Chủ cho đến các phẩm Sấm Kinh do Ngài viết, các diễn tiến của Đạo do Ngài điều hành, cộng với hoàn cảnh của một xã hội… lòng tin của người tín đồ… chúng tôi đều gắng gổ biết qua. Tuy nhiên, vấn đề quá bao la và phức tạp, lại thêm việc tìm Đạo xưa nay đã có lối vạch rồi “Đạo chỉ tại tâm đắc, nếu dùng lời giảng Đạo, chỉ kẹt Đạo trong lời”. Hai yếu tố nầy đã đủ khiến tôi hiểu rằng: Chúng tôi không nói hết được những gì mình muốn nói. Vậy nếu mục tiêu cần đạt đến là mặt trăng của Phật Tổ, là con thỏ của Trang Chu, thì ngón tay chỉ trăng, cái dò săn thỏ chỉ là những phương tiện để hiểu được Đạo mà thôi. Chúng tôi không dám mộng ước gì hơn là những dòng chữ trong sách nầy chỉ là một phương tiện nhỏ nhoi để đưa độc giả đến chỗ hiểu được phần nào cái Đạo. Xin hãy quên đi tất cả, những gì coi là phương tiện…', N'bia-moi-pghh-vang-nau-final-15-12-426x600.png', 500, CAST(N'2017-02-25' AS Date), 40, 19, 26, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (115, N'00000000000000', N'Hoàng Đế nội kinh - Linh khu', N'Sách “Hoàng Đế nội kinh” được xem là một trong tứ đại kinh điển Đông y sớm nhất hiện còn tồn tại đến ngày nay. Tuy nhiên, bộ sách không chỉ đơn giản là tài liệu y học quý giá mà còn là tác phẩm triết học có vị trí hang đầu trong lịch sử tư tưởng phương Đông. “Hoàng Đế nôi kinh” cho rằng con người và tự nhiên có mối quan hệ khăng khít với nhau. Sự vận động biến đổi của tự nhiên luôn ảnh hưởng đến cơ thể. Không chỉ vậy bộ sách còn trình bày về mối quan hệ thống nhất biện chứng giữa cơ thể và tinh thần.   Về nền tảng y học, trong “Hoàng Đế nội kinh” là cả một hệ thống lý luận bao gồm bốn học thuyết lớn: tạng tượng (nghiên cứu chức năng sinh lý, tổ chức tạng phủ và quan hệ thống kinh lạc của cơ thể), bệnh cơ (nhiên cứu cơ chế nội tại của sự phát sinh, phát triển và biến đổi bệnh tật), chuẩn pháp (bốn phép chuẩn – vọng, văn, vấn, thiết) và trị tắc (nghiên cứu về nguyên tắc trị bệnh)   Ấn bản “Hoàng Đế nội kinh” được chúng tôi ra mắt lần này bao gồm cả hai quyển Tố Vấn và linh khu và Linh Khu được biên tập công phu, mỗi cuốn đầy đủ 81 thiên cả phần chữ Hán, phiên âm lẫn dịch nghĩa, đây không chỉ là bộ sách Hoàng Đế nội kinh Linh khu quý cho giới y học mà còn bổ ích cho các nhà nghiên cứu, học thuật.', N'86b1dd6e6d0ead92e04c4d6ddf8e6f03.jpg', 500, CAST(N'2017-02-25' AS Date), 41, 19, 13, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (116, N'00000000000000', N'Mai hoa dịch số', N'Mai hoa dịch số là bộ kỳ thư độc đáo trong lịch sử văn hóa Trung Hoa, là viên ngọc quý của khoa chiêm bốc dự đoán học, tương truyền do Thiệu Khang Tiết, nhà đại triết học đời Tống biên soạn. Nền tảng của Mai hoa dịch số là Kinh Dịch, nội dung của Mai hoa dịch số là các phép gieo quẻ và đoán quẻ rất linh hoạt, có thể gieo quẻ và đoán quẻ ở bất cứ nơi nào, bất cứ lúc nào, mức độ ứng nghiệm hết sức đặc sắc, xưa nay là môn chiêm bốc được ứng dụng rộng rãi và phổ biến trong mọi lĩnh vực của đời sống. Mai hoa dịch số cũng như các phép chiêm bốc khác đều dựa trên tượng số bát quái, những tượng số này thể hiện ở hầu hết mọi sự vật, tất cả đều xuất phát từ Kinh Dịch, cuốn sách kinh điển đứng đầu lục kinh', N'22214_b6u_sv_20150209_8935073097089_1.jpg', 500, CAST(N'2017-02-25' AS Date), 42, 19, 27, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (117, N'00000000000000', N'Trung Châu Tử Vi Đẩu Số - Tam Hợp Phái (Bộ 2 Tập)', N'Ngày nay, có thể nói Tử Vi Đẩu Số chia thành hai dòng chính: Một là, chủ yếu lấy "tinh diệu" để luận đoán, gọi chung là Tam Hợp phái (hay Nam phái). Trong số các chi lưu thuộc Tam hợp phái, thì phái Trung Châu Vương Đình Chi là có hệ thống hoàn bị nhất. Hai là, chủ yếu lấy "tứ hóa" để luận đoán, gọi chung là Tứ hóa phái (hay Bắc phái). Trong số các chi lưu thuộc hệ phái Tứ Hóa, thì Khâm Thiên Môn là có hệ thống nghiêm cẩn nhất. Riêng tại Trung Hoa lục địa, trào lưu nghiên cứu thuật số nói chung, và Tử Vi Đẩu Số nói riêng, cũng khá rầm rộ. Các lưu phái Tử Vi Đẩu Số ở đây phần lớn đều có khuynh hướng tổng hợp hai dòng chủ lưu kể trên. Trung châu tử vi đẩu số - tam hợp phái - Tập 1 Chương 1: Nhập môn tử vi đẩu số - Phái trung châu Chương 2: Đặc trưng hình dáng và diện mạo của các sao Chương 3: Tính tình của các sao Chương 4: Luận về cách cục Chương 5: Kĩ thuật luận đoán tinh bàn Chương 6: Ý nghĩa của bốn mươi hóa diệu Trung châu tử vi đẩu số - tam hợp phái - Tập 2 Chương 1: Chính diệu luận Chương 2: Phụ tá sát hóa diệu luận Chương 3: Tạp diệu luận Chương 4: Luận về sáu mươi tinh hệ Chương 5: Cung viên luận', N'trung-chau-tu-vi-dau-so-tam-hop-phai-(bo.jpg', 500, CAST(N'2017-02-25' AS Date), 43, 19, 13, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (118, N'00000000000000', N'Nghiên cứu về THIỀN UYỂN TẬP ANH', N'Bộ sách Nghiên cứu về Thiền uyển tập anh này là bản in lại của lần in thứ nhất năm 1976, biết dưới tên Thiền uyển tập anh, nhưng thường được trích dẫn bằng nhan đề như ta có trong lần tái bản đây. Về cơ bản nó không có gì thay đổi lớn so với lần in trước. Điều này có nghĩa nó vẫn có phần nghiên cứu về Thiền uyển tập anh, phần dịch và phần chú thích. Tuy nhiên, do gần một phần tư thế kỷ đã trôi qua, có một số tiến bộ về mặt nghiên cứu cũng như in ấn, nên trong lần in nầy có một số bổ sung mới.', N'15683212_1814389308778867_39429373_n.jpg', 500, CAST(N'2017-02-25' AS Date), 44, 19, 10, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (119, N'00000000000000', N'Chu Dịch Đại Truyện', N'Chu Dịch gồm hai phần: Kinh và Truyện. Cuốn sách này giới thiệu phần truyện tập trung vào: - Văn ngôn: giảng rộng thêm về hai quẻ Càn và Khôn. - Hệ từ (Thượng và Hạ): trình bày vũ trụ quan và nhận thức luận của người Trung Quốc cổ đại, giúp người đọc hiểu được ý nghĩa của “Quái Từ” và “Hào Từ”. - Thuyết quái: phân tích ý nghĩa tượng trưng cơ bản của Bát Quái. - Tự quái: giải thích 30 quẻ ở Thượng Kinh, 34 quẻ ở Hạ Kinh. - Tạp Quái: thuyết minh ý nghĩa của từng quẻ. Cuốn sách giúp ta hiểu nhiều hơn về Triết học cổ đại Phương Đông.', N'chu-dich-dai-truyen.jpg', 500, CAST(N'2017-02-25' AS Date), 45, 19, 28, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (216, N'00000000000000', N'Triết gia Trần Đức Thảo - Di cảo, khảo luận, kỷ niệm', N'Theo lời giới thiệu của nhà xuất bản, giáo sư Trần Đức Thảo (1917-1993) là nhà triết học lớn của thế kỷ 20, đã để lại một di sản triết học đồ sộ, phong phú, bàn về những vấn đề lớn của triết học và khoa học. Tuy nhiên, do nhiều lý do khách quan, hiện mới chỉ có một phần nhỏ tác phẩm của ông được giới thiệu với người đọc. Cuốn sách này ra đời là nỗ lực lớn của một tập thể gồm những nhà nghiên cứu triết học, nhà văn, nhà báo, nhà giáo trong và ngoài nước, nhằm cung cấp cho người đọc một nguồn tư liệu đầy đủ hơn về triết gia Trần Đức Thảo. Sách dày gần 1.700 trang với ba phần: di cảo, khảo luận, kỷ niệm, được tác giả Nguyễn Trung Kiên thực hiện trong 12 năm mà tác giả xem như là một cuộc “hành hương” đi qua nhiều miền đất triết học, hạnh ngộ biết bao tư tưởng, trí tuệ và tấm lòng dành cho triết gia Trần Đức Thảo.  - Minh Tự Theo tuoitre.vn', N'trietgiatran-sachkhaitam.jpg', 500, CAST(N'2017-02-25' AS Date), 46, 20, 24, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (217, N'00000000000000', N'TRIẾT HỌC CHO TRẺ EM 3 - HẠNH PHÚC THẬT VÀ GIẢ', N'" Làm sao bạn biết được bên trong bạn cảm thấy thế nào? Bạn có thể cảm thấy " vừa muốn khóc vừa muốn cười" được không? Nếu được thì cảm giác đó như thế nào? Bạn có thể yêu người bạn không biết được không? Có phải hai người giống nhau thì mới yêu nhau được không? Chúng ta có thể yêu ai đó chỉ vì thành tích của họ không ? Điều gì khiến chúng ta yêu người khác?"', N'tri%E1%BA%BFt-h%E1%BB%8Dc-cho-tr%E1%BA%BB-em-3.jpg', 500, CAST(N'2017-02-25' AS Date), 47, 20, 15, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (218, N'00000000000000', N'Ngẫu nhiên và tất yếu', N'Trong cuốn Ngẫu nhiên và tất yếu (Le Hasard et la Nécessité, 1970), từ những khám phá mới nhất về sinh vật học phân tử, Jacques Monod đề xuất một cách nhìn triết học mới về sự tiến hoá. Khác với các học thuyết được coi là “hữu linh”, tức là dựa trên giả thuyết cho rằng tự nhiên có “ý chí” hay “dự định” (như của Hegel, Marx, Engels, Bergson, Teilhard de Chardin, v.v.), Monod quan niệm rằng sự sống cũng như con người xuất hiện là do ngẫu nhiên. Tác giả cũng từ đó rút ra những kết luận chung về thái độ khách quan cần thiết trong khoa học và hiểu biết văn hoá hiện đại.', N'300_300_ngau-nhien-va-tat-yeu-bia-1.jpg', 500, CAST(N'2017-02-25' AS Date), 48, 20, 29, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (219, N'00000000000000', N'Định chế totem hiện nay', N'[...] ảo tưởng về tôtem chủ yếu là điều này: một triết gia không biết gì về dân tộc học như Bergson, và một triết gia khác, sống vào một thời đại trong đó khái niệm định chế tôtem còn chưa thành hình, đã có thể, trước các chuyên gia đương đại, và, trong trường hợp của Rousseau, trước ngay cả sự “phát hiện” ra định chế tôtem, thâm nhập bản chất của các tín ngưỡng và các tập tục mà họ không quen thuộc, hay còn chưa có ai tìm cách thiết lập sự hiện hữu. […] Do sự kì dị mà người ta gán cho nó, và lại còn bị các diễn giải của các nhà quan sát và các tư biện của các lí thuyết gia cường điệu, định chế tôtem đã được dùng, trong một thời gian, để tăng cường sự căng thẳng tác động trên các định chế nguyên thủy nhằm tách chúng với các định chế của chúng ta.   (Trích Chương 5: Định chế tôtem từ bên trong, Định chế tôtem hiện nay, Claude Lévi-Strauss, Nguyễn Tùng dịch, NXB Tri thức, 2017)', N'300_300_dinh-che-totem-bia-1.jpg', 500, CAST(N'2017-02-25' AS Date), 49, 20, 29, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (220, N'00000000000000', N'Bộ công cụ mới', N'Những người dám nói về tự nhiên như một đối tượng đã được nghiên cứu - họ làm điều đó là do quá tự tin hoặc do háo danh và thói quen thuyết giáo - đã gây ra một tổn thất to lớn cho triết học và cho các khoa học. Bởi vì, họ mạnh mẽ tới mức nào trong việc buộc người khác phải tin vào mình thì họ cũng thành công tới mức đó trong việc chặn đứng và bóp chết công việc nghiên cứu. Họ không hẳn đã mang lại lợi ích nhờ các năng lực của mình, mà chủ yếu gây ra tổn thất do đã lãng phí và giết chết năng lực của những người khác. Còn những người đi theo con đường đối lập và nhất quyết khẳng định rằng chúng ta không thể nhận thức được một cái gì cả đã đi tới sự tin tưởng ấy do họ căm ghét các nhà ngụy biện thời cổ đại, hoặc là do tinh thần yếu ớt, hay thậm chí là do có một kiểu thông thái nào đó, đã viện dẫn những lí do không nên coi thường. Tuy nhiên, trong ý kiến của mình, họ không xuất phát từ các cơ sở chân thực, và khi bị khát vọng và lòng nhiệt tình lôi cuốn về phía trước thì họ lại đi quá xa. Những người Hi Lạp cổ nhất (mà tác phẩm của họ đã bị thất lạc) giữ một lập trường hợp lí hơn giữa những phán đoán dứt khoát đầy tự tin và thái độ thất vọng. Mặc dù họ thường kêu ca và phàn nàn về khó khăn trong việc nghiên cứu và về sự bí ẩn của các sự vật, song cắn răng chịu đựng, họ không ngừng vươn tới mục đích và thử nghiệm giới tự nhiên. Như đã rõ, họ cho rằng vấn đề này (nghĩa là việc có thể nhận thức được một cái gì đó hay không) được giải quyết không phải bằng tranh luận mà bằng kinh nghiệm. Nhưng, khi chỉ biết đến sức mạnh của lí tính, cả họ cũng không dựa vào các quy tắc, mà vẫn thường trông cậy vào tư duy sắc sảo, vào tính năng động và tính tích cực của trí tuệ.', N'300_300_bo-cong-cu-moi-bia-1.jpg', 500, CAST(N'2017-02-25' AS Date), 50, 20, 29, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (221, N'00000000000000', N'Albert Einstein mặt nhân bản những góc nhìn qua các bức thư từ kho lưu trữ', N'“Không một ngày  Không có EinstEin” “ Và rồi einstein ở đâu hôm nay? Trong những tìm tòi, nghiên cứu, trong những thí nghiệm, tính toán của chúng ta. Trong những cuốn sách giáo khoa đại học từ vật lý đến lịch sử văn hóa. Trong những lời nói dí dỏm của chúng ta. Trong trái tim bạn bè và đồng nghiệp của chúng ta, những người gọi điện lúc nửa đêm kể cho nhau nghe về một ý tưởng ngớ ngẩn để giải một bài toán ngớ ngẩn. Trong trái tim những nghệ sĩ, doanh nhân, thợ điện và triết gia mà chúng ta gặp, những người muốn biết công thức e = mc2 thực sự có nghĩa gì ngay khi họ biết chúng ta là những nhà vật lý. Trong tất cả những người trí thức biết làm thế nào để dễ thương, khiêm tốn và đùa bỡn với truyền thông. Trong những người tỏ rõ lập trường. Trong mỗi cuộc biểu tình chống lại vũ khí hạt nhân. Trong tất cả những người trẻ biểu lộ một chút bất kính đối với quyền uy, và trong tất cả những người lớn tuổi uy tín có tư tưởng cấp tiến. Trong những người đã trốn chạy khỏi những gia đình độc tài, áp bức và những nhà giáo dục đầu óc hẹp hòi. Trong tất cả sinh viên của chúng ta, những em có thể giải được một bài toán mà chúng ta không thể giải. Trong tất cả những người chúng ta nghĩ là thiên tài thơ ngây không xem mình là quan trọng lắm. Trong tất cả những nhà vật lý cứng đầu và khó tính, những người nghĩ về những bài toán vật lý như lý do tồn tại của mình. Và trong tất cả những người tìm cách giải quyết những bài toán mà họ biết họ không thể hay sẽ không giải được.” maria piropulu', N'biahop_einsteinmatnhanban.jpg', 500, CAST(N'2017-02-25' AS Date), 51, 20, 19, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (222, N'00000000000000', N'Phê phán năng lực phán đoán', N'Phê phán năng lực phán đoán là quyển Phê phán thứ 3 và, như Kant nói trong lời tựa của lần xuất bản thứ nhất, “với công trình này, tôi đã hoàn tất toàn bộ công cuộc phê phán của mình”. Hai quyển trước là “Phê phán lý tính thuần túy” nhằm trả lời câu hỏi “Tôi có thể biết gì?” và “Phê phán lý tính thực hành” trả lời câu hỏi “Tôi phải làm gì?”. Câu hỏi thứ 3 “Tôi có thể hy vọng gì?” được Kant dành cho các bài viết và các công trình nghiên cứu tương đối ngắn viết về triết học lịch sử và triết học tôn giáo . Quyển Phê phán năng lực phán đoán là cầu nối cho cả ba câu hỏi trên, và tìm cách trả lời cho câu hỏi thứ tư, bao trùm ba câu hỏi trên do chính Kant đặt ra: “Con người là gì?” bằng cách gợi lên vấn đề mới: Tôi có thể cảm nhận và suy tưởng như thế nào về bản thân và thế giới xung quanh mình. Phê phán năng lực phán đoán là một tác phẩm có kết cấu đa tầng, thực hiện hai chức năng: một mặt thực hiện chức năng hệ thống như là phần kết thức đóng góp về mặt phương pháp luận cho việc thúc đẩy luân lý và nghiên cứu về khoa học tự nhiên. Vì thế, tác phẩm này được đánh giá như một “viên đá đỉnh vòm” của toàn bộ tòa nhà triết học.', N'phephannang-sachkhaitam.jpg', 500, CAST(N'2017-02-25' AS Date), 52, 20, 29, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (223, N'00000000000000', N'Phê Phán Lý Tính Thuần Túy - Trọn bộ 2 tập', N'Phê phán lý tính thuần túy là tác phẩm chính yếu của I. Kant, đồng thời cũng là tác phẩm nền tảng của triết học cổ điển Đức, danh tác bất hủ của văn hóa Tây phương và thế giới – lần đầu tiên được dịch đầy đủ sang tiếng Việt và được chú giải công phu nhân kỷ niệm 200 năm ngày mất và 280 năm ngày sinh của triết gia. Mấy lưu ý của người dịch: 1) “Phê phán lý tính thuần túy” của Immanuel Kant được mọi người thừa nhận là tác phẩm nền tảng của triết học cổ điển Đức. Nó là chỗ kết tinh những nhận định có tính phê phán đối với nhiều trào lưu triết học trước đó (từ Platon cho tới Christian Wolff), đồng thời là điểm xuất phát và điểm quy chiếu của triết học cổ điển (duy tâm) Đức (Fichte, Schelling, Hegel) và có ảnh hưởng sâu đậm đến sự phát triển của triết học và khoa học Tây phương cho đến ngày nay. Song, “Phê phán lý tính thuần túy” không chỉ là một tác phẩm “bắt buộc phải đọc” của những ai muốn tìm hiểu và nghiên cứu triết học mà còn là một danh tác bất hủ của văn hóa Tây phương và của thế giới. Tác động của nó vượt ra khỏi lãnh vực chuyên môn của triết học. Hai đặc điểm nổi bật của tác phẩm là: một mặt, việc phê phán Siêu hình học cổ truyền đã làm rung chuyển cơ sở siêu hình học-thần học của thế giới quan truyền thống và do đó, là diễn đàn của “lý tính con người” buộc mọi thứ phải phục tùng sự “kiểm tra và phê phán tự do và công khai”. Mặt khác, tác phẩm phát triển những tiền đề cơ bản để nhận chân quyền tự do và tự trị của con người với tư cách là sinh vật có lý tính, tạo cơ sở cho sự tự-nhận thức về mặt đạo đức và pháp quyền của xã hội hiện đại. Trong ba quyển “Phê phán” nổi tiếng của Immanuel KANT (Phê phán lý tính thuần túy; Phê phán lý tính thực hành và Phê phán năng lực pháp đoán), tác phẩm này có vị trí đặc biệt. Nó ra đời trước (1781), có nội dung rất phong phú, ngoài ra cũng dày và phức tạp nhất!. Xét về bản thân hệ thống, ta đều biết - và chính Kant xác nhận -, hai quyển sau mới bộc lộ phần tinh túy của triết học Kant, tuy nhiên, “Phê phán lý tính thuần túy” vẫn thường được xem là tác phẩm chính yếu gắn liền với tên tuổi Kant và là tiền đề để thực sự hiểu được hai tác phẩm sau. Nếu “Phê phán lý tính thực hành” (1788) (và gắn liền với nó là tác phẩm khá ngắn nhưng quan trọng: “Đặt cơ sở cho Siêu hình học về đức lý” (Grundlegung zur Metaphysik der Sitten, 1785) khẳng định tính “thứ nhất” (das Primat) của lý tính thuần túy thực hành và sinh hoạt đạo đức so với lý tính thuần túy lý thuyết để trả lời câu hỏi “Tôi phải làm gì?”; và “Phê phán năng lực phán đoán” (1790) - trong đó Kant bàn về Mỹ học và Mục đích luận - là “viên đá cuối cùng” (Schlussstein) để hoàn tất mái vòm của cả tòa nhà triết học (Tôi có thể hy vọng gì?), thì “Phê phán lý tính thuần túy” này (Tôi có thể biết gì?) là hòn đá tảng tạo nên cơ sở lý luận cho triết học Kant. Vì lý do đó, tôi chọn dịch và giới thiệu tác phẩm này trước. (Tác phẩm này đã được dịch - và chú giải - trong hầu hết các ngôn ngữ quan trọng trên thế giới. Ở Châu Á, riêng Nhật Bản đã có từ lâu hai bản dịch “Toàn tập Kant” và nhiều bản dịch khác nhau về các tác phẩm chính của Kant). 2) Bên cạnh vị trí then chốt của tác phẩm này trong triết học Kant, vị trí và ý nghĩa lịch sử của quyển “Phê phán lý tính thuần túy” càng nổi bật hơn khi được đặt trong toàn cảnh sự phát triển của triết học cận đại Tây phương. Từ thời cổ đại, triết học Tây phương không chỉ được hiểu như là “yêu thích sự minh triết” (philo-sophia), nhất là với Socrate (470-399 t.T.L) và Platon (427-347 t.T.L) mà còn là tri thức hay khoa học, nhất là từ Aristote (384-322 t.T.L). Không chỉ hướng đến cuộc sống thiện lương và hạnh phúc, triết học còn được quan niệm như sự thấu hiểu (episteme), qua đó câu hỏi về thế đứng của nó như là khoa học (scientia) và học thuyết (doctrina) đã sớm được đặt ra. Nhưng chỉ đến thời cận đại với sự ra đời của khoa học tự nhiên, câu hỏi về tính khoa học của triết học mới có tính thời sự cấp thiết. Các triết gia phải đáp ứng yêu cầu mang lại một “tri thức” nào đó, dù dưới hình thức này hay hình thức khác, bằng cách thiết lập nền móng mới mẻ cho triết học. Nhưng đồng thời, triết học vẫn muốn giữ vững yêu sách cố hữu của mình là một “scientia universalis” (“khoa học phổ quát”), tức không muốn và không thể trở thành một khoa học riêng lẻ bên cạnh những ngành khoa học khác mà cố gắng trở thành “khoa học của mọi ngành khoa học”. Từ bối cảnh ấy nảy sinh nhiều con đường khác nhau để tạo nên diện mạo mới cho triết học. Các con đường này đang xen nhau, khó tách bạch nhưng tựu trung có ba dạng: - hoặc triết học tự vừa lòng với việc tập hợp những thành quả của các khoa học riêng lẻ, rồi tổng hợp chúng lại theo một trật tự nào đó. Con đường này ít được ưa chuộng, hoặc nếu có, chỉ là thứ yếu hoặc bị che đậy. - hoặc triết học với tư cách là nhận thức luận hay khoa học luận có tính phản tư (reflexiv) nỗ lực rút ra các nguyên tắc của nhận thức (khoa học) theo kiểu nhận thức ở cấp độ cao hơn – gọi là nhận thức siêu-kinh nghiệm (transempirisch) hay siêu-hiện tượng (metaphänomenal), tức là nhận thức về nhận thức – nhằm lý giải các nguyên tắc của nhận thức nói chung. Con đường này là đặc trưng của triết học Anh. - hoặc triết học với tư cách là một khoa học “đi trước” hay “khoa học nền tảng” (Fundamentalwissenschaft), dựa vào các nguyên tắc có giá trị phổ quát và hiển nhiên để đặt một nền móng vững chắc cho các khoa học thường nghiệm và toán học vốn chỉ có tính giả thuyết và trong chừng mực đó, đưa chúng vào một hệ thống. Đây là con đường của triết học Châu Âu lục địa. Hai con đường sau đánh dấu sự ra đời một mặt của các lý luận về nhận thức và mặt khác, của các hệ thống siêu hình học đầu tiên của thời cận đại. Tuy về căn bản, cả hai con đường đều muốn vượt lên trên các khoa học riêng lẻ bằng một nền triết học dựa trên các nguyên tắc (có tính phản tư hoặc đặt nền tảng) nhưng đều không dẫn đến kết quả thực sự thuyết phục vì trong mỗi con đường đều tồn tại hay nảy sinh những vấn đề khó khăn không giải quyết được. Sau Francis Bacon (1561-1626), John Locke (1632-1704) là người đầu tiên đề ra một môn nhận thức luận toàn diện, quy mọi ý niệm (ideas) của ta (kể cả những ý niệm về toán học và luân lý) vào tri giác cảm tính, mang lại một bước ngoặt nhân loại học và tâm lý học còn ảnh hưởng mạnh mẽ đến ngày nay của triết học Anh. George Berkeley (1685-1753) và David Hume (1711-1776) tiếp tục phát triển luận điểm của Locke theo hướng “duy hiện tượng” và “thực chứng”, một mặt nhấn mạnh đến tính không thể chứng minh được về lý thuyết đối với mối quan hệ giữa những biểu tượng của ta với thực tại khách quan, mặt khác, đến sự tất yếu về thực hành phải giả định sự tồn tại của thực tại khách quan. Trong khi nhận thức luận duy nghiệm của Anh ngay từ rất sớm đã mang tính hoài nghi thì siêu hình học duy lý (có định hướng toán học) thống trị ở Châu Âu lục địa vẫn hoàn toàn vững tin vào những nhận thức “hiển nhiên” mang đậm tính giáo điều. René Descartes (1596-1650) tin rằng có thể xây dựng triết học thành một môn khoa học nền tảng, phổ quát, tức một hệ thống gồm những nguyên tắc hiển nhiên được rút ra từ lý tính thuần túy, hay nói khác đi, từ điều hiển nhiên duy nhất là sự tự-xác tín của Tự-ý thức, do đó Descartes còn được gọi là cha đẻ của Siêu hình học cận đại trong hình thức của triết học về chủ thể hay triết học về ý thức. Nhưng trong hàng ngũ của Siêu hình học duy lý cũng có sự cạnh tranh quyết liệt giữa các mô hình khác nhau. Khác với “cái Tôi” của Descartes, Baruch Spinoza (1632-1677) xem Thượng đế hay Tự nhiên là Bản thể duy nhất và tuyệt đối, còn mọi thực tại khác đều là những thuộc tính và cách thái (Modi) của Bản thể này. Gottfried Wilhelm Leibniz (1646-1716) lại giả định một số lượng vô tận của những bản thể đơn giản (“những đơn tử”/Monaden) chứa đựng toàn bộ thế giới như là hiện tượng trong những “tri giác” của chúng. Descartes và cả Spinoza, Leibniz đều cho rằng giả định của mình là hiển nhiên và Siêu hình học do mình lập ra mới là khoa học nền tảng đích thực. Nói khái quát, vào giữa thế kỷ 18, triết học Tây phương chứng kiến sự đối lập giữa hai “lề lối suy tư”: nhận thức luận duy nghiệm, hoài nghi kiểu Anh và Siêu hình học duy lý, giáo điều kiểu Châu Âu lục địa. Trong tình hình đó, Immanuel Kant (1724-1804) thấy bức thiết phải đặt lại câu hỏi về khả thể của Siêu hình học như là khoa học. Ông xem triết học của mình như là con đường thứ ba giữa thuyết giáo điều và thuyết hoài nghi, giữa thuyết duy lý và thuyết duy nghiệm. Quyển Phê phán lý tính thuần túy lý giải và khẳng định khả thể của khoa học thường nghiệm, đồng thời bác bỏ khả thể trở thành khoa học của Siêu hình học duy lý. Chỉ trong kinh nghiệm về cái “Phải làm”, tức trong lãnh vực đạo đức và nhân sinh của lý tính thực hành, ta mới có được sự tiếp cận nào đó với cái Tuyệt đối, qua đó cái Tuyệt đối (Thượng đế, tự do, linh hồn bất tử...) của tôn giáo cũng được quy về cho Đạo đức học. Mặt khác, với Kant, dù lý tưởng của triết học vẫn là tri thức có tính nguyên tắc và tính hệ thống, thậm chí là tri thức tổng hợp-tiên nghiệm, nhưng về cơ bản, triết học đã trở thành sự phê phán và tự phê phán toàn diện. Ngay khi Kant còn sống, sự giải phóng về tôn giáo và chính trị nhờ vào phong trào Khai sáng và Đại Cách mạng Pháp đã tạo ra những kích thích mới mẻ về tinh thần và xã hội. Tư tưởng cộng hòa cách mạng lan tràn khắp nơi đòi hỏi thế hệ kế tiếp ngay sau Kant tiếp tục đi tìm một sự xác tín đầu tiên và tuyệt đối, một nhận thức “cao hơn” bằng cách quay trở lại với loại nhận thức tuyệt đối, tức một nền Siêu hình học tư biện mới mẻ với Johann Gottlieb Fichte (1762-1814), Friedrich W. Joseph Schelling (1785-1854) và Georg W. Friedrich Hegel (1770-1831). Dù một số luận điểm cơ bản của Kant bị các thuyết duy tâm tuyệt đối này phản bác và cải biến (nhất là đối với khái niệm “vật tự thân” vừa không thể nhận thức được, vừa vẫn tất yếu phải được suy tưởng), nhưng luôn lấy Kant làm điểm xuất phát và quy chiếu, nhất là vẫn giữ vững tinh thần phê phán của Kant. Và cũng chính tinh thần phê phán này của Kant sẽ thâm nhập vào tâm thức của các thế hệ triết gia sau đó, dẫn đến sự “sụp đổ” của hệ thống duy tâm tuyệt đối này vào nửa đầu thế kỷ 19 với sự ra đời mạnh mẽ của triết học hiện đại, khởi đầu với các tên tuổi lớn như Arthur Schopenhauer (1788-1860), Ludwig Feuerbach (1804-1872), Karl Marx (1818-1883), Sưren Kierkegaard (1813-1855) và Friedrich Nietzsche (1844-1900)... Có thể nói, “Phê phán lý tính thuần túy” với hạt nhân là tinh thần phê phán của nó đã khép lại một giai đoạn, mở ra một thời kỳ và tiếp tục gây ảnh hưởng sâu đậm đến tương lai. Tác phẩm có vị trí đặc biệt này, do đó, đáng được quan tâm một cách đặc biệt. 3) “Phê phán lý tính thuần túy” có hai ấn bản chính: ấn bản lần thứ nhất năm 1781 (thường gọi là bản A) và ấn bản lần thứ hai năm 1787 (thường gọi là bản B, Kant gọi là “ấn bản được chữa đi chữa lại nhiều lần”). Nhờ tác giả “chữa đi chữa lại”, bản B thường được dùng phổ biến làm căn cứ để nghiên cứu và trích dẫn. Trong bản B, Kant viết lại hoặc bổ sung thêm một số phần vốn khó hiểu hoặc quá vắn tắt trong bản A: viết Lời tựa mới, mở rộng Lời dẫn nhập, viết lại phần “Diễn dịch siêu nghiệm các khái niệm thuần túy của giác tính” (B130-B169), bổ sung chương “Về cơ sở phân biệt mọi đối tượng nói chung ra làm Phänomena [những hiện tượng] và Noumena [những vật tự thân” (B295-B315), viết lại phần “Võng luận của lý tính thuần túy” (B407-B431). Bản dịch này căn cứ vào nguyên bản B (NXB FELIX MEINER VERLAG, HAMBURG, 1998). Các phần dị biệt còn lại trong bản A như vừa kể trên đều được dịch đầy đủ vì xét thấy chúng có tầm quan trọng riêng biệt. Như vậy, bản dịch này bao gồm trọn vẹn cả bản A lẫn bản B. Để việc tra cứu và trích dẫn được thống nhất và thuận tiện theo thói quen của những nhà nghiên cứu về Kant, trên lề trái của mỗi trang đều có đánh số trang theo nguyên bản (Vd: B100 = trang 100 trong nguyên bản B xuất bản năm 1787, hoặc A100 = trang 100 trong nguyên bản A xuất bản năm 1781). Những chỗ không có khác biệt giữa bản A và bản B, chỉ được đánh số trang theo bản B để đỡ rườm. 4) Chú thích cuối trang: số Á Rập: (1); (2)… là chú thích của tác giả; dấu sao (*) là của người dịch (viết tắt: N.D). Phần chú thích của người dịch ở ngay cuối trang thường là để giải thích ngắn gọn các chữ khó giúp bạn đọc đỡ mất công tra cứu và đọc tiếp dễ dàng. Về nội dung chi tiết các thuật ngữ, bạn đọc có thể tìm thêm trong “Mục lục vấn đề và nội dung thuật ngữ” ở cuối sách. Dấu [  ] là phần nói thêm của người dịch để ý câu văn được rõ hơn, và do đó, không có trong nguyên bản. Để đỡ nhàm chán, tôi tự cho phép mình nhấn mạnh bằng cách in nghiêng hoặc in đậm một số từ và một số câu xét thấy quan trọng. Dịch thuật ngữ bao giờ cũng là công việc khó khăn nhất. Tôi cố tránh dùng các thuật ngữ quá mới lạ hay cầu kỳ và sau các thuật ngữ do tôi đề nghị dịch ra tiếng Việt thường có ghi thêm thuật ngữ trong nguyên tác tiếng Đức để người đọc tiện so sánh hoặc có thể đề nghị cách dịch khác tốt hơn. 5) Đọc và hiểu triết học cổ điển Đức trong nguyên bản là việc khá vất vả, thậm chí là một “khổ hình” như nhiều người thừa nhận. Tuy nhiên, công bình mà nói, văn Kant tuy nặng nề, phức tạp, nhưng rất mạch lạc và sáng sủa, có khi lại rất ý vị và duyên dáng (nhất là ở phần II: Học thuyết siêu nghiệm về phương pháp), chứ không đến nỗi vừa nặng nề vừa tối tăm, kỳ ảo như văn Hegel sau này. Trong khi dịch, tôi cố gắng tăng cường tính mạch lạc và sáng sủa đồng thời giảm bớt phần nặng nề. Nhằm mục đích đó, ở nhiều chỗ, tôi buộc phải chấm câu lại cho gãy gọn (câu văn ông thường rất dài, có khi hơn nữa trang giấy!) được đánh dấu | (ở những nơi đó, Kant viết liền một mạch hoặc dùng dấu (,) hay (;)), mặc dù cố theo sát, không bỏ sót điều gì cũng như không tùy tiện thay đổi trật tự câu văn. Về phần người dịch, dù sao, đây chỉ là cố gắng của một cá nhân nên thành thật mong các bậc cao minh chỉ giáo những chỗ sai sót không thể tránh khỏi trong khi chờ đợi sự ra đời của các bản dịch khác tốt hơn trong tương lai. Tuy biết là việc làm quá sức mình nhưng dịch và chú giải Kant thực ra chính là dịp để được tự học lại Kant phần nào mà thôi. 6) Kant thuộc số không nhiều lắm những đại triết gia đã lưu lại dấu ấn và ảnh hưởng lâu dài và sâu đậm trong lịch sử triết học. Do đó, tìm hiểu Kant về nội dung là rất cần thiết để hiểu triết học cận và hiện đại. Nhưng đồng thời, về phong cách diễn đạt, tính mạch lạc, chặt chẽ và có hệ thống trong các lập luận của Kant cũng là mẫu mực giúp ta làm quen với lối suy tư Tây phương - Âu Châu. Đọc Kant ngay trong nguyên bản là cách tốt nhất để tiếp cận trực tiếp với thuật ngữ và tản văn triết học. Tuy nhiên, chúng tôi cũng đưa thêm phần Dẫn luận (giới thiệu khái quát về tác giả và tác phẩm) ở đầu sách do THÁI KIM LAN viết và phần Chú giải dẫn nhập đi sâu hơn vào chi tiết do tôi soạn đặt ở cuối mỗi chương với mục đích khiêm tốn: giúp các bạn đọc mới lần đầu tiếp xúc với Kant đỡ phần nào bỡ ngỡ và lúng túng, mặc dù có thể không cần thiết với người đọc đã thành thạo. Phần Chú giải dẫn nhập sẽ tóm tắt những ý chính trong chương, giải thích các chỗ khó hiểu, sắp xếp lại những bước lập luận của tác giả cho dễ theo dõi, và trong chừng mực cho phép, có đề cập qua những cách lý giải khác nhau cũng như tình hình thảo luận hiện nay liên quan đến nội dung vấn đề đang tìm hiểu. Chú giải dẫn nhập - đúng với tên gọi - chỉ là phần trợ giúp cho người đọc, không có tham vọng tát cạn vấn đề, càng không nhằm đưa ra những nhận định, đánh giá vốn là công việc dành cho người đọc và của những công trình nghiên cứu chuyên sâu khác. Tuy nhiên, với những bạn đọc có ít thời gian, phần Chú giải dẫn nhập cũng có thể giúp có một cái nhìn khái quát và tương đối ngắn gọn về toàn bộ tác phẩm quá dài và khô khan này[1]. Đúng như nhiều người đã nhận định: đọc tiểu sử của Kant (ở cuối sách), ta có thể thấy buồn cười hoặc thú vị trước lối sống quá đơn điệu và âm thầm của ông, nhưng nụ cười ấy sẽ tắt dần khi đi vào đọc ông, vì để theo dõi được tư tưởng của Kant, nhiều lúc ta cảm thấy nghi ngờ về khả năng trí tuệ của chính mình!. Nhưng khi đã phần nào theo dõi được ông, quả thật ta bắt đầu thụ hưởng điều mà cổ nhân gọi là sự hỷ lạc về tinh thần!. Là người đọc từ phương Đông, chúng ta đặc biệt cảm nhận niềm “hỷ lạc” ấy về cả hai mặt: cuộc đời và phong cách suy tưởng của Kant. Đó là một cuộc đời an nhiên và cao nhã của một bậc hiền triết sống nhất quán với tư tưởng và niềm tin của mình (trước khi mất vào tuổi 80, ông chỉ nói một câu: “Thế là tốt!” giống như thi hào Nguyễn Du của chúng ta). Về tư tưởng, ông nêu những vấn đề rất to tát nhưng với giọng điệu thân mật, ôn tồn, “tuần tuần thiện dụ” giúp ta đỡ “sợ”, để rồi lần lượt đề nghị giải quyết những câu hỏi lớn lao ấy một cách sâu sắc nhưng giản dị, khiêm tốn, cận nhân tình khiến ta không khỏi liên tưởng đến tinh thần “đạo bất viễn nhân” khá gần gũi của đức Khổng: “… Triết học chỉ làm sáng tỏ điều mà trước đây ta chưa thấy hết, đó là: đối với những vấn đề liên quan thiết thân đến mọi người, Tự nhiên không bao giờ thiên vị và sẵn sàng phân phối quà tặng cho mọi người chúng ta một cách công bằng, không phân biệt. Và đối với các cứu cánh cơ bản và tối hậu của con người, không có nền triết học cao siêu nào có thể hướng dẫn cho ta bằng sự hướng dẫn mà Tự nhiên đã phú bẩm cho lương năng bình thường nhất (Phê phán lý tính thuần túy, B859). Mặt khác, chỗ mới mẻ đã nâng vị trí của Kant thành một trong số ít người đã tiên phong mở đường cho nên văn hóa hiện đại - cũng như cho công cuộc hiện đại hóa văn hóa - là ở năng lực tự phê phán toàn diện của con người[2] để: “Con đường triết học phải đi là con đường của sự minh triết, đồng thời cũng là con đường của khoa học, mà một khi đã được khai phá sẽ không bao giờ để cho bị vùi lấp lại và làm ta lạc hướng” (B878). “Sự đào luyện lý tính con người” (B879) là mục đích của Kant và cũng là lời mời gọi nhiều thế hệ người đọc thử tìm hiểu con đường ông đã khai phá ấy. Bản dịch này được ra mắt vào đúng dịp kỷ niệm 200 năm ngày mất (1804) và 280 năm ngày sinh (1724) của Kant là nhờ sự khuyến khích và giúp đỡ của nhiều người mà tôi xin phép được tỏ lòng biết ơn chung ở đây. Đặc biệt, xin cảm ơn: - chị Thái Kim Lan đã gợi ý việc dịch và tham gia tài trợ cùng với Ts. W. Bưhne (Trung tâm giao lưu Đức-Á) và Viện Văn hóa Goethe (Goethe-Institut) để ấn hành tập sách này; - ông bạn thân Trương Văn Hùng (Strassbourg, Pháp) đã góp nhiều ý kiến quý báu về việc dịch triết học Đức sang tiếng Việt và xem lại một phần bản dịch (tất nhiên, mọi sai sót là hoàn toàn thuộc về trách nhiệm của người dịch); - Ông Nguyễn Văn Lưu, Giám đốc Nhà Xuất Bản Văn Học và Ông Lê Nguyên Đại, Giám đốc Công ty Văn Hóa Thời Đại đã khuyến khích và tận tình hỗ trợ việc xuất bản; - cử nhân Nguyễn Hiền đã giúp đỡ về kỹ thuật vi tính. Theo Sachhay.org', N'phe-phan-ly-tinh-thuan-tuy-tron-bo-2-tap.jpg', 500, CAST(N'2017-02-25' AS Date), 52, 20, 17, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (224, N'00000000000000', N'Những Tư Tưởng Lớn Từ Những Tác Phẩm Vĩ Đại', N'Cuốn sách các bạn đang cầm trên tay là một tập hợp những câu hỏi và trả lời. Những câu hỏi này được đặt ra cho tác giả, một chuyên gia về lịch sử tư tưởng phương Tây, từ những độc giả thuộc đủ mọi tầng lớp xã hội Mỹ muốn tìm hiểu về đủ loại vấn đề. Nhìn chung đông đảo độc giả muốn biết các nhà tư tưởng trong quá khứ suy giải và lý luận như thế nào về những vấn đề mà con người hôm nay đang phải đối mặt. Họ không mưu cầu tìm một câu trả lời dứt khoát, một giải pháp rốt ráo, mà thường họ muốn hiểu rõ vấn đề và muốn rút được bài học từ các nhà tư tưởng lớn trong truyền thống triết học phương Tây. Những câu hỏi này được tác giả trả lời trong chuyên mục của ông, ban đầu chỉ được đăng tải trên tờ Chicago Sun-Times và Chicago Daily News. Trong vòng một năm sau khi ra đời, đã có tới 28 tờ báo mua bản quyền để đăng tải chuyên mục này (trong đó có tờ Kenkyu Sha ở Tokyo). Sự thành công của chuyên mục đã đưa tới việc tập hợp những câu hỏi và trả lời thành một cuốn sách.', N'nhung-tu-tuong-lon-tu-nhung-tac-pham-vi-.jpg', 500, CAST(N'2017-02-25' AS Date), 53, 20, 18, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (225, N'00000000000000', N'Đối Thoại Socratic 1', N'Đối thoại Socratic 1 tập hợp một số tác phẩm tiêu biểu của Plato, bao gồm Euthyphro, Socrates tự biện, Crito, Pheado. Ngoài ra, cuốn sách còn có những chú giải chi tiết và phần dẫn nhập của dịch giả Nguyễn Văn Khoa, tập trung vào những vấn đề lí luận trong Hi Lạp học nói chung và Socrates học nói riêng, như quan hệ phức tạp giữa Socrates và Plato, sự phát triển và suy vong của nền dân chủ Athens, nội dung và phong cách triết lí của Socrates. Mỗi dẫn nhập vào từng đối thoại nhằm nêu lên các vấn đề triết học đặc thù của nó, giúp cho việc tiếp cận các tác phẩm kinh điển này được dễ dàng hơn. ------------------------------------- Trích sách “Socrates tin vào tôn giáo và Thành quốc, trên bình diện tinh thần và chân lý – còn họ, họ tin nơi mặt chữ. Các thẩm phán và Ông không đứng trên cùng một sân chơi. Giá mà Ông giải thích rõ rệt hơn, người ta đã có thể thấy ngay rằng Ông không tìm kiếm thần linh mới, không bỏ rơi các vị thần của Athens: Ông chỉ cho các thần ấy một ý nghĩa, chỉ giải thích các vị. Điều bất hạnh là thao tác này lại không vô tội đến thế. Chính trong thế giới của triết gia mà người ta cứu hộ được thần thánh và luật pháp bằng sự hiểu biết, và để bố trí sân chơi của triết học trên mặt đất, đúng là cần phải có những triết gia kiểu Socrates. Nhưng tôn giáo được giải thích, đối với kẻ khác, đấy là tôn giáo bị thủ tiêu, và quan điểm của họ về Ông chính là lời kết tội báng thần. Ông đưa ra những lý lẽ để tuân hành pháp luật, nhưng mà phải có lý do mới tuân thủ đã là điều quá đáng: có lý do này thì sẽ có lý do kia chống lại, còn đâu là sự tôn kính nữa. Điều mà người ta chờ đợi ở Ông chính là điều Ông không thể cho: nhắm mắt tuân hành không có lý do. Socrates, ngược lại, ra trình diện trước các thẩm phán, nhưng để giải thích cho họ Thành quốc là gì. Như thể họ không biết, như thể họ không phải là Thành quốc. Ông không bào chữa cho mình, Ông biện hộ cho chính nghĩa của một thành quốc biết chào đón triết học. Ông đảo ngược vai trò và nói với họ: tôi đâu có bào chữa cho tôi mà cho quý ông đấy. Rốt cuộc thì Thành quốc ở trong Ông, còn họ mới là kẻ thù của luật pháp, chính họ mới là kẻ bị xét xử, còn ông là quan tòa. Một sự lộn đảo không tránh được nơi Triết gia, bởi vì Ông biện chính cho cái vỏ ngoài bằng loại giá trị xuất phát từ bên trong” (Trích “Socrates thành Athens, tên hành khất và bà đỡ”, Đối thoại Socratic 1, Plato)', N'doi-thoai-socratic-1.jpg', 500, CAST(N'2017-02-25' AS Date), 54, 20, 29, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (226, N'00000000000000', N'Trò Chuyện Triết Học - Bộ 2 Tập', N'TRIẾT HỌC NHƯ MỘT CUỘC TRÒ CHUYỂN Ở nơi chợ búa ồn ã bán mua, nơi chợ đời bụi bặm, triết học héo lánh tới làm gì, có héo lánh tới nổi không? Hẳn nhiều người đã không khỏi ái ngại, đặt ra câu hỏi ấy khi thấy trên tờ Sài Gòn Tiếp Thị - mà như tên gọi của nó, là cầu nối giữa doanh nghiệp và người tiêu dùng, nơi tiếp cận thị trường của doanh nghiệp, nói cách khác là một thứ chợ - xuất hiện một chuyên mục gọi là “Trò chuyện triết học”. Với nhiều người, triết học là cái gì đó cao siêu, xa vời, chỉ có thể “kính nhi viễn chi” chứ chẳng ăn nhập gì với cuộc sống trần trụi, với thời buổi mà con người phải lặn hụp mệt nhoài trong cuộc mưu sinh, phải nhanh mắt nhanh tay chụp giựt cho mình những thứ có thể chụp giựt được, phải đối diện với bao nhiêu câu hỏi, bao nhiêu thách thức của cuộc sống trước mặt. Nói tóm lại, triết học là cái gì đó vô bổ, chỉ để dành cho những kẻ “rỗi hơi”. Ấy thế mà “ngạc nhiên chưa”!? Kể từ bài đầu tiên xuất hiện vào ngày 25.5.2010 trên Sài Gòn Tiếp Thị đến bài cuối cùng được tập hợp trong “Trò chuyện triết học” này, xuất hiện trên báo vào ngày 16.4.2012, qua gần hai năm với 92 bài báo của tác giả Bùi Văn Nam Sơn, chuyên mục đã được đông đảo bạn đọc đón nhận như một món ăn tinh thần khó thể bỏ qua khi cầm tờ Sài Gòn Tiếp Thị mỗi thứ tư hàng tuần. Nhiều bạn đọc, thuộc nhiều môi trường nghề nghiệp, bối cảnh xã hội, lứa tuối khác nhau, đã phản hồi đầy hứng khỏi như được thỏa mãn một nhu cầu, một khao khát từ lâu không đuợc đáp ứng, dù không phải lúc nào họ cũng đồng ý hoàn toàn với tác giả. Những tưởng trong thời buổi hội nhập, toàn cầu hóa và cạnh tranh kinh tê khốc liệt, triết học chẳng thể nào có chỗ đứng, nhưng hóa ra những câu hỏi muôn thuở về nhân sinh, về thế giới, đặt trong bối cảnh hôm nay, vẫn luôn thôi thúc người ta đi tìm câu trả lời. Và thế là, như một người bạn đồng hành, như một người trò chuyện thủ thỉ, qua 92 kỳ báo, tác già đã từng bước, từng bước dẫn dắt người đọc đi vào triết học, làm quen với những khái niệm cơ bản của triết học, vói những triết gia và những giai đoạn quan trọng của lịch sử triết học, lịch sử tư tưỏng của nhân loại. Rồi từ những khái niệm cơ bản của triết học, tác giả dần dần giúp ta tiếp cận dưới giác độ triết học với những vấn đề cụ thể hơn của đời sống, của nhân sinh, như những vấn đề về con người, về tự nhiên và văn hóa; những vấn đề khoa học và giáo dục vừa sát sườn với cuộc sống hôm nay lại vừa có môi liên hệ sâu xa với những câu hỏi muôn thuở của con người. Và cũng thật lạ lùng, như thấy trước được logic phát triển của sự vật thông qua các hiện tượng trước mắt, cả năm rưỡi trời trước khi xảy ra vụ cưỡng chế đất đai vừa trái pháp luật, vừa trái đạo lý cùa chính (huyện Tiên Lãng, Hải Phòng khiến dư luận cả nước phẫn nộ, trong mấy câu mở đầu cho bài mở đầu của chuyên mục, tựa đề: Tư tưởng đổi thay sô phận, bàn về “công dụng” của triết học, tác giả đã viết: “Giải quyết việc lương bổng hay... đền bù giải toả, chẳng lẽ người ta không một phút thoáng nghĩ đến khái niệm “công bằng”? Quả đúng vậy, nếu có một chút tư duy về sự công băng, nếu được hướng dần bởi chút ít tư duy triết học về nhà nước, có lẽ những người ra quyết định thu hồi và cưỡng chế thu hồi đất ở Tiên Lãng đã không hành xử như họ đã hành xử. Vậy, triết học có “công dụng” đấỵ chứ! Tuy nhiên, đó không phải là thứ “công dụng” trước mắt, công dụng “mì ăn liền”. Như tác giả viết, triết học không phải là công cụ, không phải là phương pháp, “ta không đến với triết học để tìm ra những giải pháp nhanh chóng, nhất thời mà để phát hiện những con đường xưa nay chưa biết để đi đến giải pháp”. Nói cách khác, nó như một ngọn đèn, một tia sáng soi đường, giúp ta “hiểu hậu cảnh; quyết định có cơ sở; hành động có trách nhiệm; hoạt động có hiệu quả; truyền thông rõ ràng, sống thanh thản, hạnh phúc”. Trong ý hướng đó, Sài Gòn Tiếp Thị và Công tỵ sách Thời Đại trân trọng giới thiệu với bạn đọc “Trò chuyện triết học” của nhà nghiên cứu triết học, dịch giả Bùi Văn Nam Sơn. Hy vọng cuốn sách giúp thoả mãn phần nào một nhu cầu không thể thiếu, dù đôi khi tiềm ẩn, của người đọc. Nhà báo ĐOÀN KHẮC XUYÊN', N'tro-chuyen-triet-hoc-bo-2-tap.jpg', 500, CAST(N'2017-02-25' AS Date), 55, 20, 29, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (227, N'00000000000000', N'Hành trình của Trần Đức Thảo', N'"Hành trình của Trần Đức Thảo - Hiện tượng học và chuyển giao văn hoá (dịch từ nguyên bản tiếng Pháp: L’itinéraire de Tran Duc Thao. Phénoménologie et transferts culturels) là cuốn sách mới nhất ở Việt Nam phản ánh toàn diện nhất, sâu sắc nhất và có giá trị học thuật cao nhất, là kết quả nghiên cứu  của các nhà triết học, các học giả uy tín, các giáo sư danh tiếng của  Pháp, Bỉ, Canada,... Công trình đồ sộ này đã tiếp tục khẳng định tầm vóc của triết gia Trần Đức Thảo và vai trò của triết học Trần Đức Thảo đối với sự chuyển giao giữa các nền triết học trong thế giới đương đại. Cuốn sách gồm hai phần chính: Phần thứ nhất tuyển chọn các bài nghiên cứu của các học giả quốc tế về triết gia Trần Đức Thảo; Phần thứ hai là tác phẩm quan trọng nhất, nổi tiếng nhất của Giáo sư Trần Đức Thảo được xuất bản tại Pháp năm 1951 – Hiện tượng học và chủ nghĩa duy vật biện chứng (Phénoménologie et matérialisme dialectique). Ngoài ra, ở phần cuối sách, chúng tôi thêm Phụ lục về Chương trình Hội thảo: Hành trình của Trần Đức Thảo. Hiện tượng học và chuyển giao văn hoá diễn ra tại Pháp vào hai ngày 22 – 23/6/2012 và Bảng chỉ mục một số tên riêng, tên tác phẩm và thuật ngữ được đề cập đến trong Phần thứ hai của cuốn sách. Cuốn sách do Nhà nghiên cứu Bùi Văn Nam Sơn chủ trì dịch, hiệu đính và giới thiệu, các dịch giả: Bùi Văn Nam Sơn, Đinh Hồng Phúc, Phạm Anh Tuấn, Phạm Văn Quang.', N'untitled.png', 500, CAST(N'2017-02-25' AS Date), 56, 20, 30, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (324, N'00000000000000', N'TUYỂN TẬP NGUYỄN ĐÌNH CHIỂU', N'Nguyễn Đình Chiểu là ngôi sao sáng trong bầu trời văn nghệ dân tộc. Từ sau Cách mạng tháng Tám, và nhất là từ năm 1975, tác phẩm của ông đã được giới thiệu, phổ biến rộng rãi trong cả nước. Song những tác phẩm này chưa được khảo sát dưới góc độ văn bản học chặt chẽ, vì chúng ta chưa có đủ những bản Nôm cần thiết. Phải đợi đến sau ngày giải phóng, chúng ta mới có được các bản Nôm ấy để làm việc đó. Chính vì vậy, mà "Tuyển tập Nguyễn Đình Chiểu" mãi tới nay mới ra mắt bạn đọc nhân dịp kỷ niệm 90 năm ngày mất của tác giả. Công tác văn bản học đòi hỏi phải hiểu chính xác văn bản, thuyết minh văn bản theo ý đồ tư tưởng nghệ thuật của tác giả, hiểu được mục đích tính của tác phẩm để rồi cuối cùng tái hiện lại một cách tổng quát các giai đoạn của quá trình lao động đó dưới hình thức một văn bản minh xác thỏa đáng. Tuyển Tập Nguyễn Đình Chiểu cố gắng trình bày văn bản theo những yêu cầu đó của văn bản khoa học, nhằm đáp ứng nhu cầu học tập và nghiên cứu hiện nay của các trường đại học và của nhân dân ta đối với nhà thơ đã có một lòng tin vĩ đại vào quần chúng nhân dân - ngọn cờ tiên khu của dòng văn học yêu nước trong thời cận đại.', N'tuy%E1%BB%83n-t%E1%BA%ADp-nguy%E1%BB%85n-%C4%91%C3%ACnh-chi%E1%BB%83u.jpg', 500, CAST(N'2017-02-25' AS Date), 57, 21, 17, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (325, N'00000000000000', N'TUỔI 20 TÔI ĐÃ SỐNG NHƯ MỘT BÔNG HOA DẠI', N'Cuốn sách cho những trăn trở thanh xuân. Ngòi bút sắc sảo, tinh tế, và cũng vô cùng hài hước. Tác giả, một cô gái đang trong độ tuổi 20, đang nói hộ chúng ta rất nhiều điều ta không diễn đạt được bằng lời.  "Bố mẹ không hỏi các con đi học vui không, chỉ hỏi điểm cao không. Bố mẹ không hỏi đi làm vui không, mệt không, chỉ hỏi lương cao không, công ty to không. Kết hôn không hỏi có yêu nhau không, mà hỏi có hợp năm tuổi không, chúc mừng sale-off tuổi xuân thành công. Ly dị không ai hỏi vì sao không sống cùng nhau nữa, chỉ hỏi định nhìn mặt mẹ cha xóm giềng thế nào. Đâu phải đến lúc đi làm bạn mới sợ thứ Hai, bạn sợ thứ hai từ lúc đi học cơ mà. Hóa ra chúng ta vẫn là những đứa trẻ đi dưới sân trường, chỉ vì tiếng trống mà chạy đua náo loạn trong sợ hãi. Tiếng trống tuổi 25, tiếng trống tuổi 30, chưa gióng lên mà ta đã sợ hãi lao đi rồi. Người ta nói kẻ dùng trái tim là yếu đuối, thực ra chỉ kẻ mạnh mới dám dùng thôi."', N'tu%E1%BB%95i-20-r%C3%B4i-%C4%91%C3%A3-s%E1%BB%91ng-nh%C6%B0-m%E1%BB%99t-b%C3%B4ng-hoa-d%E1%BA%A1i.jpg', 500, CAST(N'2017-02-25' AS Date), 58, 21, 16, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (326, N'00000000000000', N'6 NGÀY', N'6 ngày của một tuần với các buổi sáng trưa chiều tối đêm. Nhân vật công chức sống thế nào trong một ngày ấy trong thế giới của mình, nghĩ thế nào cho mỗi công việc, vui buồn thế nào cho mổi chuyện anh chứng kiến và tham dự. Cuộc sống thì đẹp, đời người thì hữu hạn, vui vẻ hay chán chường, giàu hay nghèo không phải là việc quan trọng nữa, mà quan trọng là được sống bình thường.', N'6-ng%C3%A0y.jpg', 500, CAST(N'2017-02-25' AS Date), 59, 21, 16, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (327, N'00000000000000', N'THƯƠNG NHAU HAI TIẾNG CỐ NHÂN', N' THƯƠNG NHAU HAI TIẾNG CỐ NHÂN gồm những truyện ngắn và tản văn nhẹ nhõm, dễ chịu viết về cuộc sống quanh ta. Nơi đó có tiếng cười hài hước, có nước mắt rơi, có người xưa chốn cũ gợi biết bao yêu thương và nhung nhớ, nhưng cũng có những cái níu tay rất chặt nhắc ta hiện tại mới là đáng quý, hãy biết trân trọng và yêu thương. Một tập sách đặc biệt dành cho những ai đã qua tuổi trưởng thành, đủ chiêm nghiệm về cuộc sống để thấy mỗi khoảnh khắc đã qua, dù vui hay buồn, đều THƯƠNG biết bao nhiêu.', N'th%C6%B0%C6%A1ng-nhau-hai-ti%E1%BA%BFng-c%E1%BB%91-nh%C3%A2n.jpg', 500, CAST(N'2017-02-25' AS Date), 60, 21, 16, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (328, N'00000000000000', N'THƯ MỤC NGHIÊN CỨU NGUYỄN DU', N'', N'16809270_795814620573903_31911815_n.jpg', 500, CAST(N'2017-02-25' AS Date), 11, 21, 17, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (329, N'00000000000000', N'Người về với như', N'Tiệc hoa đối với con người thì cũng tưng bừng như lửa hồng đối với con thiêu thân. Ngày ngày lửa hồng cháy. Ngày ngày thiêu thân bay đến. Chỉ có điều, không thể gặp lại con thiêu thân của ngày hôm qua. Có vô tận lửa thì có vô tận thiêu thân. Lửa cứ cháy, không tự biết. Và thiêu thân cứ điêu tàn, không tự biết. Đó là chuyện trước mắt. Đó là chuyện ngày ngày. Nhà thơ nhìn chuyện đời diễn ra và những điều trong thấy mà đau đớn lòng. Những chuyến xe cứ đi vào bụi hồng mà mất hút, không biết để làm gì và đi về đâu? Và mấy ai can đảm bước xuống xe, từ chối không đi với bụi hồng?', N'16787962_795790013909697_2081393991_n.jpg', 500, CAST(N'2017-02-25' AS Date), 61, 21, 13, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (330, N'00000000000000', N'QUÊ NHÀ Ở PHÍA NGÔI SAO', N'“Thơ Nguyễn Duy đưa ta về một thế giới quen thuộc. Nguyễn Duy đặc biệt thấm thía cái cao đẹp của những con người, những cuộc đời cần cù gian khổ, không tuổi không tên. Đọc thơ Nguyễn Duy thấy anh hay cảm xúc, suy nghĩ trước những chuyện lớn, chuyện nhỏ quanh mình. Cái điều ở người khác có thể chỉ là chuyện thoáng qua thì ở anh, nó lắng sâu và dường như đọng lại…” (Hoài Thanh, Báo Văn Nghệ, ngày 14.4.1972)', N'que-nha-o-phia-ngoi-sao.278x404.w.b.jpg', 500, CAST(N'2017-02-25' AS Date), 62, 21, 25, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (331, N'00000000000000', N'NGUYỄN DUY - TUYỂN THƠ LỤC BÁT', N'Duy phải lòng lục bát. Duy thấy giữa mình và lục bát biết bao nhiêu nghĩa cũ càng. Trong tay Duy chẳng những lục bát được làm mới mà còn lẩy lên được cả những tâm tình ở đàng sau tâm tình. Và rồi, cũng hảo tâm như thần đèn, thần đàn đã luôn đền bù cho Duy một cách hào phóng. Cây đàn này của Duy chơi điệu mới, nhịp mới, hồn mới. Giai điệu lục bát của Duy có cổ điển, có dân gian. Duy mạnh tay đốc quân, đưa những lời nói, lối nói đời mới xâm nhập vào cấu trúc lục bát, khiến nó phải nới mình ra, dàn xếp lại, tìm đến những dạng hài hòa cũng theo lối mới. Và ở lục bát hồn vía Nguyễn Duy mới dậy men nổi gió làm "trời lao đao đất lao đao lừ đừ" đến thế.', N'nguyen-duy-tuyen-tho-luc-bat.278x404.w.b.jpg', 500, CAST(N'2017-02-25' AS Date), 62, 21, 25, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (332, N'00000000000000', N'PÀ PÁ, MÌNH KIẾM MÓN GÌ NGON ĂN ĐI', N'Có câu “Ăn cơm Tàu” để chỉ sự hấp dẫn của ẩm thực Trung Hoa. “Pà Pá, mình kiếm món gì ngon ăn đi” là câu cửa miệng mỗi chiều tuổi thơ của một gia đình người Hoa sống ở Chợ Lớn trả qua ba thế hệ gần 100 năm. Nhà báo Phạm Công Luận tâm đắc: “Qua cuốn sách này, có thể thấy vẻ đẹp, sự hấp dẫn của nghệ thuật ẩm thực do người Hoa sống lâu đời ở Chợ Lớn còn được giữ gìn và phổ biến. Còn thấy được tình người, tình đời trong cuộc sống gắn bó với truyền thống nhưng cởi mở với cộng đồng của họ”. Pà Pá, Mình Kiếm Món Gì Ngon Ăn Đi không phải là sách dạy nấu ăn, dù cuốn sách là hơn 30 món thuộc loại “đặc sản” của người Hoa: Bánh bao, bánh tổ, bánh hẹ, cải chua ruột heo, chì mà phủ (chè mè đen), lạp vịt, sủi cảo, hột gà trà… mà sau món ăn còn là tình, là nghĩa. Ông già Tiều 80 tuổi buổi sáng chỉ ăn cháo trắng nhưng đủ sức tát vào mặt để cảnh cáo ông thầy giáo vì ham vợ bé nên đánh vợ lớn đến gãy tay. Hoặc món bánh bá trạng là cách cư xử đẹp đẽ với nhau giữa hai người phụ nữ lấy chồng chung. Tâm tình của những người phụ nữ Chợ Lớn lo toan bữa cơm hàng ngày phục vụ chồng con.', N'pa-pa-minh-kiem-mon-gi-ngon-an-di.278x404.w.b.jpg', 500, CAST(N'2017-02-25' AS Date), 63, 21, 15, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (333, N'00000000000000', N'TÌM ĐƯỜNG TUỔI 20S', N'Bởi đã từng là một cô gái đầy tự ti với bản tính nhút nhát, hướng nội của mình, tác giả ghi lại những câu chuyện về việc mình đã trải qua và vượt qua sự tự ti đó như thế nào và bằng cách nào. Từ nỗi sợ phải nói tiếng Anh trước đám đông, nỗi sợ phải thuyết trình bằng tiếng Anh đến sự cố dẫn chương trình bằng tiếng Anh thất bại, Thùy Trang đã vượt qua và không chỉ thành công trong vai trò MC của nhiều chương trình, có những bài thuyết trình khiến nhiều bạn bè phải ngưỡng mộ. Từ nỗi sợ mình nhút nhát, nhạy cảm, không phù hợp với các vị trí đứng đầu một nhóm, một tổ chức, Thùy Trang đã trải qua vai trò là leader của một câu lạc bộ lên đến hàng trăm người, leader của những nhóm thuyết trình trong quá trình du học nước ngoài và cuối cùng là người điều hành một trung tâm tiếng Anh do chính mình lập ra. Trong cuốn sách của mình, tác giả chia sẻ những thất bại, những điểm yếu của bản thân. Nhưng quan trọng hơn hết thảy, cô không tìm cách trốn tránh. Bài học lớn nhất mà cô chỉ ra là dám đối mặt với nỗi sợ hãi, với những điểm yếu của mình, bình tĩnh suy nghĩ và tìm ra những điểm mạnh của bản thân, dùng những “vũ khí” ấy để chuẩn bị kĩ càng trước bất kì vấn đề gì.  Chiến thắng sự tự ti, nỗi sợ hãi của bản thân bằng cách tìm ra giải pháp cho những vấn đề mình gặp phải thay vì trốn tránh. Đừng để nỗi sợ hãi nhấn chìm mình, đừng để nỗi sợ hãi biến bạn thành bé nhỏ, thu mình vào một góc, mà hãy dùng nỗi sợ hãi đó như một động lực để nỗ lực hết sức, hết mình và tìm ra giải pháp để giải quyết vấn đề.  Giá trị cuối cùng bạn đạt được không phải là một cái đích đã được định sẵn hay những gì bạn đạt được. Đó lại là những gì bạn đã trải qua trên hành trình và sự thay đổi nội tại đến từ bên trong bạn. Bạn không thể chiến thắng thế giới, nhưng bạn có thể chiến thắng chính mình. Đó là thông điệp mà cuốn sách “Tìm đường tuổi 20s” muốn gửi tới cho độc giả.', N'1.png', 500, CAST(N'2017-02-25' AS Date), 64, 21, 13, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (334, N'00000000000000', N'Chung Một Cuộc Tình', N'Với ý thức kể chuyện hiện đại, cái nhìn đầy tinh tế cùng giọng văn sắc lạnh, Nguyễn Nguyên Phước đã đưa người đọc vào một câu chuyện tình nhiều ẩn ức, hiện thực cuộc sống của những con người trẻ lạc lõng giữa mê đắm và chán chường, giữa tình yêu và dục vọng, giữa hạnh phúc và phản bội, giữa sự sống và cái chết… Chung một cuộc tình đã dệt nên một bức tranh đa chiều đầy ám ảnh về xã hội đô thị hiện đại.  “Thế giới này đẹp và tàn nhẫn. Luôn luôn là như thế. Thế giới này đẹp chính bởi vì nó tàn nhẫn. Sự tàn nhẫn bao giờ cũng là thứ làm cho cuộc sống mang một vẻ đẹp đích thực…”', N'image001.jpg', 500, CAST(N'2017-02-25' AS Date), 65, 21, 11, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (335, N'00000000000000', N'Cà Phê Cùng Tony', N'Cà Phê Cùng Tony là tập hợp các bài viết trên trạng mạng xã hội của tác giả Tony Buổi Sáng (TnBS) về những bài học, câu chuyện anh đã trải nghiệm trong cuộc sống. Đó có thể là cách anh chia sẻ với các bạn trẻ về những chuyện to tát như khởi nghiệp, đạo đức kinh doanh, học tập đến những việc nhỏ nhặt như ăn mặc, giao tiếp, vệ sinh cơ thể… sao cho văn minh, lịch sự. Hay chỉ đơn giản thuật lại những trải nghiệm thực tế của anh trong quá trình sống, kinh doanh ở trong và ngoài nước. Xuyên suốt cuốn sách, các câu chuyện được kể với giọng điệu trào phúng, hài hước lại được thể hiện bằng ngôn ngữ “cư dân mạng” tạo sự gần gũi để các bạn trẻ có thể dễ dàng tiếp nhận. Mặc dù tác giả luôn khẳng định những thông tin, chi tiết trong câu chuyện là hư cấu và thậm xưng nhưng điều đó không có nghĩa làm cuốn sách bớt đi sự thú vị. Chia sẻ về sự ra đời của cuốn sách, tác giả tâm niệm không muốn những điều anh tâm đắc và đúc kết chỉ dừng lại ở mạng xã hội. Anh hi vọng những câu chuyện của mình thông qua Cà Phê Cùng Tony có thể thổi nguồn cảm hứng tới những độc giả không có điều kiện sử dụng internet, đồng thời khuyến khích văn hóa đọc ở các bạn trẻ trong thời đại mà văn hóa nghe nhìn đang  dần chiếm ưu thế. Đơn giản và không cầu kì, đọc Cà Phê Cùng Tony, độc giả sẽ cảm thấy như đang khám phá câu chuyện của chính mình qua cách kể  của một người khác. Đọc “Cà phê cùng Tony”, độc giả không thể cười lớn như khi đọc những mẩu chuyện cười, họ chỉ có thể tủm tỉm với những triết lí dí dỏm mà TnBS mang đến.', N'nxbtre_thumb_06532017_025349.jpg', 500, CAST(N'2017-02-25' AS Date), 66, 21, 18, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (804, N'00000000000000', N'Căn Phòng Khóa', N'“Căn Phòng Khóa” là một cuốn tiểu thuyết lấy cảm hứng từ một câu chuyện có thật từng gây rúng động thế giới về một người đàn ông ở Áo đã từng bắt cóc, giam cầm và hãm hiếp chính con gái ruột của mình trong suốt 24 năm, khiến cô sinh 7 đứa con. Jack, cậu bé 5 tuổi được sinh ra và lớn lên trong một căn phòng bị khóa kín cùng với mẹ. Jack tuy nhỏ bé, tinh nghịch nhưng rất thông minh và mạnh mẽ. Ở trong căn phòng không lối thoát, nạn nhân của cuộc bắt cóc - mẹ Jack, dù phải đối mặt với bạo hành, cưỡng hiếp… từng ngày, vẫn luôn đấu tranh để bảo vệ sự trong sáng cho con. Và, để đeo đuổi giấc mơ đào thoát. Chìa khóa của giấc mơ ấy, là một kế hoạch liều lĩnh. Bằng lối kể chuyện thông qua lăng kính của một đứa trẻ khác thường, do chỉ được giáo dục trong môi trường đóng kín là căn phòng, tác giả Emma Donoghue đã đưa người đọc vào một hành trình hấp dẫn, li kì và hồi hộp đến nghẹt thở. Bạn đọc được đưa vào căn phòng của hai mẹ con để thấy thế giới trong đó không chỉ giới hạn trong những thông số mét vuông mà mở ra bất tận bằng ngôn từ của người mẹ, bằng khả năng tưởng tượng của người con. Nếu hành trình trốn chạy để đưa mẹ ra khỏi địa ngục trần gian của Jack làm độc giả không thể dừng lại vì quá hồi hộp thì quá trình tái hòa nhập với cuộc sống thực tế của hai mẹ con cũng đầy khủng hoảng. Không gian quá rộng lớn bên ngoài so với cuộc sống trong căn phòng khóa khiến Jack nhiều phen hoảng loạn. Nỗi lo lắng của Jack được miêu tả tinh tế bằng ngôn ngữ của trẻ thơ. Người đọc vì thế mà hiểu hơn, cảm phục hơn những tố chất tốt đẹp của cậu bé này. Từ đó, càng thấy vai trò người mẹ to lớn thế nào với sự phát triển của con trẻ. Chỉ cần dành thời gian, chỉ cần kiên nhẫn, người mẹ có thể vượt mọi trở ngại về không gian, địa lý để mang đến cho con cả một bầu trời lẫn sức mạnh để làm nên những điều tưởng chừng bất khả. Hiện thực đầy ám ảnh của một cô gái người Áo, dưới ngòi bút của Emma Donoghue không quá khốc liệt nhưng vẫn chạm đến trái tim người đọc. Trong cái cách nói về khái niệm thời gian cô gái ấy bị hại, có thể thấy được sự điềm tĩnh lạ lùng: “Đó là vào cuối tháng Giêng. Tôi vừa đi học lại được vài tuần…”. Sở thích bệnh hoạn đã khiến cô nữ sinh trong sáng bất ngờ thành một thứ đồ chơi, thành thú cưng cho một tên biến thái. Tưởng sẽ buông xuôi, tưởng chừng không gượng nổi…Vậy mà, cô gái ấy vẫn kiên trì, vẫn thúc giục bản thân phải nỗ lực hàng ngày. Thế mới biết, nghịch cảnh, có thể đổ ập xuống bất cứ ai, bất cứ lúc nào. Vấn đề là làm thế nào để vượt qua được con sóng dữ ấy, tìm đến bến bờ bình yên. Chạm đến xúc cảm người đọc, không khó hiểu khi cuốn sách đã được dịch ra hơn 35 ngôn ngữ, được tạp chí The New York Times  đánh giá là một trong 6 cuốn tiểu thuyết đáng đọc nhất trong năm 2010 và Washington Post đưa vào Top 10 tiểu thuyết đáng đọc nhất thế giới. 7 năm sau khi Căn Phòng Khóa càn quét các nhà sách quốc tế, tiểu thuyết này đã chính thức có mặt tại Việt Nam. Thiết kế tinh tế, sách in trang trọng bằng giấy cao cấp, không làm mỏi tay người đọc dù dung lượng của nó tròm trèm 500 trang.', N'c%C4%83n-ph%C3%B2ng-kh%C3%B3a.jpg', 500, CAST(N'2017-02-25' AS Date), 67, 22, 11, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (805, N'00000000000000', N'Phải Trái Đúng Sai', N'Giáo sư Đại học Harvard Michael J. Sandel (sinh ngày 05-3-1953) là triết gia chính trị Mỹ. Ông được bầu làm Viện sĩ Viện hàn lâm Nghệ thuật và khoa học Hoa Kỳ năm 2002. Ông từng là thành viên Ủy Ban Đạo đức sinh học của Tổng thống George w. Bush. Cuốn sách và bài giảng của ông ở Đại học Harvard Justice: What’s the Right Thing to Do? (Công lý: Đâu là việc đúng nên làm?) khơi gợi lên những câu hỏi lớn của triết học chính trị thông qua việc đánh giá những vấn đề gai góc gây nhiều tranh cãi nhất của thời đại chúng ta: nhập ngũ, đẻ thuê, ưu tiên thiểu số khi tuyển sinh... Đây là một khóa học có số lượng sinh viên tham dự đông kỷ lục ở Mỹ. Giáo sư Sandel có nhiều tác phẩm khác như Chủ nghĩa tự do và giới hạn của công lý (1998), Bất mãn trong nền dân chủ (1996), Triết học: Các tiểu luận về đạo đức trong chính trị (2005), và Lý lẽ chống lại sự hoàn hảo: Đạo đức trong thời đại kỹ thuật di truyên (2007). Các tác phẩm của ông đã được dịch ra mười lăm ngôn ngữ nước ngoài. Ông cũng viết nhiều bài báo cho các ấn phẩm lớn như Atlantic Monthly, The New York Times. Ông được đài truyền hình Nhật Bản NHK và Đài BBC Anh quốc mời diễn thuyết về các chủ đề đạo đức và công lý.', N'ph%E1%BA%A3i-tr%C3%A1i-%C4%91%C3%BAng-sai.jpg', 500, CAST(N'2017-02-25' AS Date), 68, 22, 16, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (806, N'00000000000000', N'CHIẾN TRANH VÀ CHIẾN TRANH', N'“Krasznahorkai László - bậc thầy Hungary khiến người ta nhớ tới Gogol và Melville tiên tri.” - Susan Sontag Trong phòng lưu trữ tỉnh lẻ heo hút, cách Budapest trăm hai mươi cây số, Dr. Korin György tình cờ phát hiện một cảo bản huyền bí không nhan đề, không niên đại, tác giả vô danh. Bốn người đàn ông trong cảo bản, xuất hiện ở những bước ngoặt khác nhau của lịch sử thế giới, lúc ở Creta, lúc ở Venice, lúc ở Köln, luôn phải trốn chạy khỏi chiến tranh thảm khốc, khỏi sự tàn phá. Và rất lâu sau, trong một khoảnh khắc tăm tối bất chợt vào sinh nhật lần thứ bốn mươi tư, Korin cảm thấy chính mình cũng cần trốn chạy, như các nhân vật trong tập cảo bản kỳ lạ liên tục trượt về phía trước, và cuốn gã vào mê lộ của nó. Gã bán hết gia sản, đến New York, để kết thúc cuộc đời cũ, và thực hiện giấc mơ đưa cảo bản quý giá vào cõi vĩnh hằng... Chiến tranh và chiến tranh – tiểu thuyết lồng trong tiểu thuyết, thể hiện cái nhìn u tối về thực tại bạo tàn trong vẻ đẹp bí ẩn và bi thảm, nhưng đầy sức thôi miên, khiến độc giả nhập thân sâu sắc vào cuộc xê dịch ác mộng của nhân vật đi tìm ý nghĩa của thế giới và chính đời mình. Chiến tranh và chiến tranh đã góp phần khẳng định vị trí của Krasznahorkai László như một tên tuổi lớn đặc biệt đáng chú ý, một ngôi sao sáng khác lạ trên bầu trời văn học đương đại Hungary và thế giới.', N'chi%E1%BA%BFn-tranh-v%C3%A0-chi%E1%BA%BFn-tranh.jpg', 500, CAST(N'2017-02-25' AS Date), 69, 22, 11, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (807, N'00000000000000', N'BA NGÀY VÀ MỘT ĐỜI', N'Bạn chờ đợi gì ở tác phẩm tiếp theo của một nhà văn vừa giành Giải Goncourt danh giá nhất nước Pháp? Nhất là khi giải thưởng ấy đã được trao cho tác phẩm không-trinh-thám đầu tiên của nhà văn chuyên viết trinh thám? Với Ba ngày và một đời, Pierre Lemaitre đã có một lời đáp thật khéo léo cho những trông đợi ấy. Ba năm sau giải Goncourt, Lemaitre trở về với sở trường trinh thám, nhưng là kiểu trinh thám rất khác với những gì ông viết trước đây. Một cốt truyện có thể tóm tắt được chỉ trong một câu nhưng chứa đựng câu chuyện của cả một đời người, và cả xã hội đương thời. Chậm rãi, u uẩn và đầy triết lý. Bởi vậy, hãy quên hào quang của Hẹn gặp lại trên kia đi, hãy nhắm mắt lại và để Pierre Lemaitre dẫn bạn khám phá những ngóc ngách sâu kín trong đầu óc của một “kẻ sát nhân mười hai tuổi”!', N'ba-ng%C3%A0y-v%C3%A0-m%E1%BB%99t-%C4%91%E1%BB%9Di.jpg', 500, CAST(N'2017-02-25' AS Date), 70, 22, 11, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (808, N'00000000000000', N'BÁ TƯỚC DRACULA', N'Đáp lại lời mời của bá tước Dracula, Jonathan Harker, một thư ký công chứng viên, rời Luân Đôn tới khám phá một xứ sở bí hiểm nằm sâu trong rặng Karpat xa xôi. Chủ nhà đón tiếp anh nồng nhiệt, nhưng Jonathan vẫn cảm thấy nỗi lo sợ mơ hồ lớn dần lên. Bá tước Dracula kiểm soát thư từ của anh, khóa chốt nhiều cánh cửa trong tòa lâu đài, lão còn có thể bò trên tường chẳng khác gì một con thằn lằn, hình ảnh của lão cũng không phản chiếu trong gương... Rồi Jonathan nhận ra một sự thật hiển nhiên: anh bị cầm tù bởi một kẻ không phải là con người! Và đó mới chỉ là bắt đầu... Cảm giác hồi hộp, sợ hãi thường trực cuốn người đọc đi qua hơn 600 trang viết đầy ắp những kiến thức lịch sử, địa lý. Hơn một trăm năm đã trôi qua kể từ khi Bram Stoker cho xuất bản cuốn tiểu thuyết về ma cà rồng của ông và Bá tước Dracula chưa bao giờ ngừng làm mê say độc giả. “Một năng lượng lớn, một năng lực tưởng tượng phong phú, cùng rất nhiều chi tiết tài tình và khủng khiếp. Stoker dường như đã thành công trong việc biến điều không thể thành có thể, khiến cuốn sách hứa hẹn mở ra những gốc rễ của sự bí ẩn và nỗi sợ hãi nằm sâu trong bản chất con người.” - Athenaeum magazine', N'b%C3%A1-t%C6%B0%E1%BB%9Bc-dracula.jpg', 500, CAST(N'2017-02-25' AS Date), 71, 22, 17, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (809, N'00000000000000', N'CÔ GÁI BROOKLYN', N'Sững sờ choáng váng, tôi lặng người nhìn bí mật của nàng, và biết rằng cuộc đời chúng tôi vừa bị đảo lộn mãi mãi. Không chịu nổi cú sốc ấy, tôi đứng dậy và đi khỏi, không nói một lời. Khi trở lại thì đã quá muộn: Anna đã biến mất. Kể từ đó, tôi đi tìm nàng. Dữ dội và lôi cuốn, một vụ án treo khiến người ta mê mẩn. Những tình tiết cốt truyện quỷ quái, những nhân vật đặc biệt và cuốn hút, những giây phút hồi hộp chờ đợi, với Cô Gái Brooklyn, tác phẩm mới nhất được phát hành tại Pháp vào tháng 3/2016, Guillaume Musso đã một lần nữa ký tên mình vào một trong những cuốn tiểu thuyết đầy tham vọng và thành công nhất trong sự nghiệp cầm bút.', N'c%C3%B4-g%C3%A1i-brooklyn.jpg', 500, CAST(N'2017-02-25' AS Date), 72, 22, 17, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (810, N'00000000000000', N'Bố Già - Bìa mềm', N'Thế giới ngầm được phản ánh trong tiểu thuyết Bố già là sự gặp gỡ giữa một bên là ý chí cương cường và nền tảng gia tộc chặt chẽ theo truyền thống mafia xứ Sicily với một bên là xã hội Mỹ nhập nhằng đen trắng, mảnh đất màu mỡ cho những cơ hội làm ăn bất chính hứa hẹn những món lợi kếch xù. Trong thế giới ấy, hình tượng Bố già được tác giả dày công khắc họa đã trở thành bức chân dung bất hủ trong lòng người đọc. Từ một kẻ nhập cư tay trắng đến ông trùm tột đỉnh quyền uy, Don Vito Corleone là con rắn hổ mang thâm trầm, nguy hiểm khiến kẻ thù phải kiềng nể, e dè, nhưng cũng được bạn bè, thân quyến xem như một đấng toàn năng đầy nghĩa khí. Nhân vật trung tâm ấy đồng thời cũng là hiện thân của một pho triết lí rất “đời” được nhào nặn từ vốn sống của hàng chục năm lăn lộn giữa chốn giang hồ bao phen vào sinh ra tử, vì thế mà có ý kiến cho rằng “Bố già là sự tổng hòa của mọi hiểu biết. Bố già là đáp án cho mọi câu hỏi”.   Với cấu tứ hoàn hảo, cốt truyện không thiếu những pha hành động gay cấn, tình tiết bất ngờ và không khí kình địch đến nghẹt thở, Bố già xứng đáng là đỉnh cao trong sự nghiệp văn chương của Mario Puzo. Và như một cơ duyên đặc biệt, ngay từ năm 1971-1972, Bố già đã đến với bạn đọc trong nước qua phong cách chuyển ngữ hào sảng, đậm chất giang hồ của dịch giả Ngọc Thứ Lang.', N'sach-bo-gia-mario-puzo-mua-sach-hay.jpg', 500, CAST(N'2017-02-25' AS Date), 73, 22, 17, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (811, N'00000000000000', N'HARRY POTTER VÀ PHÒNG CHỨA BÍ MẬT (BẢN ĐẶC BIỆT CÓ TRANH MINH HỌA MÀU)', N'Vào năm học thứ 2 tại trường Hogwarts, Harry và các bạn tiếp tục đối mặt với những bài học thú vị mới và những bí mật mới. Người kế vị Slytherin đã gây ra nỗi kinh hoàng trong trường, với lời đồn đại về căn phòng chứa bí mật. Cuộc phiêu lưu của Harry và hai người bạn, Ron và Hermione, hấp dẫn hơn bao giờ hết nhờ minh họa sống động của họa sĩ Jim Kay. Harry Potter và Phòng chứa bí mật là tập 2 trong bộ sách Harry Potter với phiên bản có tranh minh họa.', N'harry-potter-v%C3%A0-ph%C3%B2ng-ch%E1%BB%A9a-b%C3%AD-m%E1%BA%ADt-2.jpg', 500, CAST(N'2017-02-25' AS Date), 74, 22, 16, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (812, N'00000000000000', N'Tâm Hồn Cao Thượng - Bìa Cứng', N'Ngày 18/10 hằng năm là ngày khai trường truyền thống ở Ý. Vào ngày này năm 1886, Tâm hồn cao thượng (nguyên tác Cuore, nghĩa là Trái tim) cuốn tiểu thuyết trẻ em của nhà văn người Ý Edmondo De Amicis chính thức ra mắt. Ngay lập tức, nó chinh phục trái tim bạn đọc, không chỉ ở Ý mà còn lan khắp các châu lục khác. Đến tận bây giờ, Tâm hồn cao thượng vẫn là một trong những tác phẩm có sức sống bền bỉ trong đời sống xuất bản của nhiều quốc gia. Năm 1948, Tâm hồn cao thượng lần đầu tiên xuất bản ở Việt Nam để rồi từ đó đến tận bây giờ, tác phẩm này vẫn luôn là sách gối đầu giường của nhiều thế hệ. Tác phẩm được xem như một cuốn "luân lý giáo khoa thư" của thế kỷ 20. Sức ảnh hưởng một cuốn tiểu thuyết trẻ em, xuất phát từ đâu? Câu trả lời, rất đơn giản: Từ điều bình dị nhất, là sự tử tế. Được viết theo hình thức nhật ký của Enico Bottini, cậu học trò 10 tuổi, Tâm hồn cao thượng đem đến người đọc những câu chuyện nhỏ, diễn ra theo thứ tự thời gian xuyên suốt năm lớp 3 của Enrico, nhưng lại là những vấn đề quan tâm của toàn xã hội. Gia đình Enico Bottini thuộc tầng lớp thượng lưu trong khi nhiều bạn cùng lớp lại xuất thân từ tầng lớp lao động. Đó chính là lý do, dù là trong thế giới của những đứa trẻ, những va đập xã hội vẫn diễn ra liên tục. Bất ngờ là sau những va đập đó, những mảnh vỡ nhặt được lại lóng lánh giá trị sống: lòng yêu nước, sự chân thành và hơn cả, là sự tử tế của mỗi con người. Trong bối cảnh mà lòng tốt bị đem ra mổ xẻ, ứng xử tử tế có thể gây nên nhiều hồ nghi, giới trẻ xem nút "like" trên mạng xã hội là lẽ sống. Như hiện nay thì sự xuất hiện trở lại của Tâm hồn cao thượng thực sự là một cơn gió mát. Nhiều người nói rằng, Việt Nam là một dân tộc kỳ lạ. Chúng ta có thể chinh phục được rất nhiều trở ngại để vươn lên phía trước. Chúng ta tiếp nhận kiến thức và phát huy những giá trị rất nhanh. Cái khó nhất, vẫn là câu chuyện nuôi dưỡng tâm hồn. Không có lời lý giải nào cho việc thanh niên sẵng sàng đốt thân, nhảy cầu hay cô bé 13 tuổi mua xăng đốt trường, nếu có người cổ vũ (bằng nút like quyền lực), không có biện minh nào cho việc những "thánh nữ" sẽ live stream thoát y cho cả thế giới cùng chiêm ngưỡng. Tất cả những câu chuyện này, là dị tật của văn hóa "câu like" mà giới trẻ đang "cuồng". Làm thế nào để giải tỏa những ung nhọt này? Lời giải cho bài toán này, thiết nghĩ, chỉ có sách. Trên mảnh đất mà phù sa là những câu chuyện nhỏ của Enico Bottini đắp bồi, những người biên soạn tập sách nổi tiếng nay hy vọng, những hạt mầm tử tế sẽ ươm chồi, nảy lộc. Đó chính là lý do, nhóm biên soạn mang đến bạn đọc Tâm hồn cao thượng, một tác phẩm chưa bao giờ cũ dù đã hơn trăm tuổi trong những ngày đầu năm 2017. Thắp lên một ngọn nến sáng, gieo một niềm tin yêu, từ bạn đọc, ngọn lửa của sự tử tế sẽ tỏa lan.', N't%C3%A2m-h%E1%BB%93n-cao-th%C6%B0%E1%BB%A3ng.jpg', 500, CAST(N'2017-02-25' AS Date), 75, 22, 17, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (813, N'00000000000000', N'NĂM EM GẶP ANH', N'Từ một cô gái kiêu hãnh, thành công rực rỡ trong sự nghiệp, Jasmine đột ngột mất việc. Cô bị trầm cảm nặng nề, nhưng cũng chính nhờ một năm ở nhà theo chế độ "về vườn", cô khám phá ra những sở thích của chính mình lâu nay bị guồng quay công việc che lấp, tình cảm gia đình, xóm giềng, và tìm được một  tình yêu đích thực. Truyện nhẹ nhàng, lãng mạn, sâu sắc và tinh tế trong từng chi tiết nhỏ. Cecelia Ahern là một nhà văn nổi tiếng với các truyện dài: Cảm ơn ký ức, Món quà bí ẩn, Có một nời gọi là chốn này... viết sâu sắc và hư ảo, luôn biết cách khơi gợi để người đọc nhìn thấy những phần sâu thẳm nhất trong tâm hồn mình.', N'n%C4%83m-em-g%E1%BA%B7p-anh.jpg', 500, CAST(N'2017-02-25' AS Date), 76, 22, 16, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (814, N'00000000000000', N'HARRY POTTER VÀ ĐỨA TRẺ BỊ NGUYỀN RỦA: PHẦN MỘT VÀ HAI', N'Kịch bản Harry Potter và Đứa trẻ bị nguyền rủa được viết dựa trên câu chuyện của J.K. Rowling, Jack Thorne và John Tiffany. Từ những nhân vật quen thuộc trong bộ Harry Potter, kịch bản nói về cuộc phiêu lưu của những hậu duệ, sự can thiệp vào dòng thời gian đã gây ra những thay đổi không ngờ cho tương lai tưởng chừng đã yên ổn sau khi vắng bóng chúa tể Voldermort', N'harry-potter-v%C3%A0-%C4%91%E1%BB%A9a-tr%E1%BA%BB-b%E1%BB%8B-nguy%E1%BB%81n-r%E1%BB%A7a.jpg', 500, CAST(N'2017-02-25' AS Date), 74, 22, 16, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (815, N'00000000000000', N'Lễ Hội Tháng Ba', N'“… Nhà ngươi đã từng công kích những gì? Nhà ngươi từng đã bị những gì công kích? Ta không công kích nhiều như ngươi, nhưng còn những kẻ công kích ta, chúng đã dùng những thủ đoạn nhà người không sao hình dung được. Từ lời công kích trực tiếp tới lời công kích lẩn quất âm u, từ những cái bắt tay giả vờ bồ bịch tới những cuộc “phỏng vấn” lập lờ thêu dệt chuyện cuồng điên! Hỡi ôi? Điên hay cuồng, tỉnh hay say, ôn hoà hay cáu kỉnh, đảo ngược hay lộn xộn xuôi, bao giờ cũng theo thể lệ của linh hồn thi nhiên rất mực của tao. Đâu có liên can gì tới những thứ quan niệm âm u mưu toan trong linhhồn chúng nó. Nietzsche ạ, nhà người bình sinh cũng gặp một vài bạn hữu sáng suốt chân thành. Còn ta, quả nhiên bình sinh không hề gặp một nửa con người bạn hữu. Bởi vì nếu có bạn hữu chân thành, thì tuyệt nhiên nó chẳng nghe rõ một chút gì trong điều tao nói. Và cũng chẳng bao giờ tao hiểu được những điều bọn chúng đã nói ra. Thì những thằng bạn đó cũng làm quẫn bách người ta cũng ngang mực địch thủ bức bách mà thôi. Tao cô độc gấp ngàn lần rưỡi nhà ngươi Nietzsche Zarathustra Nhà Ma ạ. Đáng lẽ ra từ lâu ta đã điên rồ thật sự. Nhưng vì lẽ gì ta không điên? Vì lẽ gì ta còn tỉnh táo tới bây giờ để cùng nhà ngươi đàm thoại về tâm sự tuế nguyệt tinh sương? Về tâm tư tinh sương sinh tương diệt, đương diệt tức sinh, về lẽ bất thình lình sát na nhiếp tận, về lẽ nhẫn tiếp tiệp mẫn tẫn khôi vô sinh pháp nhẫn tàng ẩn giữa cheo leo tịch hạp hai vành trong thể lệ tam muội tần thân phen phen nhiếp hai bờ tịch hạp thù thắng mỗi thượng thừa, vì lẽ gì bài ca bất tận của tao vẫn hằng hằng lên cung bậc phấp phới phiêu bồng như du nhiên thế ngoại? Rồi bất thình lình về trở lại yêu mến biển dâu, o bế o bồng xiết bao là hình ảnh nữ chúa nữ vương suốt ngàn năm lạc loài trong vũ trụ. Và riêng biệt Một Cô Em Mọi Nhỏ ở một góc sườn núi sườn non cũng đi về song song bước chân hoàng hậu? Bởi đâu mà ra thế?...”.', N'le-hoi-thang-ba.jpg', 500, CAST(N'2017-02-25' AS Date), 77, 22, 21, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (1524, N'00000000000000', N'HOÀNG LÊ NHẤT THỐNG CHÍ', N'“Sách Hoàng Lê nhất thống chí này mới cách đây hơn một trăm năm, chép theo chính sử mà in tường truyện luận chia ra từng hồi. Xem qua thì biết vua Lê hèn yếu, chúa Trịnh chuyên quyền, chính trị thì rối loạn ở trên, phong tục thì bại hoại ở dưới, nàng Tuyên Phi lấy làm người bé thiếp, chỉ cầu sủng ái mà gây nên cái họa chiêu binh, Cống Chỉnh thì là kẻ gian thần, cầu lấy thoát thân mà gây ra cái cơ ngoại hoạn. May mà: Trời còn dành sơn hà cho Nam quốc, mới sinh ra anh hùng ở Tây Sơn. Một lần cử binh mà trừ được uy quyền chúa Trịnh. Hai lần cử binh mà đốt hết lông cánh quận Bằng. Tôn Sĩ Nghị thì ôm đầu về Bắc, Phúc Khang An không dám tiến bước sang Nam. Vua tôi nhà Thanh ngại dùng binh mà không dám sinh lòng xâm lược. Vua tôi nhà Lê bị chước dối mà không trở lại nước nhà.” - Trích Bài tựa', N'ho%C3%A0ng-l%C3%AA-nh%E1%BA%A5t-th%E1%BB%91ng-ch%C3%AD.jpg', 500, CAST(N'2017-02-25' AS Date), 78, 23, 11, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (1525, N'00000000000000', N'KHU PHỐ TÂY Ở HÀ NỘI NỬA ĐẦU THẾ KỶ XX QUA TƯ LIỆU ĐỊA CHÍNH', N'Có rất nhiều tư liệu miêu tả về các hoạt động thương mại ở đây, tuy nhiên, những miêu tả về cảnh quan, nhà cửa nơi này dường như không được chú trọng lắm. Nếu qua địa bạ cổ Hà Nội (lập trong nửa đầu thế kỷ XIX), chúng ta có được những hình dung về quang cảnh Hà Nội nói chung, khu phố cổ nói riêng, với sự phân chia theo các đơn vị hành chính xã/thôn hay phường, theo những sở/khoảnh đất thuộc các loại sở hữu khác nhau, hay các loại hình mặt nước như ao, hồ, đoạn sông… những hình ảnh mang nhiều dáng dấp của nông thôn hơn thành phố (trừ những miêu tả về các dấu ấn của thành Hà Nội) thì tới nửa cuối thế kỷ XIX, đầu thế kỷ XX, với những ghi chép của người Pháp và người bản xứ cùng các nguồn tư liệu lưu trữ, sự chuyển mình đô thị hóa của Hà Nội đã được phác họa ngày càng rõ nét. Có thể nhận thấy, quá trình biến đổi của Hà Nội giai đoạn cận đại trải qua hai thời kỳ chính: giai đoạn đầu từ năm 1888 - 1920 và giai đoạn thứ hai từ năm 1920 - 1945. Ở mỗi thời kỳ, nhịp độ và mức độ các hoạt động của thực dân Pháp tác động tới sự biến đổi diện mạo khu phố cổ hoàn toàn khác nhau. Trong thời kỳ đầu, hai hoạt động chính được tiến hành đồng thời của người Pháp là phá huỷ và tái tạo cảnh quan tự nhiên khu phố cổ. Những cảnh quan cũ mang đậm tính chất nông thôn đan xen trong quang cảnh đô thị thời kỳ trước từng bước nhường chỗ cho những cảnh quan thuần chất đô thị. Ở giai đoạn tiếp sau, người Pháp đã tiến hành chỉnh trang diện mạo đường xá, nhà cửa của khu phố cổ trong quá trình quy hoạch tổng thể đô thị Hà Nội. Đặc biệt, từ năm 1930 đến năm 1944, liên tục những đề án quy hoạch đô thị Hà Nội được Sở kiến trúc và đô thị đưa ra nhằm cải tạo và mở rộng thành phố Hà Nội, áp dụng những nguyên lý quy hoạch hiện đại thịnh hành ở châu Âu đương thời, có sửa đổi cho phù hợp với hoàn cảnh Đông Dương. Diện mạo của khu phố cổ có những đổi thay, đặc biệt là những đổi thay về nhà cửa và phố xá.', N'khu-ph%E1%BB%91-t%C3%A2y-%E1%BB%9F-h%C3%A0-n%E1%BB%99i-n%E1%BB%ADa-%C4%91%E1%BA%A7u-th%E1%BA%BF-k%E1%BB%B7-xx-qua-t%C6%B0-li%E1%BB%87u-%C4%91%E1%BB%8Ba-ch%C3%ADnh.jpg', 500, CAST(N'2017-02-25' AS Date), 79, 23, 31, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (1526, N'00000000000000', N'Từ Beirut Đến Jerusalem', N'Những vấn đề liên quan đến Trung Đông, tới Israel, Liban, Syria... luôn nhận được sự quan tâm theo dõi của cộng đồng quốc tế. Họ rất muốn tìm hiểu sự thực về sự phát triển thần kỳ của Israel, hay các xung đột chính trị ngoại giao ở Liban, Syria, hay quyền lực của các nhà nước Arab giàu có, hay lịch sử lâu đời và đẫm màu sắc tôn giáo của vùng đất này, hay vai trò của Mỹ, Châu Âu với Trung Đông… Cuốn sách rất dày này của Thomas Friedman đã đề cập đến gần như tất cả những vấn đề đó. Từ Beirut đến Jerusalem tập trung xoay quanh những xung đột gay gắt ở khu vực Trung Đông, được chia làm hai phần: Beirut và Jerusalem. - Phần thứ nhất: Beirut, Friedman đã tái hiện một cách sống động về cuộc nội chiến của người dân Liban. Từ lịch sử cuộc nội chiến, những xung đột nội bộ gay gắt đến chi tiết nước Mỹ nhảy vào cuộc chiến này bằng cách nào và diễn biến ra sao đều được ống kính phóng viên của ông thu trọn. - Phần thứ hai: Jerusalem, người đọc bắt gặp bức tranh thu nhỏ nền văn hóa của người Do Thái và nguồn gốc của người Israel. Từ đó, tác giả đi sâu phân tích lịch sử và diễn biến của cuộc xung đột giữa người Palestine và người Israel. Với giọng văn sắc sảo, trong sáng, Từ Beirut đến Jerusalem đã chạm sâu hơn vào lịch sử đau thương và vô cùng phức tạp của cuộc xung đột ở khu vực Trung Đông. Cuốn sách khiến độc giả trải nghiệm hết những cung bậc cảm xúc, từ những đau đớn tột cùng đến những nụ cười sảng khoái. Một cuốn sách không thể bỏ qua đối với bất cứ ai đang tìm kiếm cái nhìn sâu hơn về những nguyên nhân chính trị và những ảnh hưởng tâm lý của cuộc xung đột đa sắc tộc đã bủa vây khu vực chưa bao giờ chấm dứt tiếng súng này.', N'tu-beirut-den-jerusalem.jpg', 500, CAST(N'2017-02-25' AS Date), 80, 23, 32, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (1527, N'00000000000000', N'Việt - Pháp bang giao sử lược - Bìa cứng', N'Lịch sử cuộc mất chủ quyền của một nước là lịch sử tối cần thiết cho nhân dân nước ấy. Vì có thấu rõ việc trước mới đề phòng và lo liệu cho việc sau, có thấy những sai lầm, những đắc sách của người xưa, thì người nay và người sau mới lo tránh hoặc gắng bắt chước theo, có cảm những hờn tủi của người dân mất nước mới phấn khích, tự cường mà mưu nghĩ đến cuộc phục hưng. Trong lịch sử cận đại của Việt Nam, sự can thiệp của nước Pháp, lấy Nam Kỳ làm thuộc địa, đặt bảo hộ ở Trung, Bắc Kỳ... là một biến cố lớn lao và hệ trọng. Từ trước đến nay, biến cố ấy chỉ ghi chép trong các sách, đoạn sử rời rạc, tùy theo việc lặt vặt, chưa có một quyển sử nào chuyên chép riêng ra và cho đầy đủ. Mà những sự tình trong tám mươi năm ngoại thuộc ấy lại tô điểm bởi một cuộc chống chọi, tranh đấu không ngừng của dân tộc Việt Nam, đáng cho hậu thế chiêm nghiệm biết bao! Thấy sự thiếu thốn ấy, chúng tôi sưu tầm tài liệu trong các sách sử tây, ta, soạn ra sách này để giúp một phần cho mục đích nói trên. Chúng tôi truy nguyên từ khi người Âu châu mới đặt chân lên đất Việt Nam, thế kỷ XVI, sự giao thiệp giữa họ và ta ở thế kỷ XVII làm họ xét biết và bắt đầu để ý đến nước ta. Tiếp đến sự cầu cứu nước Pháp của Hoàng tử Cảnh và hiệp ước Versailles không hiệu quả, vua Minh Mạng cũng có ý tưởng tự cường, tự chủ, nhưng không hiểu tình thế thiên hạ, lại không dung nạp đạo Gia Tô nên cái mầm xung đột sinh ra từ đó. Vua Thiệu Trị tiếp tục chính sách ấy, người Pháp có cớ mà gây hấn và tiếng súng đầu tiên nổ ở Đà Nẵng năm 1847 đã báo hiệu những ngày mai đầy gian hiểm. Thế mà kế vua, vua Tự Đức cũng không lo tự tân, tự cường để theo kịp trào lưu thế giới, kẻ sĩ trong nước thì chỉ lo gọt giũa văn chương, ngâm nga thi phú, rồi đến khi quân địch tới bên cạnh, kẻ bàn chiến, người nói thủ, kẻ ưng hòa, không nhất quyết một bề nào, khiến dẫn đến việc mất ba tỉnh phía đông, ba tỉnh phía tây Nam Kỳ. Trong các sự tình ấy, thao lược của Nguyễn Tri Phương, nghĩa khí của Trương Định, là những tài liệu rất quý báu của Quốc sử. Chiếm xong toàn cõi Nam Kỳ, người Pháp mưu bành trướng thế lực ra Bắc, Trung Kỳ. Việc Françis Garnier và Jean Dupuis, Henri Rivière hai lần gây sự ở Hà Nội, việc Thuận An thất thủ, tình cảnh “tứ nguyệt tam vương”(*), cuộc đột kích ở Huế, vua Hàm Nghi xuất bôn là những tấn bi kịch đầy chi tiết cảm động. - trích Lời nói đầu', N'bia1.jpg', 500, CAST(N'2017-02-25' AS Date), 81, 23, 28, 1)
GO
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (1528, N'00000000000000', N'Cảnh huống song ngữ Việt - Hoa tại Đồng bằng sông Cửu Long', N'Lời giới thiệu Quy ước viết tắt Mở đầu Chương 1: Cơ sở lý luận về song ngữ Chương 2: Bức tranh tổng quát về người Hoa và tiếng Hoa ở đồng bằng sông Cửu Long Chương 3: Đặc điểm sử dụng ngôn ngữ của người Hoa ở An Giang Chương 4: Đặc điểm sử dụng ngôn ngữ của người Hoa ở Sóc Trăng, Kiên Giang và Bạc Liêu Chương 5: Đặc điểm sử dụng ngôn ngữ và thái độ của người Hoa đối với việc học tập ngôn ngữ trong nhà trường Kết luận Tài liệu tham khảo', N'canh-huong-song-ngu-viet-hoa-tai-dong-ba.jpg', 500, CAST(N'2017-02-25' AS Date), 82, 23, 28, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (1529, N'00000000000000', N'ĐẠI VIỆT SỬ KÝ TOÀN THƯ', N'Đại Việt sử ký toàn thư là bộ quốc sử danh tiếng, một di sản quý báu của dân tộc Việt Nam nghìn năm văn hiến. Đó là bộ sử cái, có giá trị nhiều mặt, gắn liền với tên tuổi các nhà sử học nổi tiếng như Lê Văn Hưu, Phan Phu Tiên, Ngô Sĩ Liên, Phạm Công Trứ, Lê Hy… Việc phát hiện bản in xưa nhất của bộ Đại Việt sử ký toàn thư, bản Nội các quan bản, năm Chính Hòa thứ 18, tức năm 1697 có một ý nghĩa đặc biệt. Bộ sách đã được ra mắt bạn đọc vào những năm 90 của thế kỷ trước và từng được tái bản trong những năm gần đây. Nhân Đại lễ 1000 năm Thăng Long – Hà Nội, Nhà xuất bản Khoa học xã hội và Công ty Văn hóa Đông A liên kết tái bản bộ Đại Việt sử ký toàn thư, theo bản in năm 1998 gồm 4 tập trong một tập khổ lớn và được PGS.TS Ngô Đức Thọ chỉnh lý các thông tin mới đối với một số chú thích có các khảo chú về địa danh mà nay các đơn vị hành chính đã có nhiều thay đổi. Công trình xuất bản Đại Việt sử ký toàn thư gồm 4 tập: Tập I gồm Lời Nhà xuất bản Khoa học xã hội, Lời giới thiệu của Giáo sư Viện sĩ Nguyễn Khánh Toàn, bài Khảo cứu về “Đại Việt sử ký toàn thư: tác giả - văn bản - tác phẩm” của Giáo sư Phan Huy Lê và bản dịch phần đầu Đại Việt sử ký toàn thư gồm Quyển thủ, Ngoại kỷ Q. 1 - 5, Bản kỷ Q. 1 - 4, do nhà nghiên cứu Hán Nôm Ngô Đức Thọ dịch, chú giải, và Giáo sư Hà Văn Tấn hiệu đính. Tập II gồm phần dịch và chú giải Bản kỷ Q.5 - 13 do nhà nghiên cứu Hán Nôm Hoàng Văn Lâu dịch, Giáo sư Hà Văn Tấn hiệu đính. Tập III gồm phần dịch và chú giải Bản kỷ Q.14 - 19 do nhà nghiên cứu Hán Nôm Hoàng Văn Lâu dịch, Giáo sư Hà Văn Tấn hiệu đính và phần Phụ lục với bản dịch Đại Việt sử ký tục biên Q.20 - 21 của Phạm Công Trứ do nhà nghiên cứu Hán Nôm Ngô Thế Long thực hiện và Sách dẫn để tra cứu do Bộ môn phương pháp luận sử học thuộc Khoa sử Trường Đại học Tổng hợp Hà Nội thực hiện. Tập IV in lại bản chụp nguyên văn chữ Hán bản in Nội các quan bản bộ Đại Việt sử ký toàn thư.', N'dai-viet-su-ky-toan-thu-(1).jpg', 500, CAST(N'2017-02-25' AS Date), 11, 23, 28, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (1530, N'00000000000000', N'SỬ KÝ TƯ MÃ THIÊN - Tập II - Liệt Truyện - Hạ', N'“Thế rồi Thái tử tìm chủy thủ sắc bén trong thiên hạ, kiếm được chủy thủ của Từ phu nhân nước Triệu, trả giá trăm dật vàng, sai thợ đem tôi trong thuốc độc, dùng người để thử, rướm máu như sợi tơ, không ai không chết ngay. Bèn chuẩn bị hành trang cho Kinh Kha lên đường. Nước Yên có dũng sĩ Tần Vũ Dương, mười ba tuổi, giết người, không ai dám nhìn thẳng. Bèn lệnh Tần Vũ Dương làm phó. Kinh Kha đợi người đến, muốn cùng đi; người đó ở xa chưa đến, sắp sẵn hành lý cho. Lâu sau, chưa lên đường, Thái tử cho là chậm trễ, ngờ Kinh Kha hối hận đổi ý, lại thúc giục: ‘Thời gian đã hết, Kinh Khanh há có ý gì chăng? Đan xin được sai Tần Vũ Dương đi trước.’ Kinh Kha giận, quát Thái tử: ‘Sao Thái tử sai hắn đi trước? Đi mà không trở về, là trò trẻ con! Vả lại đem một dao chủy thủ vào Tần mạnh đầy bất trắc, cho nên tôi còn lưu lại, đợi người khách của tôi đến đi cùng. Nay Thái tử cho là chậm trễ, vậy xin từ biệt!’ Bèn xuất phát. Thái tử cùng tân khách biết việc đó, đều mặc áo đội mũ trắng đưa tiễn. Đến trên sông Dịch, tế thần đường xong, liền xuất phát, Cao Tiệm Ly đánh đàn tranh, Kinh Kha họa lại hát theo điệu biến chủy, kẻ sĩ đều nhỏ lệ sụt sùi. Lại bước lên hát rằng:  ‘Gió se sắt chừ sông Dịch lạnh, tráng sĩ một đi chừ không trở lại!’ Lại hát bằng âm vũ khảng khái, kẻ sĩ đều trợn mắt, tóc dựng xiên lên mũ. Thế rồi Kinh Kha lên xe ra đi, không ngoái nhìn lại nữa.” - Truyện Kinh Kha, Thích khách liệt truyện', N'5b1jyx43.jpg', 500, CAST(N'2017-02-25' AS Date), 83, 23, 17, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (1531, N'00000000000000', N'XÃ HỘI VIỆT NAM QUA BÚT KÝ CỦA NGƯỜI NƯỚC NGOÀI - Bìa cứng', N'Trong lịch sử nước ta, thời Lê-Trịnh ở Đàng Ngoài và các chúa Nguyễn ở Đàng Trong vào những thế kỷ XVI, XVII, XVIII là thời kỳ phong phú nhất về mặt sử liệu. Đó là thời kỳ ra đời của nhiều tác phẩm đến nay vẫn còn là những tài liệu nghiên cứu có giá trị: Đại Việt sử ký toàn thư (tục biên) (Phạm Công Trứ và nhiều người khác), Đại Việt sử ký tiền biên, Việt sử tiêu án (Ngô Thì Sĩ), Hoàng Lê nhất thống chí (Ngô Thì Chí), Đại Việt thông sử, Phủ biên tạp lục, Kiến văn tiểu lục (Lê Quý Đôn)… Ngoài những tác phẩm do người Việt soạn thảo, còn có một bộ phận sử liệu rất quan trọng khác là các hồi ký, du ký, tài liệu nghiên cứu được các thương nhân, giáo sĩ nước ngoài viết nhằm mục đích chính là phục vụ nhu cầu tìm hiểu, khuếch trương việc buôn bán hoặc giảng đạo ở Đại Việt.  Xét về mặt học thuật, bên cạnh những nhận định chủ quan chịu ảnh hưởng của quan điểm thực dân, tác phẩm của họ nêu lên được nhiều khía cạnh của đời sống cư dân Việt thời đó mà các bộ chính sử và ngoại sử Việt Nam tỏ ra khá thiếu sót. Hai thế kỷ XVII, XVIII là thời điểm phát triển của loại tác phẩm này; những Cristoforo Borri, Alexandre de Rhodes, Thích Đại Sán, John Barrow… đã cung cấp cho giới nghiên cứu những tư liệu quý được soạn thảo bằng khả năng quan sát nhạy bén, sự trình bày có tính khoa học, bổ sung nhiều khiếm khuyết của chính sử, nhất là về phong tục tập quán, nhà cửa, cách ăn mặc, sinh hoạt của người dân hai miền Đàng Ngoài và Đàng Trong.  Người viết không có tham vọng trình bày một cách có hệ thống và đầy đủ những tư liệu đó, chỉ cố chắt lọc những gì có thể giúp người đọc có một cái nhìn khái quát về xã hội Đại Việt và Việt Nam vào các thế kỷ XVII, XVIII, XIX và thời kỳ mà cha ông ta đã đổ nhiều mồ hôi, máu và nước mắt, chinh phục những vùng đất hoang dã, biến chúng thành những khu vực trù phú như ngày nay. Bức tranh xã hội với những nét chấm phá còn thô sơ, rất mong được các bậc thức giả bổ khuyết cho.', N'image001.jpg', 500, CAST(N'2017-02-25' AS Date), 84, 23, 13, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (1532, N'00000000000000', N'NGOÀI BỜ ĐÔNG LÀ MẶT TRỜI', N'Câu chuyện về kinh thành bên cạnh dòng sông. Một cô cung nữ, những cô công chúa, hoàng tử và những vị vua, người con lai mang hai dòng máu... Khi chiến tranh đã đi qua, một kinh thành mới được dựng lên cạnh dòng sông. Rồi những con người mới cùng tới vùng đất ấy, được sinh ra trên vùng đất ấy. Một vị vua mới lên ngôi. Đất nước phương Đông đầu thế kỷ mười chín với ước muốn chuyển mình trong sự trì trệ của hàng ngàn năm văn minh nông nghiệp. Đất nước phương Đông với giấc mơ về hòa bình sau cuộc chiến tranh dài, trong những cuộc chiến tranh dài. Người chiến binh Tây dương viết trong cuốn hồi ký của mình: Đó là một đất nước buồn... Câu chuyện là góc nhìn mới, khách quan về triều Nguyễn và lịch sử Việt Nam đầu thế kỷ 19.', N'nxbtre_full_10312017_113101.jpg', 500, CAST(N'2017-02-25' AS Date), 85, 23, 16, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (1533, N'00000000000000', N'XÃ HỘI VIỆT NAM QUA BÚT KÝ CUẢ NGƯỜI NƯỚC NGOÀI - Bìa mềm', N'Trong lịch sử nước ta, thời Lê-Trịnh ở Đàng Ngoài và các chúa Nguyễn ở Đàng Trong vào những thế kỷ XVI, XVII, XVIII là thời kỳ phong phú nhất về mặt sử liệu. Đó là thời kỳ ra đời của nhiều tác phẩm đến nay vẫn còn là những tài liệu nghiên cứu có giá trị: Đại Việt sử ký toàn thư (tục biên) (Phạm Công Trứ và nhiều người khác), Đại Việt sử ký tiền biên, Việt sử tiêu án (Ngô Thì Sĩ), Hoàng Lê nhất thống chí (Ngô Thì Chí), Đại Việt thông sử, Phủ biên tạp lục, Kiến văn tiểu lục (Lê Quý Đôn)… Ngoài những tác phẩm do người Việt soạn thảo, còn có một bộ phận sử liệu rất quan trọng khác là các hồi ký, du ký, tài liệu nghiên cứu được các thương nhân, giáo sĩ nước ngoài viết nhằm mục đích chính là phục vụ nhu cầu tìm hiểu, khuếch trương việc buôn bán hoặc giảng đạo ở Đại Việt.  Xét về mặt học thuật, bên cạnh những nhận định chủ quan chịu ảnh hưởng của quan điểm thực dân, tác phẩm của họ nêu lên được nhiều khía cạnh của đời sống cư dân Việt thời đó mà các bộ chính sử và ngoại sử Việt Nam tỏ ra khá thiếu sót. Hai thế kỷ XVII, XVIII là thời điểm phát triển của loại tác phẩm này; những Cristoforo Borri, Alexandre de Rhodes, Thích Đại Sán, John Barrow… đã cung cấp cho giới nghiên cứu những tư liệu quý được soạn thảo bằng khả năng quan sát nhạy bén, sự trình bày có tính khoa học, bổ sung nhiều khiếm khuyết của chính sử, nhất là về phong tục tập quán, nhà cửa, cách ăn mặc, sinh hoạt của người dân hai miền Đàng Ngoài và Đàng Trong.  Người viết không có tham vọng trình bày một cách có hệ thống và đầy đủ những tư liệu đó, chỉ cố chắt lọc những gì có thể giúp người đọc có một cái nhìn khái quát về xã hội Đại Việt và Việt Nam vào các thế kỷ XVII, XVIII, XIX và thời kỳ mà cha ông ta đã đổ nhiều mồ hôi, máu và nước mắt, chinh phục những vùng đất hoang dã, biến chúng thành những khu vực trù phú như ngày nay. Bức tranh xã hội với những nét chấm phá còn thô sơ, rất mong được các bậc thức giả bổ khuyết cho.', N'image001.jpg', 500, CAST(N'2017-02-25' AS Date), 84, 23, 13, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (1534, N'00000000000000', N'NHỮNG NGƯỜI CHÂU ÂU Ở NƯỚC AN NAM - Bìa Cứng', N'Trong kho tàng tư liệu phương Tây viết về lịch sử, văn hóa Việt Nam truyền thống, chúng ta có thể phân biệt nhiều thế hệ tác giả. Thế hệ thứ nhất là các nhà du hành, thương nhân, giáo sĩ phương Tây đã từng đến hai miền lãnh thổ Đại Việt (Đàng Ngoài và Đàng Trong) trong những thế kỷ XVII-XVIII như các tác giả A. de Rhodes, S. Baron, W. Dampier, C. Borri, P. Poivre, J. Barrow... Thế hệ thứ hai là các tác giả (chủ yếu là người Pháp) có thời gian sinh sống ở Việt Nam vào nửa sau thế kỷ XIX, trong và ngay sau cuộc xâm lược của Pháp, bao gồm các sĩ quan, phóng viên, quan chức cai trị như G. Aubaret, J. Boissière, Hocquard, J. Silvestre, Luro... Thuộc thế hệ thứ ba, ta có thể kể đến các cha cố, nhà giáo, nhà nghiên cứu, học giả đã từng làm việc ở thuộc địa Đông Dương những thập niên đầu thế kỷ XX như L. Cadière, G. Dumoutier, Pelliot, H. Maspéro, Ch.B. Maybon... Từ đó đến nay, còn tiếp nối những thế hệ thứ tư, thứ năm nữa... Ch.B. Maybon, tác giả của những công trình được dịch ra ở đây, là một trong những nhà Việt Nam học người Pháp xuất sắc hồi đầu thế kỷ trước. Là giáo sư, tiến sĩ văn khoa, thông thạo nhiều ngoại ngữ (Anh, Đức, Hán, Latinh..)., ông được đánh giá như một gương mặt học giả thực sự uyên bác và nghiêm túc về lịch sử Việt Nam thời kỳ tiền thực dân. Ông là tác giả của nhiều tiểu luận và công trình nghiên cứu nổi tiếng như Une factorerie anglaise au Tonkin au XVII siècle - BEFEO, 1910 (Thương điếm Anh ở Đàng Ngoài thế kỷ XVII); Marchands européens en Cochinchine et au Tonkin - R.I.1916 (Các thương nhân người Âu ở Đàng Trong và Đàng Ngoài); Au sujet de la rivière du Tonkin - 1916 (Về vấn đề sông Đàng Ngoài); Histoire moderne du pays d’Annam - Paris, 1920 (Lịch sử cận đại xứ An Nam)... Cuốn sách Những người châu Âu ở nước An Nam là bản dịch hai chương II và IV cùng có nhan đề Les européens en pays d’Annam của cuốn Histoire moderne du pays d’Annam và tiểu luận Une factorerie anglaise au Tonkin au XVII siècle vừa nói bên trên. Trong hai chuyên luận Những người châu Âu ở nước An Nam và Thương điếm Anh ở Đàng Ngoài, Ch.B. Maybon đã dựng lên một toàn cảnh về sự có mặt và hoạt động của các giáo sĩ và thương nhân phương Tây ở An Nam trong hai thế kỷ XVII và XVIII. Riêng chuyên luận thứ hai đi sâu khai thác và phân tích những tư liệu lưu trữ viết về Công ty Đông Ấn Anh và thương điếm Anh ở Phố Hiến, sau chuyển đến Kẻ Chợ, trong ba thập kỷ cuối thế kỷ XVII. Đây là thời kỳ mà hai xứ Đàng Ngoài và Đàng Trong của Đại Việt đã có những tiếp xúc, đụng độ đầu tiên về kinh tế và văn hóa với các nước tư bản phương Tây. Các sử sách Việt Nam cung cấp cho chúng ta rất ít tư liệu về vấn đề này, may mắn là nó đã được bù đắp lại bằng những nguồn tư liệu phương Tây phong phú. Tổng hợp những tư liệu đó, tác giả đã phân tích những bối cảnh và sự chuyển biến của lịch sử thế giới, tình hình các nước Tây Âu, khu vực Đông Á và Đông Nam Á, Đàng Ngoài dưới quyền vua Lê chúa Trịnh và Đàng Trong dưới quyền các chúa Nguyễn, làm nền tảng cho những chính sách và những mối quan hệ về chính trị, thương mại, tôn giáo giữa phương Tây và Đại Việt, qua các phái bộ và các cuộc tiếp xúc, thương lượng ngoại giao, những chuyến đi của các tàu buôn, hoạt động truyền giáo của các giáo sĩ, công việc buôn bán của các thương điếm ngoại quốc với nhà nước phong kiến và dân chúng. Tác giả cũng đi sâu miêu tả những tình tiết, những liên minh và mâu thuẫn trong nội bộ những hoạt động đó, những tranh chấp, xung đột gay gắt giữa các nhóm thế lực: về tôn giáo là giữa các giáo đoàn dòng Tên (Jésuites) do Bồ Đào Nha bảo trợ và Hội truyền giáo ngoại quốc được triều đình Pháp ủng hộ, về lợi ích là giữa các Công ty Đông Ấn hoặc nhóm thương nhân người Bồ Đào Nha, Hà Lan, Anh, Pháp... Đồng thời là những động cơ, toan tính, kế hoạch, kể cả những thủ đoạn, âm mưu hiểm độc để loại trừ nhau giữa các cá nhân có chức quyền, ảnh hưởng trong cùng một địa phận, một tổ chức, giữa những chức sắc giáo hội cùng là tín đồ xả thân vì Chúa, hoặc những thủ trưởng, quan chức cùng phục vụ cho lợi ích dân tộc của một quốc gia thực dân. Cũng qua những chứng cứ lịch sử, chúng ta hiểu biết rõ hơn chính sách đối ngoại về kinh tế và tôn giáo đối với các nước phương Tây của các chúa Trịnh, chúa Nguyễn, sự chuyển biến có thể giải thích được từ một thái độ cởi mở, khoan dung đến những biện pháp bài ngoại khắt khe, cấm đoán và khủng bố của chính quyền phong kiến Đại Việt. Tác giả còn đưa ra những sử liệu nói lên tính toán vụ lợi và có khi là thái độ áp đặt trịch thượng của một số quan chức người phương Tây trong những cuộc giao thiệp, thương thuyết với nhà cầm quyền bản xứ, ở một mặt khác, là những thói sách nhiễu, tệ hà lạm tham nhũng của những quan chức Việt Nam, nhất là bộ phận quan lại ngạch hải quan có nhiệm vụ giao thiệp, khám xét và đánh thuế các tàu buôn nước ngoài. Điều đáng quý ở Ch.B. Maybon là tính trung thực, khách quan của một trí thức có nhân cách độc lập, thoát khỏi sự ràng buộc của những định kiến về chủng tộc, chính trị hoặc tôn giáo, tín ngưỡng. Là người Pháp chính cống, nhưng ông không bênh vực cho chủ nghĩa thực dân như một số tác giả khác cùng thời đã làm. Là người yêu Việt Nam, nhưng ông cũng không ngần ngại vạch ra những thói hư tật xấu của giới quan liêu và cơ chế phiền hà của bộ máy chính quyền phong kiến. Ngòi bút của ông trầm tĩnh nhưng không lạnh lùng, để cho những sự kiện lịch sử tự nó nói lên, không áp đặt suy diễn, đây đó được điểm xuyết bằng một vài lời bình súc tích, ngắn gọn, nhưng không kém phần sắc sảo, hóm hỉnh. Tác giả chứng minh cho chúng ta thấy quan hệ phức tạp rắc rối khó tháo gỡ giữa thương mại và tôn giáo, kinh tế và chính trị từ cả hai phía phương Tây và Việt Nam, trong một thời đoạn lịch sử đã xuất hiện những tiềm năng và cơ hội tiếp xúc giao lưu Đông-Tây, đáng lý ra có thể tạo đà cho những chuyển biến tích cực, tiến bộ của xã hội Việt Nam truyền thống, nhưng đã bị tuột khỏi mất, và như vậy đã dẫn đến tình trạng và những sự cố mang tính bi kịch…', N'nhung-nguoi-chau-au-o-nuoc-an-nam.jpg', 500, CAST(N'2017-02-25' AS Date), 86, 23, 33, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (1535, N'00000000000000', N'Lịch Sử Nội Chiến Ở Việt Nam Từ 1771 Đến 1802', N'Thoát khỏi sự ràng buộc bắt nguồn từ những định kiến và lập trường chính trị, Lịch sử nội chiến ở Việt Nam từ 1771 đến 1802 đã dựng lại chi tiết bàn cờ quyền lực trong xã hội Đại Việt nửa cuối thế kỷ 18. Những liên minh và đối địch, tạm thời hay lâu bền dựa trên căn bản quyền lợi thiết thân được tái hiện sinh động: những giáo sĩ thừa sai và các nhà buôn Tây phương, nhóm di dân Hoa kiều và cướp biển Tề Ngôi, các thế lực ngoại bang Xiêm La và Mãn Thanh, nhà Lê-Trịnh thời mạt diệp và những vị hoàng thân chạy loạn... Vượt lên trên hết là gương mặt hai đối thủ lớn nhất của thời đại: Quang Trung Nguyễn Huệ và Gia Long Nguyễn Ánh.   Trong số rất nhiều sách sử, Lịch sử nội chiến ở Việt Nam từ 1771 đến 1802 chiếm một địa vị thật riêng. Ngay từ khi xuất bản lần đầu năm 1973, tác phẩm đã được học giới nhìn nhận như một công trình chung quyết về lịch sử phân ly và nhất thống đất nước. Nhà chuyên môn tìm thấy ở sách một tinh thần học thuật không vì nể, người đọc phổ thông tìm thấy trong sách những câu chuyện xảy ra nhiều thế kỷ trước mà ảnh hưởng còn mãi đến ngày nay.', N'lich-su-noi-chien-o-viet-nam-tu-1771-den.jpg', 500, CAST(N'2017-02-25' AS Date), 87, 23, 29, 1)
INSERT [dbo].[Books] ([BookId], [Isbn], [Title], [Description], [CoverImageUrl], [PageNumber], [PublishedDate], [AuthorId], [CategoryId], [PublisherId], [Discontinued]) VALUES (1726, N'0000000000000', N'aa', N'sach moi mai zooo!', N'', 120, CAST(N'2017-03-04' AS Date), 25, 18, 21, 0)
SET IDENTITY_INSERT [dbo].[Books] OFF
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (2, N'test')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (3, N'test')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (4, N'test')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (5, N'test')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (6, N'test')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (7, N'test')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (8, N'test')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (9, N'test')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (10, N'test')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (11, N'test')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (12, N'test')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (13, N'test')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (14, N'test')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (15, N'Sách Lễ Tết & Phong tục')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (16, N'Sách đọc mùa Giáng sinh')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (17, N'Oshawa')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (18, N'Krishnamurti')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (19, N'Minh Triết Phương Đông')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (20, N'Triết Học Phương Tây')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (21, N'Văn Học Việt Nam')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (22, N'Văn Học Thế Giới')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (23, N'Lịch Sử')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Copies] ON 

INSERT [dbo].[Copies] ([CopyId], [BookId], [IsAvailable]) VALUES (3, 25, 1)
INSERT [dbo].[Copies] ([CopyId], [BookId], [IsAvailable]) VALUES (4, 25, 0)
SET IDENTITY_INSERT [dbo].[Copies] OFF
INSERT [dbo].[LoanDetails] ([CopyId], [LoanId], [ReturnDate]) VALUES (3, 6, NULL)
INSERT [dbo].[LoanDetails] ([CopyId], [LoanId], [ReturnDate]) VALUES (4, 6, NULL)
INSERT [dbo].[LoanDetails] ([CopyId], [LoanId], [ReturnDate]) VALUES (3, 14, NULL)
INSERT [dbo].[LoanDetails] ([CopyId], [LoanId], [ReturnDate]) VALUES (4, 14, NULL)
INSERT [dbo].[LoanDetails] ([CopyId], [LoanId], [ReturnDate]) VALUES (3, 15, NULL)
INSERT [dbo].[LoanDetails] ([CopyId], [LoanId], [ReturnDate]) VALUES (4, 15, NULL)
INSERT [dbo].[LoanDetails] ([CopyId], [LoanId], [ReturnDate]) VALUES (3, 18, NULL)
INSERT [dbo].[LoanDetails] ([CopyId], [LoanId], [ReturnDate]) VALUES (4, 18, NULL)
INSERT [dbo].[LoanDetails] ([CopyId], [LoanId], [ReturnDate]) VALUES (3, 19, NULL)
INSERT [dbo].[LoanDetails] ([CopyId], [LoanId], [ReturnDate]) VALUES (4, 19, NULL)
INSERT [dbo].[LoanDetails] ([CopyId], [LoanId], [ReturnDate]) VALUES (3, 21, NULL)
INSERT [dbo].[LoanDetails] ([CopyId], [LoanId], [ReturnDate]) VALUES (4, 22, NULL)
INSERT [dbo].[LoanDetails] ([CopyId], [LoanId], [ReturnDate]) VALUES (3, 12, NULL)
INSERT [dbo].[LoanDetails] ([CopyId], [LoanId], [ReturnDate]) VALUES (4, 12, NULL)
SET IDENTITY_INSERT [dbo].[Loans] ON 

INSERT [dbo].[Loans] ([LoanId], [IssueDate], [LimitDay], [MemberId], [LibrarianId]) VALUES (1, CAST(N'2017-03-05 10:59:34.600' AS DateTime), 2, 2, 3)
INSERT [dbo].[Loans] ([LoanId], [IssueDate], [LimitDay], [MemberId], [LibrarianId]) VALUES (6, CAST(N'2017-03-04 11:09:23.000' AS DateTime), 5, 2, 3)
INSERT [dbo].[Loans] ([LoanId], [IssueDate], [LimitDay], [MemberId], [LibrarianId]) VALUES (12, CAST(N'2017-03-04 11:43:28.000' AS DateTime), 2, 2, 3)
INSERT [dbo].[Loans] ([LoanId], [IssueDate], [LimitDay], [MemberId], [LibrarianId]) VALUES (14, CAST(N'2017-03-05 11:48:13.090' AS DateTime), 5, 2, 3)
INSERT [dbo].[Loans] ([LoanId], [IssueDate], [LimitDay], [MemberId], [LibrarianId]) VALUES (15, CAST(N'2017-03-05 11:49:46.487' AS DateTime), 3, 2, 3)
INSERT [dbo].[Loans] ([LoanId], [IssueDate], [LimitDay], [MemberId], [LibrarianId]) VALUES (18, CAST(N'2017-03-05 11:54:36.100' AS DateTime), 2, 2, 3)
INSERT [dbo].[Loans] ([LoanId], [IssueDate], [LimitDay], [MemberId], [LibrarianId]) VALUES (19, CAST(N'2017-03-05 11:55:01.633' AS DateTime), 3, 2, 3)
INSERT [dbo].[Loans] ([LoanId], [IssueDate], [LimitDay], [MemberId], [LibrarianId]) VALUES (20, CAST(N'2017-03-04 21:14:59.000' AS DateTime), 3, 2, 3)
INSERT [dbo].[Loans] ([LoanId], [IssueDate], [LimitDay], [MemberId], [LibrarianId]) VALUES (21, CAST(N'2017-03-04 21:15:45.000' AS DateTime), 5, 2, 3)
INSERT [dbo].[Loans] ([LoanId], [IssueDate], [LimitDay], [MemberId], [LibrarianId]) VALUES (22, CAST(N'2017-03-04 21:17:21.000' AS DateTime), 3, 2, 3)
SET IDENTITY_INSERT [dbo].[Loans] OFF
SET IDENTITY_INSERT [dbo].[Publishers] ON 

INSERT [dbo].[Publishers] ([PublisherId], [Name], [Contact], [Address], [Description]) VALUES (10, N'test3', N'q', N'r', N'y')
INSERT [dbo].[Publishers] ([PublisherId], [Name], [Contact], [Address], [Description]) VALUES (11, N'NXB Hội Nhà Văn', NULL, NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherId], [Name], [Contact], [Address], [Description]) VALUES (12, N'NXB Lao Động - Xã Hội', NULL, NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherId], [Name], [Contact], [Address], [Description]) VALUES (13, N'NXB Hồng Đức', NULL, NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherId], [Name], [Contact], [Address], [Description]) VALUES (14, N'NXB Kim Đồng', NULL, NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherId], [Name], [Contact], [Address], [Description]) VALUES (15, N'NXB Phụ Nữ', NULL, NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherId], [Name], [Contact], [Address], [Description]) VALUES (16, N'NXB Trẻ', NULL, NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherId], [Name], [Contact], [Address], [Description]) VALUES (17, N'NXB Văn Học', NULL, NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherId], [Name], [Contact], [Address], [Description]) VALUES (18, N'NXB Văn Hóa - Thông Tin', NULL, NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherId], [Name], [Contact], [Address], [Description]) VALUES (19, N'NXB Tổng hợp Tp.HCM', NULL, NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherId], [Name], [Contact], [Address], [Description]) VALUES (20, N'NXB Lao Động', NULL, NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherId], [Name], [Contact], [Address], [Description]) VALUES (21, N'NXB Văn Hóa Sài Gòn', NULL, NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherId], [Name], [Contact], [Address], [Description]) VALUES (22, N'NXB Thời Đại', NULL, NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherId], [Name], [Contact], [Address], [Description]) VALUES (23, N'NXB Đà Nẵng', NULL, NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherId], [Name], [Contact], [Address], [Description]) VALUES (24, N'N\A', NULL, NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherId], [Name], [Contact], [Address], [Description]) VALUES (25, N'NXB Văn Hóa - Văn Nghệ', NULL, NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherId], [Name], [Contact], [Address], [Description]) VALUES (26, N'NXB Tôn Giáo', NULL, NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherId], [Name], [Contact], [Address], [Description]) VALUES (27, N'Từ Điển Bách Khoa', NULL, NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherId], [Name], [Contact], [Address], [Description]) VALUES (28, N'NXB Khoa Học - Xã Hội', NULL, NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherId], [Name], [Contact], [Address], [Description]) VALUES (29, N'NXB Tri Thức', NULL, NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherId], [Name], [Contact], [Address], [Description]) VALUES (30, N'Đại Học Sư Phạm', NULL, NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherId], [Name], [Contact], [Address], [Description]) VALUES (31, N'NXB Hà Nội', NULL, NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherId], [Name], [Contact], [Address], [Description]) VALUES (32, N'NXB Công An Nhân Dân', NULL, NULL, NULL)
INSERT [dbo].[Publishers] ([PublisherId], [Name], [Contact], [Address], [Description]) VALUES (33, N'NXB Thế giới', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Publishers] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [Name]) VALUES (1, N'admin')
INSERT [dbo].[Roles] ([RoleId], [Name]) VALUES (2, N'librarian')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [Username], [Password], [FullName], [PhoneNumber], [Address], [Email], [RoleId]) VALUES (2, N'admin', N'admin', NULL, N'admin', N'admin', N'admin', 1)
INSERT [dbo].[Users] ([UserId], [Username], [Password], [FullName], [PhoneNumber], [Address], [Email], [RoleId]) VALUES (3, N'koala1', N'koalakoala', N'koala', N'0123456789', N'forest', N'koala@forest.com', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK__Books__AuthorId__300424B4] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([AuthorId])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK__Books__AuthorId__300424B4]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK__Books__CategoryI__30F848ED] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK__Books__CategoryI__30F848ED]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK__Books__Publisher__31EC6D26] FOREIGN KEY([PublisherId])
REFERENCES [dbo].[Publishers] ([PublisherId])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK__Books__Publisher__31EC6D26]
GO
ALTER TABLE [dbo].[Copies]  WITH CHECK ADD  CONSTRAINT [FK__Copies__BookId__35BCFE0A] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([BookId])
GO
ALTER TABLE [dbo].[Copies] CHECK CONSTRAINT [FK__Copies__BookId__35BCFE0A]
GO
ALTER TABLE [dbo].[LoanDetails]  WITH CHECK ADD FOREIGN KEY([CopyId])
REFERENCES [dbo].[Copies] ([CopyId])
GO
ALTER TABLE [dbo].[LoanDetails]  WITH CHECK ADD FOREIGN KEY([LoanId])
REFERENCES [dbo].[Loans] ([LoanId])
GO
ALTER TABLE [dbo].[Loans]  WITH CHECK ADD  CONSTRAINT [FK__Loans__Librarian__35BCFE0A] FOREIGN KEY([LibrarianId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Loans] CHECK CONSTRAINT [FK__Loans__Librarian__35BCFE0A]
GO
ALTER TABLE [dbo].[Loans]  WITH CHECK ADD  CONSTRAINT [FK__Loans__MemberId__36B12243] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Loans] CHECK CONSTRAINT [FK__Loans__MemberId__36B12243]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK__Users__RoleId__37A5467C] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK__Users__RoleId__37A5467C]
GO
/****** Object:  StoredProcedure [dbo].[DeleteAuthorById]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteAuthorById](
@AuthorId int
) as
begin
	if not exists (select * from Authors Where AuthorId = @AuthorId)
		begin
			return 0;
		end
	else
		begin
			if exists (select * from Books where AuthorId = @AuthorId)
				begin
					return -1;
				end
			else 
				begin
					delete from Authors where AuthorId = @AuthorId;
					return @@ROWCOUNT;
				end
		end
end


GO
/****** Object:  StoredProcedure [dbo].[DeleteBookById]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteBookById](
@BookId int
) as
begin
	if exists (select * from Copies where BookId = @BookId) return -1;
	if not exists (select * from Books where BookId = @BookId) return 0;
	begin
		delete from Books where BookId = @BookId;
		return @@ROWCOUNT;
	end
end


GO
/****** Object:  StoredProcedure [dbo].[DeleteCategoryById]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteCategoryById](
@CategoryID int
) as
begin
	if not exists (select * from Categories where CategoryId = @CategoryID)
		begin
			return 0;
		end
	else
		begin
			if exists (select * from Books where Books.CategoryId = @CategoryID)
				begin
					return -1;
				end
			else
				begin
					delete from Categories where Categories.CategoryId = @CategoryID;
					return @@ROWCOUNT;
				end
		end
end


GO
/****** Object:  StoredProcedure [dbo].[DeleteCopiesById]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteCopiesById](
@CopyId int
) as
begin
	if not exists (select * from Copies where CopyId = @CopyId) return 0;
	if exists (select * from LoanDetails where CopyId = @CopyId) return -1;
	delete from Copies  where CopyId = @CopyId;
	return @@ROWCOUNT;
end


GO
/****** Object:  StoredProcedure [dbo].[DeleteLoanById]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteLoanById](
@LoanId int
) as
begin
	if exists (select * from LoanDetails where LoanId = @LoanId) return -1;
	if not exists (select * from Loans) return 0;
	delete from Loans where LoanId = @LoanId;
	return @@ROWCOUNT;
end


GO
/****** Object:  StoredProcedure [dbo].[DeletePublisherById]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeletePublisherById](
@PublisherId int
) as
begin
	if not exists (select * from Publishers where PublisherId = @PublisherId) return 0;
	if exists (select * from Books where PublisherId = @PublisherId) return -1;
	else
		begin
			delete from Publishers where PublisherId = @PublisherId;
			return @@Rowcount;
		end
end


GO
/****** Object:  StoredProcedure [dbo].[DeleteRoleById]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteRoleById](
@RoleID int
) as
begin
	SET NOCOUNT OFF;
	if not exists (select * from Users where  RoleId= @RoleID)
		begin
			if exists (select * from Roles where RoleId = @RoleID)
				begin
					delete from Roles where RoleId = @RoleID;
					return @@ROWCOUNT;
				end
			else 
				begin
					return 0;
				end
		end
	else
		begin
			return -1;
		end
	
end


GO
/****** Object:  StoredProcedure [dbo].[DeleteRoleByName]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteRoleByName](
@Name nvarchar(300),
@Status int output 
) as
begin
	set nocount off;
	if  not exists (select * from Users where RoleId in (select RoleId from Roles where Name = @Name))
	begin
	delete from Roles where Name = @Name;
	end
	set @Status = @@ROWCOUNT;
	return @Status;
end


GO
/****** Object:  StoredProcedure [dbo].[DeleteUserById]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteUserById](
@UserId int
) as
begin
	if not exists (select * from Users where UserId = @UserId) return 0;
	if exists (select * from Loans where MemberId = @UserId) return -1;
	if exists (select * from Loans where LibrarianId = @UserId) return -2;
	delete from Users where UserId = @UserId;
	return @@ROWCOUNT;
end


GO
/****** Object:  StoredProcedure [dbo].[HasExisted]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[HasExisted](
@Username nvarchar(300)
) as
begin
 if exists( select * from Users where Username = @Username) return 1;
 return 0;
end

GO
/****** Object:  StoredProcedure [dbo].[InsertAuthor]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InsertAuthor](
@FullName nvarchar(300),
@Contact nvarchar(1000) = null,
@Address nvarchar(300) = null,
@Bio nvarchar(MAX) = null
) as
begin
	set nocount off;
	insert into Authors values(@FullName, @Contact, @Address, @Bio);
	return SCOPE_IDENTITY();
end


GO
/****** Object:  StoredProcedure [dbo].[InsertBook]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InsertBook](
@Isbn nvarchar(MAX) = N'N/A',
@Title nvarchar(MAX),
@Description nvarchar(MAX) = N'N/A',
@CoverImageUrl nvarchar(MAX) = N'DefaultCover.jpg',
@PageNumber int = 300,
@PublishedDate date = getdate,
@AuthorId int,
@CategoryId int,
@PublisherId int,
@Discontinued bit = 0
)as
begin
	if not exists (select * from Authors where AuthorId = @AuthorId) return -1;
	if not exists (select * from Publishers where PublisherId = @PublisherId ) return -2;
	if not exists (select * from Categories where CategoryId = @CategoryId) return -3;
	else
		begin
			insert into Books values (@Isbn, @Title, @Description, @CoverImageUrl, @PageNumber, @PublishedDate, @AuthorId, @CategoryId, @PublisherId, @Discontinued);
			return SCOPE_IDENTITY();
		end
end


GO
/****** Object:  StoredProcedure [dbo].[InsertCategory]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InsertCategory](
@CategoryID int output,
@Name nvarchar(300)
) as
begin
	if not exists (select * from Categories where Name = @Name)
		begin
			insert into Categories values (@Name);
			set @CategoryID = SCOPE_IDENTITY();
		end
	else
		begin
			set @CategoryID = -1;
		end
	return  @CategoryID;
end


GO
/****** Object:  StoredProcedure [dbo].[InsertLoan]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsertLoan](
@IssueDate datetime = getdate,
@LimitDay int = 5,
@MemberId int,
@LibrarianId int
) as
begin
	if not exists (select * from Users where UserId = @MemberId) return -1;
	if not exists (select * from Users where UserId = @LibrarianId) return -2;
	insert into Loans values(@IssueDate, @LimitDay, @MemberId, @LibrarianId);
	return @@ROWCOUNT;
end


GO
/****** Object:  StoredProcedure [dbo].[InsertPublisher]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InsertPublisher](
@Name nvarchar(300),
@Contact nvarchar(1000) = null,
@Address nvarchar(300) = null,
@Description nvarchar(MAX) = null
) as
begin
	insert into Publishers values(@Name, @Contact, @Address, @Description);
	return SCOPE_IDENTITY();
end


GO
/****** Object:  StoredProcedure [dbo].[InsertRole]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InsertRole](
@Name nvarchar(300)
) as
begin
	SET NOCOUNT OFF;
	if not exists (select * from Roles Where Name = @Name)
		begin
			insert into Roles values(@Name)
			return SCOPE_IDENTITY();
		end
	else
		begin
			return -1;
		end
end


GO
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsertUser](
@Username nvarchar(300),
@Password nvarchar(60),
@FullName nvarchar(100),
@RoleId int,
@PhoneNumber nvarchar(11) = null,
@Address nvarchar(600) = null,
@Email nvarchar(50) = null
) as
begin
	set nocount off;
	if not exists (select * from Users where Username = @Username)
		begin
			insert into Users values (@Username, @Password, @FullName, @PhoneNumber, @Address, @Email, @RoleId);
			return SCOPE_IDENTITY();
		end
	else
		begin
			return -1;
		end
end


GO
/****** Object:  StoredProcedure [dbo].[UpdateAuthorById]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UpdateAuthorById](
@AuthorId int,
@FullName nvarchar(300),
@Contact nvarchar(1000),
@Address nvarchar(300),
@Bio nvarchar(MAX)
) as
begin
	if not exists (select * from Authors where AuthorId = @AuthorId) return 0;
	if exists (select * from Books where AuthorId = @AuthorId) return -1;
	update Authors set
					FullName = @FullName,
					Contact = @Contact,
					Address = @Address,
					Bio = @Bio
	where AuthorId = @AuthorId;
	return @@ROWCOUNT;
end


GO
/****** Object:  StoredProcedure [dbo].[UpdateBookById]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UpdateBookById](
@BookId int,
@Isbn nvarchar(MAX),
@Title nvarchar(MAX),
@Description nvarchar(MAX),
@CoverImageUrl nvarchar(MAX),
@PageNumber int,
@PublishedDate date,
@AuthorId int,
@CategoryId int,
@PublisherId int,
@Discontinued bit
) as
begin
	if not exists (select * from Books where BookId = @BookId) return 0;
	if not exists (select * from Authors where AuthorId = @AuthorId) return -1;
	if not exists (select * from Categories where CategoryId = @CategoryId) return -2;
	if not exists (select * from Publishers where PublisherId = @PublisherId) return -3;
	update Books set
	Isbn = @Isbn,
	Title = @Title,
	Description = @Description,
	CoverImageUrl = @CoverImageUrl,
	PageNumber = @PageNumber,
	PublishedDate = @PublishedDate,
	AuthorId = @AuthorId,
	CategoryId = @CategoryId,
	PublisherId = @PublisherId,
	Discontinued = @Discontinued
	where BookId = @BookId;
end


GO
/****** Object:  StoredProcedure [dbo].[UpdateCopyById]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateCopyById](
@CopyId int,
@BookId int,
@IsAvailable bit
) as
begin
	if not exists (select * from Copies where CopyId = @CopyId) return 0;
	if not exists (select * from Books where BookId = @BookId) return -1;
	update Copies set
					BookId = @BookId,
					IsAvailable = @IsAvailable
	where CopyId = @CopyId;
	return @@ROWCOUNT;
end

GO
/****** Object:  StoredProcedure [dbo].[UpdateLoanById]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UpdateLoanById](
@LoanId int,
@IssueDate datetime,
@MemberId int,
@LibrarianId int,
@LimitDay int
) as
begin
	if not exists (select * from Users where UserId = @MemberId) return 0;
	if not exists (select * from Users where UserId = @LibrarianId ) return -1;
	update Loans set
		IssueDate = @IssueDate,
		MemberId = @MemberId,
		LibrarianId = @LibrarianId,
		LimitDay = @LimitDay
	where LoanId = @LoanId
	return @@ROWCOUNT;
end

GO
/****** Object:  StoredProcedure [dbo].[UpdatePublisherById]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdatePublisherById](
@PublisherId int,
@Name nvarchar(300),
@Contact nvarchar(1000),
@Address nvarchar(300),
@Description nvarchar(MAX)
) as
begin
	if not exists (select * from Publishers where PublisherId = @PublisherId) return 0;
	update Publishers set
	Name = @Name,
	Contact = @Contact,
	[Address] = @Address,
	[Description] = @Description
	where PublisherId = @PublisherId;
	return @@ROWCOUNT;
end


GO
/****** Object:  StoredProcedure [dbo].[UpdateRoleById]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UpdateRoleById](
@RoleId int,
@Name nvarchar(300)
) as
begin
	update Roles set Name = @Name;
	return @@ROWCOUNT;
end


GO
/****** Object:  StoredProcedure [dbo].[UpdateUserById]    Script Date: 3/16/2017 12:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateUserById](
@UserId int,
@Username nvarchar(300),
@Password nvarchar(60),
@FullName nvarchar(100),
@PhoneNumber nvarchar(11),
@Address nvarchar(600),
@Email nvarchar(50),
@RoleId int 
) as
begin
	if not exists (select * from Users where UserId = @UserId) return 0;
	if not exists (select * from Roles where RoleId = @RoleId ) return -1;
	update Users set
		Username = @Username,
		Password = @Password,
		FullName = @FullName,
		PhoneNumber = @PhoneNumber,
		Address = @Address,
		Email = @Email,
		RoleId = @RoleId
	where UserId = @UserId
	return @@ROWCOUNT;
end


GO
USE [master]
GO
ALTER DATABASE [LibraryManagementV2] SET  READ_WRITE 
GO
