using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_Matias_Candia.Objetos
{
    public class Producto
    {
        public int id;
        public string descripcion = string.Empty;
        public double costo;
        public double precioDeVenta;
        public int stock;
        public int idUsuario;

        public Producto()
        {
            this.id = 0;
            this.descripcion = string.Empty;
            this.costo = 0;
            this.precioDeVenta = 0;
            this.stock = 0;
            this.idUsuario = 0;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public double Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        public double PrecioDeVenta
        {
            get { return precioDeVenta; }
            set { precioDeVenta = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

    }
}

