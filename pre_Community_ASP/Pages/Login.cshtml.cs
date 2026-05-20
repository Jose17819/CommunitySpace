using libServicios.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using preServicios_lib.Comunicaciones;

namespace pre_Community_ASP.Pages
{
    public class LoginModel : PageModel
    {

        public string Error { get; set; } = "";
        private Comunicaciones comunicaciones = new Comunicaciones();

        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPost(string Email, string Contrasena)
        {
            try
            {

                // Buscar usuario por email
                var usuarios = await comunicaciones.Ejecutar<List<Usuarios>>(
                    new Dictionary<string, object>
                    {
                        { "Url", "https://localhost:7026/Usuarios/Consultar" }
                    });

                var usuario = usuarios?.FirstOrDefault(x =>
                    x.Email == Email && x.Contraseña == Contrasena);

                if (usuario == null)
                {
                    Error = "Correo o contraseña incorrectos";
                    return Page();
                }



                // Guardar en sesión
                HttpContext.Session.SetInt32("UsuarioId", usuario.Id);
                HttpContext.Session.SetString("UsuarioNombre", usuario.Nombre!);
                HttpContext.Session.SetString("UsuarioEmail", usuario.Email!);



                // Verificar si es administrador
                var administradores = await comunicaciones.Ejecutar<List<Administradores>>(
                    new Dictionary<string, object>
                    {
                        { "Url", "https://localhost:7026/Administradores/Consultar" }
                    });


                var esAdmin = administradores?.Any(x => x.Usuario == usuario.Id);


                if (esAdmin == true)
                {
                    HttpContext.Session.SetString("Rol", "Administrador");
                    return RedirectToPage("/Admin/Dashboard");
                }
                else
                {
                    HttpContext.Session.SetString("Rol", "Residente");
                    return RedirectToPage("/Residente/Dashboard");
                }
            }
            catch
            {
                Error = "Error al conectar con el servidor. Verifica que la API esté corriendo.";
                return Page();
            }

        }
    }
}