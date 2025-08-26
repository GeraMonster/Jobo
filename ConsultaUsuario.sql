CREATE PROCEDURE SP_Usuario_Consulta
    @ID_usuario int = null
AS
BEGIN
    IF @ID_usuario IS NOT NULL
    BEGIN
        SELECT Nombre, Edad, Correo, FechaAlta
        FROM V_Usuario
        WHERE ID_usuario = @ID_usuario;
    END
    ELSE
    BEGIN
        SELECT Nombre, Edad, Correo, FechaAlta
        FROM V_Usuario;
    END
END;
