
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 12/26/2012 19:18:23
-- Generated from EDMX file: D:\Windows Applications\DotNet\AHPL\DataTier\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AHPL_DB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Global_CustomersCustomer_Attachments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Customer_Attachments] DROP CONSTRAINT [FK_Global_CustomersCustomer_Attachments];
GO
IF OBJECT_ID(N'[dbo].[FK_ShopShop_Details]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Shop_Details] DROP CONSTRAINT [FK_ShopShop_Details];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Attachments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Attachments];
GO
IF OBJECT_ID(N'[dbo].[Companies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Companies];
GO
IF OBJECT_ID(N'[dbo].[Contracts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contracts];
GO
IF OBJECT_ID(N'[dbo].[Customer_Attachments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customer_Attachments];
GO
IF OBJECT_ID(N'[dbo].[Customer_Profiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customer_Profiles];
GO
IF OBJECT_ID(N'[dbo].[Default_E_Rates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Default_E_Rates];
GO
IF OBJECT_ID(N'[dbo].[Default_R_Rates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Default_R_Rates];
GO
IF OBJECT_ID(N'[dbo].[Default_TaxRates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Default_TaxRates];
GO
IF OBJECT_ID(N'[AHPL_DBModelStoreContainer].[Default_W_Rates]', 'U') IS NOT NULL
    DROP TABLE [AHPL_DBModelStoreContainer].[Default_W_Rates];
GO
IF OBJECT_ID(N'[dbo].[ElectricityRate_Profiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ElectricityRate_Profiles];
GO
IF OBJECT_ID(N'[dbo].[Extended_Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Extended_Customers];
GO
IF OBJECT_ID(N'[dbo].[Floor_Levels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Floor_Levels];
GO
IF OBJECT_ID(N'[dbo].[Global_Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Global_Customers];
GO
IF OBJECT_ID(N'[dbo].[Locations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Locations];
GO
IF OBJECT_ID(N'[dbo].[Master_Electricity_Rates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Master_Electricity_Rates];
GO
IF OBJECT_ID(N'[dbo].[Master_Water_Rates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Master_Water_Rates];
GO
IF OBJECT_ID(N'[dbo].[Rental_Rates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rental_Rates];
GO
IF OBJECT_ID(N'[dbo].[Shop_Details]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Shop_Details];
GO
IF OBJECT_ID(N'[dbo].[Shops]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Shops];
GO
IF OBJECT_ID(N'[dbo].[Taxes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Taxes];
GO
IF OBJECT_ID(N'[dbo].[TaxRates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaxRates];
GO
IF OBJECT_ID(N'[dbo].[VAT_Rates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VAT_Rates];
GO
IF OBJECT_ID(N'[dbo].[WaterRate_Profiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WaterRate_Profiles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Attachments'
CREATE TABLE [dbo].[Attachments] (
    [AttachmentID] int IDENTITY(1,1) NOT NULL,
    [AttachmentName] varchar(100)  NULL
);
GO

-- Creating table 'Customer_Attachments'
CREATE TABLE [dbo].[Customer_Attachments] (
    [CustAttachmentID] int IDENTITY(1,1) NOT NULL,
    [AttachmentID] int  NULL,
    [Remarks] nvarchar(max)  NULL,
    [CustomerID] int  NOT NULL,
    [AttachedDocument] varbinary(max)  NULL
);
GO

-- Creating table 'Extended_Customers'
CREATE TABLE [dbo].[Extended_Customers] (
    [ExtendedCustomerID] int IDENTITY(1,1) NOT NULL,
    [CompanyID] int  NOT NULL,
    [LocationID] int  NOT NULL,
    [EmailAddress] nvarchar(50)  NULL,
    [SAPAlternateCode] nvarchar(10)  NOT NULL,
    [CustomerID] int  NOT NULL,
    [Remarks] nvarchar(max)  NULL
);
GO

-- Creating table 'Global_Customers'
CREATE TABLE [dbo].[Global_Customers] (
    [CustomerID] int IDENTITY(1,1) NOT NULL,
    [CustomerName] nvarchar(50)  NOT NULL,
    [CompanyAddress] nvarchar(70)  NULL,
    [TelNos] nvarchar(50)  NULL,
    [FaxNos] nvarchar(50)  NULL,
    [EmailAddress] nvarchar(50)  NULL,
    [RegNo] nvarchar(20)  NULL,
    [VATRegNo] nvarchar(50)  NULL,
    [MajShareName] nvarchar(50)  NULL,
    [YearOfInc] int  NULL,
    [NameOfPrinciple] nvarchar(50)  NULL,
    [PaidUpShareCapital] decimal(10,2)  NULL,
    [AuthShareCaptial] decimal(10,2)  NULL,
    [CreatedBy] int  NULL,
    [CreatedDate] datetime  NULL,
    [UpdatedBy] int  NULL,
    [UpdatedDate] datetime  NULL,
    [SAPCustomerCode] nvarchar(20)  NULL
);
GO

-- Creating table 'Companies'
CREATE TABLE [dbo].[Companies] (
    [CompanyID] int IDENTITY(1,1) NOT NULL,
    [CompanyCode] nvarchar(20)  NULL,
    [CompanyName] nvarchar(50)  NULL,
    [LocationID] int  NOT NULL
);
GO

-- Creating table 'Locations'
CREATE TABLE [dbo].[Locations] (
    [LocationID] int IDENTITY(1,1) NOT NULL,
    [LocationName] nvarchar(50)  NULL,
    [Address] nvarchar(70)  NULL,
    [LocationCode] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'Floor_Levels'
CREATE TABLE [dbo].[Floor_Levels] (
    [LevelID] int IDENTITY(1,1) NOT NULL,
    [LevelCode] nvarchar(20)  NOT NULL,
    [LevelName] nvarchar(50)  NULL,
    [LocationID] int  NOT NULL
);
GO

-- Creating table 'ElectricityRate_Profiles'
CREATE TABLE [dbo].[ElectricityRate_Profiles] (
    [ElectricityProfileID] int IDENTITY(1,1) NOT NULL,
    [ElectricityRateProfileCode] nvarchar(20)  NOT NULL,
    [ElectricityRateProfileName] nvarchar(50)  NULL,
    [VatActivated] bit  NOT NULL,
    [VatID] int  NOT NULL
);
GO

-- Creating table 'Master_Electricity_Rates'
CREATE TABLE [dbo].[Master_Electricity_Rates] (
    [ElectricityRatesID] int IDENTITY(1,1) NOT NULL,
    [UnitRate] decimal(10,2)  NOT NULL,
    [ProfileID] int  NOT NULL,
    [IsDefualt] bit  NOT NULL
);
GO

-- Creating table 'Master_Water_Rates'
CREATE TABLE [dbo].[Master_Water_Rates] (
    [WaterRateID] int IDENTITY(1,1) NOT NULL,
    [UnitRate] decimal(8,2)  NOT NULL,
    [IsDefault] bit  NOT NULL,
    [ProfileID] int  NOT NULL
);
GO

-- Creating table 'WaterRate_Profiles'
CREATE TABLE [dbo].[WaterRate_Profiles] (
    [WaterProfileID] int IDENTITY(1,1) NOT NULL,
    [WaterRateProfileCode] nvarchar(20)  NULL,
    [WaterRateProfileName] nvarchar(50)  NULL,
    [VatActivated] bit  NOT NULL,
    [VatID] int  NOT NULL
);
GO

-- Creating table 'Shops'
CREATE TABLE [dbo].[Shops] (
    [ShopID] int IDENTITY(1,1) NOT NULL,
    [ShopName] nvarchar(20)  NOT NULL,
    [LevelID] int  NOT NULL,
    [LocationID] int  NOT NULL,
    [CompanyID] int  NOT NULL,
    [CustomerID] int  NOT NULL
);
GO

-- Creating table 'Contracts'
CREATE TABLE [dbo].[Contracts] (
    [ContractID] int IDENTITY(1,1) NOT NULL,
    [LocationID] int  NOT NULL,
    [CompanyID] int  NOT NULL,
    [CustomerID] int  NOT NULL,
    [ShopID] int  NOT NULL,
    [LevelID] int  NOT NULL,
    [RentPerSqFt] decimal(10,2)  NOT NULL,
    [SCPerSqFt] decimal(10,2)  NOT NULL,
    [VATRate] decimal(10,2)  NOT NULL,
    [VATAmount] decimal(10,2)  NOT NULL,
    [Deposit] decimal(10,2)  NOT NULL,
    [RentPerMonth] decimal(10,2)  NOT NULL,
    [AreaInSqFt] decimal(10,2)  NOT NULL,
    [SCPerMonth] decimal(10,2)  NOT NULL,
    [RentWithSCPerMonth] decimal(10,2)  NOT NULL,
    [RentWithSCWithVatPerMonth] decimal(10,2)  NOT NULL,
    [TaxAmount] decimal(10,2)  NOT NULL,
    [Period] int  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [AgreementNo] nvarchar(20)  NOT NULL,
    [AgreementSignDate] datetime  NOT NULL,
    [Remarks] nvarchar(max)  NULL,
    [IsActive] bit  NOT NULL,
    [IsRenew] bit  NOT NULL,
    [RenewDate] datetime  NULL,
    [RentWIthSCPerSqFt] decimal(10,2)  NOT NULL,
    [TotalRentPerMonth] decimal(10,2)  NOT NULL
);
GO

-- Creating table 'Rental_Rates'
CREATE TABLE [dbo].[Rental_Rates] (
    [RentalRateID] int  NOT NULL,
    [LocationID] int  NOT NULL,
    [LevelID] int  NOT NULL,
    [RentPerSqFt] decimal(10,2)  NULL,
    [RentalRateName] nvarchar(50)  NULL,
    [Remarks] nvarchar(max)  NULL,
    [SCperSqFt] decimal(10,2)  NULL
);
GO

-- Creating table 'Customer_Profiles'
CREATE TABLE [dbo].[Customer_Profiles] (
    [CustomerProfileID] int IDENTITY(1,1) NOT NULL,
    [CustomerID] int  NOT NULL,
    [ExtendedCustomerID] int  NOT NULL,
    [ElectricitiyProfileID] int  NOT NULL,
    [WaterProfileID] int  NOT NULL,
    [RentalRateID] int  NOT NULL,
    [IsVATActive] bit  NOT NULL,
    [IsTaxActive] bit  NOT NULL
);
GO

-- Creating table 'Shop_Details'
CREATE TABLE [dbo].[Shop_Details] (
    [ShopDetailID] int IDENTITY(1,1) NOT NULL,
    [ShopID] int  NOT NULL,
    [ShopNo] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'VAT_Rates'
CREATE TABLE [dbo].[VAT_Rates] (
    [VatID] int IDENTITY(1,1) NOT NULL,
    [VatRate] decimal(10,2)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [ActiveFrom] datetime  NOT NULL,
    [ActiveTo] datetime  NULL
);
GO

-- Creating table 'Taxes'
CREATE TABLE [dbo].[Taxes] (
    [TaxID] int IDENTITY(1,1) NOT NULL,
    [TaxName] nvarchar(20)  NULL,
    [TaxCode] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'TaxRates'
CREATE TABLE [dbo].[TaxRates] (
    [TaxRateID] int IDENTITY(1,1) NOT NULL,
    [TaxID] int  NOT NULL,
    [TaxRate1] decimal(8,3)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [ActiveFrom] datetime  NOT NULL,
    [ActiveTo] datetime  NULL
);
GO

-- Creating table 'Default_E_Rates'
CREATE TABLE [dbo].[Default_E_Rates] (
    [Default_ERateID] int IDENTITY(1,1) NOT NULL,
    [ExtendedCustomerID] int  NOT NULL,
    [ElectricityRateID] int  NOT NULL
);
GO

-- Creating table 'Default_R_Rates'
CREATE TABLE [dbo].[Default_R_Rates] (
    [Default_RRateID] int IDENTITY(1,1) NOT NULL,
    [ExtendedCustomerID] int  NOT NULL,
    [RentalRateID] int  NOT NULL
);
GO

-- Creating table 'Default_TaxRates'
CREATE TABLE [dbo].[Default_TaxRates] (
    [Default_TaxRateID] int IDENTITY(1,1) NOT NULL,
    [Default_EWR_RateID] int  NOT NULL,
    [TaxRateID] int  NOT NULL
);
GO

-- Creating table 'Default_W_Rates'
CREATE TABLE [dbo].[Default_W_Rates] (
    [Default_WRateID] int IDENTITY(1,1) NOT NULL,
    [ExtendedCustomerID] int  NOT NULL,
    [WaterRateID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AttachmentID] in table 'Attachments'
ALTER TABLE [dbo].[Attachments]
ADD CONSTRAINT [PK_Attachments]
    PRIMARY KEY CLUSTERED ([AttachmentID] ASC);
GO

-- Creating primary key on [CustAttachmentID] in table 'Customer_Attachments'
ALTER TABLE [dbo].[Customer_Attachments]
ADD CONSTRAINT [PK_Customer_Attachments]
    PRIMARY KEY CLUSTERED ([CustAttachmentID] ASC);
GO

-- Creating primary key on [ExtendedCustomerID] in table 'Extended_Customers'
ALTER TABLE [dbo].[Extended_Customers]
ADD CONSTRAINT [PK_Extended_Customers]
    PRIMARY KEY CLUSTERED ([ExtendedCustomerID] ASC);
GO

-- Creating primary key on [CustomerID] in table 'Global_Customers'
ALTER TABLE [dbo].[Global_Customers]
ADD CONSTRAINT [PK_Global_Customers]
    PRIMARY KEY CLUSTERED ([CustomerID] ASC);
GO

-- Creating primary key on [CompanyID] in table 'Companies'
ALTER TABLE [dbo].[Companies]
ADD CONSTRAINT [PK_Companies]
    PRIMARY KEY CLUSTERED ([CompanyID] ASC);
GO

-- Creating primary key on [LocationID] in table 'Locations'
ALTER TABLE [dbo].[Locations]
ADD CONSTRAINT [PK_Locations]
    PRIMARY KEY CLUSTERED ([LocationID] ASC);
GO

-- Creating primary key on [LevelID] in table 'Floor_Levels'
ALTER TABLE [dbo].[Floor_Levels]
ADD CONSTRAINT [PK_Floor_Levels]
    PRIMARY KEY CLUSTERED ([LevelID] ASC);
GO

-- Creating primary key on [ElectricityProfileID] in table 'ElectricityRate_Profiles'
ALTER TABLE [dbo].[ElectricityRate_Profiles]
ADD CONSTRAINT [PK_ElectricityRate_Profiles]
    PRIMARY KEY CLUSTERED ([ElectricityProfileID] ASC);
GO

-- Creating primary key on [ElectricityRatesID] in table 'Master_Electricity_Rates'
ALTER TABLE [dbo].[Master_Electricity_Rates]
ADD CONSTRAINT [PK_Master_Electricity_Rates]
    PRIMARY KEY CLUSTERED ([ElectricityRatesID] ASC);
GO

-- Creating primary key on [WaterRateID] in table 'Master_Water_Rates'
ALTER TABLE [dbo].[Master_Water_Rates]
ADD CONSTRAINT [PK_Master_Water_Rates]
    PRIMARY KEY CLUSTERED ([WaterRateID] ASC);
GO

-- Creating primary key on [WaterProfileID] in table 'WaterRate_Profiles'
ALTER TABLE [dbo].[WaterRate_Profiles]
ADD CONSTRAINT [PK_WaterRate_Profiles]
    PRIMARY KEY CLUSTERED ([WaterProfileID] ASC);
GO

-- Creating primary key on [ShopID] in table 'Shops'
ALTER TABLE [dbo].[Shops]
ADD CONSTRAINT [PK_Shops]
    PRIMARY KEY CLUSTERED ([ShopID] ASC);
GO

-- Creating primary key on [ContractID] in table 'Contracts'
ALTER TABLE [dbo].[Contracts]
ADD CONSTRAINT [PK_Contracts]
    PRIMARY KEY CLUSTERED ([ContractID] ASC);
GO

-- Creating primary key on [RentalRateID] in table 'Rental_Rates'
ALTER TABLE [dbo].[Rental_Rates]
ADD CONSTRAINT [PK_Rental_Rates]
    PRIMARY KEY CLUSTERED ([RentalRateID] ASC);
GO

-- Creating primary key on [CustomerProfileID] in table 'Customer_Profiles'
ALTER TABLE [dbo].[Customer_Profiles]
ADD CONSTRAINT [PK_Customer_Profiles]
    PRIMARY KEY CLUSTERED ([CustomerProfileID] ASC);
GO

-- Creating primary key on [ShopDetailID] in table 'Shop_Details'
ALTER TABLE [dbo].[Shop_Details]
ADD CONSTRAINT [PK_Shop_Details]
    PRIMARY KEY CLUSTERED ([ShopDetailID] ASC);
GO

-- Creating primary key on [VatID] in table 'VAT_Rates'
ALTER TABLE [dbo].[VAT_Rates]
ADD CONSTRAINT [PK_VAT_Rates]
    PRIMARY KEY CLUSTERED ([VatID] ASC);
GO

-- Creating primary key on [TaxID] in table 'Taxes'
ALTER TABLE [dbo].[Taxes]
ADD CONSTRAINT [PK_Taxes]
    PRIMARY KEY CLUSTERED ([TaxID] ASC);
GO

-- Creating primary key on [TaxRateID] in table 'TaxRates'
ALTER TABLE [dbo].[TaxRates]
ADD CONSTRAINT [PK_TaxRates]
    PRIMARY KEY CLUSTERED ([TaxRateID] ASC);
GO

-- Creating primary key on [Default_ERateID] in table 'Default_E_Rates'
ALTER TABLE [dbo].[Default_E_Rates]
ADD CONSTRAINT [PK_Default_E_Rates]
    PRIMARY KEY CLUSTERED ([Default_ERateID] ASC);
GO

-- Creating primary key on [Default_RRateID] in table 'Default_R_Rates'
ALTER TABLE [dbo].[Default_R_Rates]
ADD CONSTRAINT [PK_Default_R_Rates]
    PRIMARY KEY CLUSTERED ([Default_RRateID] ASC);
GO

-- Creating primary key on [Default_TaxRateID] in table 'Default_TaxRates'
ALTER TABLE [dbo].[Default_TaxRates]
ADD CONSTRAINT [PK_Default_TaxRates]
    PRIMARY KEY CLUSTERED ([Default_TaxRateID] ASC);
GO

-- Creating primary key on [Default_WRateID], [ExtendedCustomerID], [WaterRateID] in table 'Default_W_Rates'
ALTER TABLE [dbo].[Default_W_Rates]
ADD CONSTRAINT [PK_Default_W_Rates]
    PRIMARY KEY CLUSTERED ([Default_WRateID], [ExtendedCustomerID], [WaterRateID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerID] in table 'Customer_Attachments'
ALTER TABLE [dbo].[Customer_Attachments]
ADD CONSTRAINT [FK_Global_CustomersCustomer_Attachments]
    FOREIGN KEY ([CustomerID])
    REFERENCES [dbo].[Global_Customers]
        ([CustomerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Global_CustomersCustomer_Attachments'
CREATE INDEX [IX_FK_Global_CustomersCustomer_Attachments]
ON [dbo].[Customer_Attachments]
    ([CustomerID]);
GO

-- Creating foreign key on [ShopID] in table 'Shop_Details'
ALTER TABLE [dbo].[Shop_Details]
ADD CONSTRAINT [FK_ShopShop_Details]
    FOREIGN KEY ([ShopID])
    REFERENCES [dbo].[Shops]
        ([ShopID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ShopShop_Details'
CREATE INDEX [IX_FK_ShopShop_Details]
ON [dbo].[Shop_Details]
    ([ShopID]);
GO

-- Creating foreign key on [TaxID] in table 'TaxRates'
ALTER TABLE [dbo].[TaxRates]
ADD CONSTRAINT [FK_TaxTaxRate]
    FOREIGN KEY ([TaxID])
    REFERENCES [dbo].[Taxes]
        ([TaxID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TaxTaxRate'
CREATE INDEX [IX_FK_TaxTaxRate]
ON [dbo].[TaxRates]
    ([TaxID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------