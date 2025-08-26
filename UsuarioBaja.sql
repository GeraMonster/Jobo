CREATE PROCEDURE SP_Usuario_Baja
    @ID_usuario INT
AS
BEGIN
    DELETE FROM Usuario
    WHERE ID_usuario = @ID_usuario;
END;
