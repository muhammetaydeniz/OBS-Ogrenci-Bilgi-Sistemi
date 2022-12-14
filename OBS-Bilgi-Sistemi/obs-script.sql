USE [VTYSPROJE]
GO
/****** Object:  Table [dbo].[TBLADMIN]    Script Date: 8.09.2022 10:50:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLADMIN](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[AdminAd] [varchar](20) NULL,
	[AdminSoyAd] [varchar](20) NULL,
	[AdminKullaniciAdi] [varchar](20) NULL,
	[AdminSifre] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBLBOLUMLER]    Script Date: 8.09.2022 10:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLBOLUMLER](
	[BolumID] [int] IDENTITY(1,1) NOT NULL,
	[BolumAd] [varchar](20) NULL,
	[BolumKod] [varchar](5) NULL,
PRIMARY KEY CLUSTERED 
(
	[BolumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBLDERSLER]    Script Date: 8.09.2022 10:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLDERSLER](
	[DersID] [int] IDENTITY(1,1) NOT NULL,
	[BolumID] [int] NULL,
	[OgretmenID] [int] NULL,
	[DersAd] [varchar](20) NULL,
	[DersKod] [varchar](5) NULL,
	[DersTarih] [varchar](20) NULL,
	[DersSınıfı] [tinyint] NULL,
 CONSTRAINT [PK__TBLDERSL__E8B3DE715B7139B3] PRIMARY KEY CLUSTERED 
(
	[DersID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBLDUYURULAR]    Script Date: 8.09.2022 10:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLDUYURULAR](
	[DuyuruID] [int] IDENTITY(1,1) NOT NULL,
	[OgretmenID] [int] NULL,
	[DuyuruMetni] [varchar](200) NULL,
	[DuyuruTarihi] [smalldatetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[DuyuruID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBLNOTLAR]    Script Date: 8.09.2022 10:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLNOTLAR](
	[NotID] [int] IDENTITY(1,1) NOT NULL,
	[DersID] [int] NULL,
	[OgretmenID] [int] NULL,
	[OgrID] [int] NULL,
	[Vize] [int] NULL,
	[Final] [int] NULL,
	[Proje] [int] NULL,
	[Ortalama] [decimal](5, 2) NULL,
	[Durum] [bit] NULL,
	[Devamsizlik] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[NotID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBLOGRDERSPROGRAMI]    Script Date: 8.09.2022 10:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLOGRDERSPROGRAMI](
	[DersProgramID] [int] IDENTITY(1,1) NOT NULL,
	[DersID] [int] NULL,
	[OgrID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[DersProgramID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBLOGRENCI]    Script Date: 8.09.2022 10:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLOGRENCI](
	[OgrID] [int] IDENTITY(1,1) NOT NULL,
	[BolumID] [int] NULL,
	[OgrAd] [varchar](20) NULL,
	[OgrSoyAd] [varchar](20) NULL,
	[OgrTC] [varchar](11) NOT NULL,
	[OgrCinsiyet] [char](1) NULL,
	[OgrDogumTarihi] [date] NULL,
	[OgrKullaniciAdi] [varchar](20) NULL,
	[OgrSifre] [varchar](10) NULL,
 CONSTRAINT [PK__TBLOGREN__5675132EF72E4A91] PRIMARY KEY CLUSTERED 
(
	[OgrID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBLOGRENCISILINMIS]    Script Date: 8.09.2022 10:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLOGRENCISILINMIS](
	[OgrenciSilinmisID] [int] IDENTITY(1,1) NOT NULL,
	[OgrID] [int] NULL,
	[BolumID] [int] NULL,
	[OgrAd] [varchar](20) NULL,
	[OgrSoyAd] [varchar](20) NULL,
	[OgrTC] [varchar](11) NULL,
	[OgrCinsiyet] [char](1) NULL,
	[OgrDogumTarihi] [date] NULL,
	[OgrKullanciAdi] [varchar](20) NULL,
	[OgrSifre] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[OgrenciSilinmisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBLOGRETMEN]    Script Date: 8.09.2022 10:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLOGRETMEN](
	[OgretmenID] [int] IDENTITY(1,1) NOT NULL,
	[BolumID] [int] NULL,
	[OgretmenAd] [varchar](20) NULL,
	[OgretmenSoyAd] [varchar](20) NULL,
	[OgretmenTc] [varchar](11) NULL,
	[OgretmenKullaniciAdi] [varchar](20) NULL,
	[OgretmenSifre] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[OgretmenID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBLSILINMISNOTLAR]    Script Date: 8.09.2022 10:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLSILINMISNOTLAR](
	[SilinmisNotID] [int] IDENTITY(1,1) NOT NULL,
	[DersID] [int] NULL,
	[OgretmenID] [int] NULL,
	[OgrID] [int] NULL,
	[Vize] [int] NULL,
	[Final] [int] NULL,
	[Proje] [int] NULL,
	[Ortalama] [decimal](5, 2) NULL,
	[Durum] [bit] NULL,
	[Devamsizlik] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SilinmisNotID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TBLADMIN] ON 

INSERT [dbo].[TBLADMIN] ([AdminID], [AdminAd], [AdminSoyAd], [AdminKullaniciAdi], [AdminSifre]) VALUES (1, N'Serkan', N'Hünerli', N'ADMİN123', N'0000')
INSERT [dbo].[TBLADMIN] ([AdminID], [AdminAd], [AdminSoyAd], [AdminKullaniciAdi], [AdminSifre]) VALUES (2, N'Berke', N'Yılmaz', N'ADMİN2', N'0000')
SET IDENTITY_INSERT [dbo].[TBLADMIN] OFF
GO
SET IDENTITY_INSERT [dbo].[TBLBOLUMLER] ON 

INSERT [dbo].[TBLBOLUMLER] ([BolumID], [BolumAd], [BolumKod]) VALUES (2, N'BİLGİSAYAR', N'BM')
INSERT [dbo].[TBLBOLUMLER] ([BolumID], [BolumAd], [BolumKod]) VALUES (3, N'MAKİNA', N'MM')
INSERT [dbo].[TBLBOLUMLER] ([BolumID], [BolumAd], [BolumKod]) VALUES (4, N'ELEKTRİK', N'EM')
INSERT [dbo].[TBLBOLUMLER] ([BolumID], [BolumAd], [BolumKod]) VALUES (5, N'İNŞAAT', N'İM')
INSERT [dbo].[TBLBOLUMLER] ([BolumID], [BolumAd], [BolumKod]) VALUES (6, N'MEKATRONİK', N'MKM')
INSERT [dbo].[TBLBOLUMLER] ([BolumID], [BolumAd], [BolumKod]) VALUES (7, N'SOSYAL HİZMET', N'SH')
INSERT [dbo].[TBLBOLUMLER] ([BolumID], [BolumAd], [BolumKod]) VALUES (9, N'TİCARET', N'TCT')
INSERT [dbo].[TBLBOLUMLER] ([BolumID], [BolumAd], [BolumKod]) VALUES (52, N'BİYOMEDİKAL ', N'BİM')
INSERT [dbo].[TBLBOLUMLER] ([BolumID], [BolumAd], [BolumKod]) VALUES (53, N'ÇEVRE M.', N'CM')
INSERT [dbo].[TBLBOLUMLER] ([BolumID], [BolumAd], [BolumKod]) VALUES (54, N'ENDÜSTRİ', N'EDM')
SET IDENTITY_INSERT [dbo].[TBLBOLUMLER] OFF
GO
SET IDENTITY_INSERT [dbo].[TBLDERSLER] ON 

INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (1, 2, 1, N'Bİlgisayar Ağları', N'BM300', N'Pazartesi 17.00', 3)
INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (2, 2, 2, N'Programlama', N'BM201', N'Salı 17.00', 2)
INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (3, 2, 3, N'Veri Tabanı', N'BM302', N'Çarşamba 17.00', 3)
INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (4, 2, 4, N'İşletim Sistemi', N'BM303', N'Perşembe 17.00', 3)
INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (5, 3, 5, N'Makine Giriş', N'MM100', N'Pazartesi 17.00', 1)
INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (6, 2, 1, N'Bilgisayar Giriş', N'BM104', N'Pazartesi 19.00', 1)
INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (8, 2, 10, N'İstatistik', N'BM105', N'Pazartesi 19.00', 1)
INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (9, 2, 1, N'Yapay Zeka', N'BM400', N'Salı 17.00', 4)
INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (10, 2, 2, N'Java Programlama', N'BM401', N'Salı 19.00', 4)
INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (11, 2, 3, N'İşaretler', N'BM304', N'Çarşamba 19.00', 3)
INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (12, 2, 4, N'Ayrık Matematik', N'BM202', N'Cuma 17.00', 2)
INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (13, 3, 11, N'Matematik', N'MM101', N'Pazartesi 17.00', 1)
INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (14, 3, 12, N'Mukavemet', N'MM102', N'Salı 17.00', 1)
INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (15, 3, 13, N'Termodinamik', N'MM200', N'Salı 17.00', 2)
INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (16, 3, 14, N'Malzeme', N'MM201', N'Çarşamba 17.00', 2)
INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (17, 4, 15, N'Isı Transferi', N'MM301', N'Perşembe 17.00', 3)
INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (20, 4, 16, N'Elektirik Devre', N'EM100', N'Pazartesi 17.00', 1)
INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (21, 4, 17, N'Elektirik Giriş', N'EM101', N'Salı 17.00', 1)
INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (22, 4, 18, N'Sayısal Yöntemler', N'EM200', N'Çarşamba 17.00', 2)
INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (23, 4, 19, N'Fizik1', N'EM102', N'Perşembe 17.00', 1)
INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (24, 5, 20, N'Fizik1', N'iM100', N'Pazartesi 17.00', 1)
INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (25, 5, 21, N'Mukavemet', N'İM200', N'Salı 17.00', 2)
INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (26, 5, 22, N'Akışkanlar', N'İM300', N'Çarşamba 17.00', 3)
INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (27, 5, 23, N'Yapı', N'İM401', N'Perşembe 17.00', 4)
INSERT [dbo].[TBLDERSLER] ([DersID], [BolumID], [OgretmenID], [DersAd], [DersKod], [DersTarih], [DersSınıfı]) VALUES (28, 5, 24, N'Çelik', N'İM405', N'Cuma 17.00', 4)
SET IDENTITY_INSERT [dbo].[TBLDERSLER] OFF
GO
SET IDENTITY_INSERT [dbo].[TBLDUYURULAR] ON 

INSERT [dbo].[TBLDUYURULAR] ([DuyuruID], [OgretmenID], [DuyuruMetni], [DuyuruTarihi]) VALUES (1, 1, N'Deneme 1', CAST(N'2020-12-22T22:35:00' AS SmallDateTime))
INSERT [dbo].[TBLDUYURULAR] ([DuyuruID], [OgretmenID], [DuyuruMetni], [DuyuruTarihi]) VALUES (2, 2, N'Deneme 2', CAST(N'2020-12-22T22:35:00' AS SmallDateTime))
INSERT [dbo].[TBLDUYURULAR] ([DuyuruID], [OgretmenID], [DuyuruMetni], [DuyuruTarihi]) VALUES (4, 1, N'deneme 3', CAST(N'2020-12-27T00:00:00' AS SmallDateTime))
INSERT [dbo].[TBLDUYURULAR] ([DuyuruID], [OgretmenID], [DuyuruMetni], [DuyuruTarihi]) VALUES (5, 1, N'Deneme 4', CAST(N'2020-12-27T00:00:00' AS SmallDateTime))
INSERT [dbo].[TBLDUYURULAR] ([DuyuruID], [OgretmenID], [DuyuruMetni], [DuyuruTarihi]) VALUES (6, 1, N'Deneme 5', CAST(N'1900-01-01T00:00:00' AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[TBLDUYURULAR] OFF
GO
SET IDENTITY_INSERT [dbo].[TBLNOTLAR] ON 

INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (77, 1, 1, 1, 100, 100, 100, CAST(100.00 AS Decimal(5, 2)), 0, 5)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (78, 1, 1, 2, 100, 80, 50, CAST(85.00 AS Decimal(5, 2)), 1, 1)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (79, 1, 1, 3, 30, 50, 30, CAST(40.00 AS Decimal(5, 2)), 0, 3)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (80, 1, 1, 4, 80, 70, 65, CAST(73.50 AS Decimal(5, 2)), 0, 5)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (81, 2, 2, 1, 100, 100, 100, CAST(100.00 AS Decimal(5, 2)), 1, 0)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (82, 2, 2, 2, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (83, 2, 2, 3, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (84, 2, 2, 4, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (85, 3, 3, 1, 100, 100, 80, CAST(98.00 AS Decimal(5, 2)), 1, 2)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (86, 3, 3, 2, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (87, 3, 3, 3, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (89, 3, 3, 4, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (90, 1, 1, 18, 100, 50, 21, CAST(67.10 AS Decimal(5, 2)), 1, 2)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (91, 2, 2, 18, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (92, 3, 3, 18, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (93, 1, 1, 19, 50, 100, 10, CAST(71.00 AS Decimal(5, 2)), 0, 5)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (94, 1, 1, 20, 100, 100, 100, CAST(100.00 AS Decimal(5, 2)), 1, 0)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (95, 1, 1, 22, 10, 10, 10, CAST(10.00 AS Decimal(5, 2)), 0, 0)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (96, 1, 1, 24, 100, 75, 80, CAST(85.50 AS Decimal(5, 2)), 1, 1)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (97, 1, 1, 25, 44, 90, 90, CAST(71.60 AS Decimal(5, 2)), 1, 2)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (98, 1, 1, 26, 68, 55, 45, CAST(59.20 AS Decimal(5, 2)), 1, 2)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (99, 2, 2, 19, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (100, 2, 2, 20, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (101, 2, 2, 22, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (102, 2, 2, 24, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (103, 2, 2, 25, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (104, 2, 2, 26, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (105, 3, 3, 19, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (106, 3, 3, 20, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (107, 3, 3, 22, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (108, 3, 3, 24, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (109, 3, 3, 25, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (110, 3, 3, 26, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (111, 4, 4, 1, 100, 100, 100, CAST(100.00 AS Decimal(5, 2)), 1, 1)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (113, 6, 1, 1, 25, 100, 100, CAST(70.00 AS Decimal(5, 2)), 1, 2)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (114, 8, 10, 1, 100, 80, 50, CAST(85.00 AS Decimal(5, 2)), 1, 0)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (115, 9, 1, 1, 60, 50, 50, CAST(54.00 AS Decimal(5, 2)), 1, 1)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (116, 10, 2, 1, 100, 100, 80, CAST(98.00 AS Decimal(5, 2)), 1, 2)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (117, 11, 3, 1, 70, 80, 100, CAST(78.00 AS Decimal(5, 2)), 1, 0)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (118, 12, 4, 1, 80, 100, 100, CAST(92.00 AS Decimal(5, 2)), 1, 1)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (119, 4, 4, 2, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (120, 8, 10, 2, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (121, 6, 1, 2, 100, 11, 100, CAST(55.50 AS Decimal(5, 2)), 1, 1)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (122, 9, 1, 2, 10, 100, 100, CAST(64.00 AS Decimal(5, 2)), 1, 1)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (123, 10, 2, 2, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (124, 11, 3, 2, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (125, 12, 4, 2, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (126, 4, 4, 3, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (127, 8, 10, 3, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (128, 6, 1, 3, 25, 35, 100, CAST(37.50 AS Decimal(5, 2)), 0, 1)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (129, 9, 1, 3, 10, 20, 10, CAST(15.00 AS Decimal(5, 2)), 0, 1)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (130, 10, 2, 3, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (131, 11, 3, 3, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (132, 12, 4, 3, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (133, 4, 4, 18, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (134, 8, 10, 18, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (135, 6, 1, 18, 55, 45, 100, CAST(54.50 AS Decimal(5, 2)), 1, 1)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (136, 9, 1, 18, 10, 25, 100, CAST(26.50 AS Decimal(5, 2)), 0, 1)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (137, 10, 2, 18, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (138, 11, 3, 18, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (139, 12, 4, 18, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (140, 4, 4, 19, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (141, 8, 10, 19, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (142, 6, 1, 19, 0, 0, 0, CAST(0.00 AS Decimal(5, 2)), 0, 14)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (143, 9, 1, 19, 46, 44, 100, CAST(50.40 AS Decimal(5, 2)), 1, 1)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (144, 10, 2, 19, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (145, 11, 3, 19, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (146, 12, 4, 19, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (147, 4, 4, 20, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (148, 8, 10, 20, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (149, 9, 1, 20, 47, 41, 100, CAST(49.30 AS Decimal(5, 2)), 0, 1)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (150, 10, 2, 20, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (151, 11, 3, 20, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (152, 12, 4, 20, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (153, 4, 4, 22, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (154, 8, 10, 22, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (155, 9, 1, 22, 48, 42, 80, CAST(48.20 AS Decimal(5, 2)), 0, 3)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (156, 10, 2, 22, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (157, 11, 3, 22, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (158, 12, 4, 22, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (159, 4, 4, 24, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (160, 8, 10, 24, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (161, 9, 1, 24, 30, 50, 40, CAST(41.00 AS Decimal(5, 2)), 0, 3)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (162, 10, 2, 24, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (163, 11, 3, 24, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (164, 12, 4, 24, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (165, 4, 4, 25, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (166, 8, 10, 25, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (167, 9, 1, 25, 100, 90, 80, CAST(93.00 AS Decimal(5, 2)), 1, 1)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (168, 10, 2, 25, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (169, 11, 3, 25, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (170, 12, 4, 25, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (171, 4, 4, 26, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (172, 8, 10, 26, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (173, 9, 1, 26, 100, 100, 100, CAST(100.00 AS Decimal(5, 2)), 1, 1)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (174, 10, 2, 26, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (175, 11, 3, 26, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (176, 12, 4, 26, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLNOTLAR] ([NotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (177, 5, 5, 27, NULL, NULL, NULL, NULL, 0, NULL)
GO
SET IDENTITY_INSERT [dbo].[TBLNOTLAR] OFF
GO
SET IDENTITY_INSERT [dbo].[TBLOGRDERSPROGRAMI] ON 

INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (50, 1, 1)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (51, 1, 2)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (52, 1, 3)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (53, 1, 4)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (54, 2, 1)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (55, 2, 2)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (56, 2, 3)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (57, 2, 4)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (58, 3, 1)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (59, 3, 2)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (60, 3, 3)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (62, 3, 4)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (64, 1, 18)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (65, 2, 18)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (66, 3, 18)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (67, 1, 19)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (68, 1, 20)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (69, 1, 22)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (70, 1, 24)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (71, 1, 25)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (72, 1, 26)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (73, 2, 19)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (74, 2, 20)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (76, 2, 22)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (77, 2, 24)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (78, 2, 25)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (79, 2, 26)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (80, 3, 19)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (81, 3, 20)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (82, 3, 22)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (83, 3, 24)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (84, 3, 25)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (85, 3, 26)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (86, 4, 1)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (87, 8, 1)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (88, 6, 1)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (89, 9, 1)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (90, 10, 1)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (91, 11, 1)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (92, 12, 1)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (93, 4, 2)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (94, 8, 2)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (95, 6, 2)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (96, 9, 2)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (97, 10, 2)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (98, 11, 2)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (99, 12, 2)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (100, 4, 3)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (101, 8, 3)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (102, 6, 3)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (103, 9, 3)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (104, 10, 3)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (105, 11, 3)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (106, 12, 3)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (107, 4, 18)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (108, 8, 18)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (109, 6, 18)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (110, 9, 18)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (111, 10, 18)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (112, 11, 18)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (113, 12, 18)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (114, 4, 19)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (115, 8, 19)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (116, 6, 19)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (117, 9, 19)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (118, 10, 19)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (119, 11, 19)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (120, 12, 19)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (121, 4, 20)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (122, 8, 20)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (123, 9, 20)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (124, 10, 20)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (125, 11, 20)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (126, 12, 20)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (127, 4, 22)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (128, 8, 22)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (129, 9, 22)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (130, 10, 22)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (131, 11, 22)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (132, 12, 22)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (133, 4, 24)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (134, 8, 24)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (135, 9, 24)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (136, 10, 24)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (137, 11, 24)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (138, 12, 24)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (139, 4, 25)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (140, 8, 25)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (141, 9, 25)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (142, 10, 25)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (143, 11, 25)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (144, 12, 25)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (145, 4, 26)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (146, 8, 26)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (147, 9, 26)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (148, 10, 26)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (149, 11, 26)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (150, 12, 26)
INSERT [dbo].[TBLOGRDERSPROGRAMI] ([DersProgramID], [DersID], [OgrID]) VALUES (151, 5, 27)
GO
SET IDENTITY_INSERT [dbo].[TBLOGRDERSPROGRAMI] OFF
GO
SET IDENTITY_INSERT [dbo].[TBLOGRENCI] ON 

INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (1, 2, N'Mehmet', N'Kubat', N'23431879748', N'E', CAST(N'1999-07-16' AS Date), N'171002034', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (2, 2, N'Mert', N'Ulaş', N'11387709004', N'E', CAST(N'1999-06-01' AS Date), N'181002058', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (3, 2, N'Emre', N'Öztürk', N'12345678912', N'E', CAST(N'1999-01-01' AS Date), N'171002060', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (4, 2, N'Muhammed', N'Aydeniz', N'23456789123', N'E', CAST(N'2000-01-01' AS Date), N'171002036', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (18, 2, N'Esra', N'Aktaş', N'23456789122', N'K', CAST(N'2000-01-01' AS Date), N'171002037', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (19, 2, N'Nida', N'Arslan', N'23456709122', N'K', CAST(N'2000-01-01' AS Date), N'171002038', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (20, 2, N'Zilan', N'Ömer', N'43456709122', N'K', CAST(N'2000-01-01' AS Date), N'171002039', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (22, 2, N'Serkan', N'Hünerli', N'53456789123', N'E', CAST(N'2000-01-01' AS Date), N'171002040', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (24, 2, N'Berke', N'Yılmaz', N'63456789123', N'E', CAST(N'2000-01-01' AS Date), N'171002041', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (25, 2, N'Hüseyin', N'İşbilir', N'73456789123', N'E', CAST(N'2000-01-01' AS Date), N'171002042', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (26, 2, N'Görkem', N'Karakaş', N'83456789123', N'K', CAST(N'2000-01-01' AS Date), N'171002043', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (27, 3, N'Kadir', N'Demirel', N'93456789123', N'E', CAST(N'2000-01-01' AS Date), N'271002043', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (28, 3, N'Serhat', N'Baykal', N'33456789123', N'E', CAST(N'2000-01-01' AS Date), N'271002045', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (29, 3, N'Doğukan', N'Kartal', N'31456789123', N'E', CAST(N'2000-01-01' AS Date), N'171102045', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (30, 3, N'Süleyman', N'Çakır', N'35456789123', N'E', CAST(N'2000-01-01' AS Date), N'171112045', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (31, 3, N'Polat', N'Alemdar', N'35156789123', N'E', CAST(N'2000-01-01' AS Date), N'171122045', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (32, 4, N'Elif', N'Karaman', N'35056789123', N'K', CAST(N'2000-01-01' AS Date), N'171022045', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (35, 4, N'Furkan', N'Kubat', N'35156089123', N'E', CAST(N'2000-01-01' AS Date), N'171022051', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (36, 4, N'Ezgi', N'Molla', N'37156089123', N'K', CAST(N'2000-01-01' AS Date), N'191022051', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (37, 4, N'İsmail', N'Koca', N'37156009123', N'E', CAST(N'2000-01-01' AS Date), N'191002051', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (38, 4, N'Emirhan', N'Soba', N'37150009123', N'E', CAST(N'2000-01-01' AS Date), N'192002051', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (39, 5, N'Hüseyin', N'Çetinkaya', N'37152009123', N'E', CAST(N'2000-01-01' AS Date), N'192003051', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (40, 5, N'Mustafa', N'Çene', N'38152009123', N'E', CAST(N'2000-01-01' AS Date), N'193003051', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (41, 5, N'Simge', N'Yırtan', N'37150000123', N'K', CAST(N'2000-01-01' AS Date), N'192012051', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (42, 5, N'Nazdar', N'Deli', N'37150100123', N'K', CAST(N'2000-01-01' AS Date), N'192012151', N'0000')
INSERT [dbo].[TBLOGRENCI] ([OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullaniciAdi], [OgrSifre]) VALUES (43, 5, N'Beyhan', N'Kılıç', N'37150202123', N'K', CAST(N'2000-01-01' AS Date), N'192212151', N'0000')
SET IDENTITY_INSERT [dbo].[TBLOGRENCI] OFF
GO
SET IDENTITY_INSERT [dbo].[TBLOGRENCISILINMIS] ON 

INSERT [dbo].[TBLOGRENCISILINMIS] ([OgrenciSilinmisID], [OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullanciAdi], [OgrSifre]) VALUES (7, 8, 3, N'Hüseyin', N'İşbilir', N'98765432101', N'E', CAST(N'1999-01-01' AS Date), N'171002026', N'0000')
INSERT [dbo].[TBLOGRENCISILINMIS] ([OgrenciSilinmisID], [OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullanciAdi], [OgrSifre]) VALUES (8, 9, 3, N'Esra', N'Aktaş', N'565656565', N'K', CAST(N'1999-01-01' AS Date), N'181002086', N'00000')
INSERT [dbo].[TBLOGRENCISILINMIS] ([OgrenciSilinmisID], [OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullanciAdi], [OgrSifre]) VALUES (9, 8, 3, N'Kadir', N'Demirel', N'34567891233', N'E', CAST(N'1999-02-01' AS Date), N'171002033', N'0000')
INSERT [dbo].[TBLOGRENCISILINMIS] ([OgrenciSilinmisID], [OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullanciAdi], [OgrSifre]) VALUES (10, 12, 3, N'Kadir', N'Demirel', N'34567891235', N'E', CAST(N'1999-02-01' AS Date), N'171003031', N'0000')
INSERT [dbo].[TBLOGRENCISILINMIS] ([OgrenciSilinmisID], [OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullanciAdi], [OgrSifre]) VALUES (11, 17, 3, N'Kadir', N'Demirel', N'34567891236', N'E', CAST(N'1999-01-02' AS Date), N'171003033', N'0000')
INSERT [dbo].[TBLOGRENCISILINMIS] ([OgrenciSilinmisID], [OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullanciAdi], [OgrSifre]) VALUES (12, 14, 3, N'Kadir', N'Demirel', N'34567891235', N'E', CAST(N'1999-02-01' AS Date), N'171003031', N'0000')
INSERT [dbo].[TBLOGRENCISILINMIS] ([OgrenciSilinmisID], [OgrID], [BolumID], [OgrAd], [OgrSoyAd], [OgrTC], [OgrCinsiyet], [OgrDogumTarihi], [OgrKullanciAdi], [OgrSifre]) VALUES (13, 5, 3, N'Kadir', N'Demirel', N'34567891234', N'E', CAST(N'1999-01-02' AS Date), N'171003030', N'0000')
SET IDENTITY_INSERT [dbo].[TBLOGRENCISILINMIS] OFF
GO
SET IDENTITY_INSERT [dbo].[TBLOGRETMEN] ON 

INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (1, 2, N'Resul', N'Kara', N'11111111111', N'resul11', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (2, 2, N'Sinan', N'Toklu', N'22222222222', N'sinan22', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (3, 2, N'Fatih', N'Kayaalp', N'33333333333', N'fatih33', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (4, 2, N'Esra', N'Şatır', N'44444444444', N'esra44', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (5, 3, N'Hamit', N'Saruhan', N'55555555555', N'hamit55', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (10, 2, N'Mustafa İsa ', N'Doğan', N'66666666666', N'mustafa66', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (11, 3, N'Arafat', N'Şentürk', N'77777777777', N'arafat77', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (12, 3, N'Mehmet', N'Şimşek', N'88888888888', N'mehmet88', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (13, 3, N'Büşra ', N'Özgür', N'99999999999', N'büşra99', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (14, 3, N'Yusuf', N'Altun', N'88888888881', N'yusuf81', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (15, 4, N'Ali', N'Öztürk', N'11111111110', N'ali10', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (16, 4, N'Emre', N'Çelik', N'11111111100', N'emre00', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (17, 4, N'Murat', N'Kale', N'11111111101', N'murat01', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (18, 4, N'İsmail', N'Ercan', N'11111111011', N'ismail011', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (19, 4, N'Engin', N'Demiroğ', N'11111101111', N'engin11', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (20, 5, N'Uğur', N'Güvenç', N'11011111111', N'Ugur11', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (21, 5, N'Uğur', N'Hasırcı', N'1011111111', N'ugur01', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (22, 5, N'Mehmet', N'Uçar', N'11110011111', N'mehmet00', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (23, 5, N'Salih', N'Tosun', N'11101110111', N'salih11', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (24, 5, N'İlyas', N'Uygur', N'11011111011', N'ilyas11', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (25, 6, N'Ali', N'Gürsel', N'11111010101', N'ali0101', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (26, 7, N'Ethem', N'Toklu', N'11101101111', N'ethem11', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (27, 9, N'Fuat', N'Kara', N'12111111111', N'fuat12', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (28, 52, N'Serkan', N'Balcı', N'11311111111', N'serkan113', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (29, 53, N'Suat', N'Sarıdemir', N'11191111111', N'suat19', N'0000')
INSERT [dbo].[TBLOGRETMEN] ([OgretmenID], [BolumID], [OgretmenAd], [OgretmenSoyAd], [OgretmenTc], [OgretmenKullaniciAdi], [OgretmenSifre]) VALUES (30, 54, N'Mustafa', N'Ayyıldız', N'11111511111', N'mustafa15', N'0000')
SET IDENTITY_INSERT [dbo].[TBLOGRETMEN] OFF
GO
SET IDENTITY_INSERT [dbo].[TBLSILINMISNOTLAR] ON 

INSERT [dbo].[TBLSILINMISNOTLAR] ([SilinmisNotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (76, 1, 1, 1, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLSILINMISNOTLAR] ([SilinmisNotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (77, 3, 3, 4, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[TBLSILINMISNOTLAR] ([SilinmisNotID], [DersID], [OgretmenID], [OgrID], [Vize], [Final], [Proje], [Ortalama], [Durum], [Devamsizlik]) VALUES (78, 5, 5, 1, NULL, NULL, NULL, NULL, 0, NULL)
SET IDENTITY_INSERT [dbo].[TBLSILINMISNOTLAR] OFF
GO
ALTER TABLE [dbo].[TBLDUYURULAR] ADD  CONSTRAINT [df_duyurutarihi]  DEFAULT (getdate()) FOR [DuyuruTarihi]
GO
ALTER TABLE [dbo].[TBLDERSLER]  WITH CHECK ADD  CONSTRAINT [fk_DerslerBolumID] FOREIGN KEY([BolumID])
REFERENCES [dbo].[TBLBOLUMLER] ([BolumID])
GO
ALTER TABLE [dbo].[TBLDERSLER] CHECK CONSTRAINT [fk_DerslerBolumID]
GO
ALTER TABLE [dbo].[TBLDERSLER]  WITH CHECK ADD  CONSTRAINT [fk_DersOgretmenID] FOREIGN KEY([OgretmenID])
REFERENCES [dbo].[TBLOGRETMEN] ([OgretmenID])
GO
ALTER TABLE [dbo].[TBLDERSLER] CHECK CONSTRAINT [fk_DersOgretmenID]
GO
ALTER TABLE [dbo].[TBLDUYURULAR]  WITH CHECK ADD  CONSTRAINT [fk_DuyurularOgretmenID] FOREIGN KEY([OgretmenID])
REFERENCES [dbo].[TBLOGRETMEN] ([OgretmenID])
GO
ALTER TABLE [dbo].[TBLDUYURULAR] CHECK CONSTRAINT [fk_DuyurularOgretmenID]
GO
ALTER TABLE [dbo].[TBLNOTLAR]  WITH CHECK ADD  CONSTRAINT [fk_NotlarDersID] FOREIGN KEY([DersID])
REFERENCES [dbo].[TBLDERSLER] ([DersID])
GO
ALTER TABLE [dbo].[TBLNOTLAR] CHECK CONSTRAINT [fk_NotlarDersID]
GO
ALTER TABLE [dbo].[TBLNOTLAR]  WITH CHECK ADD  CONSTRAINT [fk_NotlarOgretmenID] FOREIGN KEY([OgretmenID])
REFERENCES [dbo].[TBLOGRETMEN] ([OgretmenID])
GO
ALTER TABLE [dbo].[TBLNOTLAR] CHECK CONSTRAINT [fk_NotlarOgretmenID]
GO
ALTER TABLE [dbo].[TBLNOTLAR]  WITH CHECK ADD  CONSTRAINT [fk_NotlarOgrID] FOREIGN KEY([OgrID])
REFERENCES [dbo].[TBLOGRENCI] ([OgrID])
GO
ALTER TABLE [dbo].[TBLNOTLAR] CHECK CONSTRAINT [fk_NotlarOgrID]
GO
ALTER TABLE [dbo].[TBLOGRDERSPROGRAMI]  WITH CHECK ADD  CONSTRAINT [fk_DersProgramiDersID] FOREIGN KEY([DersID])
REFERENCES [dbo].[TBLDERSLER] ([DersID])
GO
ALTER TABLE [dbo].[TBLOGRDERSPROGRAMI] CHECK CONSTRAINT [fk_DersProgramiDersID]
GO
ALTER TABLE [dbo].[TBLOGRDERSPROGRAMI]  WITH CHECK ADD  CONSTRAINT [fk_DersProgramiOgrenciID] FOREIGN KEY([OgrID])
REFERENCES [dbo].[TBLOGRENCI] ([OgrID])
GO
ALTER TABLE [dbo].[TBLOGRDERSPROGRAMI] CHECK CONSTRAINT [fk_DersProgramiOgrenciID]
GO
ALTER TABLE [dbo].[TBLOGRENCI]  WITH CHECK ADD  CONSTRAINT [fk_OgrenciBolumID] FOREIGN KEY([BolumID])
REFERENCES [dbo].[TBLBOLUMLER] ([BolumID])
GO
ALTER TABLE [dbo].[TBLOGRENCI] CHECK CONSTRAINT [fk_OgrenciBolumID]
GO
ALTER TABLE [dbo].[TBLOGRETMEN]  WITH CHECK ADD  CONSTRAINT [fk_OgretmenBolumID] FOREIGN KEY([BolumID])
REFERENCES [dbo].[TBLBOLUMLER] ([BolumID])
GO
ALTER TABLE [dbo].[TBLOGRETMEN] CHECK CONSTRAINT [fk_OgretmenBolumID]
GO
ALTER TABLE [dbo].[TBLNOTLAR]  WITH CHECK ADD  CONSTRAINT [ck_final] CHECK  (([Final]>=(0) AND [Final]<=(100)))
GO
ALTER TABLE [dbo].[TBLNOTLAR] CHECK CONSTRAINT [ck_final]
GO
ALTER TABLE [dbo].[TBLNOTLAR]  WITH CHECK ADD  CONSTRAINT [ck_ortalama] CHECK  (([Ortalama]>=(0) AND [Ortalama]<=(100)))
GO
ALTER TABLE [dbo].[TBLNOTLAR] CHECK CONSTRAINT [ck_ortalama]
GO
ALTER TABLE [dbo].[TBLNOTLAR]  WITH CHECK ADD  CONSTRAINT [ck_proje] CHECK  (([Proje]>=(0) AND [Proje]<=(100)))
GO
ALTER TABLE [dbo].[TBLNOTLAR] CHECK CONSTRAINT [ck_proje]
GO
ALTER TABLE [dbo].[TBLNOTLAR]  WITH CHECK ADD  CONSTRAINT [ck_vize] CHECK  (([Vize]>=(0) AND [Vize]<=(100)))
GO
ALTER TABLE [dbo].[TBLNOTLAR] CHECK CONSTRAINT [ck_vize]
GO
ALTER TABLE [dbo].[TBLOGRENCI]  WITH CHECK ADD  CONSTRAINT [check_ogrcinsiyet] CHECK  (([Ogrcinsiyet]='K' OR [Ogrcinsiyet]='E'))
GO
ALTER TABLE [dbo].[TBLOGRENCI] CHECK CONSTRAINT [check_ogrcinsiyet]
GO
ALTER TABLE [dbo].[TBLOGRENCISILINMIS]  WITH CHECK ADD  CONSTRAINT [check_ogrcinsiyet3] CHECK  (([Ogrcinsiyet]='K' OR [Ogrcinsiyet]='E'))
GO
ALTER TABLE [dbo].[TBLOGRENCISILINMIS] CHECK CONSTRAINT [check_ogrcinsiyet3]
GO
ALTER TABLE [dbo].[TBLSILINMISNOTLAR]  WITH CHECK ADD  CONSTRAINT [ck_final2] CHECK  (([Final]>=(0) AND [Final]<=(100)))
GO
ALTER TABLE [dbo].[TBLSILINMISNOTLAR] CHECK CONSTRAINT [ck_final2]
GO
ALTER TABLE [dbo].[TBLSILINMISNOTLAR]  WITH CHECK ADD  CONSTRAINT [ck_ortalama2] CHECK  (([Ortalama]>=(0) AND [Ortalama]<=(100)))
GO
ALTER TABLE [dbo].[TBLSILINMISNOTLAR] CHECK CONSTRAINT [ck_ortalama2]
GO
ALTER TABLE [dbo].[TBLSILINMISNOTLAR]  WITH CHECK ADD  CONSTRAINT [ck_proje2] CHECK  (([Proje]>=(0) AND [Proje]<=(100)))
GO
ALTER TABLE [dbo].[TBLSILINMISNOTLAR] CHECK CONSTRAINT [ck_proje2]
GO
ALTER TABLE [dbo].[TBLSILINMISNOTLAR]  WITH CHECK ADD  CONSTRAINT [ck_vize2] CHECK  (([Vize]>=(0) AND [Vize]<=(100)))
GO
ALTER TABLE [dbo].[TBLSILINMISNOTLAR] CHECK CONSTRAINT [ck_vize2]
GO
/****** Object:  StoredProcedure [dbo].[sp_DersProgramiinsertProcedure]    Script Date: 8.09.2022 10:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create Procedure [dbo].[sp_DersProgramiinsertProcedure]
(
    @gelenDersid int,
    @gelenOgrid int
)

As
Begin

    Declare @dersid int
    Declare @ogrid int
    Select @dersid= TBLOGRDERSPROGRAMI.DersID, @ogrid = TBLOGRDERSPROGRAMI.OgrID From TBLOGRDERSPROGRAMI where @gelenDersid= TBLOGRDERSPROGRAMI.DersID and @gelenOgrid = TBLOGRDERSPROGRAMI.OgrID

    if (@gelenDersid=@dersid and @gelenOgrid = @ogrid) begin
    print 'Hata Oluştu...'
    end
    else begin
    insert into TBLOGRDERSPROGRAMI (DersID,OgrID) Values (@gelenDersid,@gelenOgrid)
    end;


End
GO
/****** Object:  StoredProcedure [dbo].[sp_DersProgramiupdateProcedure]    Script Date: 8.09.2022 10:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[sp_DersProgramiupdateProcedure]
(
    @gelenDersid int,
    @gelenOgrid int,
	@gelendersprogramiid int
)

As
Begin

    Declare @dersid int
    Declare @ogrid int


    Select @dersid= TBLOGRDERSPROGRAMI.DersID, @ogrid = TBLOGRDERSPROGRAMI.OgrID,@gelendersprogramiid=TBLOGRDERSPROGRAMI.DersProgramID From TBLOGRDERSPROGRAMI where @gelenDersid= TBLOGRDERSPROGRAMI.DersID and @gelenOgrid = TBLOGRDERSPROGRAMI.OgrID 

    if (@gelenDersid=@dersid and @gelenOgrid = @ogrid) begin
    print 'Hata Oluştu...'
    end
    else begin
    update TBLOGRDERSPROGRAMI set DersID=@gelenDersid,OgrID= @gelenOgrid where DersProgramID=@gelendersprogramiid
    end;


End

---exec sp_DersProgramiupdateProcedure 1,1,44
GO
/****** Object:  StoredProcedure [dbo].[sp_OgrBolumProcedure]    Script Date: 8.09.2022 10:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[sp_OgrBolumProcedure]
(
    @search nvarchar(20)
)
As
Begin
Select * From TBLBOLUMLER where BolumID like @search or BolumAd like @search or BolumKod like @search 
End
GO
/****** Object:  StoredProcedure [dbo].[sp_OgrDersProcedure]    Script Date: 8.09.2022 10:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[sp_OgrDersProcedure]
(
    @search nvarchar(20)
)
As
Begin
Select * From TBLDERSLER where DersID like @search or DersAd like @search or DersKod like @search
End


------------

--Create procedure sp_OgrOgrenciProcedure
--(
--    @search nvarchar(20)
--)
--As
--Begin
--Select * From TBLOGRENCI where OgrID like @search or OgrAd like @search or OgrSoyAd like @search or OgrTC like @search or OgrKullaniciAdi like @search
--End

---------------

--Create procedure sp_OgrBolumProcedure
--(
--    @search nvarchar(20)
--)
--As
--Begin
--Select * From TBLBOLUMLER where BolumID like @search or BolumAd like @search or BolumKod like @search 
--End

----------------

--Create procedure sp_OgrDersProgramiProcedure
--(
--    @search nvarchar(20)
--)
--As
--Begin
--Select * From TBLOGRDERSPROGRAMI where DersID like @search or OgrID like @search 
--End
-----------------

--Create procedure sp_OgrOgretmenProcedure
--(
--    @search nvarchar(20)
--)
--As
--Begin
--Select * From TBLOGRETMEN where OgretmenID like @search or OgretmenAd like @search or OgretmenSoyAd like @search or OgretmenTc like @search or OgretmenKullaniciAdi like @search 
--End
-----------------

--declare @ad nvarchar(20) = '%01%'
--exec sp_OgrOgretmenProcedure @ad
GO
/****** Object:  StoredProcedure [dbo].[sp_OgrDersProcedureFrmOgretmen]    Script Date: 8.09.2022 10:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[sp_OgrDersProcedureFrmOgretmen]
(
    @search nvarchar(20),
    @p2 int
)
As
Begin
Select * From TBLDERSLER where (DersID like @search or DersAd like @search or DersKod like @search) and (OgretmenID=@p2)
End
GO
/****** Object:  StoredProcedure [dbo].[sp_OgrDersProgrami3]    Script Date: 8.09.2022 10:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[sp_OgrDersProgrami3]
(
    @search nvarchar(20)
)
As
Begin
SELECT TBLDERSLER.DersID,TBLDERSLER.DersAd,TBLOGRENCI.OgrAd,TBLOGRENCI.OgrSoyAd,TBLOGRENCI.OgrID,TBLDERSLER.DersTarih FROM TBLDERSLER
  INNER JOIN TBLOGRDERSPROGRAMI ON TBLDERSLER.DersID = TBLOGRDERSPROGRAMI.DersID
  INNER JOIN TBLOGRENCI ON TBLOGRDERSPROGRAMI.OgrID = TBLOGRENCI.OgrID where TBLDERSLER.DersID like @search or TBLOGRENCI.OgrAd like @search or TBLOGRENCI.OgrSoyAd like @search or TBLDERSLER.DersTarih like @search;
End
GO
/****** Object:  StoredProcedure [dbo].[sp_OgrOgrenciProcedure]    Script Date: 8.09.2022 10:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[sp_OgrOgrenciProcedure]
(
    @search nvarchar(20)
)
As
Begin
Select * From TBLOGRENCI where OgrID like @search or OgrAd like @search or OgrSoyAd like @search or OgrTC like @search or OgrKullaniciAdi like @search
End
GO
/****** Object:  StoredProcedure [dbo].[sp_OgrOgretmenProcedure]    Script Date: 8.09.2022 10:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[sp_OgrOgretmenProcedure]
(
    @search nvarchar(20)
)
As
Begin
Select * From TBLOGRETMEN where OgretmenID like @search or OgretmenAd like @search or OgretmenSoyAd like @search or OgretmenTc like @search or OgretmenKullaniciAdi like @search 
End
GO
