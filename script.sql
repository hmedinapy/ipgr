USE [master]
GO
/****** Object:  Database [dbTest5]    Script Date: 26/5/2024 11:28:00 ******/
CREATE DATABASE [dbTest5]
GO
ALTER DATABASE [dbTest5] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbTest5].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbTest5] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbTest5] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbTest5] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbTest5] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbTest5] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbTest5] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbTest5] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbTest5] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbTest5] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbTest5] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbTest5] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbTest5] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbTest5] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbTest5] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbTest5] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbTest5] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbTest5] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbTest5] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbTest5] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbTest5] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbTest5] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbTest5] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbTest5] SET RECOVERY FULL 
GO
ALTER DATABASE [dbTest5] SET  MULTI_USER 
GO
ALTER DATABASE [dbTest5] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbTest5] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbTest5] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbTest5] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbTest5] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbTest5] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbTest5', N'ON'
GO
ALTER DATABASE [dbTest5] SET QUERY_STORE = ON
GO
ALTER DATABASE [dbTest5] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [dbTest5]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 26/5/2024 11:28:00 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[analisis_riesgo]    Script Date: 26/5/2024 11:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[analisis_riesgo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [nchar](5) NULL,
	[id_area] [int] NULL,
	[id_riesgo] [int] NULL,
	[significado] [varchar](500) NULL,
	[agente_generador] [varchar](255) NULL,
	[causa] [varchar](255) NOT NULL,
	[efecto] [varchar](255) NOT NULL,
	[probabilidad] [int] NOT NULL,
	[impacto] [int] NOT NULL,
	[resultado] [int] NOT NULL,
	[nivel_riesgo] [char](1) NULL,
	[activo] [bit] NULL,
 CONSTRAINT [PK_analisis_riesgo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[area]    Script Date: 26/5/2024 11:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[area](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](255) NOT NULL,
	[activo] [bit] NOT NULL,
	[id_departamento] [int] NOT NULL,
	[id_empresa] [int] NULL,
 CONSTRAINT [PK_area] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 26/5/2024 11:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 26/5/2024 11:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 26/5/2024 11:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 26/5/2024 11:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 26/5/2024 11:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 26/5/2024 11:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Apellido] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 26/5/2024 11:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[departamento]    Script Date: 26/5/2024 11:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departamento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](255) NOT NULL,
	[id_empresa] [int] NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_departamento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[empresa]    Script Date: 26/5/2024 11:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empresa](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	[ruc] [varchar](255) NOT NULL,
	[telefono] [varchar](255) NOT NULL,
	[direccion] [varchar](255) NOT NULL,
	[codigo_empresa] [varchar](255) NULL,
	[activo] [bit] NOT NULL,
	[fecha_creacion] [datetime] NULL,
	[usuario_creacion] [int] NULL,
	[fecha_modificacion] [datetime] NULL,
	[usuario_modificacion] [int] NULL,
 CONSTRAINT [PK_empresa] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[plan_trabajo]    Script Date: 26/5/2024 11:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[plan_trabajo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[numero] [int] NULL,
	[codigo] [varchar](255) NULL,
	[id_area] [int] NULL,
	[id_departamento] [int] NULL,
	[objetivos] [varchar](500) NULL,
	[procedimientos] [varchar](500) NULL,
	[cantidad_personas] [int] NULL,
	[horas_netas] [int] NULL,
	[productos] [int] NULL,
	[fecha_incio_auditoria] [date] NULL,
	[fecha_fin_auditoria] [date] NULL,
	[id_auditor_asignado] [int] NULL,
	[id_responsable_area_auditada] [int] NULL,
	[estado] [char](1) NULL,
	[envio_informe] [char](1) NULL,
	[fecha_creada] [date] NULL,
	[id_user_creada] [int] NULL,
	[activo] [bit] NULL,
 CONSTRAINT [PK_plan_trabajo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[plan_trabajo_cronograma]    Script Date: 26/5/2024 11:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[plan_trabajo_cronograma](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_plan_trabajo] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[cantidad_horas] [int] NOT NULL,
 CONSTRAINT [PK_plan_trabajo_cronograma] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[id_plan_trabajo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[plan_trabajo_puntos]    Script Date: 26/5/2024 11:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[plan_trabajo_puntos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_plan_trabajo] [int] NOT NULL,
	[descripcion] [varchar](300) NOT NULL,
	[tipo_punto] [char](1) NOT NULL,
	[activo] [bit] NULL,
 CONSTRAINT [PK_plan_trabajo_puntos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[riesgo]    Script Date: 26/5/2024 11:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[riesgo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](255) NOT NULL,
	[user_creado] [int] NULL,
	[activo] [bit] NULL,
 CONSTRAINT [PK_riesgo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240501082914_AddedIdentity', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240503111832_AddedDefaultRoles', N'8.0.4')
GO
SET IDENTITY_INSERT [dbo].[analisis_riesgo] ON 

INSERT [dbo].[analisis_riesgo] ([id], [codigo], [id_area], [id_riesgo], [significado], [agente_generador], [causa], [efecto], [probabilidad], [impacto], [resultado], [nivel_riesgo], [activo]) VALUES (1, N'M1   ', 10, 10, N'Gastar mucho dinero u otra cosa innecesaria o imprudentemente.', N'Personas', N'Desinteres de elaborar manuales de funciones y procedimientos.', N'Inapropiada ejecución presupuestaria e incorrecta exposición contable', 3, 31, 93, N'A', NULL)
INSERT [dbo].[analisis_riesgo] ([id], [codigo], [id_area], [id_riesgo], [significado], [agente_generador], [causa], [efecto], [probabilidad], [impacto], [resultado], [nivel_riesgo], [activo]) VALUES (4, N'M1   ', 10, 9, N'Opinión, concepto o juicio falso que proviene de percepción inadecuada o ignorancia; también se llama error al obrar sin reflexión, sin inteligencia o acierto.', N'Personas', N'Equivocada interpretación de la norma', N'Pago inadecuado retraso en las tareas y actividades / Exposición errónea', 2, 21, 42, N'A', NULL)
INSERT [dbo].[analisis_riesgo] ([id], [codigo], [id_area], [id_riesgo], [significado], [agente_generador], [causa], [efecto], [probabilidad], [impacto], [resultado], [nivel_riesgo], [activo]) VALUES (5, N'M1   ', 10, 12, N'Presentar datos o estimaciones equivocadas, incompletas o desfiguradas.', N'Personas', N'Errores en  cálculos de las asignaciones', N'Registración y exposición errónea', 2, 21, 42, N'A', NULL)
INSERT [dbo].[analisis_riesgo] ([id], [codigo], [id_area], [id_riesgo], [significado], [agente_generador], [causa], [efecto], [probabilidad], [impacto], [resultado], [nivel_riesgo], [activo]) VALUES (7, N'M1   ', 10, 13, N'Falta o delito que consiste en dejar de hacer, decir o consignar algo que debía ser hecho, dicho o consignado. Según el código penal, omisión significa omitir auxiliar a una persona cuya vida o salud se encuentre en grave peligro, o prestar asistencia humanitaria en medio de un conflicto armado a favor de las personas protegidas.', N'Personas', N'No aplicación de normativas vigentes', N'Inapropiada ejecución presupuestaria e incorrecta exposición contable', 2, 21, 42, N'A', NULL)
INSERT [dbo].[analisis_riesgo] ([id], [codigo], [id_area], [id_riesgo], [significado], [agente_generador], [causa], [efecto], [probabilidad], [impacto], [resultado], [nivel_riesgo], [activo]) VALUES (8, N'M2   ', 11, 13, N'Falta o delito que consiste en dejar de hacer, decir o consignar algo que debía ser hecho, dicho o consignado. Según el código penal, omisión significa omitir auxiliar a una persona cuya vida o salud se encuentre en grave peligro, o prestar asistencia humanitaria en medio de un conflicto armado a favor de las personas protegidas.', N'Personas', N'Negligencia, deficiencia de control', N'Pagos indebidos y/o pagos sin respaldos', 1, 10, 10, N'A', NULL)
INSERT [dbo].[analisis_riesgo] ([id], [codigo], [id_area], [id_riesgo], [significado], [agente_generador], [causa], [efecto], [probabilidad], [impacto], [resultado], [nivel_riesgo], [activo]) VALUES (9, N'M2   ', 11, 9, N'Opinión, concepto o juicio falso que proviene de percepción inadecuada o ignorancia; también se llama error al obrar sin reflexión, sin inteligencia o acierto.', N'Personas', N'Desatención, desconocimiento', N'Pagos indebidos y/o pagos sin respaldos', 1, 10, 10, N'A', NULL)
INSERT [dbo].[analisis_riesgo] ([id], [codigo], [id_area], [id_riesgo], [significado], [agente_generador], [causa], [efecto], [probabilidad], [impacto], [resultado], [nivel_riesgo], [activo]) VALUES (11, N'M3   ', 12, 13, N'Falta o delito que consiste en dejar de hacer, decir o consignar algo que debía ser hecho, dicho o consignado. Según el código penal, omisión significa omitir auxiliar a una persona cuya vida o salud se encuentre en grave peligro, o prestar asistencia humanitaria en medio de un conflicto armado a favor de las personas protegidas.
', N'Personas', N'Negligencia , desinterés, malversación, robo
', N'Faltante en inventario y dinero, error de registro, fraude

', 1, 20, 20, N'A', NULL)
INSERT [dbo].[analisis_riesgo] ([id], [codigo], [id_area], [id_riesgo], [significado], [agente_generador], [causa], [efecto], [probabilidad], [impacto], [resultado], [nivel_riesgo], [activo]) VALUES (16, N'M3   ', 12, 9, N'Opinión, concepto o juicio falso que proviene de percepción inadecuada o ignorancia; también se llama error al obrar sin reflexión, sin inteligencia o acierto.
', N'Personas', N'Desatención, desconocimiento
', N'Faltante en inventario y dinero, error de registro, fraude

', 1, 20, 20, N'A', NULL)
INSERT [dbo].[analisis_riesgo] ([id], [codigo], [id_area], [id_riesgo], [significado], [agente_generador], [causa], [efecto], [probabilidad], [impacto], [resultado], [nivel_riesgo], [activo]) VALUES (17, N'M4   ', 13, 13, N'Falta o delito que consiste en dejar de hacer, decir o consignar algo que debía ser hecho, dicho o consignado. Según el código penal, omisión significa omitir auxiliar a una persona cuya vida o salud se encuentre en grave peligro, o prestar asistencia humanitaria en medio de un conflicto armado a favor de las personas protegidas.
', N'Personas', N'Negligencia , desinterés
', N'Registración y exposición errónea

', 1, 20, 20, N'A', NULL)
INSERT [dbo].[analisis_riesgo] ([id], [codigo], [id_area], [id_riesgo], [significado], [agente_generador], [causa], [efecto], [probabilidad], [impacto], [resultado], [nivel_riesgo], [activo]) VALUES (18, N'M4   ', 13, 11, N'No realizar aquello a que se está obligado.
', N'Personas', N'Desatención, desconocimiento
', N'Registración y exposición errónea

', 1, 20, 20, N'A', NULL)
INSERT [dbo].[analisis_riesgo] ([id], [codigo], [id_area], [id_riesgo], [significado], [agente_generador], [causa], [efecto], [probabilidad], [impacto], [resultado], [nivel_riesgo], [activo]) VALUES (19, N'M5   ', 14, 13, N'Equivocación o error en la toma de decisiones / Ausencia de control
', N'Personas', N'Desinteres de elaborar manuales de funciones y procedimientos.
', N'Faltantes, fraude, pérdidas / Exposición errónea

', 2, 31, 62, N'A', NULL)
INSERT [dbo].[analisis_riesgo] ([id], [codigo], [id_area], [id_riesgo], [significado], [agente_generador], [causa], [efecto], [probabilidad], [impacto], [resultado], [nivel_riesgo], [activo]) VALUES (20, N'M5   ', 14, 9, N'Opinión, concepto o juicio falso que proviene de percepción inadecuada o ignorancia; también se llama error al obrar sin reflexión, sin inteligencia o acierto.
', N'Personas', N'Desatención, desconocimiento
', N'Faltantes, fraude, pérdidas / Exposición errónea

', 2, 31, 62, N'A', NULL)
INSERT [dbo].[analisis_riesgo] ([id], [codigo], [id_area], [id_riesgo], [significado], [agente_generador], [causa], [efecto], [probabilidad], [impacto], [resultado], [nivel_riesgo], [activo]) VALUES (21, N'M6   ', 15, 7, N'Tardanza en el cumplimiento de algo.
', N'Personas', N'Sobrecarga de actividades / incorrecto uso del sistema informático
', N' Registros incorrectos.
', 1, 20, 20, N'A', NULL)
INSERT [dbo].[analisis_riesgo] ([id], [codigo], [id_area], [id_riesgo], [significado], [agente_generador], [causa], [efecto], [probabilidad], [impacto], [resultado], [nivel_riesgo], [activo]) VALUES (22, N'M7   ', 16, 8, N'Sin Datos', N'Personas', N'Coordinanción acefala. Falta de designación de personas para el área.
', N'Incumplimiento de Objetivos
', 1, 20, 20, N'A', NULL)
INSERT [dbo].[analisis_riesgo] ([id], [codigo], [id_area], [id_riesgo], [significado], [agente_generador], [causa], [efecto], [probabilidad], [impacto], [resultado], [nivel_riesgo], [activo]) VALUES (23, N'M8   ', 17, 11, N'No realizar aquello a que se está obligado.
', N'Personas', N'No presentación de informes
', N'No cobro de tasas
', 1, 20, 20, N'A', NULL)
INSERT [dbo].[analisis_riesgo] ([id], [codigo], [id_area], [id_riesgo], [significado], [agente_generador], [causa], [efecto], [probabilidad], [impacto], [resultado], [nivel_riesgo], [activo]) VALUES (24, N'M8   ', 17, 6, N'Tardanza en el cumplimiento de algo.
', N'Personas', N'Desconocimiento o desinteres sobre los plazos
', N'Retraso en la entrega de Libros. No actualización de los datos.
', 2, 20, 40, N'A', NULL)
INSERT [dbo].[analisis_riesgo] ([id], [codigo], [id_area], [id_riesgo], [significado], [agente_generador], [causa], [efecto], [probabilidad], [impacto], [resultado], [nivel_riesgo], [activo]) VALUES (25, N'M9   ', 18, 4, N'No realizar aquello a que se está obligado.
', N'Personas', N'Falta de planeación ', N'Incumplimiento de Objetivos
', 1, 20, 20, N'A', NULL)
SET IDENTITY_INSERT [dbo].[analisis_riesgo] OFF
GO
SET IDENTITY_INSERT [dbo].[area] ON 

INSERT [dbo].[area] ([id], [descripcion], [activo], [id_departamento], [id_empresa]) VALUES (8, N'Area 2 - e1', 1, 1, 1)
INSERT [dbo].[area] ([id], [descripcion], [activo], [id_departamento], [id_empresa]) VALUES (9, N'Area 3 - e1', 1, 1, 1)
INSERT [dbo].[area] ([id], [descripcion], [activo], [id_departamento], [id_empresa]) VALUES (10, N'Estados Financieros y Ejecución Presupuestaria', 1, 9, 4)
INSERT [dbo].[area] ([id], [descripcion], [activo], [id_departamento], [id_empresa]) VALUES (11, N'Caja Chica', 1, 9, 4)
INSERT [dbo].[area] ([id], [descripcion], [activo], [id_departamento], [id_empresa]) VALUES (12, N'Departamento de Valores', 1, 9, 4)
INSERT [dbo].[area] ([id], [descripcion], [activo], [id_departamento], [id_empresa]) VALUES (13, N'Patrimonio', 1, 9, 4)
INSERT [dbo].[area] ([id], [descripcion], [activo], [id_departamento], [id_empresa]) VALUES (14, N'Archivo Central.', 1, 11, 4)
INSERT [dbo].[area] ([id], [descripcion], [activo], [id_departamento], [id_empresa]) VALUES (15, N'Coordinación de Administración de Recursos Humanos', 1, 12, 4)
INSERT [dbo].[area] ([id], [descripcion], [activo], [id_departamento], [id_empresa]) VALUES (16, N'Coordinación de Gestión de Talento Humano', 1, 12, 4)
INSERT [dbo].[area] ([id], [descripcion], [activo], [id_departamento], [id_empresa]) VALUES (17, N'Coordinación Departamentales', 1, 13, 4)
INSERT [dbo].[area] ([id], [descripcion], [activo], [id_departamento], [id_empresa]) VALUES (18, N'Unidad de Inscripciones Móviles', 1, 13, 4)
SET IDENTITY_INSERT [dbo].[area] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'0adc81fc-200f-4ecc-a0d4-b9ef985110f7', N'Auditor', N'AUDITOR', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1785c25d-80ac-4ff7-97ce-f42fcd3eb5fe', N'Auditado', N'AUDITADO', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'222d088f-b5f6-4b47-8fdb-205c992a22c0', N'Administrador', N'ADMINISTRADOR', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'dac9d2b2-2c6d-494b-8e09-284225974bb1', N'User', N'USER', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'36cdfc01-746d-4570-a274-241544ae1c07', N'222d088f-b5f6-4b47-8fdb-205c992a22c0')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Nombre], [Apellido], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'36cdfc01-746d-4570-a274-241544ae1c07', N'firstName 1', N'lastName 1', N'user1@example.com', N'USER1@EXAMPLE.COM', N'user1@example.com', N'USER1@EXAMPLE.COM', 0, N'AQAAAAIAAYagAAAAEFRs9V/ORELVRuLXOs0z/UzslWdVQ2xpCBCd1yeGInB8Lyd6wGjTvVYB5p4f9Dwn2A==', N'SYPU25AGXQKR47I24O6OQBAM7Y3JWQTL', N'9783bc1c-8bc2-4e4f-ac8f-e0f66e12464e', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUserTokens] ([UserId], [LoginProvider], [Name], [Value]) VALUES (N'36cdfc01-746d-4570-a274-241544ae1c07', N'IPGRAPI', N'RefreshToken', N'CfDJ8LoP6EJIHmBIrzCKMruQEOgIACt4U0yCiCaziXMi5HpiHayVeU56XnDOv7tGZuafZP+OaiC5lItZaLA2m7XVpr5xBs9pGOgVXo8WbeOQ6Qr1PjfZEnIbbgvuxaC+ZMpqLiSb08z696b6jGFyjVqrd38nkyo+hdxLrVkbXjZE1nXu2Yd9ouHVYLUrwo5jhkoTO17gTPrlRzSYb0SlwWhYmF7xfLS/xAaVBJbk/THpUr1i')
GO
SET IDENTITY_INSERT [dbo].[departamento] ON 

INSERT [dbo].[departamento] ([id], [descripcion], [id_empresa], [activo]) VALUES (1, N'departamento 1 - e1 - a1', 1, 1)
INSERT [dbo].[departamento] ([id], [descripcion], [id_empresa], [activo]) VALUES (2, N'departamento 2 - e1 - a1', 1, 1)
INSERT [dbo].[departamento] ([id], [descripcion], [id_empresa], [activo]) VALUES (3, N'departamento 3 - e1 - a1', 1, 1)
INSERT [dbo].[departamento] ([id], [descripcion], [id_empresa], [activo]) VALUES (5, N'departamento 1 - e1 - a2', 1, 1)
INSERT [dbo].[departamento] ([id], [descripcion], [id_empresa], [activo]) VALUES (6, N'departamento 2 - e1 - a2', 1, 1)
INSERT [dbo].[departamento] ([id], [descripcion], [id_empresa], [activo]) VALUES (7, N'departamento 3 - e1 - a2', 1, 1)
INSERT [dbo].[departamento] ([id], [descripcion], [id_empresa], [activo]) VALUES (9, N'Dirección de Administración y Finanzas / Coordinación Financiera', 4, 1)
INSERT [dbo].[departamento] ([id], [descripcion], [id_empresa], [activo]) VALUES (10, N'Dirección de Administración y Finanzas / Coordinación Administrativa', 4, 1)
INSERT [dbo].[departamento] ([id], [descripcion], [id_empresa], [activo]) VALUES (11, N'Direccion de Gestión de Documentacion Central', 4, 1)
INSERT [dbo].[departamento] ([id], [descripcion], [id_empresa], [activo]) VALUES (12, N'Dirección de Talento Humano', 4, 1)
INSERT [dbo].[departamento] ([id], [descripcion], [id_empresa], [activo]) VALUES (13, N'Dirección de Oficinas del Registro Civil', 4, 1)
SET IDENTITY_INSERT [dbo].[departamento] OFF
GO
SET IDENTITY_INSERT [dbo].[empresa] ON 

INSERT [dbo].[empresa] ([id], [nombre], [ruc], [telefono], [direccion], [codigo_empresa], [activo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (1, N'Empresa 1', N'1111111-1', N'111', N'direccion 1', N'codigoEmpresa 1', 1, CAST(N'2024-04-18T15:46:56.003' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[empresa] ([id], [nombre], [ruc], [telefono], [direccion], [codigo_empresa], [activo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (3, N'Empresa 2', N'222222-2', N'222', N'direccion 2', N'codigoEmpresa 2', 1, CAST(N'2024-04-19T07:17:17.597' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[empresa] ([id], [nombre], [ruc], [telefono], [direccion], [codigo_empresa], [activo], [fecha_creacion], [usuario_creacion], [fecha_modificacion], [usuario_modificacion]) VALUES (4, N'Dirección General del Registro Civil', N'333333-3', N'333', N'dirección 3', N'codigoEmpresa3', 1, CAST(N'2024-04-22T07:19:03.720' AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[empresa] OFF
GO
SET IDENTITY_INSERT [dbo].[plan_trabajo] ON 

INSERT [dbo].[plan_trabajo] ([id], [numero], [codigo], [id_area], [id_departamento], [objetivos], [procedimientos], [cantidad_personas], [horas_netas], [productos], [fecha_incio_auditoria], [fecha_fin_auditoria], [id_auditor_asignado], [id_responsable_area_auditada], [estado], [envio_informe], [fecha_creada], [id_user_creada], [activo]) VALUES (1, 1, N'M5', 14, 11, N'Evaluación del grado de eficiencia, eficacia y economía de la gestión en cuanto al control, registro y recepción de los diferentes actos y hechos juridicos realizado por la Institución 
', N'"1. Verificar si se realizan las actualizaciones y registros de los actos y hechos juridicos requeridos en la ley e normativas.
2. Verificar el cumplimiento de las normativas de presentación e informe de las distintas oficinas. "
', 3, 1075, 1, CAST(N'2024-05-17' AS Date), NULL, NULL, NULL, NULL, NULL, CAST(N'2024-05-17' AS Date), 1, NULL)
INSERT [dbo].[plan_trabajo] ([id], [numero], [codigo], [id_area], [id_departamento], [objetivos], [procedimientos], [cantidad_personas], [horas_netas], [productos], [fecha_incio_auditoria], [fecha_fin_auditoria], [id_auditor_asignado], [id_responsable_area_auditada], [estado], [envio_informe], [fecha_creada], [id_user_creada], [activo]) VALUES (2, 2, N'M1', 10, 9, N'Análisis de la razonabilidad de los Estados Financieros y la Ejecución Presupuestaria al 30/06/2021, conforme a los Principios de Contabilidad Generalmente Aceptados.
', N'"1. Verificar los registros de operaciones económica, contable, patrimonial y presupuestaria.
2. Verificar que las operaciones que generen o modifiquen recursos, se registren en el momento que ocurran.
3. Verificar la actualización del inventario de bienes, así como la documentación que acredite el dominio de los mismos.
"
', 3, 850, 1, CAST(N'2024-05-17' AS Date), NULL, NULL, NULL, NULL, NULL, CAST(N'2024-05-17' AS Date), 1, NULL)
INSERT [dbo].[plan_trabajo] ([id], [numero], [codigo], [id_area], [id_departamento], [objetivos], [procedimientos], [cantidad_personas], [horas_netas], [productos], [fecha_incio_auditoria], [fecha_fin_auditoria], [id_auditor_asignado], [id_responsable_area_auditada], [estado], [envio_informe], [fecha_creada], [id_user_creada], [activo]) VALUES (3, NULL, N'M8', 17, 13, NULL, NULL, NULL, NULL, NULL, CAST(N'2024-05-17' AS Date), NULL, NULL, NULL, NULL, NULL, CAST(N'2024-05-17' AS Date), 1, NULL)
INSERT [dbo].[plan_trabajo] ([id], [numero], [codigo], [id_area], [id_departamento], [objetivos], [procedimientos], [cantidad_personas], [horas_netas], [productos], [fecha_incio_auditoria], [fecha_fin_auditoria], [id_auditor_asignado], [id_responsable_area_auditada], [estado], [envio_informe], [fecha_creada], [id_user_creada], [activo]) VALUES (4, NULL, N'M9', 18, 13, NULL, NULL, NULL, NULL, NULL, CAST(N'2024-05-17' AS Date), NULL, NULL, NULL, NULL, NULL, CAST(N'2024-05-17' AS Date), 1, NULL)
SET IDENTITY_INSERT [dbo].[plan_trabajo] OFF
GO
SET IDENTITY_INSERT [dbo].[plan_trabajo_cronograma] ON 

INSERT [dbo].[plan_trabajo_cronograma] ([id], [id_plan_trabajo], [fecha], [cantidad_horas]) VALUES (2, 1, CAST(N'2024-07-01' AS Date), 65)
INSERT [dbo].[plan_trabajo_cronograma] ([id], [id_plan_trabajo], [fecha], [cantidad_horas]) VALUES (4, 1, CAST(N'2024-07-02' AS Date), 65)
INSERT [dbo].[plan_trabajo_cronograma] ([id], [id_plan_trabajo], [fecha], [cantidad_horas]) VALUES (5, 1, CAST(N'2024-07-03' AS Date), 65)
INSERT [dbo].[plan_trabajo_cronograma] ([id], [id_plan_trabajo], [fecha], [cantidad_horas]) VALUES (6, 1, CAST(N'2024-07-04' AS Date), 65)
INSERT [dbo].[plan_trabajo_cronograma] ([id], [id_plan_trabajo], [fecha], [cantidad_horas]) VALUES (8, 1, CAST(N'2024-08-01' AS Date), 65)
INSERT [dbo].[plan_trabajo_cronograma] ([id], [id_plan_trabajo], [fecha], [cantidad_horas]) VALUES (9, 1, CAST(N'2024-08-02' AS Date), 65)
INSERT [dbo].[plan_trabajo_cronograma] ([id], [id_plan_trabajo], [fecha], [cantidad_horas]) VALUES (11, 1, CAST(N'2024-08-03' AS Date), 65)
INSERT [dbo].[plan_trabajo_cronograma] ([id], [id_plan_trabajo], [fecha], [cantidad_horas]) VALUES (12, 1, CAST(N'2024-08-04' AS Date), 65)
INSERT [dbo].[plan_trabajo_cronograma] ([id], [id_plan_trabajo], [fecha], [cantidad_horas]) VALUES (13, 1, CAST(N'2024-09-01' AS Date), 65)
INSERT [dbo].[plan_trabajo_cronograma] ([id], [id_plan_trabajo], [fecha], [cantidad_horas]) VALUES (14, 1, CAST(N'2024-09-02' AS Date), 85)
INSERT [dbo].[plan_trabajo_cronograma] ([id], [id_plan_trabajo], [fecha], [cantidad_horas]) VALUES (15, 1, CAST(N'2024-09-03' AS Date), 65)
INSERT [dbo].[plan_trabajo_cronograma] ([id], [id_plan_trabajo], [fecha], [cantidad_horas]) VALUES (16, 1, CAST(N'2024-09-04' AS Date), 65)
INSERT [dbo].[plan_trabajo_cronograma] ([id], [id_plan_trabajo], [fecha], [cantidad_horas]) VALUES (17, 1, CAST(N'2024-10-01' AS Date), 50)
SET IDENTITY_INSERT [dbo].[plan_trabajo_cronograma] OFF
GO
SET IDENTITY_INSERT [dbo].[plan_trabajo_puntos] ON 

INSERT [dbo].[plan_trabajo_puntos] ([id], [id_plan_trabajo], [descripcion], [tipo_punto], [activo]) VALUES (1, 1, N'Levantam. Falta documentacion', N'L', 1)
INSERT [dbo].[plan_trabajo_puntos] ([id], [id_plan_trabajo], [descripcion], [tipo_punto], [activo]) VALUES (2, 1, N'Descargo. Estan los documentos en la sucursal 2', N'D', 1)
INSERT [dbo].[plan_trabajo_puntos] ([id], [id_plan_trabajo], [descripcion], [tipo_punto], [activo]) VALUES (3, 2, N'Levantam. Falta dinero en caja', N'L', 1)
INSERT [dbo].[plan_trabajo_puntos] ([id], [id_plan_trabajo], [descripcion], [tipo_punto], [activo]) VALUES (4, 2, N'Descargo. El dinero estaba por retirarse del banco', N'D', 1)
SET IDENTITY_INSERT [dbo].[plan_trabajo_puntos] OFF
GO
SET IDENTITY_INSERT [dbo].[riesgo] ON 

INSERT [dbo].[riesgo] ([id], [descripcion], [user_creado], [activo]) VALUES (4, N'Dejadez', 1, 1)
INSERT [dbo].[riesgo] ([id], [descripcion], [user_creado], [activo]) VALUES (6, N'Demora', 1, 1)
INSERT [dbo].[riesgo] ([id], [descripcion], [user_creado], [activo]) VALUES (7, N'Desactualización', 1, 1)
INSERT [dbo].[riesgo] ([id], [descripcion], [user_creado], [activo]) VALUES (8, N'Descontento', 1, 1)
INSERT [dbo].[riesgo] ([id], [descripcion], [user_creado], [activo]) VALUES (9, N'Error', 1, 1)
INSERT [dbo].[riesgo] ([id], [descripcion], [user_creado], [activo]) VALUES (10, N'Falta de manuales', 1, 1)
INSERT [dbo].[riesgo] ([id], [descripcion], [user_creado], [activo]) VALUES (11, N'Incumplimiento', 1, 1)
INSERT [dbo].[riesgo] ([id], [descripcion], [user_creado], [activo]) VALUES (12, N'Inexactitud', 1, 1)
INSERT [dbo].[riesgo] ([id], [descripcion], [user_creado], [activo]) VALUES (13, N'Omisión', 1, 1)
INSERT [dbo].[riesgo] ([id], [descripcion], [user_creado], [activo]) VALUES (14, N'Ausencia de control', 1, 1)
SET IDENTITY_INSERT [dbo].[riesgo] OFF
GO
/****** Object:  Index [IX_analisis_riesgo_id_area]    Script Date: 26/5/2024 11:28:00 ******/
CREATE NONCLUSTERED INDEX [IX_analisis_riesgo_id_area] ON [dbo].[analisis_riesgo]
(
	[id_area] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_analisis_riesgo_id_riesgo]    Script Date: 26/5/2024 11:28:00 ******/
CREATE NONCLUSTERED INDEX [IX_analisis_riesgo_id_riesgo] ON [dbo].[analisis_riesgo]
(
	[id_riesgo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_area_id_departamento]    Script Date: 26/5/2024 11:28:00 ******/
CREATE NONCLUSTERED INDEX [IX_area_id_departamento] ON [dbo].[area]
(
	[id_departamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_area_id_empresa]    Script Date: 26/5/2024 11:28:00 ******/
CREATE NONCLUSTERED INDEX [IX_area_id_empresa] ON [dbo].[area]
(
	[id_empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 26/5/2024 11:28:00 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 26/5/2024 11:28:00 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 26/5/2024 11:28:00 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 26/5/2024 11:28:00 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 26/5/2024 11:28:00 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 26/5/2024 11:28:00 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 26/5/2024 11:28:00 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_departamento_id_empresa]    Script Date: 26/5/2024 11:28:00 ******/
CREATE NONCLUSTERED INDEX [IX_departamento_id_empresa] ON [dbo].[departamento]
(
	[id_empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_plan_trabajo_id_auditor_asignado]    Script Date: 26/5/2024 11:28:00 ******/
CREATE NONCLUSTERED INDEX [IX_plan_trabajo_id_auditor_asignado] ON [dbo].[plan_trabajo]
(
	[id_auditor_asignado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_plan_trabajo_id_departamento]    Script Date: 26/5/2024 11:28:00 ******/
CREATE NONCLUSTERED INDEX [IX_plan_trabajo_id_departamento] ON [dbo].[plan_trabajo]
(
	[id_departamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_plan_trabajo_id_responsable_area_auditada]    Script Date: 26/5/2024 11:28:00 ******/
CREATE NONCLUSTERED INDEX [IX_plan_trabajo_id_responsable_area_auditada] ON [dbo].[plan_trabajo]
(
	[id_responsable_area_auditada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_plan_trabajo_puntos_id_plan_trabajo]    Script Date: 26/5/2024 11:28:00 ******/
CREATE NONCLUSTERED INDEX [IX_plan_trabajo_puntos_id_plan_trabajo] ON [dbo].[plan_trabajo_puntos]
(
	[id_plan_trabajo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[area] ADD  DEFAULT (CONVERT([bit],(1))) FOR [activo]
GO
ALTER TABLE [dbo].[departamento] ADD  DEFAULT (CONVERT([bit],(1))) FOR [activo]
GO
ALTER TABLE [dbo].[empresa] ADD  DEFAULT (CONVERT([bit],(1))) FOR [activo]
GO
ALTER TABLE [dbo].[empresa] ADD  DEFAULT (getdate()) FOR [fecha_creacion]
GO
ALTER TABLE [dbo].[plan_trabajo] ADD  CONSTRAINT [DF__plan_trab__fecha__6A30C649]  DEFAULT (getdate()) FOR [fecha_creada]
GO
ALTER TABLE [dbo].[plan_trabajo_puntos] ADD  DEFAULT ('L') FOR [tipo_punto]
GO
ALTER TABLE [dbo].[analisis_riesgo]  WITH NOCHECK ADD  CONSTRAINT [FK_analisis_riesgo_area] FOREIGN KEY([id_area])
REFERENCES [dbo].[area] ([id])
GO
ALTER TABLE [dbo].[analisis_riesgo] NOCHECK CONSTRAINT [FK_analisis_riesgo_area]
GO
ALTER TABLE [dbo].[analisis_riesgo]  WITH NOCHECK ADD  CONSTRAINT [FK_analisis_riesgo_riesgo] FOREIGN KEY([id_riesgo])
REFERENCES [dbo].[riesgo] ([id])
GO
ALTER TABLE [dbo].[analisis_riesgo] NOCHECK CONSTRAINT [FK_analisis_riesgo_riesgo]
GO
ALTER TABLE [dbo].[area]  WITH NOCHECK ADD  CONSTRAINT [FK_area_departamento] FOREIGN KEY([id_departamento])
REFERENCES [dbo].[departamento] ([id])
GO
ALTER TABLE [dbo].[area] NOCHECK CONSTRAINT [FK_area_departamento]
GO
ALTER TABLE [dbo].[area]  WITH NOCHECK ADD  CONSTRAINT [FK_area_empresa] FOREIGN KEY([id_empresa])
REFERENCES [dbo].[empresa] ([id])
GO
ALTER TABLE [dbo].[area] NOCHECK CONSTRAINT [FK_area_empresa]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH NOCHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] NOCHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH NOCHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] NOCHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH NOCHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] NOCHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH NOCHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] NOCHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH NOCHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] NOCHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH NOCHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] NOCHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[departamento]  WITH NOCHECK ADD  CONSTRAINT [FK_departamento_empresa] FOREIGN KEY([id_empresa])
REFERENCES [dbo].[empresa] ([id])
GO
ALTER TABLE [dbo].[departamento] NOCHECK CONSTRAINT [FK_departamento_empresa]
GO
ALTER TABLE [dbo].[plan_trabajo]  WITH NOCHECK ADD  CONSTRAINT [FK_plan_trabajo_departamento] FOREIGN KEY([id_departamento])
REFERENCES [dbo].[departamento] ([id])
GO
ALTER TABLE [dbo].[plan_trabajo] NOCHECK CONSTRAINT [FK_plan_trabajo_departamento]
GO
ALTER TABLE [dbo].[plan_trabajo_cronograma]  WITH NOCHECK ADD  CONSTRAINT [FK_plan_trabajo_cronog_plan_trabajo] FOREIGN KEY([id_plan_trabajo])
REFERENCES [dbo].[plan_trabajo] ([id])
GO
ALTER TABLE [dbo].[plan_trabajo_cronograma] CHECK CONSTRAINT [FK_plan_trabajo_cronog_plan_trabajo]
GO
ALTER TABLE [dbo].[plan_trabajo_puntos]  WITH NOCHECK ADD  CONSTRAINT [FK_plan_trabajo_puntos_plan_trabajo] FOREIGN KEY([id_plan_trabajo])
REFERENCES [dbo].[plan_trabajo] ([id])
GO
ALTER TABLE [dbo].[plan_trabajo_puntos] NOCHECK CONSTRAINT [FK_plan_trabajo_puntos_plan_trabajo]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'L : levantamiento - D : descargo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'plan_trabajo_puntos', @level2type=N'COLUMN',@level2name=N'tipo_punto'
GO
USE [master]
GO
ALTER DATABASE [dbTest5] SET  READ_WRITE 
GO
