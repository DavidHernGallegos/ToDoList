using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class TareaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll(int idUsuario) {

            Dictionary<string, object> diccionarioTareas = BL.Tarea.GetTareasByUsuario(idUsuario);
            bool resultadoTarea = (bool)diccionarioTareas["Resultado"];
            if (resultadoTarea)
            {
                BL.Tarea tarea = (BL.Tarea)diccionarioTareas["Tarea"];
                return View(tarea);
            }
            else
            {
                return View();
            }
        }
    }
}
