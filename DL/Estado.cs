using System;
using System.Collections.Generic;

namespace DL;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Tarea1> Tarea1s { get; set; } = new List<Tarea1>();

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
