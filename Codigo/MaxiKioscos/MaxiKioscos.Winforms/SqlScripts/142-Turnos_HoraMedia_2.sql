UPDATE Turno
SET HoraMedia = CAST('10:00:00' as time(0))
WHERE TurnoId = 1


UPDATE Turno
SET HoraMedia = CAST('14:00:00' as time(0))
WHERE TurnoId = 2


UPDATE Turno
SET HoraMedia = CAST('18:00:00' as time(0))
WHERE TurnoId = 3


UPDATE Turno
SET HoraMedia = CAST('22:00:00' as time(0))
WHERE TurnoId = 4


UPDATE Turno
SET HoraMedia = CAST('04:00:00' as time(0)),
	Descripcion = 'Madrugada'
WHERE TurnoId = 5


ALTER TABLE Turno
ALTER COLUMN HoraMedia time(0) NOT NULL
