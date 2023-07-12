using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsFinal
{
    public static class ClaseExtension
    {
        static string conexion;
        static SqlConnection connection;
        static SqlCommand command;


        public static string MostrarBD(this Persona a)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                command = new SqlCommand();
                conexion = @"Server=.;Database=concesionaria;Trusted_Connection=True;";
                connection = new SqlConnection(conexion);

                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM personas";
                command.Connection = connection;

                connection.Open();

                SqlDataReader lector = command.ExecuteReader();

                while (lector.Read())
                {
                    Persona item = new Persona(lector[3].ToString(), lector[1].ToString(), EIdioma.Inglés, (int)lector[2]);
                    sb.AppendLine(item.ToString());
                }

                lector.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return sb.ToString();
        }       
        public static bool AgregarBD(this Persona a)
        {
            bool todoOk = false;          
            try
            {
                command = new SqlCommand();
                conexion = @"Server=.;Database=concesionaria;Trusted_Connection=True;";
                connection = new SqlConnection(conexion);

                string query = "INSERT INTO personas (apellido,nombre,edad) VALUES (@apellido,@nombre,@edad)";

                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Connection = connection;

                connection.Open();

                command.Parameters.Clear();
                command.Parameters.AddWithValue("@apellido", a.apellido);
                command.Parameters.AddWithValue("@nombre", a.nombre);
                command.Parameters.AddWithValue("@edad", a.edad);

                command.ExecuteNonQuery();
                
                todoOk = true;

            }
            catch (Exception)
            {
                throw new Exception();
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return todoOk;
        }
    }  
}
