
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/07/2023 11:26:09
-- Generated from EDMX file: C:\Users\Melisa\Desktop\uygulamalar\OkulBilgiİslem\OkulBilgiİslem\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [OkulBilgi];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[OgrenciSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OgrenciSet];
GO
IF OBJECT_ID(N'[dbo].[VeliSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VeliSet];
GO
IF OBJECT_ID(N'[dbo].[KullaniciSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KullaniciSet];
GO
IF OBJECT_ID(N'[dbo].[OdevSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OdevSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'OgrenciSet'
CREATE TABLE [dbo].[OgrenciSet] (
    [OgrenciNo] int IDENTITY(1,1) NOT NULL,
    [OgrenciAdiSoyadi] nvarchar(max)  NOT NULL,
    [Sinifi] nvarchar(max)  NOT NULL,
    [Bolumu] nvarchar(max)  NOT NULL,
    [Adresi] nvarchar(max)  NOT NULL,
    [Telefon] nvarchar(max)  NOT NULL,
    [OkulNo] nvarchar(max)  NOT NULL,
    [VeliNo] int  NOT NULL
);
GO

-- Creating table 'VeliSet'
CREATE TABLE [dbo].[VeliSet] (
    [VeliNo] int IDENTITY(1,1) NOT NULL,
    [VeliAdiSoyadi] nvarchar(max)  NOT NULL,
    [Yakinlik] nvarchar(max)  NOT NULL,
    [Adres] nvarchar(max)  NOT NULL,
    [Telefon] nvarchar(max)  NOT NULL,
    [EgitimDurumu] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'KullaniciSet'
CREATE TABLE [dbo].[KullaniciSet] (
    [KullaniciNo] int IDENTITY(1,1) NOT NULL,
    [KullaniciAdi] nvarchar(max)  NOT NULL,
    [Sifre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OdevSet'
CREATE TABLE [dbo].[OdevSet] (
    [OdevNo] int IDENTITY(1,1) NOT NULL,
    [OgrenciAdiSoyadi] nvarchar(max)  NOT NULL,
    [Sinifi] nvarchar(max)  NOT NULL,
    [Bolumu] nvarchar(max)  NOT NULL,
    [Ders] nvarchar(max)  NOT NULL,
    [Konu] nvarchar(max)  NOT NULL,
    [VerilisTarihi] nvarchar(max)  NOT NULL,
    [TeslimTarihi] nvarchar(max)  NOT NULL,
    [Notu] nvarchar(max)  NOT NULL,
    [OgrenciNo] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [OgrenciNo] in table 'OgrenciSet'
ALTER TABLE [dbo].[OgrenciSet]
ADD CONSTRAINT [PK_OgrenciSet]
    PRIMARY KEY CLUSTERED ([OgrenciNo] ASC);
GO

-- Creating primary key on [VeliNo] in table 'VeliSet'
ALTER TABLE [dbo].[VeliSet]
ADD CONSTRAINT [PK_VeliSet]
    PRIMARY KEY CLUSTERED ([VeliNo] ASC);
GO

-- Creating primary key on [KullaniciNo] in table 'KullaniciSet'
ALTER TABLE [dbo].[KullaniciSet]
ADD CONSTRAINT [PK_KullaniciSet]
    PRIMARY KEY CLUSTERED ([KullaniciNo] ASC);
GO

-- Creating primary key on [OdevNo] in table 'OdevSet'
ALTER TABLE [dbo].[OdevSet]
ADD CONSTRAINT [PK_OdevSet]
    PRIMARY KEY CLUSTERED ([OdevNo] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [VeliNo] in table 'OgrenciSet'
ALTER TABLE [dbo].[OgrenciSet]
ADD CONSTRAINT [FK_VeliOgrenci]
    FOREIGN KEY ([VeliNo])
    REFERENCES [dbo].[VeliSet]
        ([VeliNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VeliOgrenci'
CREATE INDEX [IX_FK_VeliOgrenci]
ON [dbo].[OgrenciSet]
    ([VeliNo]);
GO

-- Creating foreign key on [OgrenciNo] in table 'OdevSet'
ALTER TABLE [dbo].[OdevSet]
ADD CONSTRAINT [FK_OgrenciOdev]
    FOREIGN KEY ([OgrenciNo])
    REFERENCES [dbo].[OgrenciSet]
        ([OgrenciNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OgrenciOdev'
CREATE INDEX [IX_FK_OgrenciOdev]
ON [dbo].[OdevSet]
    ([OgrenciNo]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------