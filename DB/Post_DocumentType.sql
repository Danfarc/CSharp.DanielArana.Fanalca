USE [Fanalca]
GO
/****** Object:  StoredProcedure [dbo].[Post_DocumentType]    Script Date: 22/11/2021 8:56:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Post_DocumentType]
 @Name varchar(50) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO DocumentType
	OUTPUT Inserted.Id, Inserted.Name
	VALUES(@Name);

END
