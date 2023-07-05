using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_Matias_Candia.Objetos
{
    public class ProductoVendido
    {
        public int id;
        public int idProducto;
        public int stock;
        public long idVenta;

        public ProductoVendido()
        {
            this.id = 0;
            this.idProducto = 0;
            this.stock = 0;
            this.idVenta = 0;
        }

        public int Id 
        {
            get { return id; }
            set { id = value; }
        }

        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public long IdVenta
        {
            get { return idVenta; }
            set { idVenta = value; }
        }
    }


}
