using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_Matias_Candia.Objetos
{
    public class Venta
    {
        public int id;
        public string comentarios = string.Empty;
        public int idUsuario;

        public Venta()
        {
            this.id = 0;
            this.comentarios = string.Empty;
            this.idUsuario = 0;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Comentarios
        {
            get { return comentarios; }
            set { comentarios = value; }
        }

        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
    }
}
