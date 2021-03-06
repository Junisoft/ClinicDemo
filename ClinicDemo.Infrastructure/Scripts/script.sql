USE [master]
GO
/****** Object:  Database [ClinicDB]    Script Date: 14/02/2022 16:14:37 ******/
CREATE DATABASE [ClinicDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ClinicDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ClinicDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ClinicDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ClinicDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ClinicDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ClinicDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ClinicDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ClinicDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ClinicDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ClinicDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ClinicDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ClinicDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ClinicDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ClinicDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ClinicDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ClinicDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ClinicDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ClinicDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ClinicDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ClinicDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ClinicDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ClinicDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ClinicDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ClinicDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ClinicDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ClinicDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ClinicDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ClinicDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ClinicDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ClinicDB] SET  MULTI_USER 
GO
ALTER DATABASE [ClinicDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ClinicDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ClinicDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ClinicDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ClinicDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ClinicDB] SET QUERY_STORE = OFF
GO
USE [ClinicDB]
GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 14/02/2022 16:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctors](
	[DoctorId] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](255) NULL,
	[Lastname] [nvarchar](255) NULL,
	[Email] [nvarchar](100) NULL,
	[SpecialtyId] [int] NOT NULL,
	[CreatedBy] [varchar](100) NULL,
	[UpdateBy] [varchar](100) NULL,
	[CreationDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[DoctorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specialties]    Script Date: 14/02/2022 16:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialties](
	[SpecialtyId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[SpecialtyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Doctors] ON 

INSERT [dbo].[Doctors] ([DoctorId], [Firstname], [Lastname], [Email], [SpecialtyId], [CreatedBy], [UpdateBy], [CreationDate], [UpdateDate], [IsDeleted]) VALUES (1, N'Jose Manuel', N'Gonzales Perez', N'jgonzales@gmail.com', 1, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Doctors] ([DoctorId], [Firstname], [Lastname], [Email], [SpecialtyId], [CreatedBy], [UpdateBy], [CreationDate], [UpdateDate], [IsDeleted]) VALUES (2, N'Esperanza', N'Izquierdo Diaz', N'eizquierdo@gmail.com', 2, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Doctors] ([DoctorId], [Firstname], [Lastname], [Email], [SpecialtyId], [CreatedBy], [UpdateBy], [CreationDate], [UpdateDate], [IsDeleted]) VALUES (3, N'Luis Pedro', N'Paredes Sanchez', N'lparedes@gmail.com', 3, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Doctors] ([DoctorId], [Firstname], [Lastname], [Email], [SpecialtyId], [CreatedBy], [UpdateBy], [CreationDate], [UpdateDate], [IsDeleted]) VALUES (4, N'Gabriel', N'Quizpe Lopez', N'gquizpe@gmail.com', 3, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Doctors] ([DoctorId], [Firstname], [Lastname], [Email], [SpecialtyId], [CreatedBy], [UpdateBy], [CreationDate], [UpdateDate], [IsDeleted]) VALUES (5, N'Mariela Susana', N'Valderrama Ramos', N'mvalderrama@gmail.com', 2, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Doctors] ([DoctorId], [Firstname], [Lastname], [Email], [SpecialtyId], [CreatedBy], [UpdateBy], [CreationDate], [UpdateDate], [IsDeleted]) VALUES (10, N'Doctor Fn 1', N'Doctor Ln 1', N'doctor1@gmail.com', 3, N'ADMIN', NULL, CAST(N'2022-02-10T18:14:18.000' AS DateTime), NULL, 0)
INSERT [dbo].[Doctors] ([DoctorId], [Firstname], [Lastname], [Email], [SpecialtyId], [CreatedBy], [UpdateBy], [CreationDate], [UpdateDate], [IsDeleted]) VALUES (11, N'Doctor Fn 2', N'Doctor Ln 2', N'doctor2@gmail.com', 3, N'ADMIN', NULL, CAST(N'2022-02-11T21:46:12.440' AS DateTime), NULL, 0)
INSERT [dbo].[Doctors] ([DoctorId], [Firstname], [Lastname], [Email], [SpecialtyId], [CreatedBy], [UpdateBy], [CreationDate], [UpdateDate], [IsDeleted]) VALUES (12, N'Doctor Fn 2', N'Doctor Ln 2', N'doctor2@gmail.com', 3, N'ADMIN', N'ADMIN', CAST(N'2022-02-11T22:30:05.600' AS DateTime), CAST(N'2022-02-14T13:24:04.697' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Doctors] OFF
GO
SET IDENTITY_INSERT [dbo].[Specialties] ON 

INSERT [dbo].[Specialties] ([SpecialtyId], [Name], [Description]) VALUES (1, N'Dermatologia', N'Especialidad médica encargada de estudiar la estructura y funciones de la piel, así como los problemas y enfermedades que la afectan')
INSERT [dbo].[Specialties] ([SpecialtyId], [Name], [Description]) VALUES (2, N'Neumologia', N'Especialidad médica que se encarga del estudio de la fisiología y la patología del aparato respiratorio, así como de las técnicas diagnósticas, terapéuticas y preventivas para mantener una salud respiratoria adecuada.')
INSERT [dbo].[Specialties] ([SpecialtyId], [Name], [Description]) VALUES (3, N'Medicina General', N'Especialidad médica que se encarga del estudio de la fisiología y la patología del aparato respiratorio, así como de las técnicas diagnósticas, terapéuticas y preventivas para mantener una salud respiratoria adecuada.')
INSERT [dbo].[Specialties] ([SpecialtyId], [Name], [Description]) VALUES (4, N'Sp 01', N'Desc 01')
INSERT [dbo].[Specialties] ([SpecialtyId], [Name], [Description]) VALUES (5, N'Sp 02', N'Desc 02')
SET IDENTITY_INSERT [dbo].[Specialties] OFF
GO
ALTER TABLE [dbo].[Doctors]  WITH CHECK ADD  CONSTRAINT [FK_DoctorSpecialty] FOREIGN KEY([SpecialtyId])
REFERENCES [dbo].[Specialties] ([SpecialtyId])
GO
ALTER TABLE [dbo].[Doctors] CHECK CONSTRAINT [FK_DoctorSpecialty]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteDoctor]    Script Date: 14/02/2022 16:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_DeleteDoctor]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	delete [dbo].[Doctors]
	where DoctorId = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EnableDisableDoctor]    Script Date: 14/02/2022 16:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_EnableDisableDoctor]
	@DoctorId int,
	@IsActive bit
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Doctors]
	SET
		IsDeleted		= @IsActive,
		UpdateBy		= 'ADMIN',
		UpdateDate		= GETDATE()
	WHERE DoctorId = @DoctorId;

