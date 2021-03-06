USE [KtpAcsMiddleware]
GO
/****** Object:  Table [dbo].[FaceDevice]    Script Date: 01/28/2019 19:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FaceDevice](
	[Id] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[IpAddress] [nvarchar](50) NOT NULL,
	[IdentityId] [int] NULL,
	[IsCheckIn] [bit] NULL,
	[Description] [nvarchar](300) NULL,
	[CreateTime] [datetime] NOT NULL,
	[ModifiedTime] [datetime] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_FaceDevice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrgUser]    Script Date: 01/28/2019 19:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgUser](
	[Id] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Account] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Mobile] [nvarchar](50) NULL,
	[Mail] [nvarchar](100) NOT NULL,
	[Birthday] [datetime] NULL,
	[Status] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[ModifiedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_OrgUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[OrgUser] ([Id], [Code], [Name], [Account], [Password], [Mobile], [Mail], [Birthday], [Status], [CreateTime], [ModifiedTime]) VALUES (N'b57d87c1577c4333835aee5d7b7e00e4', N'adminitrator', N'Adminitrator', N'admin', N'fEqNCco3Yq9h5ZUglD3CZJT4lBs=', N'-', N'-', NULL, 0, CAST(0x0000A9D600E4B5B1 AS DateTime), CAST(0x0000A9D600E4B5B1 AS DateTime))
/****** Object:  Table [dbo].[FileMap]    Script Date: 01/28/2019 19:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileMap](
	[Id] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[FileName] [nvarchar](300) NOT NULL,
	[PhysicalFileName] [nvarchar](300) NOT NULL,
	[PhysicalFullName] [nvarchar](1000) NOT NULL,
	[Length] [int] NOT NULL,
	[FileExtensionName] [nvarchar](20) NOT NULL,
	[QiniuKey] [nvarchar](100) NULL,
	[QiniuUrl] [nvarchar](200) NULL,
	[CreateTime] [datetime] NOT NULL,
	[ModifiedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_FileMap] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeamWorkType]    Script Date: 01/28/2019 19:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamWorkType](
	[Id] [nvarchar](50) NOT NULL,
	[Value] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_TeamWorkType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[TeamWorkType] ([Id], [Value], [Name], [CreateTime], [IsDelete]) VALUES (N'4b638315dd4847eead0d783b1c645044', 24, N'其他', CAST(0x0000A9D600E4B633 AS DateTime), 0)
INSERT [dbo].[TeamWorkType] ([Id], [Value], [Name], [CreateTime], [IsDelete]) VALUES (N'7ad20224308e47fd81c1b25a0ae7194a', 19, N'木工', CAST(0x0000A9D600E4B633 AS DateTime), 0)
INSERT [dbo].[TeamWorkType] ([Id], [Value], [Name], [CreateTime], [IsDelete]) VALUES (N'8ce63b296ecc4607a2172540e9d0300c', 20, N'铁工', CAST(0x0000A9D600E4B633 AS DateTime), 0)
INSERT [dbo].[TeamWorkType] ([Id], [Value], [Name], [CreateTime], [IsDelete]) VALUES (N'c32f949776184eddb72bd7d3cad512cc', 23, N'粗装修', CAST(0x0000A9D600E4B633 AS DateTime), 0)
INSERT [dbo].[TeamWorkType] ([Id], [Value], [Name], [CreateTime], [IsDelete]) VALUES (N'df315699a9ea4b3b906e5fd029380434', 21, N'混泥土', CAST(0x0000A9D600E4B633 AS DateTime), 0)
INSERT [dbo].[TeamWorkType] ([Id], [Value], [Name], [CreateTime], [IsDelete]) VALUES (N'e0b4855c54b74637a32586ee08771c5c', 22, N'外架', CAST(0x0000A9D600E4B633 AS DateTime), 0)
/****** Object:  Table [dbo].[WorkerIdentity]    Script Date: 01/28/2019 19:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkerIdentity](
	[Id] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Sex] [int] NOT NULL,
	[Nation] [int] NOT NULL,
	[Birthday] [datetime] NOT NULL,
	[Address] [nvarchar](300) NOT NULL,
	[IssuingAuthority] [nvarchar](100) NOT NULL,
	[ActivateTime] [datetime] NOT NULL,
	[InvalidTime] [datetime] NOT NULL,
	[PicId] [nvarchar](50) NULL,
	[BackPicId] [nvarchar](50) NULL,
	[Base64Photo] [text] NULL,
	[CreateType] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[ModifiedTime] [datetime] NOT NULL,
	[CreditGrade] [decimal](18, 2) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_WorkerIdentity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZmskAuthentication]    Script Date: 01/28/2019 19:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZmskAuthentication](
	[Id] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IdNumber] [nvarchar](300) NULL,
	[Nation] [nvarchar](20) NULL,
	[Address] [nvarchar](200) NULL,
	[Avatar] [nvarchar](max) NOT NULL,
	[Sex] [int] NULL,
	[Type] [int] NOT NULL,
	[Result] [int] NOT NULL,
	[DeviceNumber] [nvarchar](50) NOT NULL,
	[GroupId] [nvarchar](50) NULL,
	[AuthTimeStamp] [nvarchar](50) NOT NULL,
	[IdcardImage] [nvarchar](max) NULL,
	[IdcardInfo] [nvarchar](50) NULL,
	[SimilarDegree] [nvarchar](200) NULL,
	[SignOffice] [nvarchar](200) NULL,
	[LegalDate] [nvarchar](50) NULL,
	[Birthday] [nvarchar](50) NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_ZmskAuthentication] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZmskAuthenticationSync]    Script Date: 01/28/2019 19:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZmskAuthenticationSync](
	[Id] [nvarchar](50) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[ThirdPartyWorkerId] [int] NOT NULL,
	[ClockType] [int] NOT NULL,
	[ClockPic] [nvarchar](300) NOT NULL,
	[Status] [int] NOT NULL,
	[FeedbackCode] [int] NULL,
	[Feedback] [nvarchar](500) NULL,
	[CreateTime] [datetime] NOT NULL,
	[ModifiedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_ZmskAuthenticationSync] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Team]    Script Date: 01/28/2019 19:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[Id] [nvarchar](50) NOT NULL,
	[IdentityId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[WorkTypeId] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](300) NULL,
	[CreateTime] [datetime] NOT NULL,
	[ModifiedTime] [datetime] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[LeaderId] [nvarchar](50) NULL,
 CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeamSync]    Script Date: 01/28/2019 19:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamSync](
	[Id] [nvarchar](50) NOT NULL,
	[ThirdPartyId] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[FeedbackCode] [int] NULL,
	[Feedback] [nvarchar](500) NULL,
	[CreateTime] [datetime] NOT NULL,
	[ModifiedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_TeamSync] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Worker]    Script Date: 01/28/2019 19:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Worker](
	[Id] [nvarchar](50) NOT NULL,
	[IdentityId] [nvarchar](50) NOT NULL,
	[TeamId] [nvarchar](50) NOT NULL,
	[InTime] [datetime] NOT NULL,
	[OutTime] [datetime] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Mobile] [nvarchar](20) NOT NULL,
	[Status] [int] NOT NULL,
	[IdentityFaceSim] [decimal](18, 2) NULL,
	[AddressNow] [nvarchar](300) NOT NULL,
	[ContractPicId] [nvarchar](50) NULL,
	[FacePicId] [nvarchar](50) NULL,
	[CreatorId] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[ModifiedTime] [datetime] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[BankCardTypeId] [int] NULL,
	[BankCardCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Worker] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkerSync]    Script Date: 01/28/2019 19:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkerSync](
	[Id] [nvarchar](50) NOT NULL,
	[ThirdPartyId] [int] NOT NULL,
	[TeamThirdPartyId] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[FeedbackCode] [int] NULL,
	[Feedback] [nvarchar](500) NULL,
	[CreateTime] [datetime] NOT NULL,
	[ModifiedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_WorkerSync] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FaceDeviceWorker]    Script Date: 01/28/2019 19:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FaceDeviceWorker](
	[Id] [nvarchar](50) NOT NULL,
	[IdentityId] [int] IDENTITY(1,1) NOT NULL,
	[WorkerId] [nvarchar](50) NOT NULL,
	[DeviceId] [nvarchar](50) NOT NULL,
	[Status] [int] NOT NULL,
	[ErrorCode] [nvarchar](50) NULL,
	[CreateTime] [datetime] NOT NULL,
	[ModifiedTime] [datetime] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_FaceDeviceWorker] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_FaceDevice_IsDelete]    Script Date: 01/28/2019 19:07:50 ******/
