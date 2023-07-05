﻿using System.Data.SqlClient; 
using System.Data;
using System;
using Proyecto_Final_Matias_Candia.Objetos;

namespace Proyecto_Final_Matias_Candia.ADO.NET
{
    public static class UsuarioHandler
    {
        public const string connectionString = "Server=localhost;Database=SistemaGestion;Trusted_Connection=True";

        public static bool ModificarUsuario(Usuario usuario)
        {
            bool resultado = false;
            int rowsAffected = 0;

            if (usuario.Id <= 0) 
            {
                return false;
            }

            if (String.IsNullOrEmpty(usuario.Nombre) ||
                String.IsNullOrEmpty(usuario.Apellido) ||
                String.IsNullOrEmpty(usuario.NombreUsuario) ||
                String.IsNullOrEmpty(usuario.Contrasena) ||
                String.IsNullOrEmpty(usuario.Mail))
            {
                return false; 
            }

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string queryUpdate = "UPDATE [SistemaGestion].[dbo].[Usuario] " + 
                                        "SET Nombre = @nombre, " +
                                            "Apellido = @apellido, " +
                                            "NombreUsuario = @nombreUsuario, " +
                                            "Contraseña = @contraseña, " +
                                            "Mail = @mail " +
                                            "WHERE Id = @id";

                var parameterNombre = new SqlParameter("nombre", SqlDbType.VarChar);
                parameterNombre.Value = usuario.Nombre;

                var parameterApellido = new SqlParameter("apellido", SqlDbType.VarChar);
                parameterApellido.Value = usuario.Apellido;

                var parameterNombreUsuario = new SqlParameter("nombreUsuario", SqlDbType.VarChar);
                parameterNombreUsuario.Value = usuario.NombreUsuario;

                var parameterContraseña = new SqlParameter("contrasena", SqlDbType.VarChar);
                parameterContraseña.Value = usuario.Contrasena;

                var parameterMail = new SqlParameter("mail", SqlDbType.VarChar);
                parameterMail.Value = usuario.Mail;

                var parameterId = new SqlParameter("id", SqlDbType.BigInt);
                parameterId.Value = usuario.Id;

                sqlConnection.Open(); 

                using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                {
                    sqlCommand.Parameters.Add(parameterNombre);
                    sqlCommand.Parameters.Add(parameterApellido);
                    sqlCommand.Parameters.Add(parameterNombreUsuario);
                    sqlCommand.Parameters.Add(parameterMail);
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
