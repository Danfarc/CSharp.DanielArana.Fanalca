USE [Fanalca]
GO
/****** Object:  StoredProcedure [dbo].[Get_DocumentTypeById]    Script Date: 22/11/2021 8:56:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_DocumentTypeById]
 @Id int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM DocumentType WITH(NOLOCK) where Id = @Id
END
