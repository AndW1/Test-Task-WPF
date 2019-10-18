CREATE DATABASE [TestTask_WPF]
GO

/****** Object:  Table [dbo].[TaskNodes]    Script Date: 18.10.2019 8:02:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TaskNodes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[DateStart] [datetime2](7) NULL,
	[DateFinish] [datetime2](7) NULL,
	[DateCreate] [datetime2](7) NULL,
	[Status] [nvarchar](50) NOT NULL,
	[IsStart] [bit] NULL,
	[IsFinish] [bit] NULL,
	[IsProgress] [bit] NULL
) ON [PRIMARY]
GO


