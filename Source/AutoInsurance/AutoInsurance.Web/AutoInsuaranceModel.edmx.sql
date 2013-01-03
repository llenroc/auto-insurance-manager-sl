
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/04/2011 08:51:11
-- Generated from EDMX file: D:\Programming\Silverlight\AutoInsurance\Source\AutoInsurance\AutoInsurance.Web\AutoInsuaranceModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AutoInsurance];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Autos_AutoTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Autos] DROP CONSTRAINT [FK_Autos_AutoTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_Autos_FuelTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Autos] DROP CONSTRAINT [FK_Autos_FuelTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_Autos_Persons]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Autos] DROP CONSTRAINT [FK_Autos_Persons];
GO
IF OBJECT_ID(N'[dbo].[FK_Autos_Purposes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Autos] DROP CONSTRAINT [FK_Autos_Purposes];
GO
IF OBJECT_ID(N'[dbo].[FK_InsuarancePolicy_Agencies]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InsurancePolicy] DROP CONSTRAINT [FK_InsuarancePolicy_Agencies];
GO
IF OBJECT_ID(N'[dbo].[FK_InsuarancePolicy_Companies]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InsurancePolicy] DROP CONSTRAINT [FK_InsuarancePolicy_Companies];
GO
IF OBJECT_ID(N'[dbo].[FK_InsurancePolicy_Autos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InsurancePolicy] DROP CONSTRAINT [FK_InsurancePolicy_Autos];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Agencies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Agencies];
GO
IF OBJECT_ID(N'[dbo].[Autos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Autos];
GO
IF OBJECT_ID(N'[dbo].[AutoTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AutoTypes];
GO
IF OBJECT_ID(N'[dbo].[Companies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Companies];
GO
IF OBJECT_ID(N'[dbo].[FuelTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FuelTypes];
GO
IF OBJECT_ID(N'[dbo].[InsurancePolicy]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InsurancePolicy];
GO
IF OBJECT_ID(N'[dbo].[Persons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Persons];
GO
IF OBJECT_ID(N'[dbo].[Purposes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Purposes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Agencies'
CREATE TABLE [dbo].[Agencies] (
    [AgencyId] varchar(50)  NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Address] nvarchar(255)  NULL
);
GO

-- Creating table 'Autos'
CREATE TABLE [dbo].[Autos] (
    [AutoId] int IDENTITY(1,1) NOT NULL,
    [RegNumber] nvarchar(15)  NULL,
    [FrameNumber] nvarchar(20)  NULL,
    [EngineDisplacement] int  NULL,
    [Make] nvarchar(32)  NULL,
    [Model] nvarchar(32)  NULL,
    [Description] nvarchar(255)  NULL,
    [Color] nvarchar(32)  NULL,
    [OwnerPersonId] int  NULL,
    [AutoTypeId] int  NULL,
    [PurposeId] int  NULL,
    [FirstRegistrationDate] datetime  NULL,
    [MakeYear] int  NULL,
    [SeatsCount] int  NULL,
    [DoorsCount] int  NULL,
    [FuelTypeId] int  NULL,
    [LoadingCapacity] int  NULL
);
GO

-- Creating table 'AutoTypes'
CREATE TABLE [dbo].[AutoTypes] (
    [AutoTypeId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(32)  NULL,
    [Coeficient] decimal(15,2)  NULL,
    [HasLoadingCapacity] bit  NULL
);
GO

-- Creating table 'Companies'
CREATE TABLE [dbo].[Companies] (
    [CompanyId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(30)  NULL,
    [InsuranceBasePrice] decimal(19,4)  NULL,
    [YoungDriverCoeficient] decimal(15,2)  NULL,
    [OldDriverCoeficient] decimal(15,2)  NULL,
    [PurposePrice] decimal(15,2)  NULL,
    [AutoTypePrice] decimal(15,2)  NULL,
    [VechicleDisplacementPrice] decimal(15,2)  NULL,
    [LoadingCapacityPricePer1000kg] decimal(15,2)  NULL
);
GO

-- Creating table 'FuelTypes'
CREATE TABLE [dbo].[FuelTypes] (
    [FuelTypeId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(32)  NULL
);
GO

-- Creating table 'InsurancePolicies'
CREATE TABLE [dbo].[InsurancePolicies] (
    [InsurancePolicyId] int IDENTITY(1,1) NOT NULL,
    [CompanyId] int  NULL,
    [Number] varchar(8)  NULL,
    [IssueDate] datetime  NULL,
    [EndDate] datetime  NULL,
    [AgencyName] varchar(50)  NULL,
    [AutoId] int  NULL,
    [Price] decimal(15,2)  NULL,
    [DriverExperienceYears] int  NULL,
    [HasAccidents] bit  NULL
);
GO

-- Creating table 'Persons'
CREATE TABLE [dbo].[Persons] (
    [PersonId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Number] nvarchar(50)  NULL,
    [Address] nvarchar(50)  NULL
);
GO

-- Creating table 'Purposes'
CREATE TABLE [dbo].[Purposes] (
    [PurposeId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(32)  NULL,
    [Coeficient] decimal(15,2)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AgencyId] in table 'Agencies'
ALTER TABLE [dbo].[Agencies]
ADD CONSTRAINT [PK_Agencies]
    PRIMARY KEY CLUSTERED ([AgencyId] ASC);
GO

-- Creating primary key on [AutoId] in table 'Autos'
ALTER TABLE [dbo].[Autos]
ADD CONSTRAINT [PK_Autos]
    PRIMARY KEY CLUSTERED ([AutoId] ASC);
GO

-- Creating primary key on [AutoTypeId] in table 'AutoTypes'
ALTER TABLE [dbo].[AutoTypes]
ADD CONSTRAINT [PK_AutoTypes]
    PRIMARY KEY CLUSTERED ([AutoTypeId] ASC);
GO

-- Creating primary key on [CompanyId] in table 'Companies'
ALTER TABLE [dbo].[Companies]
ADD CONSTRAINT [PK_Companies]
    PRIMARY KEY CLUSTERED ([CompanyId] ASC);
GO

-- Creating primary key on [FuelTypeId] in table 'FuelTypes'
ALTER TABLE [dbo].[FuelTypes]
ADD CONSTRAINT [PK_FuelTypes]
    PRIMARY KEY CLUSTERED ([FuelTypeId] ASC);
GO

-- Creating primary key on [InsurancePolicyId] in table 'InsurancePolicies'
ALTER TABLE [dbo].[InsurancePolicies]
ADD CONSTRAINT [PK_InsurancePolicies]
    PRIMARY KEY CLUSTERED ([InsurancePolicyId] ASC);
GO

-- Creating primary key on [PersonId] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [PK_Persons]
    PRIMARY KEY CLUSTERED ([PersonId] ASC);
GO

-- Creating primary key on [PurposeId] in table 'Purposes'
ALTER TABLE [dbo].[Purposes]
ADD CONSTRAINT [PK_Purposes]
    PRIMARY KEY CLUSTERED ([PurposeId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AgencyName] in table 'InsurancePolicies'
ALTER TABLE [dbo].[InsurancePolicies]
ADD CONSTRAINT [FK_InsuarancePolicy_Agencies]
    FOREIGN KEY ([AgencyName])
    REFERENCES [dbo].[Agencies]
        ([AgencyId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InsuarancePolicy_Agencies'
CREATE INDEX [IX_FK_InsuarancePolicy_Agencies]
ON [dbo].[InsurancePolicies]
    ([AgencyName]);
GO

-- Creating foreign key on [AutoTypeId] in table 'Autos'
ALTER TABLE [dbo].[Autos]
ADD CONSTRAINT [FK_Autos_AutoTypes]
    FOREIGN KEY ([AutoTypeId])
    REFERENCES [dbo].[AutoTypes]
        ([AutoTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Autos_AutoTypes'
CREATE INDEX [IX_FK_Autos_AutoTypes]
ON [dbo].[Autos]
    ([AutoTypeId]);
GO

-- Creating foreign key on [FuelTypeId] in table 'Autos'
ALTER TABLE [dbo].[Autos]
ADD CONSTRAINT [FK_Autos_FuelTypes]
    FOREIGN KEY ([FuelTypeId])
    REFERENCES [dbo].[FuelTypes]
        ([FuelTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Autos_FuelTypes'
CREATE INDEX [IX_FK_Autos_FuelTypes]
ON [dbo].[Autos]
    ([FuelTypeId]);
GO

-- Creating foreign key on [OwnerPersonId] in table 'Autos'
ALTER TABLE [dbo].[Autos]
ADD CONSTRAINT [FK_Autos_Persons]
    FOREIGN KEY ([OwnerPersonId])
    REFERENCES [dbo].[Persons]
        ([PersonId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Autos_Persons'
CREATE INDEX [IX_FK_Autos_Persons]
ON [dbo].[Autos]
    ([OwnerPersonId]);
GO

-- Creating foreign key on [PurposeId] in table 'Autos'
ALTER TABLE [dbo].[Autos]
ADD CONSTRAINT [FK_Autos_Purposes]
    FOREIGN KEY ([PurposeId])
    REFERENCES [dbo].[Purposes]
        ([PurposeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Autos_Purposes'
CREATE INDEX [IX_FK_Autos_Purposes]
ON [dbo].[Autos]
    ([PurposeId]);
GO

-- Creating foreign key on [AutoId] in table 'InsurancePolicies'
ALTER TABLE [dbo].[InsurancePolicies]
ADD CONSTRAINT [FK_InsurancePolicy_Autos]
    FOREIGN KEY ([AutoId])
    REFERENCES [dbo].[Autos]
        ([AutoId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InsurancePolicy_Autos'
CREATE INDEX [IX_FK_InsurancePolicy_Autos]
ON [dbo].[InsurancePolicies]
    ([AutoId]);
GO

-- Creating foreign key on [CompanyId] in table 'InsurancePolicies'
ALTER TABLE [dbo].[InsurancePolicies]
ADD CONSTRAINT [FK_InsuarancePolicy_Companies]
    FOREIGN KEY ([CompanyId])
    REFERENCES [dbo].[Companies]
        ([CompanyId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InsuarancePolicy_Companies'
CREATE INDEX [IX_FK_InsuarancePolicy_Companies]
ON [dbo].[InsurancePolicies]
    ([CompanyId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------