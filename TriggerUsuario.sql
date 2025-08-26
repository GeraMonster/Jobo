CREATE TRIGGER Tr_Usuario_Alta
ON usuario 
AFTER INSERT
AS 
BEGIN 
	INSERT INTO usuarioAuditoria(
		ID_usuarioauditoria,
		Nombre, 
		Edad,
		Correo,
		FechaAlta,
		Movimientoauditoria,
		Usuarioauditoria,
		FechaAuditoria
	)
	SELECT 
		i.ID_usuario,
		i.Nombre,
		i.Edad,
		i.Correo,
		i.FechaAlta,
		'A',
		CURRENT_USER,
		GETDATE()
	FROM INSERTED i;
END