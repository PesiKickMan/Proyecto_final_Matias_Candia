using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Matias_Candia.ADO.NET;
using Proyecto_Final_Matias_Candia.Objetos;

namespace Proyecto_Final_Matias_Candia.Controller
{
    [ApiController]
    [Route("[controller]")]
    internal class VentaController : ControllerBase
    {
        public bool CargarVenta([FromBody] List<Venta> listaDeProductosVendidos)
        {

            Producto producto = new Producto();
            Usuario usuario = new Usuario();


            Venta venta = new Venta();
            long idVenta = VentaHandler.CargarVenta(venta);

            if (idVenta >= 0)
            {
                List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
                foreach (Venta item in listaDeProductosVendidos)
                {
                    ProductoVendido productoVendido = new ProductoVendido();
                    productoVendido.IdProducto = item.Id;
                    productoVendido.IdVenta = idVenta;
                    productosVendidos.Add(productoVendido);
                }

                    bool resultado = false;

                    foreach (ProductoVendido item in productosVendidos)
                    {
                        producto.Id = item.IdProducto;
                        producto.Stock = producto.Stock - item.Stock;
                        if (resultado == false) 
                        {
                            break;
                        }
                    }
                    return resultado;

            }
            else
            {
                return false; 
            }
        }
    }
}
