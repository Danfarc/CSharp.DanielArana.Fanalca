USE [Fanalca]
GO

/****** Object:  Table [dbo].[SubArea]    Script Date: 22/11/2021 9:04:52 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SubArea](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AreaId] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[State] [bit] NOT NULL,
 CONSTRAINT [PK_SubArea] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SubArea] ADD  CONSTRAINT [DF_SubArea_State]  DEFAULT ((1)) FOR [State]
GO

ALTER TABLE [dbo].[SubArea]  WITH CHECK ADD  CONSTRAINT [FK_SubArea_Area] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Area] ([Id])
GO

ALTER TABLE [dbo].[SubArea] CHECK CONSTRAINT [FK_SubArea_Area]
GO


