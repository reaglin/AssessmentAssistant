USE [aspnet-AssessmentAssistant-53bc9b9d-9d6a-45d4-8429-2a2761773502]
GO
/* This script will crate all the tables for the Database AssessmentAssistant*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Table [dbo].[AcademicCourses]    Script Date: 7/20/2022 1:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcademicCourses](
	[AcademicCourseId] [bigint] IDENTITY(1,1) NOT NULL,
	[CourseTitle] [nvarchar](max) NOT NULL,
	[CourseDescription] [nvarchar](max) NULL,
	[CourseCoordinatorID] [nvarchar](max) NULL,
	[AcademicProgramId] [bigint] NOT NULL,
	[MeasurementPeriod] [nvarchar](max) NULL,
	[EnteredByUserName] [nvarchar](max) NULL,
	[RecordOwnerUserName] [nvarchar](max) NULL,
 CONSTRAINT [PK_AcademicCourses] PRIMARY KEY CLUSTERED 
(
	[AcademicCourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AcademicPrograms]    Script Date: 7/20/2022 1:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcademicPrograms](
	[AcademicProgramId] [bigint] IDENTITY(1,1) NOT NULL,
	[ProgramTitle] [nvarchar](max) NOT NULL,
	[ProgramDescription] [nvarchar](max) NULL,
	[MeasurementPeriod] [nvarchar](max) NULL,
	[EnteredByUserName] [nvarchar](max) NULL,
	[RecordOwnerUserName] [nvarchar](max) NULL,
 CONSTRAINT [PK_AcademicPrograms] PRIMARY KEY CLUSTERED 
(
	[AcademicProgramId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 7/20/2022 1:08:25 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 7/20/2022 1:08:25 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 7/20/2022 1:08:25 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 7/20/2022 1:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 7/20/2022 1:08:25 PM ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 7/20/2022 1:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
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
	[UserComments] [nvarchar](max) NULL,
	[UserDisplayName] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 7/20/2022 1:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseOfferings]    Script Date: 7/20/2022 1:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseOfferings](
	[CourseOfferingId] [bigint] IDENTITY(1,1) NOT NULL,
	[SectionNumber] [nvarchar](max) NULL,
	[Semester] [nvarchar](max) NULL,
	[Instructor] [nvarchar](max) NULL,
	[AcademicCourseId] [bigint] NOT NULL,
	[Number_A] [int] NULL,
	[Number_B] [int] NULL,
	[Number_C] [int] NULL,
	[Number_D] [int] NULL,
	[Number_F] [int] NULL,
	[Number_W] [int] NULL,
	[MeasurementPeriod] [nvarchar](max) NULL,
	[EnteredByUserName] [nvarchar](max) NULL,
	[RecordOwnerUserName] [nvarchar](max) NULL,
	[IssuesFaced] [nvarchar](max) NULL,
	[ProposedImprovements] [nvarchar](max) NULL,
	[ResultsOfImprovements] [nvarchar](max) NULL,
 CONSTRAINT [PK_CourseOfferings] PRIMARY KEY CLUSTERED 
(
	[CourseOfferingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseOutcomes]    Script Date: 7/20/2022 1:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseOutcomes](
	[CourseOutcomeId] [bigint] IDENTITY(1,1) NOT NULL,
	[OutcomeNumber] [int] NOT NULL,
	[OutcomeStatement] [nvarchar](max) NOT NULL,
	[ProgramOutcomeNumber] [int] NULL,
	[OutcomeLevel] [nvarchar](max) NULL,
	[AcademicCourseId] [bigint] NOT NULL,
	[MeasurementPeriod] [nvarchar](max) NULL,
	[EnteredByUserName] [nvarchar](max) NULL,
	[RecordOwnerUserName] [nvarchar](max) NULL,
 CONSTRAINT [PK_CourseOutcomes] PRIMARY KEY CLUSTERED 
(
	[CourseOutcomeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseReview]    Script Date: 7/20/2022 1:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseReview](
	[CourseReviewId] [bigint] IDENTITY(1,1) NOT NULL,
	[CourseReviewStatement] [nvarchar](max) NULL,
	[CourseOfferingReviewedId] [bigint] NOT NULL,
	[ReviewedByUserName] [nvarchar](max) NULL,
	[EnteredByUserName] [nvarchar](max) NULL,
	[RecordOwnerUserName] [nvarchar](max) NULL,
 CONSTRAINT [PK_CourseReview] PRIMARY KEY CLUSTERED 
(
	[CourseReviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseReviewStandards]    Script Date: 7/20/2022 1:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseReviewStandards](
	[CourseReviewStandardsId] [bigint] IDENTITY(1,1) NOT NULL,
	[GeneralStandardVersion] [int] NULL,
	[GeneralStandardNumber] [int] NOT NULL,
	[GeneralStandard] [nvarchar](max) NOT NULL,
	[ReviewStandardNumber] [int] NULL,
	[ReviewStandard] [nvarchar](max) NULL,
	[ReviewStandardPoints] [int] NULL,
	[EnteredByUserName] [nvarchar](max) NULL,
	[RecordOwnerUserName] [nvarchar](max) NULL,
 CONSTRAINT [PK_CourseReviewStandards] PRIMARY KEY CLUSTERED 
(
	[CourseReviewStandardsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseStandardsReview]    Script Date: 7/20/2022 1:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseStandardsReview](
	[CourseStandardsReviewId] [bigint] IDENTITY(1,1) NOT NULL,
	[ReviewStatement] [nvarchar](max) NULL,
	[ReviewResponse] [nvarchar](max) NULL,
	[PointsAssigned] [int] NULL,
	[CourseReviewStandardsId] [bigint] NOT NULL,
	[ReviewedByUserName] [nvarchar](max) NULL,
	[EnteredByUserName] [nvarchar](max) NULL,
	[RecordOwnerUserName] [nvarchar](max) NULL,
 CONSTRAINT [PK_CourseStandardsReview] PRIMARY KEY CLUSTERED 
(
	[CourseStandardsReviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enumerations]    Script Date: 7/20/2022 1:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enumerations](
	[EnumerationId] [bigint] IDENTITY(1,1) NOT NULL,
	[Identifier] [nvarchar](max) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[Order] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Enumerations] PRIMARY KEY CLUSTERED 
(
	[EnumerationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeasurementsPeriods]    Script Date: 7/20/2022 1:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeasurementsPeriods](
	[MeasurementPeriod] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_MeasurementsPeriods] PRIMARY KEY CLUSTERED 
(
	[MeasurementPeriod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OutcomeMeasures]    Script Date: 7/20/2022 1:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OutcomeMeasures](
	[OutcomeMeasureId] [bigint] IDENTITY(1,1) NOT NULL,
	[CourseOutcomeNumber] [int] NOT NULL,
	[AssessmentType] [nvarchar](max) NULL,
	[MeasurementStatement] [nvarchar](max) NULL,
	[ThresholdValue] [int] NULL,
	[NumberMeasured] [int] NULL,
	[NumberMeetingThreshold] [int] NULL,
	[CourseOfferingId] [bigint] NULL,
	[MeasurementPeriod] [nvarchar](max) NULL,
	[EnteredByUserName] [nvarchar](max) NULL,
	[RecordOwnerUserName] [nvarchar](max) NULL,
 CONSTRAINT [PK_OutcomeMeasures] PRIMARY KEY CLUSTERED 
(
	[OutcomeMeasureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgramOutcomes]    Script Date: 7/20/2022 1:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgramOutcomes](
	[ProgramOutcomeId] [bigint] IDENTITY(1,1) NOT NULL,
	[OutcomeNumber] [int] NOT NULL,
	[OutcomeStatement] [nvarchar](max) NOT NULL,
	[AcademicProgramId] [bigint] NOT NULL,
	[MeasurementPeriod] [nvarchar](max) NULL,
	[EnteredByUserName] [nvarchar](max) NULL,
	[RecordOwnerUserName] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProgramOutcomes] PRIMARY KEY CLUSTERED 
(
	[ProgramOutcomeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Semesters]    Script Date: 7/20/2022 1:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semesters](
	[Semester] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Semesters] PRIMARY KEY CLUSTERED 
(
	[Semester] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSettings]    Script Date: 7/20/2022 1:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSettings](
	[UserSettingsId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](max) NULL,
	[AcademicProgramId] [bigint] NULL,
	[MeasurementPeriod] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserSettings] PRIMARY KEY CLUSTERED 
(
	[UserSettingsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[CourseOutcomes] ADD  DEFAULT (CONVERT([bigint],(0))) FOR [AcademicCourseId]
GO
ALTER TABLE [dbo].[AcademicCourses]  WITH CHECK ADD  CONSTRAINT [FK_AcademicCourses_AcademicPrograms_AcademicProgramId] FOREIGN KEY([AcademicProgramId])
REFERENCES [dbo].[AcademicPrograms] ([AcademicProgramId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AcademicCourses] CHECK CONSTRAINT [FK_AcademicCourses_AcademicPrograms_AcademicProgramId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CourseOfferings]  WITH CHECK ADD  CONSTRAINT [FK_CourseOfferings_AcademicCourses_AcademicCourseId] FOREIGN KEY([AcademicCourseId])
REFERENCES [dbo].[AcademicCourses] ([AcademicCourseId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CourseOfferings] CHECK CONSTRAINT [FK_CourseOfferings_AcademicCourses_AcademicCourseId]
GO
ALTER TABLE [dbo].[CourseOutcomes]  WITH CHECK ADD  CONSTRAINT [FK_CourseOutcomes_AcademicCourses_AcademicCourseId] FOREIGN KEY([AcademicCourseId])
REFERENCES [dbo].[AcademicCourses] ([AcademicCourseId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CourseOutcomes] CHECK CONSTRAINT [FK_CourseOutcomes_AcademicCourses_AcademicCourseId]
GO
ALTER TABLE [dbo].[CourseReview]  WITH CHECK ADD FOREIGN KEY([CourseOfferingReviewedId])
REFERENCES [dbo].[CourseOfferings] ([CourseOfferingId])
GO
ALTER TABLE [dbo].[CourseStandardsReview]  WITH CHECK ADD FOREIGN KEY([CourseReviewStandardsId])
REFERENCES [dbo].[CourseReviewStandards] ([CourseReviewStandardsId])
GO
ALTER TABLE [dbo].[OutcomeMeasures]  WITH CHECK ADD  CONSTRAINT [FK_OutcomeMeasures_CourseOfferings_CourseOfferingId] FOREIGN KEY([CourseOfferingId])
REFERENCES [dbo].[CourseOfferings] ([CourseOfferingId])
GO
ALTER TABLE [dbo].[OutcomeMeasures] CHECK CONSTRAINT [FK_OutcomeMeasures_CourseOfferings_CourseOfferingId]
GO
ALTER TABLE [dbo].[ProgramOutcomes]  WITH CHECK ADD  CONSTRAINT [FK_ProgramOutcomes_AcademicPrograms_AcademicProgramId] FOREIGN KEY([AcademicProgramId])
REFERENCES [dbo].[AcademicPrograms] ([AcademicProgramId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProgramOutcomes] CHECK CONSTRAINT [FK_ProgramOutcomes_AcademicPrograms_AcademicProgramId]
GO