END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllDoctors]    Script Date: 14/02/2022 16:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllDoctors]
	@PageNumber int,
	@PageSize int
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT DoctorId, Firstname, Lastname, Email 
	FROM [dbo].[Doctors]
	ORDER BY Firstname
	OFFSET ( @PageNumber - 1 ) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllSpecialties]    Script Date: 14/02/2022 16:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllSpecialties]
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT * FROM [dbo].[Specialties]
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDoctorById]    Script Date: 14/02/2022 16:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetDoctorById] 
	@Id int
AS
BEGIN
	
	SET NOCOUNT ON;

	select DoctorId, Firstname, Lastname, Email 
	from doctors
	where DoctorId = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertDoctor]    Script Date: 14/02/2022 16:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertDoctor] 
	@Firstname nvarchar(255),
	@Lastname nvarchar(255),
	@Email nvarchar(100),
	@SpecialtyId int
AS
BEGIN
	SET NOCOUNT ON;

	insert into [dbo].[Doctors](Firstname, Lastname, Email, SpecialtyId, CreatedBy, CreationDate, IsDeleted)
	values (@Firstname, @Lastname, @Email, @SpecialtyId, 'ADMIN', GETDATE(), 0)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertSpecialty]    Script Date: 14/02/2022 16:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertSpecialty] 
	@Name nvarchar(255),
	@Description nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	insert into [dbo].[Specialties](Name, Description)
	values (@Name, @Description)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateDoctor]    Script Date: 14/02/2022 16:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateDoctor]
	@DoctorId int,
	@Firstname nvarchar(255),
	@Lastname nvarchar(255),
	@Email nvarchar(100),
	@SpecialtyId int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Doctors]
	SET
		Firstname		= @Firstname, 
		Lastname		= @Lastname,
		Email			= @Email,
		SpecialtyId		= @SpecialtyId,
		UpdateBy		= 'ADMIN',
		UpdateDate		= GETDATE()
	WHERE DoctorId = @DoctorId;

END
GO
USE [master]
GO
ALTER DATABASE [ClinicDB] SET  READ_WRITE 
GO
