using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_Matias_Candia
{
    internal class Usuario
    {
        private int id;
        private string nombre = string.Empty;
        private string apellido = string.Empty;
        private string nombreUsuario = string.Empty;
        private string contraseña = string.Empty;
        private string mail = string.Empty;

        public Usuario(int id, string nombre, string apellido, string nombreUsuario, string contraseña, string mail) 
        { 
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.nombreUsuario= nombreUsuario;
            this.contraseña = contraseña;
            this.mail = mail;
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

        public string Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
    }
}
