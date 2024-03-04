using DL;

namespace BL
{
    public class Tarea
    {
        public int IdTarea { get; set; }

        public string? Titulo { get; set; }

        public string? Descripcion { get; set; }

        public DateTime? FechaVencimiento { get; set; }

        public  BL.Estado Estado{ get; set; }

        public BL.Usuario Usuario { get; set; }

        public List<object> Tareas { get; set; }


        public static Dictionary<string,object> GetTareasByUsuario(int IdUsuario)
        {
            BL.Tarea tarea = new BL.Tarea();
            Dictionary<string,object> diccionario = new Dictionary<string, object> { {"Tarea", tarea },{"Resultado", false },{"Mensaje", "" } };

            try
            {
                using(DL.ToDoListBdContext context = new DL.ToDoListBdContext())
                {
                    tarea.Tareas = new List<object>();

                    var query = (from task in context.Tareas1 
                                 join estado in context.Estados on task.IdEstado equals estado.IdEstado
                                 where task.IdUsuario == IdUsuario
                                 select new
                                 {
                                     IdTarea = task.IdTarea,
                                     NombreTarea = task.Titulo,
                                     Descripcion = task.Descripcion,
                                     FechaVencimiento = task.FechaVencimiento,
                                     IdEstado = estado.IdEstado,
                                     Status = estado.Status
                                 }).ToList();

                    if(query != null)
                    {
                        
                    
                        foreach(var item in query)
                        {
                            BL.Tarea tareaObj = new BL.Tarea();
                            tareaObj.IdTarea = item.IdTarea;
                            tareaObj.Titulo = item.NombreTarea;
                            tareaObj.Descripcion = item.Descripcion;
                            tareaObj.FechaVencimiento = item.FechaVencimiento;
                            tareaObj.Estado = new Estado();
                            tareaObj.Estado.IdEstado = item.IdEstado;
                            tareaObj.Estado.Status = item.Status;
                            tarea.Tareas .Add(tareaObj);
                        }

                        diccionario["Tarea"] = tarea;
                        diccionario["Resultado"] = true;
                        diccionario["Mensaje"] = "Se han recuperado las tareas";
                       
                    }
                    else
                    {
                        diccionario["Mensaje"] = "No han recuperado las tareas";
                    }
                }
            }
            catch(Exception ex)
            {
                diccionario["Mensaje"] = "No se han recuperado las tareas" + ex;
            }

            return diccionario;
        }
    }
}