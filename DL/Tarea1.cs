using System;
using System.Collections.Generic;

namespace DL;

public partial class Tarea1
{
    public int IdTarea { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public int? IdEstado { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Estado? IdEstadoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
