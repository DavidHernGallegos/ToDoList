using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public string? Nombre { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public List<object> Usuarios { get; set; }


        public static Dictionary<string, object> GetUsuarioByEmail (string email)
        {
            BL.Usuario usuario = new BL.Usuario();
            Dictionary<string,object> diccionario = new Dictionary<string, object> { {"Usuario", usuario },{"Resultado", false },{"Mensaje", "" } };
            try
            {
                using (DL.ToDoListBdContext context = new DL.ToDoListBdContext())
                {
                    var query = (from User in context.Usuarios
                                 where User.Email == email
                                 select new
                                 {
                                     IdUsuario = User.IdUsuario,
                                     Nombre = User.Nombre,
                                     Password = User.Password,
                                     Email =  User.Email
                                 }).SingleOrDefault();

                    if (query != null)
                    {
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        usuario.Nombre = query.Nombre;

                        diccionario["Usuario"] = usuario;
                        diccionario["Resultado"] = true;
                        diccionario["Mensaje"] = "El usuario si se encuentra";
                    }
                    else
                    {
                        diccionario["Mensaje"] = "El usuario no se encuentra";
                    }
                }
            }
            catch(Exception ex)
            {
                diccionario["Mensaje"] = "El usuario no se encuentra" + ex;
            }

            return diccionario;
        }


        public static Dictionary<string, object> Login(string email, string password)
        {
            BL.Usuario usuario = new BL.Usuario();
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Usuario", usuario }, { "Resultado", false }, { "Mensaje", "" } };
            Dictionary<string,object> diccionarioUser = BL.Usuario.GetUsuarioByEmail(email);
            bool resultado = (bool)diccionarioUser["Resultado"]; 

            try
            {
                using (DL.ToDoListBdContext context = new DL.ToDoListBdContext())
                {
                    
                    if(resultado)
                    {
                        usuario = (BL.Usuario)diccionarioUser["Usuario"];

                        if(usuario.Password== password)
                        {

                            diccionario["Usuario"] = usuario;
                            diccionario["Resultado"] = true;
                            diccionario["Mensaje"] = "Has accesado al sistema";
                        }
                        else
                        {
                            diccionario["Mensaje"] = "Contraseña incorrecta";
                        }
                    }

                    else
                    {
                        diccionario["Mensaje"] = "correo  incorrecto";
                    }



                }
            }
            catch (Exception ex)
            {
                diccionario["Mensaje"] = "El usuario no se encuentra" + ex;
            }

            return diccionario;
        }
    }
}
