using System.Data.SqlClient;
using System.Data;
using Proyecto_Final_Matias_Candia.Objetos;

namespace Proyecto_Final_Matias_Candia.ADO.NET
{
    public static class ProductoHandler
    {
        public const string connectionString = "Server=localhost;Database=SistemaGestion;Trusted_Connection=True";

        public static bool CrearProducto(Producto producto)
        {
            bool resultado = false; 
            long idProducto = 0;    

            using (SqlConnection sqlConnection = new SqlConnection(connectionString)) 
            {
                string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[Producto] (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) " + 
                                        "VALUES (@descripciones, @costo, @precioVenta, @stock, @idUsuario) " +
                                        "SELECT @@IDENTITY";

                // Creo y defino todos los objetos SqlParameter necesarios para definir queryInsert.
                var parameterDescripciones = new SqlParameter("descripciones", SqlDbType.VarChar);  
                parameterDescripciones.Value = producto.Descripcion;                                

                var parameterCosto = new SqlParameter("costo", SqlDbType.Money);
                parameterCosto.Value = producto.Costo;

                var parameterPrecioVenta = new SqlParameter("precioVenta", SqlDbType.Money);
                parameterPrecioVenta.Value = producto.PrecioDeVenta;

                var parameterStock = new SqlParameter("stock", SqlDbType.Int);
                parameterStock.Value = producto.Stock;

                var parameterIdUsuario = new SqlParameter("idUsuario", SqlDbType.BigInt);
                parameterIdUsuario.Value = producto.IdUsuario;

                sqlConnection.Open(); 

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection)) 
                {
                    sqlCommand.Parameters.Add(parameterDescripciones); 
                    sqlCommand.Parameters.Add(parameterCosto);
                    sqlCommand.Parameters.Add(parameterPrecioVenta);
                    sqlCommand.Parameters.Add(parameterStock);
                    sqlCommand.Parameters.Add(parameterIdUsuario);
                    idProducto = Convert.ToInt64(sqlCommand.ExecuteScalar());  
                }
                sqlConnection.Close(); 
            }
            if (idProducto != 0) 
            {
                resultado = true; 
            }
            return resultado;
        }

        public static bool ModificarProducto(Producto producto)
        {
            bool resultado = false; 
            int rowsAffected = 0;   

            if (producto.Id <= 0) 
            {
                return false;
            }

            using (SqlConnection sqlConnection = new SqlConnection(connectionString)) 
            {
                string queryUpdate = "UPDATE [SistemaGestion].[dbo].[Producto] " + 
                                        "SET Descripciones = @descripciones, " +
                                        "Costo = @costo, " +
                                        "PrecioVenta = @precioVenta, " +
                                        "stock = @Stock, " +
                                        "IdUsuario = @idUsuario " +
                                        "WHERE Id = @id";

                var parameterId = new SqlParameter("id", SqlDbType.BigInt); 
                parameterId.Value = producto.Id;                            

                var parameterDescripciones = new SqlParameter("descripciones", SqlDbType.VarChar);
                parameterDescripciones.Value = producto.Descripcion;

                var parameterCosto = new SqlParameter("costo", SqlDbType.Money);
                parameterCosto.Value = producto.Costo;

                var parameterPrecioVenta = new SqlParameter("precioVenta", SqlDbType.Money);
                parameterPrecioVenta.Value = producto.PrecioDeVenta;

                var parameterStock = new SqlParameter("stock", SqlDbType.Int);
                parameterStock.Value = producto.Stock;

                var parameterIdUsuario = new SqlParameter("idUsuario", SqlDbType.BigInt);
                parameterIdUsuario.Value = producto.IdUsuario;

                sqlConnection.Open(); 

                using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))  
                {
                    sqlCommand.Parameters.Add(parameterId); 
                    sqlCommand.Parameters.Add(parameterDescripciones);
                    sqlCommand.Parameters.Add(parameterCosto);
                    sqlCommand.Parameters.Add(parameterPrecioVenta);
                    sqlCommand.Parameters.Add(parameterStock);
                    sqlCommand.Parameters.Add(parameterIdUsuario);
                    rowsAffected = sqlCommand.ExecuteNonQuery(); 
                }
                sqlConnection.Close(); 
            }
            if (rowsAffected == 1) 
            {
                resultado = true; 
            }
            return resultado;
        }

        public static bool EliminarProducto(long id)
        {
            if (id <= 0) 
            {
                return false;
            }

            bool resultado = false; 
            int rowsAffected = 0;   

            using (SqlConnection sqlConnection = new SqlConnection(connectionString)) 
            {
                string queryDelete = "DELETE FROM [SistemaGestion].[dbo].[Producto] " + 
                                        "WHERE Id = @id";

                var parameterId = new SqlParameter("id", SqlDbType.BigInt); 
                parameterId.Value = id;                                     

                sqlConnection.Open(); 

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection)) 
                {
                    sqlCommand.Parameters.Add(parameterId); 
                    rowsAffected = sqlCommand.ExecuteNonQuery(); 
                }
                sqlConnection.Close(); 
            }
            if (rowsAffected == 1) 
            {
                resultado = true; 
            }
            return resultado;
        }
    }
}