ALTER TABLE [dbo].[FaceDevice] ADD  CONSTRAINT [DF_FaceDevice_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
/****** Object:  Default [DF_FaceDeviceWorker_CreateTime]    Script Date: 01/28/2019 19:07:50 ******/
ALTER TABLE [dbo].[FaceDeviceWorker] ADD  CONSTRAINT [DF_FaceDeviceWorker_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_FaceDeviceWorker_ModifiedTime]    Script Date: 01/28/2019 19:07:50 ******/
ALTER TABLE [dbo].[FaceDeviceWorker] ADD  CONSTRAINT [DF_FaceDeviceWorker_ModifiedTime]  DEFAULT (getdate()) FOR [ModifiedTime]
GO
/****** Object:  Default [DF_FaceDeviceWorker_IsDelete]    Script Date: 01/28/2019 19:07:50 ******/
ALTER TABLE [dbo].[FaceDeviceWorker] ADD  CONSTRAINT [DF_FaceDeviceWorker_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
/****** Object:  Default [DF_Team_IsDelete]    Script Date: 01/28/2019 19:07:50 ******/
ALTER TABLE [dbo].[Team] ADD  CONSTRAINT [DF_Team_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
/****** Object:  Default [DF_TeamWorkType_CreateTime]    Script Date: 01/28/2019 19:07:50 ******/
ALTER TABLE [dbo].[TeamWorkType] ADD  CONSTRAINT [DF_TeamWorkType_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_TeamWorkType_IsDelete]    Script Date: 01/28/2019 19:07:50 ******/
ALTER TABLE [dbo].[TeamWorkType] ADD  CONSTRAINT [DF_TeamWorkType_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
/****** Object:  Default [DF_Worker_CreateTime]    Script Date: 01/28/2019 19:07:50 ******/
ALTER TABLE [dbo].[Worker] ADD  CONSTRAINT [DF_Worker_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_Worker_ModifiedTime]    Script Date: 01/28/2019 19:07:50 ******/
ALTER TABLE [dbo].[Worker] ADD  CONSTRAINT [DF_Worker_ModifiedTime]  DEFAULT (getdate()) FOR [ModifiedTime]
GO
/****** Object:  Default [DF_Worker_IsDelete]    Script Date: 01/28/2019 19:07:50 ******/
ALTER TABLE [dbo].[Worker] ADD  CONSTRAINT [DF_Worker_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
/****** Object:  Default [DF_WorkerIdentity_CreateTime]    Script Date: 01/28/2019 19:07:50 ******/
ALTER TABLE [dbo].[WorkerIdentity] ADD  CONSTRAINT [DF_WorkerIdentity_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_WorkerIdentity_IsDelete]    Script Date: 01/28/2019 19:07:50 ******/
ALTER TABLE [dbo].[WorkerIdentity] ADD  CONSTRAINT [DF_WorkerIdentity_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
/****** Object:  Default [DF_ZmskAuthentication_CreateTime]    Script Date: 01/28/2019 19:07:50 ******/
ALTER TABLE [dbo].[ZmskAuthentication] ADD  CONSTRAINT [DF_ZmskAuthentication_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  ForeignKey [FK_FaceDeviceWorker_FaceDevice]    Script Date: 01/28/2019 19:07:50 ******/
ALTER TABLE [dbo].[FaceDeviceWorker]  WITH CHECK ADD  CONSTRAINT [FK_FaceDeviceWorker_FaceDevice] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[FaceDevice] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FaceDeviceWorker] CHECK CONSTRAINT [FK_FaceDeviceWorker_FaceDevice]
GO
/****** Object:  ForeignKey [FK_FaceDeviceWorker_Worker]    Script Date: 01/28/2019 19:07:50 ******/
ALTER TABLE [dbo].[FaceDeviceWorker]  WITH CHECK ADD  CONSTRAINT [FK_FaceDeviceWorker_Worker] FOREIGN KEY([WorkerId])
REFERENCES [dbo].[Worker] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FaceDeviceWorker] CHECK CONSTRAINT [FK_FaceDeviceWorker_Worker]
GO
/****** Object:  ForeignKey [FK_Team_TeamWorkType]    Script Date: 01/28/2019 19:07:50 ******/
ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [FK_Team_TeamWorkType] FOREIGN KEY([WorkTypeId])
REFERENCES [dbo].[TeamWorkType] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Team] CHECK CONSTRAINT [FK_Team_TeamWorkType]
GO
/****** Object:  ForeignKey [FK_TeamSync_Team]    Script Date: 01/28/2019 19:07:50 ******/
ALTER TABLE [dbo].[TeamSync]  WITH CHECK ADD  CONSTRAINT [FK_TeamSync_Team] FOREIGN KEY([Id])
REFERENCES [dbo].[Team] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeamSync] CHECK CONSTRAINT [FK_TeamSync_Team]
GO
/****** Object:  ForeignKey [FK_Worker_Team]    Script Date: 01/28/2019 19:07:50 ******/
ALTER TABLE [dbo].[Worker]  WITH CHECK ADD  CONSTRAINT [FK_Worker_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Worker] CHECK CONSTRAINT [FK_Worker_Team]
GO
/****** Object:  ForeignKey [FK_Worker_WorkerIdentity]    Script Date: 01/28/2019 19:07:50 ******/
ALTER TABLE [dbo].[Worker]  WITH CHECK ADD  CONSTRAINT [FK_Worker_WorkerIdentity] FOREIGN KEY([IdentityId])
REFERENCES [dbo].[WorkerIdentity] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Worker] CHECK CONSTRAINT [FK_Worker_WorkerIdentity]
GO
/****** Object:  ForeignKey [FK_WorkerSync_Worker]    Script Date: 01/28/2019 19:07:50 ******/
ALTER TABLE [dbo].[WorkerSync]  WITH CHECK ADD  CONSTRAINT [FK_WorkerSync_Worker] FOREIGN KEY([Id])
REFERENCES [dbo].[Worker] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WorkerSync] CHECK CONSTRAINT [FK_WorkerSync_Worker]
GO
/****** Object:  ForeignKey [FK_ZmskAuthenticationSync_ZmskAuthentication]    Script Date: 01/28/2019 19:07:50 ******/
ALTER TABLE [dbo].[ZmskAuthenticationSync]  WITH CHECK ADD  CONSTRAINT [FK_ZmskAuthenticationSync_ZmskAuthentication] FOREIGN KEY([Id])
REFERENCES [dbo].[ZmskAuthentication] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ZmskAuthenticationSync] CHECK CONSTRAINT [FK_ZmskAuthenticationSync_ZmskAuthentication]
GO
