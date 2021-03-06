USE [AutoInsuarance]
GO
/****** Object:  Table [dbo].[Agencies]    Script Date: 12/21/2010 12:43:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Agencies](
	[AgencyId] [varchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](255) NULL,
 CONSTRAINT [PK_Agencies] PRIMARY KEY CLUSTERED 
(
	[AgencyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Purposes]    Script Date: 12/21/2010 12:43:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purposes](
	[PurposeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](32) NULL,
	[Coeficient] [numeric](15, 2) NULL,
 CONSTRAINT [PK_Purposes] PRIMARY KEY CLUSTERED 
(
	[PurposeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 12/21/2010 12:43:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Number] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FuelTypes]    Script Date: 12/21/2010 12:43:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FuelTypes](
	[FuelTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](32) NULL,
 CONSTRAINT [PK_FuelTypes] PRIMARY KEY CLUSTERED 
(
	[FuelTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 12/21/2010 12:43:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NULL,
	[InsuranceBasePrice] [money] NULL,
	[YoungDriverCoeficient] [numeric](15, 2) NULL,
	[OldDriverCoeficient] [numeric](15, 2) NULL,
	[PurposePrice] [numeric](15, 2) NULL,
	[AutoTypePrice] [numeric](15, 2) NULL,
	[VechicleDisplacementPrice] [numeric](15, 2) NULL,
	[LoadingCapacityPricePer1000kg] [numeric](15, 2) NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Базова цена' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Companies', @level2type=N'COLUMN',@level2name=N'InsuranceBasePrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Коефициент за млад водач' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Companies', @level2type=N'COLUMN',@level2name=N'YoungDriverCoeficient'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Коефициент за опитен водач' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Companies', @level2type=N'COLUMN',@level2name=N'OldDriverCoeficient'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Цена за предназначение' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Companies', @level2type=N'COLUMN',@level2name=N'PurposePrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Цена за тип на превоното средство' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Companies', @level2type=N'COLUMN',@level2name=N'AutoTypePrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Цена за кубатура' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Companies', @level2type=N'COLUMN',@level2name=N'VechicleDisplacementPrice'
GO
/****** Object:  Table [dbo].[AutoTypes]    Script Date: 12/21/2010 12:43:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AutoTypes](
	[AutoTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](32) NULL,
	[Coeficient] [numeric](15, 2) NULL,
	[HasLoadingCapacity] [bit] NULL,
 CONSTRAINT [PK_AutoTypes] PRIMARY KEY CLUSTERED 
(
	[AutoTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Autos]    Script Date: 12/21/2010 12:43:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autos](
	[AutoId] [int] IDENTITY(1,1) NOT NULL,
	[RegNumber] [nvarchar](15) NULL,
	[FrameNumber] [nvarchar](20) NULL,
	[EngineDisplacement] [int] NULL,
	[Make] [nvarchar](32) NULL,
	[Model] [nvarchar](32) NULL,
	[Description] [nvarchar](255) NULL,
	[Color] [nvarchar](32) NULL,
	[OwnerPersonId] [int] NULL,
	[AutoTypeId] [int] NULL,
	[PurposeId] [int] NULL,
	[FirstRegistrationDate] [date] NULL,
	[MakeYear] [int] NULL,
	[SeatsCount] [int] NULL,
	[DoorsCount] [int] NULL,
	[FuelTypeId] [int] NULL,
	[LoadingCapacity] [int] NULL,
 CONSTRAINT [PK_Autos] PRIMARY KEY CLUSTERED 
(
	[AutoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Регистрационен номер' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Autos', @level2type=N'COLUMN',@level2name=N'RegNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Номер на рамата' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Autos', @level2type=N'COLUMN',@level2name=N'FrameNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Обем на двигателя' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Autos', @level2type=N'COLUMN',@level2name=N'EngineDisplacement'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Товароносимост' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Autos', @level2type=N'COLUMN',@level2name=N'LoadingCapacity'
GO
/****** Object:  Table [dbo].[InsurancePolicy]    Script Date: 12/21/2010 12:43:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InsurancePolicy](
	[InsurancePolicyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[Number]  AS (CONVERT([varchar](2),[CompanyId],(0))+CONVERT([varchar](6),[InsurancePolicyId],(0))),
	[IssueDate] [date] NULL,
	[EndDate] [date] NULL,
	[AgencyName] [varchar](50) NULL,
	[AutoId] [int] NULL,
	[Price] [numeric](15, 2) NULL,
	[DriverExperienceYears] [int] NULL,
	[HasAccidents] [bit] NULL,
 CONSTRAINT [PK_InsurancePolicy] PRIMARY KEY CLUSTERED 
(
	[InsurancePolicyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_Autos_AutoTypes]    Script Date: 12/21/2010 12:43:56 ******/
