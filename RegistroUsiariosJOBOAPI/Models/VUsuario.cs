using System;
using System.Collections.Generic;

namespace RegistroUsiariosJOBOAPI.Models;

public partial class VUsuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Correo { get; set; }

    public short Edad { get; set; }

    public DateTime FechaAlta { get; set; }
}
