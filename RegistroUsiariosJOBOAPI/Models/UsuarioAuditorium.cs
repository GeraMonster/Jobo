using System;
using System.Collections.Generic;

namespace RegistroUsiariosJOBOAPI.Models;

public partial class UsuarioAuditorium
{
    public int IdUsuarioauditoria { get; set; }

    public string? Nombre { get; set; }

    public short? Edad { get; set; }

    public string? Correo { get; set; }

    public DateTime? FechaAlta { get; set; }

    public string Movimientoauditoria { get; set; } = null!;

    public string Usuarioauditoria { get; set; } = null!;

    public DateTime FechaAuditoria { get; set; }
}
