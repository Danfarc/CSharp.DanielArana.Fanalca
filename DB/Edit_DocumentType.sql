USE [Fanalca]
GO
/****** Object:  StoredProcedure [dbo].[Edit_DocumentType]    Script Date: 22/11/2021 8:54:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Edit_DocumentType]
 @Id int,
 @Name varchar(50) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	UPDATE DocumentType SET Name=@Name WHERE Id = @Id
	SELECT * FROM DocumentType WITH (NOLOCK) WHERE Id = @Id

END
