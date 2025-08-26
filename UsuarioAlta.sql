CREATE PROCEDURE SP_Usuario_Alta
    @Nombre     VARCHAR(50),
    @Edad       INT,
    @Correo     VARCHAR(50),
    @FechaAlta  DATETIME
AS
BEGIN
    INSERT INTO Usuario (
        Nombre,
        Edad,
        Correo,
        FechaAlta
    )
    VALUES (
        @Nombre,
        @Edad,
        @Correo,
        @FechaAlta
    );
END;
