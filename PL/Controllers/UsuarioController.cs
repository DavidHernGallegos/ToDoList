using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string email, string password)
        {
            Dictionary<string,object> diccionario = BL.Usuario.Login(email, password);
            bool resultado = (bool)diccionario["Resultado"];
            BL.Usuario usuario = (BL.Usuario)diccionario["Usuario"];
           

            if (resultado)
            {
                //Dictionary<string, object> diccionarioTareas = BL.Tarea.GetTareasByUsuario(usuario.IdUsuario);
                //bool resultadoTarea = (bool)diccionarioTareas["Resultado"];
                //if (resultadoTarea)
                //{
                //    BL.Tarea tarea = (BL.Tarea)diccionarioTareas["Tarea"];
                return RedirectToAction("GetAll", "Tarea", new { idUsuario  = usuario.IdUsuario});
                //}
                //else
                //{

                //}
                //    return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        
        }
    }
}
