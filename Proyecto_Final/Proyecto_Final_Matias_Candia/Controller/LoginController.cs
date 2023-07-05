using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Matias_Candia.Objetos;
using Proyecto_Final_Matias_Candia.Repository;

namespace Proyecto_Final_Matias_Candia.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpGet(Name = "InicioDeSesion")]
        public Usuario InicioDeSesion(string nombreUsuario, string pass)
        {
            return ADO_Metodos.IniciarSesion(nombreUsuario, pass);
        }
    }
}
