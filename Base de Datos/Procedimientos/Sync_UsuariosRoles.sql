
/****** Object:  StoredProcedure [dbo].[Sync_UsuariosRoles]    Script Date: 08/09/2014 15:51:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_UsuariosRoles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_UsuariosRoles]
GO


CREATE PROCEDURE [dbo].[Sync_UsuariosRoles] 
	@XML XML,
	@SobreescribirLocal bit
AS
BEGIN
	    
	DECLARE @idoc int, @doc nvarchar(MAX);
	SET @doc = (SELECT CAST(@XML as nvarchar(max)));

	--Create an internal representation of the XML document.
	EXEC sp_xml_preparedocument @idoc OUTPUT, @doc;
	-- Execute a SELECT statement that uses the OPENXML rowset provider.
	
	
	Declare @Temp table
	(
	   UserId INT,
	   RoleId INT, 
	   UsuarioIdentifier UNIQUEIDENTIFIER
	);
	
	
	WITH UsuarioRolesCTE (UserId, RoleId, UsuarioIdentifier)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/UsersInRoles/UR/U',2) 
				 WITH (UserId INT '../UserId', 
					   RoleId INT '../RoleId',
					   UsuarioIdentifier UNIQUEIDENTIFIER 'UsuarioIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM UsuarioRolesCTE
	 
	 	
	 DELETE FROM webpages_UsersInRoles
	 WHERE UserId IN (SELECT U.UsuarioId
					  FROM @Temp CTE 
						INNER JOIN Usuario U
						 ON CTE.UsuarioIdentifier = U.Identifier)
	 
	 
	 INSERT INTO webpages_UsersInRoles (UserId, RoleId)
	 SELECT U.UsuarioId,
			CTE.RoleId
	 FROM @Temp CTE
		INNER JOIN Usuario U
			ON CTE.UsuarioIdentifier = U.Identifier
	
	 
	
END




GO


