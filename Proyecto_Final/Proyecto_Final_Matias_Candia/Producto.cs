using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_Matias_candia
{
    internal class Producto
    {
        private int id;
        private string descripcion = string.Empty;
        private double costo;
        private double precioDeVenta;
        private int stock;
        private int idUsuario;

        public Producto(int id, string descripcion, double costo, double precioDeVenta, int stock, int idUsuario)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.costo = costo;
            this.precioDeVenta = precioDeVenta;
            this.stock = stock;
            this.idUsuario = idUsuario;
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
