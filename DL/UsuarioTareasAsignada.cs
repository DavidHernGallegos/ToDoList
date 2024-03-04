using System;
using System.Collections.Generic;

namespace DL;

public partial class UsuarioTareasAsignada
{
    public int? IdUsuario { get; set; }

    public int? IdTarea { get; set; }

    public virtual Tarea? IdTareaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
