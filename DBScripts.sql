CREATE DATABASE [HDICASESAMPLE]
GO
USE [HDICASESAMPLE]
GO
/****** Object:  Table [dbo].[Contracts]    Script Date: 10/27/2024 11:04:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contracts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PartnerId] [bigint] NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[Count] [bigint] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[ActiveFlg] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Contracts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partners]    Script Date: 10/27/2024 11:04:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partners](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[ActiveFlg] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Partners] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 10/27/2024 11:04:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[ActiveFlg] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Works]    Script Date: 10/27/2024 11:04:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Works](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PartnerId] [bigint] NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[Date] [datetime] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[ActiveFlg] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Works] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[GetContractResults]    Script Date: 10/27/2024 11:04:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetContractResults] ()
RETURNS TABLE
AS
RETURN
(
    SELECT 
       X.*, CAST(((X.WORKCOUNT * 100) / X.COUNT) AS DECIMAL)  as WORKPERCENT
    FROM(
        SELECT 
            C.Id,
            P.Name AS PartnerName, PR.Name AS ProductName, 
            C.Price, C.StartDate, C.EndDate, C.CreateDate, C.UpdateDate, C.ActiveFlg, C.Count,
            (SELECT CAST(COUNT(*) AS BIGINT)  FROM WORKS W 
             WHERE W.PartnerId = C.PartnerId 
                   AND W.ProductId = C.ProductId 
                   AND W.[Date] BETWEEN C.StartDate AND C.EndDate) WORKCOUNT,
            CASE WHEN C.EndDate < SYSDATETIME() THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END EXPIRE
        FROM Contracts C 
        INNER JOIN Products PR ON PR.Id = C.ProductId
        INNER JOIN Partners P  ON P.Id  = C.PartnerId
    ) AS X
);
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 10/27/2024 11:04:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET IDENTITY_INSERT [dbo].[Contracts] ON 

INSERT [dbo].[Contracts] ([Id], [PartnerId], [ProductId], [Count], [Price], [StartDate], [EndDate], [CreateDate], [UpdateDate], [ActiveFlg]) VALUES (1, 1, 1, 5, CAST(200.00 AS Decimal(18, 2)), CAST(N'2024-10-01T16:21:52.000' AS DateTime), CAST(N'2024-10-31T16:21:52.000' AS DateTime), CAST(N'2024-10-27T19:22:15.997' AS DateTime), NULL, 1)
INSERT [dbo].[Contracts] ([Id], [PartnerId], [ProductId], [Count], [Price], [StartDate], [EndDate], [CreateDate], [UpdateDate], [ActiveFlg]) VALUES (2, 1, 2, 10, CAST(500.00 AS Decimal(18, 2)), CAST(N'2024-10-01T16:21:52.000' AS DateTime), CAST(N'2024-10-31T16:21:52.000' AS DateTime), CAST(N'2024-10-27T19:22:33.643' AS DateTime), NULL, 1)
INSERT [dbo].[Contracts] ([Id], [PartnerId], [ProductId], [Count], [Price], [StartDate], [EndDate], [CreateDate], [UpdateDate], [ActiveFlg]) VALUES (3, 2, 2, 5, CAST(500.00 AS Decimal(18, 2)), CAST(N'2024-10-01T16:21:52.000' AS DateTime), CAST(N'2024-10-31T16:21:52.000' AS DateTime), CAST(N'2024-10-27T19:22:48.077' AS DateTime), NULL, 1)
INSERT [dbo].[Contracts] ([Id], [PartnerId], [ProductId], [Count], [Price], [StartDate], [EndDate], [CreateDate], [UpdateDate], [ActiveFlg]) VALUES (4, 3, 3, 15, CAST(100.00 AS Decimal(18, 2)), CAST(N'2024-10-01T16:21:52.000' AS DateTime), CAST(N'2024-10-31T16:21:52.000' AS DateTime), CAST(N'2024-10-27T19:23:05.350' AS DateTime), NULL, 1)
INSERT [dbo].[Contracts] ([Id], [PartnerId], [ProductId], [Count], [Price], [StartDate], [EndDate], [CreateDate], [UpdateDate], [ActiveFlg]) VALUES (5, 1, 2, 5, CAST(500.00 AS Decimal(18, 2)), CAST(N'2024-09-01T19:31:08.000' AS DateTime), CAST(N'2024-09-30T19:31:08.000' AS DateTime), CAST(N'2024-10-27T22:31:30.183' AS DateTime), NULL, 1)
INSERT [dbo].[Contracts] ([Id], [PartnerId], [ProductId], [Count], [Price], [StartDate], [EndDate], [CreateDate], [UpdateDate], [ActiveFlg]) VALUES (8, 3, 1, 5, CAST(200.00 AS Decimal(18, 2)), CAST(N'2024-06-01T19:44:01.000' AS DateTime), CAST(N'2024-06-30T19:44:01.000' AS DateTime), CAST(N'2024-10-27T22:44:49.373' AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[Contracts] OFF
GO
SET IDENTITY_INSERT [dbo].[Partners] ON 

INSERT [dbo].[Partners] ([Id], [Name], [CreateDate], [UpdateDate], [ActiveFlg]) VALUES (1, N'Servis 1', CAST(N'2024-10-27T19:21:04.530' AS DateTime), NULL, 1)
INSERT [dbo].[Partners] ([Id], [Name], [CreateDate], [UpdateDate], [ActiveFlg]) VALUES (2, N'Servis 2', CAST(N'2024-10-27T19:21:08.897' AS DateTime), NULL, 1)
INSERT [dbo].[Partners] ([Id], [Name], [CreateDate], [UpdateDate], [ActiveFlg]) VALUES (3, N'Servis 3', CAST(N'2024-10-27T19:21:13.037' AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[Partners] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [CreateDate], [UpdateDate], [ActiveFlg]) VALUES (1, N'Cam Servisi', CAST(N'2024-10-27T19:21:32.863' AS DateTime), NULL, 1)
INSERT [dbo].[Products] ([Id], [Name], [CreateDate], [UpdateDate], [ActiveFlg]) VALUES (2, N'Kaporta Tamiri', CAST(N'2024-10-27T19:21:41.597' AS DateTime), NULL, 1)
INSERT [dbo].[Products] ([Id], [Name], [CreateDate], [UpdateDate], [ActiveFlg]) VALUES (3, N'Lastik', CAST(N'2024-10-27T19:21:48.087' AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Works] ON 

INSERT [dbo].[Works] ([Id], [PartnerId], [ProductId], [Date], [CreateDate], [UpdateDate], [ActiveFlg]) VALUES (1, 1, 1, CAST(N'2024-10-02T00:00:00.000' AS DateTime), CAST(N'2024-10-27T19:53:41.533' AS DateTime), NULL, 1)
INSERT [dbo].[Works] ([Id], [PartnerId], [ProductId], [Date], [CreateDate], [UpdateDate], [ActiveFlg]) VALUES (2, 1, 2, CAST(N'2024-10-10T00:00:00.000' AS DateTime), CAST(N'2024-10-27T19:53:49.547' AS DateTime), NULL, 1)
INSERT [dbo].[Works] ([Id], [PartnerId], [ProductId], [Date], [CreateDate], [UpdateDate], [ActiveFlg]) VALUES (3, 1, 1, CAST(N'2024-08-10T00:00:00.000' AS DateTime), CAST(N'2024-10-27T20:03:48.427' AS DateTime), NULL, 1)
INSERT [dbo].[Works] ([Id], [PartnerId], [ProductId], [Date], [CreateDate], [UpdateDate], [ActiveFlg]) VALUES (4, 1, 1, CAST(N'2024-08-10T00:00:00.000' AS DateTime), CAST(N'2024-10-27T20:04:07.830' AS DateTime), NULL, 1)
INSERT [dbo].[Works] ([Id], [PartnerId], [ProductId], [Date], [CreateDate], [UpdateDate], [ActiveFlg]) VALUES (5, 2, 2, CAST(N'2024-10-23T00:00:00.000' AS DateTime), CAST(N'2024-10-27T20:31:02.117' AS DateTime), NULL, 1)
INSERT [dbo].[Works] ([Id], [PartnerId], [ProductId], [Date], [CreateDate], [UpdateDate], [ActiveFlg]) VALUES (6, 2, 2, CAST(N'2024-10-23T00:00:00.000' AS DateTime), CAST(N'2024-10-27T20:31:10.483' AS DateTime), NULL, 1)
INSERT [dbo].[Works] ([Id], [PartnerId], [ProductId], [Date], [CreateDate], [UpdateDate], [ActiveFlg]) VALUES (7, 3, 3, CAST(N'2024-10-15T00:00:00.000' AS DateTime), CAST(N'2024-10-27T20:31:28.970' AS DateTime), NULL, 1)
INSERT [dbo].[Works] ([Id], [PartnerId], [ProductId], [Date], [CreateDate], [UpdateDate], [ActiveFlg]) VALUES (8, 3, 3, CAST(N'2024-10-17T00:00:00.000' AS DateTime), CAST(N'2024-10-27T20:31:35.403' AS DateTime), NULL, 1)
INSERT [dbo].[Works] ([Id], [PartnerId], [ProductId], [Date], [CreateDate], [UpdateDate], [ActiveFlg]) VALUES (9, 3, 3, CAST(N'2024-10-18T00:00:00.000' AS DateTime), CAST(N'2024-10-27T20:32:10.040' AS DateTime), NULL, 1)
INSERT [dbo].[Works] ([Id], [PartnerId], [ProductId], [Date], [CreateDate], [UpdateDate], [ActiveFlg]) VALUES (10, 3, 3, CAST(N'2024-10-15T00:00:00.000' AS DateTime), CAST(N'2024-10-27T20:48:07.847' AS DateTime), NULL, 1)
INSERT [dbo].[Works] ([Id], [PartnerId], [ProductId], [Date], [CreateDate], [UpdateDate], [ActiveFlg]) VALUES (11, 1, 2, CAST(N'2024-09-11T00:00:00.000' AS DateTime), CAST(N'2024-10-27T22:32:42.550' AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[Works] OFF
GO
/****** Object:  Index [IX_PartnerId]    Script Date: 10/27/2024 11:04:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_PartnerId] ON [dbo].[Contracts]
(
	[PartnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductId]    Script Date: 10/27/2024 11:04:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[Contracts]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PartnerId]    Script Date: 10/27/2024 11:04:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_PartnerId] ON [dbo].[Works]
(
	[PartnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductId]    Script Date: 10/27/2024 11:04:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[Works]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contracts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Contracts_dbo.Partners_PartnerId] FOREIGN KEY([PartnerId])
REFERENCES [dbo].[Partners] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Contracts] CHECK CONSTRAINT [FK_dbo.Contracts_dbo.Partners_PartnerId]
GO
ALTER TABLE [dbo].[Contracts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Contracts_dbo.Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Contracts] CHECK CONSTRAINT [FK_dbo.Contracts_dbo.Products_ProductId]
GO
ALTER TABLE [dbo].[Works]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Works_dbo.Partners_PartnerId] FOREIGN KEY([PartnerId])
REFERENCES [dbo].[Partners] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Works] CHECK CONSTRAINT [FK_dbo.Works_dbo.Partners_PartnerId]
GO
ALTER TABLE [dbo].[Works]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Works_dbo.Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Works] CHECK CONSTRAINT [FK_dbo.Works_dbo.Products_ProductId]
GO
USE [master]
GO
ALTER DATABASE [HDICASESAMPLE] SET  READ_WRITE 
GO
