using System.Data.SqlClient; 
using System.Data;
using Proyecto_Final_Matias_Candia.Objetos;

namespace Proyecto_Final_Matias_Candia.ADO.NET
{
    public static class VentaHandler
    {
        public const string connectionString = "Server=localhost;Database=SistemaGestion;Trusted_Connection=True";

        public static long CargarVenta(Venta venta)
        {
            bool resultado = false;
            long idVenta = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[Venta] (Comentarios) " + 
                                        "VALUES (@comentarios) " +
                                        "SELECT @@IDENTITY";

                var parameterComentarios = new SqlParameter("comentarios", SqlDbType.VarChar);
                parameterComentarios.Value = venta.Comentarios;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(parameterComentarios);
                    idVenta = Convert.ToInt64(sqlCommand.ExecuteScalar());
                }
                sqlConnection.Close();
            }
            return idVenta;
        }
    }
}
