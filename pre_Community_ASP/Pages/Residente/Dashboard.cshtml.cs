using libServicios.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using preServicios_lib.Comunicaciones;

namespace pre_Community_ASP.Pages.Residente
{
    public class DashboardModel : PageModel
    {
        private Comunicaciones comunicaciones = new Comunicaciones();
        private string UrlBase = "http://localhost:5124";

        public Usuarios? Usuario { get; set; }
        public List<Reservas>? MisReservas { get; set; }
        public List<ZonasComunes>? ZonasDisponibles { get; set; }
        public List<Sanciones>? MisSanciones { get; set; }
        public List<Pagos>? MisPagos { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var session = HttpContext.Session.GetString("Usuario");
            if (string.IsNullOrEmpty(session))
                return RedirectToPage("/Login");

            var usuarioId = HttpContext.Session.GetInt32("UsuarioId") ?? 0;

            try
            {
                // Cargar zonas disponibles
                ZonasDisponibles = await comunicaciones.Ejecutar<List<ZonasComunes>>(
                    new Dictionary<string, object>
                    {
                        { "Url", $"{UrlBase}/ZonasComunes/ConsultarDisponibles" }
                    });

                // Cargar reservas del residente
                var residentes = await comunicaciones.Ejecutar<List<Residentes>>(
                    new Dictionary<string, object>
                    {
                        { "Url", $"{UrlBase}/Residentes/Consultar" }
                    });

                var residente = residentes?.FirstOrDefault(x => x.Usuario == usuarioId);

                if (residente != null)
                {
                    HttpContext.Session.SetInt32("ResidenteId", residente.Id);

                    MisReservas = await comunicaciones.Ejecutar<List<Reservas>>(
                        new Dictionary<string, object>
                        {
                            { "Url", $"{UrlBase}/Reservas/ConsultarPorResidente?residenteId={residente.Id}" }
                        });

                    MisSanciones = await comunicaciones.Ejecutar<List<Sanciones>>(
                        new Dictionary<string, object>
                        {
                            { "Url", $"{UrlBase}/Sanciones/Consultar" }
                        });

                    MisSanciones = MisSanciones?.Where(x => x.ResidenteId == residente.Id).ToList();
                }
            }
            catch { }

            return Page();
        }
    }
}