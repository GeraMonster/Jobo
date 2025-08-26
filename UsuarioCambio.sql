CREATE PROCEDURE SP_Usuario_Cambio
    @ID_usuario INT,
    @Nombre     VARCHAR(50) = NULL,
    @Edad       INT = NULL, 
    @Correo     VARCHAR(50) = NULL
AS
BEGIN
    IF @Edad IS NOT NULL
    BEGIN
        UPDATE Usuario
        SET Edad = @Edad
        WHERE ID_usuario = @ID_usuario;
    END;

    IF @Correo IS NOT NULL
    BEGIN
        UPDATE Usuario
        SET Correo = @Correo
        WHERE ID_usuario = @ID_usuario;
    END;

    IF @Nombre IS NOT NULL
    BEGIN
        UPDATE Usuario
        SET Nombre = @Nombre
        WHERE ID_usuario = @ID_usuario;
    END;
END;
