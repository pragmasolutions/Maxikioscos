BEGIN TRANSACTION
ALTER TABLE dbo.Cuenta ADD
	MaxiKioscoIdentifierPredeterminadoTransferencias uniqueidentifier NULL
COMMIT
