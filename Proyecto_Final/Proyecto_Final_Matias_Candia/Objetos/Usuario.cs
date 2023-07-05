using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_Matias_Candia.Objetos
{
    public class Usuario
    {
        public int id;
        public string nombre = string.Empty;
        public string apellido = string.Empty;
        public string nombreUsuario = string.Empty;
        public string contrasena = string.Empty;
        public string mail = string.Empty;

        public Usuario() 
        { 
            this.id = 0;
            this.nombre = string.Empty;
            this.apellido = string.Empty;
            this.nombreUsuario= string.Empty;
            this.contrasena = string.Empty;
            this.mail = string.Empty;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set{ apellido = value; }
        }

        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }

        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
    }
}
