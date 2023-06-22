using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Proyecto_Final_Matias_Candia.Objetos;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto_Final_Matias_Candia.Repository
{
    public class ADO_Metodos
    {
        static string connectionString = "Server=localhost;Database=SistemaGestion;Trusted_Connection=True;";

        public static List<Producto> ObtenerProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT id, descripcion, costo, precioDeVenta, stock, idUsuario, FROM Poroducto";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Producto producto = new Producto();
                    producto.id = Convert.ToInt32(reader["id"]);
                    producto.descripcion = (string)reader["descripcion"];
                    producto.costo = Convert.ToInt32(reader["costo"]);
                    producto.precioDeVenta = Convert.ToInt32(reader["precioDeVenta"]);
                    producto.stock = Convert.ToInt32(reader["stock"]);
                    producto.idUsuario = Convert.ToInt32(reader["idUsuario"]);

                    productos.Add(producto);
                }

                reader.Close();
            }

            return productos;
        }

        public static List<ProductoVendido> ObtenerProductosVendidos()
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT id, idProducto, stock, idVenta FROM ProductoVendido";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProductoVendido productoVendido = new ProductoVendido();
                    productoVendido.id = Convert.ToInt32(reader["id"]);
                    productoVendido.idProducto = Convert.ToInt32(reader["idProducto"]);
                    productoVendido.stock = Convert.ToInt32(reader["stock"]);
                    productoVendido.idVenta = Convert.ToInt32(reader["idVenta"]);

                    productosVendidos.Add(productoVendido);
                }

                reader.Close();
            }

            return productosVendidos;
        }

        public static List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT id, nombre, apellido, nombreUsuario, contrasena, mail FROM Usuario";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.id = Convert.ToInt32(reader["id"]);
                    usuario.nombre = (string)reader["nombre"];
                    usuario.apellido = (string)reader["apellido"];
                    usuario.nombreUsuario = (string)reader["nombreUsuario"];
                    usuario.contrasena = (string)reader["contrasena"];
                    usuario.mail = (string)reader["mail"];

                    usuarios.Add(usuario);
                }

                reader.Close();
            }

            return usuarios;
        }

        public static List<Venta> ObtenerVentas()
        {
            List<Venta> ventas = new List<Venta>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT id, comentarios FROM Venta";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Venta venta = new Venta();
                    venta.id = Convert.ToInt32(reader["id"]);
                    venta.comentarios = (string)reader["comentarios"];

                    ventas.Add(venta);
                }

                reader.Close();
            }

            return ventas;
        }

        public static Usuario IniciarSesion(string nombreUsuario, string contrasena)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                const string query = @"SELECT Id, Nombre, Apellido, NombreUsuario, Contrasena, Mail FROM Usuario WHERE NombreUsuario = @nombreUsuario AND Contrasena = @contrasena";

                using(var cmd  = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario()
                            {
                                id = Convert.ToInt32(reader[0]),
                                nombre = reader.GetString(1),
                                apellido = reader.GetString(2),
                                nombreUsuario = reader.GetString(3),
                                contrasena = reader.GetString(4),
                                mail = reader.GetString(5)
                            };

                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
    }
}
