USE [Fanalca]
GO
/****** Object:  StoredProcedure [dbo].[Delete_DocumentType]    Script Date: 22/11/2021 8:53:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Delete_DocumentType]
 @Id int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE DocumentType WHERE Id =@Id
	RETURN 1
END
