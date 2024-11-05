using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_de_Personas
{
    static class CPersonaAccesoDatos
    {
        //private SqlConnection connection = new SqlConnection("Data Source =GERALD\\MYGERALDDATABASE;Database=UTN_DB; User Id = sa; Password=root");
        static string connectionString;
        static SqlCommand command;
        static SqlConnection connection;



        static CPersonaAccesoDatos()
        {
            connectionString = "Server=GERALD\\MYGERALDDATABASE;Database=UTN_DB;UID=sa;PWD=root;TrustServerCertificate=True";
            //;                 //"Server=GERALD\\MYGERALDDATABASE;Database=myDataBase;User Id=myUsername;Password=myPassword;";
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();

            command.Connection = connection;
            command.CommandType= System.Data.CommandType.Text;
        }

        public static List<CPersona> Leer()
        {
            List<CPersona> personas = new List<CPersona>();

            try
            {
                connection.Open();
                command.CommandText = "SELECT *FROM PERSONAS";

                SqlDataReader datareader = command.ExecuteReader();

                while (datareader.Read())
                {
                    personas.Add( new CPersona(Convert.ToUInt32(datareader["id"]),datareader["nombre"].ToString(), datareader["apellido"].ToString()));
                    
                }
                return personas;
            }
            catch(Exception ) 
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public static void EliminarPersonaID(int id)
        {
            try
            {
                command.Parameters.Clear();// Cuando trabajos con clases estatica es necesario para limpiar el buffer
                connection.Open();
                command.CommandText = $"DELETE *from PERSONAS WHERE ID =@id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                connection.Close() ;
            }
        }

        public static void Guardar(CPersona persona)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"INSERT INTO PERSONAS (nombre,apellido) VALUES (@nombre,@apellido)";
                command.Parameters.AddWithValue("@nombre", persona.Nombre);
                command.Parameters.AddWithValue("@apellido", persona.Apellido);
                command.ExecuteNonQuery();
            }
            catch (Exception )
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
