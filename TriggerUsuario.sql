CREATE TRIGGER Tr_Usuario_Alta
ON usuario 
AFTER INSERT
AS 
BEGIN 
	INSERT INTO usuarioAuditoria(
		Nombre, 
		Edad,
		Correo,
		FechaAlta,
		Movimientoauditoria,
		Usuarioauditoria,
		FechaAuditoria
	)
	SELECT 
		i.Nombre,
		i.Edad,
		i.Correo,
		i.FechaAlta,
		'A',
		CURRENT_USER,
		GETDATE()
	FROM INSERTED i;

END
