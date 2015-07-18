ALTER PROCEDURE [dbo].[Sync_Membership] 
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
	    UserId int,
		CreateDate datetime,
		ConfirmationToken nvarchar(128),
		IsConfirmed bit,
		LastPasswordFailureDate datetime,
		PasswordFailuresSinceLastSuccess int,
		[Password] nvarchar(128),
		PasswordChangedDate datetime,
		PasswordSalt nvarchar(128),
		PasswordVerificationToken nvarchar(128),
		PasswordVerificationTokenExpirationDate datetime,
		UsuarioIdentifier uniqueidentifier
	);
	
	
	WITH MembershipCTE (UserId, CreateDate, ConfirmationToken,IsConfirmed, LastPasswordFailureDate, 
						PasswordFailuresSinceLastSuccess, [Password], PasswordChangedDate, PasswordSalt, 
						PasswordVerificationToken, PasswordVerificationTokenExpirationDate, UsuarioIdentifier)
	AS (
		SELECT    *
		FROM OPENXML (@idoc, '/Exportacion/Membership/M/U',2) 
				 WITH (
						UserId int '../UserId',
						CreateDate datetime '../CreateDate',
						ConfirmationToken nvarchar(128) '../ConfirmationToken',
						IsConfirmed bit '../IsConfirmed',
						LastPasswordFailureDate datetime '../LastPasswordFailureDate',
						PasswordFailuresSinceLastSuccess int '../PasswordFailuresSinceLastSuccess',
						[Password] nvarchar(128) '../Password',
						PasswordChangedDate datetime '../PasswordChangedDate',
						PasswordSalt nvarchar(128) '../PasswordSalt',
						PasswordVerificationToken nvarchar(128) '../PasswordVerificationToken',
						PasswordVerificationTokenExpirationDate datetime '../PasswordVerificationTokenExpirationDate',
						UsuarioIdentifier uniqueidentifier 'UsuarioIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM MembershipCTE
	 
	 
	 UPDATE M
	 SET CreateDate = CTE.CreateDate, 
		 ConfirmationToken = CTE.ConfirmationToken,
		 IsConfirmed = CTE.IsConfirmed, 
		 LastPasswordFailureDate = CTE.LastPasswordFailureDate, 
		 PasswordFailuresSinceLastSuccess = CTE.PasswordFailuresSinceLastSuccess, 
		 [Password] = CTE.[Password], 
		 PasswordChangedDate = CTE.PasswordChangedDate, 
		 PasswordSalt = CTE.PasswordSalt, 
		 PasswordVerificationToken = CTE.PasswordVerificationToken, 
		 PasswordVerificationTokenExpirationDate = CTE.PasswordVerificationTokenExpirationDate
	FROM @Temp CTE
		INNER JOIN Usuario U
			ON CTE.UsuarioIdentifier = U.Identifier
			INNER JOIN webpages_Membership M
		ON U.UsuarioId = M.UserId;
	 
	 INSERT INTO webpages_Membership (UserId, CreateDate, ConfirmationToken,IsConfirmed, LastPasswordFailureDate, 
						PasswordFailuresSinceLastSuccess, [Password], PasswordChangedDate, PasswordSalt, 
						PasswordVerificationToken, PasswordVerificationTokenExpirationDate)
	 SELECT (SELECT TOP 1 UsuarioId FROM Usuario WHERE Identifier = CTE.UsuarioIdentifier), 
			CreateDate, 
			ConfirmationToken,
			IsConfirmed, 
			LastPasswordFailureDate, 
			PasswordFailuresSinceLastSuccess, 
			[Password], 
			PasswordChangedDate, 
			PasswordSalt, 
			PasswordVerificationToken, 
			PasswordVerificationTokenExpirationDate 
	 FROM @Temp CTE
	 WHERE CTE.UsuarioIdentifier NOT IN (SELECT Identifier
										 FROM Usuario U
											INNER JOIN webpages_Membership M
											ON U.UsuarioId = M.UserId
										 )
	
	
END


