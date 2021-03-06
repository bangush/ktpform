USE [KtpAcsMiddleware]
GO
/****** Object:  Table [dbo].[WorkerIdentity]    Script Date: 04/08/2019 18:12:25 ******/
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerIdentity', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份证号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerIdentity', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerIdentity', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别，对应到代码WorkerSex枚举' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerIdentity', @level2type=N'COLUMN',@level2name=N'Sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'民族(值)，对应到代码IdentityNation枚举' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerIdentity', @level2type=N'COLUMN',@level2name=N'Nation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出生日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerIdentity', @level2type=N'COLUMN',@level2name=N'Birthday'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份证上的地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerIdentity', @level2type=N'COLUMN',@level2name=N'Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发证机关' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerIdentity', @level2type=N'COLUMN',@level2name=N'IssuingAuthority'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效时间(起始)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerIdentity', @level2type=N'COLUMN',@level2name=N'ActivateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效时间(结束)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerIdentity', @level2type=N'COLUMN',@level2name=N'InvalidTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'正面照片ID，对应到FileMap的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerIdentity', @level2type=N'COLUMN',@level2name=N'PicId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'背面照片ID，对应到FileMap的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerIdentity', @level2type=N'COLUMN',@level2name=N'BackPicId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份证头像(Base64)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerIdentity', @level2type=N'COLUMN',@level2name=N'Base64Photo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建类型，对应到代码WorkerIdentityCreateType枚举' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerIdentity', @level2type=N'COLUMN',@level2name=N'CreateType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerIdentity', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerIdentity', @level2type=N'COLUMN',@level2name=N'ModifiedTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'信用分(开太平提供)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerIdentity', @level2type=N'COLUMN',@level2name=N'CreditGrade'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已经被删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerIdentity', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工人身份证表，存储工人身份证信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerIdentity'
GO
/****** Object:  Table [dbo].[ZmskAuthentication]    Script Date: 04/08/2019 18:12:25 ******/
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthentication', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthentication', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份证号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthentication', @level2type=N'COLUMN',@level2name=N'IdNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'民族' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthentication', @level2type=N'COLUMN',@level2name=N'Nation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthentication', @level2type=N'COLUMN',@level2name=N'Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'打卡时的头像' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthentication', @level2type=N'COLUMN',@level2name=N'Avatar'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别，此处的性别不对应系统系统枚举，而是对应面板的原始信息。1：女 2：男' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthentication', @level2type=N'COLUMN',@level2name=N'Sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型1：人证，2人脸' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthentication', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'认证结果 0：未通过 1：通过' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthentication', @level2type=N'COLUMN',@level2name=N'Result'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthentication', @level2type=N'COLUMN',@level2name=N'DeviceNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属分组Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthentication', @level2type=N'COLUMN',@level2name=N'GroupId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'认证时间戳' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthentication', @level2type=N'COLUMN',@level2name=N'AuthTimeStamp'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份证图片，base64string' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthentication', @level2type=N'COLUMN',@level2name=N'IdcardImage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份证基本信息-放空' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthentication', @level2type=N'COLUMN',@level2name=N'IdcardInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对比相似度-放空' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthentication', @level2type=N'COLUMN',@level2name=N'SimilarDegree'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'放空-已弃用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthentication', @level2type=N'COLUMN',@level2name=N'SignOffice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'放空-已弃用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthentication', @level2type=N'COLUMN',@level2name=N'LegalDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生日-放空' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthentication', @level2type=N'COLUMN',@level2name=N'Birthday'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthentication', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考勤原始信息表，存储面板产生的考勤数据' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthentication'
GO
/****** Object:  Table [dbo].[FaceDevice]    Script Date: 04/08/2019 18:12:25 ******/
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaceDevice', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaceDevice', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IP地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaceDevice', @level2type=N'COLUMN',@level2name=N'IpAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份ID号（旧设备不能直接传设备号，使用这个字段进行匹配，现已弃用这个字段）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaceDevice', @level2type=N'COLUMN',@level2name=N'IdentityId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否是进场方向，用户标记上下班' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaceDevice', @level2type=N'COLUMN',@level2name=N'IsCheckIn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaceDevice', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaceDevice', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最新修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaceDevice', @level2type=N'COLUMN',@level2name=N'ModifiedTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaceDevice', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'人脸识别设备表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaceDevice'
GO
/****** Object:  Table [dbo].[OrgUser]    Script Date: 04/08/2019 18:12:25 ******/
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrgUser', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrgUser', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrgUser', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrgUser', @level2type=N'COLUMN',@level2name=N'Account'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrgUser', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrgUser', @level2type=N'COLUMN',@level2name=N'Mobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrgUser', @level2type=N'COLUMN',@level2name=N'Mail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrgUser', @level2type=N'COLUMN',@level2name=N'Birthday'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态，对应到代码OrgUserState枚举' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrgUser', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrgUser', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrgUser', @level2type=N'COLUMN',@level2name=N'ModifiedTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户表，存储本地系统的登录账号信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrgUser'
GO
/****** Object:  Table [dbo].[FileMap]    Script Date: 04/08/2019 18:12:25 ******/
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileMap', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'唯一编号，代码中默认是code等于id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileMap', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文件名称，用于系统中显示的名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileMap', @level2type=N'COLUMN',@level2name=N'FileName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物理文件名称，为保证物理存储时的文件名唯一性，系统自动生成的物理文件名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileMap', @level2type=N'COLUMN',@level2name=N'PhysicalFileName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'含路径的物理文件名，基本不会通过这个获取文件，而是通过配置文件拼接物理名称获取' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileMap', @level2type=N'COLUMN',@level2name=N'PhysicalFullName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文件长度(大小KB)，无实际作用，只是记录，不一定每个文件都在此保存好真实的大小' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileMap', @level2type=N'COLUMN',@level2name=N'Length'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文件扩展名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileMap', @level2type=N'COLUMN',@level2name=N'FileExtensionName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'七牛KEY，上传至七牛后返回的key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileMap', @level2type=N'COLUMN',@level2name=N'QiniuKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'七牛链接，上传至七牛后产生的文件链接' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileMap', @level2type=N'COLUMN',@level2name=N'QiniuUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileMap', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileMap', @level2type=N'COLUMN',@level2name=N'ModifiedTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文件映射表，保存文件信息和对应的物理文件映射数据' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileMap'
GO
/****** Object:  Table [dbo].[TeamWorkType]    Script Date: 04/08/2019 18:12:25 ******/
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeamWorkType', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'值，对应到开天平给的工种类型的value值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeamWorkType', @level2type=N'COLUMN',@level2name=N'Value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称，对应开天平的工种类型名称，不一定全部一致，但是基本一样' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeamWorkType', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeamWorkType', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeamWorkType', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班组的工种类型表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeamWorkType'
GO
/****** Object:  Table [dbo].[ZmskAuthenticationSync]    Script Date: 04/08/2019 18:12:25 ******/
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthenticationSync', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当前项目ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthenticationSync', @level2type=N'COLUMN',@level2name=N'ProjectId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工人第三方ID（开太平ID）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthenticationSync', @level2type=N'COLUMN',@level2name=N'ThirdPartyWorkerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'打卡类型，对应到代码WorkerAuthClockType枚举' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthenticationSync', @level2type=N'COLUMN',@level2name=N'ClockType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'打卡当时产生的照片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthenticationSync', @level2type=N'COLUMN',@level2name=N'ClockPic'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'同步的状态，对应到KtpLibrary下的KtpSyncState枚举' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthenticationSync', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'返回的code，调用开太平接口后的返回值中的code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthenticationSync', @level2type=N'COLUMN',@level2name=N'FeedbackCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'返回信息，调用开太平接口后的返回值的信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthenticationSync', @level2type=N'COLUMN',@level2name=N'Feedback'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthenticationSync', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthenticationSync', @level2type=N'COLUMN',@level2name=N'ModifiedTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考勤同步表，存储开太平考勤同步信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZmskAuthenticationSync'
GO
/****** Object:  Table [dbo].[Team]    Script Date: 04/08/2019 18:12:25 ******/
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Team', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份ID，相当于自增长的ID主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Team', @level2type=N'COLUMN',@level2name=N'IdentityId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'项目ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Team', @level2type=N'COLUMN',@level2name=N'ProjectId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Team', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属工种类型编号，对应到工种类型表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Team', @level2type=N'COLUMN',@level2name=N'WorkTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Team', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Team', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Team', @level2type=N'COLUMN',@level2name=N'ModifiedTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Team', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班组长ID，对应到工人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Team', @level2type=N'COLUMN',@level2name=N'LeaderId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班组表，保存班组信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Team'
GO
/****** Object:  Table [dbo].[TeamSync]    Script Date: 04/08/2019 18:12:25 ******/
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键，与班组表ID一致，关联到班组表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeamSync', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'第三方ID（开太平返回的ID）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeamSync', @level2type=N'COLUMN',@level2name=N'ThirdPartyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'同步的类型，对应到KtpLibrary下的KtpSyncType枚举' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeamSync', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'同步的状态，对应到KtpLibrary下的KtpSyncState枚举' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeamSync', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'返回的code，调用开太平接口后的返回值中的code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeamSync', @level2type=N'COLUMN',@level2name=N'FeedbackCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'返回信息，调用开太平接口后的返回值的信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeamSync', @level2type=N'COLUMN',@level2name=N'Feedback'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeamSync', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeamSync', @level2type=N'COLUMN',@level2name=N'ModifiedTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班组同步表，保存班组与开太平的同步信息，与班组表一对一关联，ID等于班组表的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeamSync'
GO
/****** Object:  Table [dbo].[Worker]    Script Date: 04/08/2019 18:12:25 ******/
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Worker', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份ID，对应到身份证表的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Worker', @level2type=N'COLUMN',@level2name=N'IdentityId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班组ID，对应到班组表的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Worker', @level2type=N'COLUMN',@level2name=N'TeamId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入场(入职)时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Worker', @level2type=N'COLUMN',@level2name=N'InTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'离场(离职)时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Worker', @level2type=N'COLUMN',@level2name=N'OutTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Worker', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Worker', @level2type=N'COLUMN',@level2name=N'Mobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职位状态，对应到代码WorkerPositionState枚举' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Worker', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'人脸相似度（暂时不做处理）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Worker', @level2type=N'COLUMN',@level2name=N'IdentityFaceSim'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'现在住址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Worker', @level2type=N'COLUMN',@level2name=N'AddressNow'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'合同照片ID，对应到FileMap表的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Worker', @level2type=N'COLUMN',@level2name=N'ContractPicId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'人脸照片ID，对应到FileMap表的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Worker', @level2type=N'COLUMN',@level2name=N'FacePicId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人ID，对应到OrgUser的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Worker', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Worker', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Worker', @level2type=N'COLUMN',@level2name=N'ModifiedTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Worker', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行卡类型id(所属银行)，对应到代码BankCardType枚举' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Worker', @level2type=N'COLUMN',@level2name=N'BankCardTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行卡号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Worker', @level2type=N'COLUMN',@level2name=N'BankCardCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班组工人表，存班组工人信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Worker'
GO
/****** Object:  Table [dbo].[WorkerSync]    Script Date: 04/08/2019 18:12:25 ******/
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerSync', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'第三方ID，即开太平返回的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerSync', @level2type=N'COLUMN',@level2name=N'ThirdPartyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班组的第三方(开太平)ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerSync', @level2type=N'COLUMN',@level2name=N'TeamThirdPartyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'同步的类型，对应到KtpLibrary下的KtpSyncType枚举' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerSync', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'同步的状态，对应到KtpLibrary下的KtpSyncState枚举' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerSync', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'返回的code，调用开太平接口后的返回值中的code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerSync', @level2type=N'COLUMN',@level2name=N'FeedbackCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'返回信息，调用开太平接口后的返回值的信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerSync', @level2type=N'COLUMN',@level2name=N'Feedback'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerSync', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerSync', @level2type=N'COLUMN',@level2name=N'ModifiedTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工人同步表，保存工人与开太平同步的信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerSync'
GO
/****** Object:  Table [dbo].[WorkerAuth]    Script Date: 04/08/2019 18:12:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkerAuth](
	[Id] [nvarchar](50) NOT NULL,
	[WorkerId] [nvarchar](50) NOT NULL,
	[TeamId] [nvarchar](50) NOT NULL,
	[TeamName] [nvarchar](50) NOT NULL,
	[ClockType] [int] NOT NULL,
	[ClockTime] [datetime] NOT NULL,
	[SimilarDegree] [decimal](18, 3) NULL,
	[IsPass] [bit] NOT NULL,
	[ClockPicId] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[AuthId] [nvarchar](50) NULL,
	[ClientCode] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_WorkerAuth] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerAuth', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工人ID，对应到Worker表的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerAuth', @level2type=N'COLUMN',@level2name=N'WorkerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'(当时)班组ID，对应到Team表的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerAuth', @level2type=N'COLUMN',@level2name=N'TeamId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'(当时)班组名称，对应到Team表的名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerAuth', @level2type=N'COLUMN',@level2name=N'TeamName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'打卡类型，对应到代码WorkerAuthClockType枚举' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerAuth', @level2type=N'COLUMN',@level2name=N'ClockType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'打卡时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerAuth', @level2type=N'COLUMN',@level2name=N'ClockTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'相似度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerAuth', @level2type=N'COLUMN',@level2name=N'SimilarDegree'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否通过' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerAuth', @level2type=N'COLUMN',@level2name=N'IsPass'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'打卡当时产生的照片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerAuth', @level2type=N'COLUMN',@level2name=N'ClockPicId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerAuth', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原始考勤的ID，对应到ZmskAuthentication表的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerAuth', @level2type=N'COLUMN',@level2name=N'AuthId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户端号码，对应到人脸识别设备的编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerAuth', @level2type=N'COLUMN',@level2name=N'ClientCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工人考勤信息，原始信息整理过后的考勤信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkerAuth'
GO
/****** Object:  Table [dbo].[FaceDeviceWorker]    Script Date: 04/08/2019 18:12:25 ******/
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaceDeviceWorker', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份ID，相当于自动增长的int主键，可不管' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaceDeviceWorker', @level2type=N'COLUMN',@level2name=N'IdentityId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工人ID，关联到工人表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaceDeviceWorker', @level2type=N'COLUMN',@level2name=N'WorkerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备ID，关联到设备表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaceDeviceWorker', @level2type=N'COLUMN',@level2name=N'DeviceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态，对应枚举:FaceWorkerState' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaceDeviceWorker', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'错误代码，设备处理数据后如果出现异常，则返回相应代码，存到此处' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaceDeviceWorker', @level2type=N'COLUMN',@level2name=N'ErrorCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaceDeviceWorker', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最新修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaceDeviceWorker', @level2type=N'COLUMN',@level2name=N'ModifiedTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaceDeviceWorker', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备工人表，记录设备与工人的关联和数据的状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaceDeviceWorker'
GO
/****** Object:  Default [DF_FaceDevice_IsDelete]    Script Date: 04/08/2019 18:12:25 ******/
ALTER TABLE [dbo].[FaceDevice] ADD  CONSTRAINT [DF_FaceDevice_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
/****** Object:  Default [DF_FaceDeviceWorker_CreateTime]    Script Date: 04/08/2019 18:12:25 ******/
ALTER TABLE [dbo].[FaceDeviceWorker] ADD  CONSTRAINT [DF_FaceDeviceWorker_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_FaceDeviceWorker_ModifiedTime]    Script Date: 04/08/2019 18:12:25 ******/
ALTER TABLE [dbo].[FaceDeviceWorker] ADD  CONSTRAINT [DF_FaceDeviceWorker_ModifiedTime]  DEFAULT (getdate()) FOR [ModifiedTime]
GO
/****** Object:  Default [DF_FaceDeviceWorker_IsDelete]    Script Date: 04/08/2019 18:12:25 ******/
ALTER TABLE [dbo].[FaceDeviceWorker] ADD  CONSTRAINT [DF_FaceDeviceWorker_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
/****** Object:  Default [DF_Team_IsDelete]    Script Date: 04/08/2019 18:12:25 ******/
ALTER TABLE [dbo].[Team] ADD  CONSTRAINT [DF_Team_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
/****** Object:  Default [DF_TeamWorkType_CreateTime]    Script Date: 04/08/2019 18:12:25 ******/
ALTER TABLE [dbo].[TeamWorkType] ADD  CONSTRAINT [DF_TeamWorkType_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_TeamWorkType_IsDelete]    Script Date: 04/08/2019 18:12:25 ******/
ALTER TABLE [dbo].[TeamWorkType] ADD  CONSTRAINT [DF_TeamWorkType_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
/****** Object:  Default [DF_Worker_CreateTime]    Script Date: 04/08/2019 18:12:25 ******/
ALTER TABLE [dbo].[Worker] ADD  CONSTRAINT [DF_Worker_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_Worker_ModifiedTime]    Script Date: 04/08/2019 18:12:25 ******/
ALTER TABLE [dbo].[Worker] ADD  CONSTRAINT [DF_Worker_ModifiedTime]  DEFAULT (getdate()) FOR [ModifiedTime]
GO
/****** Object:  Default [DF_Worker_IsDelete]    Script Date: 04/08/2019 18:12:25 ******/
ALTER TABLE [dbo].[Worker] ADD  CONSTRAINT [DF_Worker_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
/****** Object:  Default [DF_WorkerAuth_CreateTime]    Script Date: 04/08/2019 18:12:25 ******/
ALTER TABLE [dbo].[WorkerAuth] ADD  CONSTRAINT [DF_WorkerAuth_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_WorkerIdentity_CreateTime]    Script Date: 04/08/2019 18:12:25 ******/
ALTER TABLE [dbo].[WorkerIdentity] ADD  CONSTRAINT [DF_WorkerIdentity_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_WorkerIdentity_IsDelete]    Script Date: 04/08/2019 18:12:25 ******/
ALTER TABLE [dbo].[WorkerIdentity] ADD  CONSTRAINT [DF_WorkerIdentity_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
/****** Object:  Default [DF_ZmskAuthentication_CreateTime]    Script Date: 04/08/2019 18:12:25 ******/
ALTER TABLE [dbo].[ZmskAuthentication] ADD  CONSTRAINT [DF_ZmskAuthentication_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  ForeignKey [FK_FaceDeviceWorker_FaceDevice]    Script Date: 04/08/2019 18:12:25 ******/
ALTER TABLE [dbo].[FaceDeviceWorker]  WITH CHECK ADD  CONSTRAINT [FK_FaceDeviceWorker_FaceDevice] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[FaceDevice] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FaceDeviceWorker] CHECK CONSTRAINT [FK_FaceDeviceWorker_FaceDevice]
GO
/****** Object:  ForeignKey [FK_FaceDeviceWorker_Worker]    Script Date: 04/08/2019 18:12:25 ******/
ALTER TABLE [dbo].[FaceDeviceWorker]  WITH CHECK ADD  CONSTRAINT [FK_FaceDeviceWorker_Worker] FOREIGN KEY([WorkerId])
REFERENCES [dbo].[Worker] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FaceDeviceWorker] CHECK CONSTRAINT [FK_FaceDeviceWorker_Worker]
GO
/****** Object:  ForeignKey [FK_Team_TeamWorkType]    Script Date: 04/08/2019 18:12:25 ******/
ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [FK_Team_TeamWorkType] FOREIGN KEY([WorkTypeId])
REFERENCES [dbo].[TeamWorkType] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Team] CHECK CONSTRAINT [FK_Team_TeamWorkType]
GO
/****** Object:  ForeignKey [FK_TeamSync_Team]    Script Date: 04/08/2019 18:12:25 ******/
ALTER TABLE [dbo].[TeamSync]  WITH CHECK ADD  CONSTRAINT [FK_TeamSync_Team] FOREIGN KEY([Id])
REFERENCES [dbo].[Team] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeamSync] CHECK CONSTRAINT [FK_TeamSync_Team]
GO
/****** Object:  ForeignKey [FK_Worker_Team]    Script Date: 04/08/2019 18:12:25 ******/
ALTER TABLE [dbo].[Worker]  WITH CHECK ADD  CONSTRAINT [FK_Worker_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Worker] CHECK CONSTRAINT [FK_Worker_Team]
GO
/****** Object:  ForeignKey [FK_Worker_WorkerIdentity]    Script Date: 04/08/2019 18:12:25 ******/
ALTER TABLE [dbo].[Worker]  WITH CHECK ADD  CONSTRAINT [FK_Worker_WorkerIdentity] FOREIGN KEY([IdentityId])
REFERENCES [dbo].[WorkerIdentity] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Worker] CHECK CONSTRAINT [FK_Worker_WorkerIdentity]
GO
/****** Object:  ForeignKey [FK_WorkerAuth_Worker]    Script Date: 04/08/2019 18:12:25 ******/
ALTER TABLE [dbo].[WorkerAuth]  WITH CHECK ADD  CONSTRAINT [FK_WorkerAuth_Worker] FOREIGN KEY([WorkerId])
REFERENCES [dbo].[Worker] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WorkerAuth] CHECK CONSTRAINT [FK_WorkerAuth_Worker]
GO
/****** Object:  ForeignKey [FK_WorkerSync_Worker]    Script Date: 04/08/2019 18:12:25 ******/
ALTER TABLE [dbo].[WorkerSync]  WITH CHECK ADD  CONSTRAINT [FK_WorkerSync_Worker] FOREIGN KEY([Id])
REFERENCES [dbo].[Worker] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WorkerSync] CHECK CONSTRAINT [FK_WorkerSync_Worker]
GO
/****** Object:  ForeignKey [FK_ZmskAuthenticationSync_ZmskAuthentication]    Script Date: 04/08/2019 18:12:25 ******/
ALTER TABLE [dbo].[ZmskAuthenticationSync]  WITH CHECK ADD  CONSTRAINT [FK_ZmskAuthenticationSync_ZmskAuthentication] FOREIGN KEY([Id])
REFERENCES [dbo].[ZmskAuthentication] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ZmskAuthenticationSync] CHECK CONSTRAINT [FK_ZmskAuthenticationSync_ZmskAuthentication]
GO