ALTER TABLE [dbo].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_Autos_AutoTypes] FOREIGN KEY([AutoTypeId])
REFERENCES [dbo].[AutoTypes] ([AutoTypeId])
GO
ALTER TABLE [dbo].[Autos] CHECK CONSTRAINT [FK_Autos_AutoTypes]
GO
/****** Object:  ForeignKey [FK_Autos_FuelTypes]    Script Date: 12/21/2010 12:43:56 ******/
ALTER TABLE [dbo].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_Autos_FuelTypes] FOREIGN KEY([FuelTypeId])
REFERENCES [dbo].[FuelTypes] ([FuelTypeId])
GO
ALTER TABLE [dbo].[Autos] CHECK CONSTRAINT [FK_Autos_FuelTypes]
GO
/****** Object:  ForeignKey [FK_Autos_Persons]    Script Date: 12/21/2010 12:43:56 ******/
ALTER TABLE [dbo].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_Autos_Persons] FOREIGN KEY([OwnerPersonId])
REFERENCES [dbo].[Persons] ([PersonId])
GO
ALTER TABLE [dbo].[Autos] CHECK CONSTRAINT [FK_Autos_Persons]
GO
/****** Object:  ForeignKey [FK_Autos_Purposes]    Script Date: 12/21/2010 12:43:56 ******/
ALTER TABLE [dbo].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_Autos_Purposes] FOREIGN KEY([PurposeId])
REFERENCES [dbo].[Purposes] ([PurposeId])
GO
ALTER TABLE [dbo].[Autos] CHECK CONSTRAINT [FK_Autos_Purposes]
GO
/****** Object:  ForeignKey [FK_InsuarancePolicy_Agencies]    Script Date: 12/21/2010 12:43:56 ******/
ALTER TABLE [dbo].[InsurancePolicy]  WITH CHECK ADD  CONSTRAINT [FK_InsuarancePolicy_Agencies] FOREIGN KEY([AgencyName])
REFERENCES [dbo].[Agencies] ([AgencyId])
GO
ALTER TABLE [dbo].[InsurancePolicy] CHECK CONSTRAINT [FK_InsuarancePolicy_Agencies]
GO
/****** Object:  ForeignKey [FK_InsuarancePolicy_Companies]    Script Date: 12/21/2010 12:43:56 ******/
ALTER TABLE [dbo].[InsurancePolicy]  WITH CHECK ADD  CONSTRAINT [FK_InsuarancePolicy_Companies] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([CompanyId])
GO
ALTER TABLE [dbo].[InsurancePolicy] CHECK CONSTRAINT [FK_InsuarancePolicy_Companies]
GO
/****** Object:  ForeignKey [FK_InsurancePolicy_Autos]    Script Date: 12/21/2010 12:43:56 ******/
ALTER TABLE [dbo].[InsurancePolicy]  WITH CHECK ADD  CONSTRAINT [FK_InsurancePolicy_Autos] FOREIGN KEY([AutoId])
REFERENCES [dbo].[Autos] ([AutoId])
GO
ALTER TABLE [dbo].[InsurancePolicy] CHECK CONSTRAINT [FK_InsurancePolicy_Autos]
GO
