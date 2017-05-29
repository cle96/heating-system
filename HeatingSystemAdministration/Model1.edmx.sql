
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/29/2017 15:38:25
-- Generated from EDMX file: C:\Users\Cristian\Source\Repos\exam-heating-system\HeatingSystemAdministration\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [localStorage];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Meters'
CREATE TABLE [dbo].[Meters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Customer_Id] int  NOT NULL
);
GO

-- Creating table 'MeterReadings'
CREATE TABLE [dbo].[MeterReadings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [kWh] float  NOT NULL,
    [CubeMeters] float  NOT NULL,
    [UsageHours] float  NOT NULL,
    [Year] datetime  NOT NULL,
    [Meter_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Meters'
ALTER TABLE [dbo].[Meters]
ADD CONSTRAINT [PK_Meters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MeterReadings'
ALTER TABLE [dbo].[MeterReadings]
ADD CONSTRAINT [PK_MeterReadings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Customer_Id] in table 'Meters'
ALTER TABLE [dbo].[Meters]
ADD CONSTRAINT [FK_CustomerMeter]
    FOREIGN KEY ([Customer_Id])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerMeter'
CREATE INDEX [IX_FK_CustomerMeter]
ON [dbo].[Meters]
    ([Customer_Id]);
GO

-- Creating foreign key on [Meter_Id] in table 'MeterReadings'
ALTER TABLE [dbo].[MeterReadings]
ADD CONSTRAINT [FK_MeterMeterReading]
    FOREIGN KEY ([Meter_Id])
    REFERENCES [dbo].[Meters]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MeterMeterReading'
CREATE INDEX [IX_FK_MeterMeterReading]
ON [dbo].[MeterReadings]
    ([Meter_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------