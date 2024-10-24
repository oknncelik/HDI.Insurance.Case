CREATE DATABASE HDICASESAMPLE
GO
USE HDICASESAMPLE
GO
--TABLOLAR

--Partnerler
CREATE TABLE Partners(
    Id BIGINT IDENTITY(1,1) PRIMARY KEY,
    [Name] VARCHAR(64),
    CreateDate DATETIME NOT NULL,
    UpdateDate DATETIME,
    ActiveFlg BIT
)
GO

--Ürünler
CREATE TABLE Products(
    Id BIGINT IDENTITY(1,1) PRIMARY KEY,
    [Name] VARCHAR(64),
    CreateDate DATETIME NOT NULL,
    UpdateDate DATETIME,
    ActiveFlg BIT
)
GO

--Anlaşmalar
CREATE TABLE Contracts(
    Id BIGINT IDENTITY(1,1) PRIMARY KEY,
    PartnerId BIGINT FOREIGN KEY REFERENCES Partners(Id),
    ProductId BIGINT FOREIGN KEY REFERENCES Products(Id),
    [Count] INT,
    StartDate DATETIME,
    EndDate DATETIME,
    CreateDate DATETIME NOT NULL,
    UpdateDate DATETIME,
    ActiveFlg BIT
)
GO
--Indexler
CREATE INDEX Partners_INDX1
ON Partner (Id)
GO
CREATE INDEX Products_INDX1
ON Product (Id)
GO
CREATE INDEX Contracts_INDX1
ON Contract (Id)
GO