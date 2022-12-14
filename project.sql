if DB_ID ('LibraryDB') IS NOT NULL
USE [LibraryDB]
GO
ALTER TABLE [dbo].[tblLendingDetail] DROP CONSTRAINT [FK_tblLendingDetail_tblLending]
GO
ALTER TABLE [dbo].[tblLendingDetail] DROP CONSTRAINT [FK_tblLendingDetail_tblBook]
GO
ALTER TABLE [dbo].[tblLending] DROP CONSTRAINT [FK_tblLending_tblStudent]
GO
ALTER TABLE [dbo].[tblLending] DROP CONSTRAINT [FK_tblLending_tblLibrarian]
GO
ALTER TABLE [dbo].[tblBook] DROP CONSTRAINT [FK_tblBook_tblCategory]
GO
/****** Object:  Index [IX_tblLibrarian]    Script Date: 10/24/2022 5:09:13 PM ******/
ALTER TABLE [dbo].[tblLibrarian] DROP CONSTRAINT [IX_tblLibrarian]
GO
/****** Object:  Index [IX_tblCategory]    Script Date: 10/24/2022 5:09:13 PM ******/
ALTER TABLE [dbo].[tblCategory] DROP CONSTRAINT [IX_tblCategory]
GO
/****** Object:  Table [dbo].[tblStudent]    Script Date: 10/24/2022 5:09:13 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblStudent]') AND type in (N'U'))
DROP TABLE [dbo].[tblStudent]
GO
/****** Object:  Table [dbo].[tblLibrarian]    Script Date: 10/24/2022 5:09:13 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblLibrarian]') AND type in (N'U'))
DROP TABLE [dbo].[tblLibrarian]
GO
/****** Object:  Table [dbo].[tblLendingDetail]    Script Date: 10/24/2022 5:09:13 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblLendingDetail]') AND type in (N'U'))
DROP TABLE [dbo].[tblLendingDetail]
GO
/****** Object:  Table [dbo].[tblLending]    Script Date: 10/24/2022 5:09:13 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblLending]') AND type in (N'U'))
DROP TABLE [dbo].[tblLending]
GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 10/24/2022 5:09:13 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblCategory]') AND type in (N'U'))
DROP TABLE [dbo].[tblCategory]
GO
/****** Object:  Table [dbo].[tblBook]    Script Date: 10/24/2022 5:09:13 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblBook]') AND type in (N'U'))
DROP TABLE [dbo].[tblBook]
GO
USE [master]
GO
/****** Object:  Database [LibraryDB]    Script Date: 10/24/2022 5:09:13 PM ******/
DROP DATABASE [LibraryDB]
GO
/****** Object:  Database [LibraryDB]    Script Date: 10/24/2022 5:09:13 PM ******/
CREATE DATABASE [LibraryDB]
GO
ALTER DATABASE [LibraryDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibraryDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibraryDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibraryDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibraryDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibraryDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibraryDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LibraryDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibraryDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibraryDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibraryDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibraryDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibraryDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibraryDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibraryDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LibraryDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibraryDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibraryDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibraryDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibraryDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibraryDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibraryDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibraryDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LibraryDB] SET  MULTI_USER 
GO
ALTER DATABASE [LibraryDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibraryDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibraryDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibraryDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LibraryDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LibraryDB] SET QUERY_STORE = OFF
GO
USE [LibraryDB]
GO
/****** Object:  Table [dbo].[tblBook]    Script Date: 10/24/2022 5:09:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBook](
	[bookID] [int] IDENTITY(1000,1) NOT NULL,
	[title] [nvarchar](30) NOT NULL,
	[categoryID] [int] NOT NULL,
	[printer] [nvarchar](50) NOT NULL,
	[author] [nvarchar](20) NOT NULL,
	[publishYear] [char](4) NOT NULL,
	[quantity] [int] NOT NULL,
	[price] [float] NOT NULL,
 CONSTRAINT [PK_tblBook] PRIMARY KEY CLUSTERED 
(
	[bookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 10/24/2022 5:09:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCategory](
	[categoryID] [int] IDENTITY(1,1) NOT NULL,
	[categoryTitle] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_tblCategory] PRIMARY KEY CLUSTERED 
(
	[categoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLending]    Script Date: 10/24/2022 5:09:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLending](
	[lendID] [int] IDENTITY(1,1) NOT NULL,
	[studentID] [int] NOT NULL,
	[librarianID] [int] NOT NULL,
	[lendDate] [date] NOT NULL,
	[returnDate] [date] NULL,
	[deadline] [date] NOT NULL,
 CONSTRAINT [PK_tblLending] PRIMARY KEY CLUSTERED 
(
	[lendID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLendingDetail]    Script Date: 10/24/2022 5:09:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLendingDetail](
	[lendID] [int] NOT NULL,
	[bookID] [int] NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_tblLendingDetail] PRIMARY KEY CLUSTERED 
(
	[lendID] ASC,
	[bookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLibrarian]    Script Date: 10/24/2022 5:09:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLibrarian](
	[librarianID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[username] [varchar](20) NOT NULL,
	[password] [varchar](16) NOT NULL,
 CONSTRAINT [PK_tblLibrarian] PRIMARY KEY CLUSTERED 
(
	[librarianID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblStudent]    Script Date: 10/24/2022 5:09:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStudent](
	[studentID] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[generation] [char](3) NOT NULL,
	[gender] [bit] NOT NULL,
	[DOB] [date] NOT NULL,
	[debt] [float] NOT NULL,
 CONSTRAINT [PK_tblStudent] PRIMARY KEY CLUSTERED 
(
	[studentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblBook] ON 

INSERT [dbo].[tblBook] ([bookID], [title], [categoryID], [printer], [author], [publishYear], [quantity], [price]) VALUES (1000, N'Lập trình Java cơ bản', 6, N'Nhà Xuất Bản Lao Động', N'Nguyễn Duy Nhất', N'2007', 37, 25000)
INSERT [dbo].[tblBook] ([bookID], [title], [categoryID], [printer], [author], [publishYear], [quantity], [price]) VALUES (1001, N'Làm Đĩ', 5, N'Nhà Xuất Bản Văn Học ', N'Vũ Trọng Phụng', N'2017', 15, 50000)
INSERT [dbo].[tblBook] ([bookID], [title], [categoryID], [printer], [author], [publishYear], [quantity], [price]) VALUES (1002, N'Báo Thiếu Niên Tiền Phong', 3, N'Toà soạn báo Thiếu Niên Tiền Phong', N'Không rõ', N'2022', 30, 35000)
INSERT [dbo].[tblBook] ([bookID], [title], [categoryID], [printer], [author], [publishYear], [quantity], [price]) VALUES (1003, N'Toán 10', 1, N'Nhà Xuất Bản Giáo Dục', N'Hà Huy Khoai', N'2022', 20, 20000)
INSERT [dbo].[tblBook] ([bookID], [title], [categoryID], [printer], [author], [publishYear], [quantity], [price]) VALUES (1004, N'Lược sử loài người', 4, N'Nhà Xuất Bản Tri Thức', N'Yuval Noah Harari', N'2019', 10, 109000)
INSERT [dbo].[tblBook] ([bookID], [title], [categoryID], [printer], [author], [publishYear], [quantity], [price]) VALUES (1005, N'Slam Dunk Tập 1', 2, N'Nhà Xuất Bản Kim Đồng', N'Inoue Takehiko', N'2021', 10, 54000)
INSERT [dbo].[tblBook] ([bookID], [title], [categoryID], [printer], [author], [publishYear], [quantity], [price]) VALUES (1006, N'Nguyễn Đình Thi Toàn Tập Tập 1', 8, N'Nhà Xuất Bản Văn Học', N'Nguyễn Đình Thi', N'2022', 3, 200000)
INSERT [dbo].[tblBook] ([bookID], [title], [categoryID], [printer], [author], [publishYear], [quantity], [price]) VALUES (1007, N'Lịch Sử Việt Nam Tập 1', 7, N'Nhà Xuất Bản Khoa Học & Xã Hội', N'Nguyễn Ngọc Mão', N'2022', 2, 300000)
INSERT [dbo].[tblBook] ([bookID], [title], [categoryID], [printer], [author], [publishYear], [quantity], [price]) VALUES (1008, N'Slam Dunk Tập 2', 2, N'Nhà Xuất Bản Kim Đồng', N'Inoue Takehiko', N'2021', 10, 54000)
INSERT [dbo].[tblBook] ([bookID], [title], [categoryID], [printer], [author], [publishYear], [quantity], [price]) VALUES (1009, N'Số Đỏ', 5, N'Nhà Xuất Bản Văn Học', N'Vũ Trọng Phụng', N'2010', 10, 86000)
INSERT [dbo].[tblBook] ([bookID], [title], [categoryID], [printer], [author], [publishYear], [quantity], [price]) VALUES (1010, N'Lịch Sử 10', 1, N'Nhà Xuất Bản Giáo Dục', N'Phan Ngọc Liên', N'2015', 20, 20000)
INSERT [dbo].[tblBook] ([bookID], [title], [categoryID], [printer], [author], [publishYear], [quantity], [price]) VALUES (1011, N'Air Gear Tập 1', 2, N'Nhà Xuất Bản Trẻ', N'Oh great', N'2018', 10, 35000)
SET IDENTITY_INSERT [dbo].[tblBook] OFF
GO
SET IDENTITY_INSERT [dbo].[tblCategory] ON 

INSERT [dbo].[tblCategory] ([categoryID], [categoryTitle]) VALUES (1, N'Sách giáo khoa')
INSERT [dbo].[tblCategory] ([categoryID], [categoryTitle]) VALUES (2, N'Truyện tranh')
INSERT [dbo].[tblCategory] ([categoryID], [categoryTitle]) VALUES (3, N'Báo')
INSERT [dbo].[tblCategory] ([categoryID], [categoryTitle]) VALUES (4, N'Sách khoa học')
INSERT [dbo].[tblCategory] ([categoryID], [categoryTitle]) VALUES (5, N'Tiểu thuyết')
INSERT [dbo].[tblCategory] ([categoryID], [categoryTitle]) VALUES (6, N'Sách tham khảo')
INSERT [dbo].[tblCategory] ([categoryID], [categoryTitle]) VALUES (7, N'Sách lịch sử')
INSERT [dbo].[tblCategory] ([categoryID], [categoryTitle]) VALUES (8, N'Thơ')
SET IDENTITY_INSERT [dbo].[tblCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[tblLending] ON 

INSERT [dbo].[tblLending] ([lendID], [studentID], [librarianID], [lendDate], [returnDate], [deadline]) VALUES (1, 14103, 1, CAST(N'2022-06-06' AS Date), CAST(N'2022-06-08' AS Date), CAST(N'2022-06-13' AS Date))
INSERT [dbo].[tblLending] ([lendID], [studentID], [librarianID], [lendDate], [returnDate], [deadline]) VALUES (2, 15245, 2, CAST(N'2022-08-03' AS Date), CAST(N'2022-08-10' AS Date), CAST(N'2022-08-10' AS Date))
INSERT [dbo].[tblLending] ([lendID], [studentID], [librarianID], [lendDate], [returnDate], [deadline]) VALUES (3, 17214, 1, CAST(N'2022-10-22' AS Date), NULL, CAST(N'2022-10-29' AS Date))
INSERT [dbo].[tblLending] ([lendID], [studentID], [librarianID], [lendDate], [returnDate], [deadline]) VALUES (4, 16312, 3, CAST(N'2022-10-14' AS Date), NULL, CAST(N'2022-10-21' AS Date))
INSERT [dbo].[tblLending] ([lendID], [studentID], [librarianID], [lendDate], [returnDate], [deadline]) VALUES (5, 18693, 2, CAST(N'2022-10-13' AS Date), NULL, CAST(N'2022-10-28' AS Date))
INSERT [dbo].[tblLending] ([lendID], [studentID], [librarianID], [lendDate], [returnDate], [deadline]) VALUES (6, 15245, 3, CAST(N'2021-09-08' AS Date), CAST(N'2021-09-08' AS Date), CAST(N'2021-09-15' AS Date))
SET IDENTITY_INSERT [dbo].[tblLending] OFF
GO
INSERT [dbo].[tblLendingDetail] ([lendID], [bookID], [quantity]) VALUES (1, 1000, 1)
INSERT [dbo].[tblLendingDetail] ([lendID], [bookID], [quantity]) VALUES (2, 1003, 1)
INSERT [dbo].[tblLendingDetail] ([lendID], [bookID], [quantity]) VALUES (3, 1002, 1)
INSERT [dbo].[tblLendingDetail] ([lendID], [bookID], [quantity]) VALUES (3, 1005, 1)
INSERT [dbo].[tblLendingDetail] ([lendID], [bookID], [quantity]) VALUES (4, 1004, 1)
INSERT [dbo].[tblLendingDetail] ([lendID], [bookID], [quantity]) VALUES (4, 1006, 1)
INSERT [dbo].[tblLendingDetail] ([lendID], [bookID], [quantity]) VALUES (5, 1001, 1)
INSERT [dbo].[tblLendingDetail] ([lendID], [bookID], [quantity]) VALUES (6, 1006, 1)
INSERT [dbo].[tblLendingDetail] ([lendID], [bookID], [quantity]) VALUES (6, 1007, 1)
GO
SET IDENTITY_INSERT [dbo].[tblLibrarian] ON 

INSERT [dbo].[tblLibrarian] ([librarianID], [name], [username], [password]) VALUES (1, N'Công ', N'admin', N'1')
INSERT [dbo].[tblLibrarian] ([librarianID], [name], [username], [password]) VALUES (2, N'Duy', N'admin1', N'1')
INSERT [dbo].[tblLibrarian] ([librarianID], [name], [username], [password]) VALUES (3, N'Đức Anh', N'admin2', N'1')
SET IDENTITY_INSERT [dbo].[tblLibrarian] OFF
GO
INSERT [dbo].[tblStudent] ([studentID], [name], [generation], [gender], [DOB], [debt]) VALUES (14032, N'Hồ Minh Quân', N'K14', 1, CAST(N'1998-09-15' AS Date), 0)
INSERT [dbo].[tblStudent] ([studentID], [name], [generation], [gender], [DOB], [debt]) VALUES (14103, N'Võ Minh Hiếu', N'K14', 1, CAST(N'1999-06-07' AS Date), 0)
INSERT [dbo].[tblStudent] ([studentID], [name], [generation], [gender], [DOB], [debt]) VALUES (14597, N'Nguyễn Ngọc Hà', N'K14', 0, CAST(N'1999-10-24' AS Date), 0)
INSERT [dbo].[tblStudent] ([studentID], [name], [generation], [gender], [DOB], [debt]) VALUES (15201, N'Lê Minh Trang', N'K15', 0, CAST(N'2005-10-24' AS Date), 0)
INSERT [dbo].[tblStudent] ([studentID], [name], [generation], [gender], [DOB], [debt]) VALUES (15245, N'Trần Hải Nam', N'K15', 1, CAST(N'2001-08-21' AS Date), 0)
INSERT [dbo].[tblStudent] ([studentID], [name], [generation], [gender], [DOB], [debt]) VALUES (16053, N'Phạm Phúc Thành Công', N'K16', 1, CAST(N'2002-04-16' AS Date), 0)
INSERT [dbo].[tblStudent] ([studentID], [name], [generation], [gender], [DOB], [debt]) VALUES (16312, N'Trần Tuấn Đạt', N'K16', 1, CAST(N'2001-10-18' AS Date), 100000)
INSERT [dbo].[tblStudent] ([studentID], [name], [generation], [gender], [DOB], [debt]) VALUES (16702, N'Nguyễn Đình Dũng', N'K16', 1, CAST(N'1997-07-18' AS Date), 0)
INSERT [dbo].[tblStudent] ([studentID], [name], [generation], [gender], [DOB], [debt]) VALUES (17214, N'Nguyễn Thị Hoa', N'K17', 0, CAST(N'2003-06-06' AS Date), 12000)
INSERT [dbo].[tblStudent] ([studentID], [name], [generation], [gender], [DOB], [debt]) VALUES (18693, N'Phạm Nguyễn Mỹ Tiên', N'K18', 0, CAST(N'2004-11-21' AS Date), 0)
GO
/****** Object:  Index [IX_tblCategory]    Script Date: 10/24/2022 5:09:14 PM ******/
ALTER TABLE [dbo].[tblCategory] ADD  CONSTRAINT [IX_tblCategory] UNIQUE NONCLUSTERED 
(
	[categoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tblLibrarian]    Script Date: 10/24/2022 5:09:14 PM ******/
ALTER TABLE [dbo].[tblLibrarian] ADD  CONSTRAINT [IX_tblLibrarian] UNIQUE NONCLUSTERED 
(
	[librarianID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblBook]  WITH CHECK ADD  CONSTRAINT [FK_tblBook_tblCategory] FOREIGN KEY([categoryID])
REFERENCES [dbo].[tblCategory] ([categoryID])
GO
ALTER TABLE [dbo].[tblBook] CHECK CONSTRAINT [FK_tblBook_tblCategory]
GO
ALTER TABLE [dbo].[tblLending]  WITH CHECK ADD  CONSTRAINT [FK_tblLending_tblLibrarian] FOREIGN KEY([librarianID])
REFERENCES [dbo].[tblLibrarian] ([librarianID])
GO
ALTER TABLE [dbo].[tblLending] CHECK CONSTRAINT [FK_tblLending_tblLibrarian]
GO
ALTER TABLE [dbo].[tblLending]  WITH CHECK ADD  CONSTRAINT [FK_tblLending_tblStudent] FOREIGN KEY([studentID])
REFERENCES [dbo].[tblStudent] ([studentID])
GO
ALTER TABLE [dbo].[tblLending] CHECK CONSTRAINT [FK_tblLending_tblStudent]
GO
ALTER TABLE [dbo].[tblLendingDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblLendingDetail_tblBook] FOREIGN KEY([bookID])
REFERENCES [dbo].[tblBook] ([bookID])
GO
ALTER TABLE [dbo].[tblLendingDetail] CHECK CONSTRAINT [FK_tblLendingDetail_tblBook]
GO
ALTER TABLE [dbo].[tblLendingDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblLendingDetail_tblLending] FOREIGN KEY([lendID])
REFERENCES [dbo].[tblLending] ([lendID])
GO
ALTER TABLE [dbo].[tblLendingDetail] CHECK CONSTRAINT [FK_tblLendingDetail_tblLending]
GO
USE [master]
GO
ALTER DATABASE [LibraryDB] SET  READ_WRITE 
GO
