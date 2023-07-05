using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Matias_Candia.ADO.NET;
using Proyecto_Final_Matias_Candia.Objetos;
using Proyecto_Final_Matias_Candia.Repository;

namespace Proyecto_Final_Matias_Candia.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        [HttpPut(Name = "ModificarProducto")]
        public bool ModificarProducto([FromBody] Producto producto)
        {
            try
            {
                return ProductoHandler.ModificarProducto(
                    new Producto
                    {
                        Id = producto.Id,
                        Descripcion = producto.Descripcion,
                        Costo = producto.Costo,
                        PrecioDeVenta = producto.PrecioDeVenta,
                        Stock = producto.Stock,
                        IdUsuario = producto.IdUsuario,
                    }
                  );
            }
            catch ( Exception ex )
            {
                return false;
            }
        }

        public bool CrearProducto([FromBody] Producto producto)
        {
            try
            {
                return ProductoHandler.CrearProducto(
                    new Producto
                    {
                        Descripcion = producto.Descripcion,
                        Costo = producto.Costo,
                        PrecioDeVenta = producto.PrecioDeVenta,
                        Stock = producto.Stock,
                        IdUsuario = producto.IdUsuario
                    }
                );
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EliminarProducto([FromBody] long idProducto)
        {
            try
            {
                return ProductoHandler.EliminarProducto(idProducto);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
