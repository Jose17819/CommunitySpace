using libServicios.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using preServicios_lib.Comunicaciones;

namespace pre_Community_ASP.Pages
{
    public class RegistroModel : PageModel
    {

        [BindProperty] public string? Nombre { get; set; }
        [BindProperty] public string? Apellido { get; set; }
        [BindProperty] public string? Email { get; set; }
        [BindProperty] public string? Telefono { get; set; }
        [BindProperty] public string? Contraseña { get; set; }

        public string Error { get; set; } = "";
        public string Exito { get; set; } = "";

        private Comunicaciones comunicaciones = new Comunicaciones();

        public void OnGet() { }



        public async Task OnPostBtClean()
        {
            Nombre = string.Empty;
            Apellido = string.Empty;
            Email = string.Empty;
            Telefono = string.Empty;
            Contraseña = string.Empty;
        }



        public async Task OnPostBtRegistrar()
        {
            try
            {

                if (string.IsNullOrEmpty(Nombre) ||
                    string.IsNullOrEmpty(Apellido) ||
                    string.IsNullOrEmpty(Email) ||
                    string.IsNullOrEmpty(Contraseña))
                {
                    Error = "Por favor completa todos los campos obligatorios";
                    return;
                }


                var usuario = new Usuarios
                {
                    Id = 0,
                    Nombre = Nombre,
                    Apellido = Apellido,
                    Email = Email,
                    Telefono = Telefono,
                    Contraseña = Contraseña
                };


                var resultado = await comunicaciones.Ejecutar<Usuarios>(
                    new Dictionary<string, object>
                    {
                        { "Url", "http://localhost:5124/Usuarios/Guardar" },
                        { "Entidad", usuario }
                    });


                if (resultado != null && resultado.Id > 0)
                {
                    Exito = "¡Cuenta creada exitosamente! Ya puedes iniciar sesión.";
                    await OnPostBtClean();
                }
                else
                {
                    Error = "No se pudo crear la cuenta. Intenta de nuevo.";
                }
            }
            catch (Exception)
            {
                Error = "Error al conectar con el servidor.";
            }
        }



    }
}