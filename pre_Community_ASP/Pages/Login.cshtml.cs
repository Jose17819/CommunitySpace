using libServicios.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using preServicios_lib.Comunicaciones;

namespace pre_Community_ASP.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty] public string? Email { get; set; }
        [BindProperty] public string? Contraseña { get; set; }
        public string Error { get; set; } = "";
        private Comunicaciones comunicaciones = new Comunicaciones();

        public void OnGet()
        {
            // Si ya hay sesión activa redirige directo
            var session = HttpContext.Session.GetString("Usuario");
            if (!string.IsNullOrEmpty(session))
            {
                var rol = HttpContext.Session.GetString("Rol");
                if (rol == "Administrador")
                    HttpContext.Response.Redirect("/Admin/Dashboard");
                else
                    HttpContext.Response.Redirect("/Residente/Dashboard");
            }
        }

        public async Task OnPostBtClean()
        {
            Email = string.Empty;
            Contraseña = string.Empty;
        }

        public async Task<IActionResult> OnPostBtEnter()
        {


            try
            {
                if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Contraseña))
                {
                    Error = "Por favor ingresa tu correo y contraseña";
                    return Page();
                }

                var usuarios = await comunicaciones.Ejecutar<List<Usuarios>>(
                    new Dictionary<string, object>
                    {
                        { "Url", "http://localhost:5124/Usuarios/Consultar" }
                    });

                var usuario = usuarios?.FirstOrDefault(x =>
                    x.Email == Email && x.Contraseña == Contraseña);

                if (usuario == null)
                {
                    Error = "Correo o contraseña incorrectos";
                    return Page();
                }

                // Guardar sesión — igual que el profesor
                HttpContext.Session.SetString("Usuario", usuario.Email!);
                HttpContext.Session.SetString("UsuarioNombre", usuario.Nombre!);
                HttpContext.Session.SetInt32("UsuarioId", usuario.Id);

                // Verificar rol
                var administradores = await comunicaciones.Ejecutar<List<Administradores>>(
                    new Dictionary<string, object>
                    {
                        { "Url", "http://localhost:5124/Administradores/Consultar" }
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
            catch (Exception ex)
            {
                Error = "Error al conectar con el servidor";
                return Page();
            }


        }
    }
}