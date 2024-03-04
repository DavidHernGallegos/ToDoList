using System;
using System.Collections.Generic;

namespace DL;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Tarea1> Tarea1s { get; set; } = new List<Tarea1>();
}
