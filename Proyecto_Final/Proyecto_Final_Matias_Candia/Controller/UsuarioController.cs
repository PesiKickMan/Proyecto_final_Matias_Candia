using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Matias_Candia.ADO.NET;
using Proyecto_Final_Matias_Candia.Objetos;

namespace Proyecto_Final_Matias_Candia.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpPut(Name = "ModificarUsuario")]
        public bool ModificarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                Usuario usuarioExistente = new Usuario();
                if (usuarioExistente.Id <= 0)
                {
                    return false; 
                }
                else
                {
                    return UsuarioHandler.ModificarUsuario(
                    new Usuario
                    {
                        Id = usuario.Id,
                        Nombre = usuario.Nombre,
                        Apellido = usuario.Apellido,
                        NombreUsuario = usuario.NombreUsuario,
                        Contrasena = usuario.Contrasena,
                        Mail = usuario.Mail
                    }
                    );
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
