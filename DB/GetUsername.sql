USE [Fanalca]
GO
/****** Object:  StoredProcedure [dbo].[GetUsername]    Script Date: 22/11/2021 8:56:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUsername]
	-- Add the parameters for the stored procedure here
	@Username varchar(100) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id,Nameuser,Password,State from dbo.Users where Nameuser=@Username
END
