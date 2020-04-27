using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace VeterinarioRifeño
{
    class Conexion
    {

        public MySqlConnection conexion;
        

        public Conexion()
        {
            conexion = new MySqlConnection("Server = 192.168.71.179; Database = veterinario; Uid = root; Pwd =; Port = 3306");
        }
        public DataTable getmascota()
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                    new MySqlCommand("SELECT * FROM mascota,", conexion);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable mascota = new DataTable();
                mascota.Load(resultado);
                conexion.Close();
                return mascota;

            }
            catch (MySqlException e)
            {
            throw e;
          }
        }
            
            
        public Boolean loginVeterinario(String LoginName, String Password)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                new MySqlCommand("SELECT * FROM usuario where LoginName = @user AND Password = @pass", conexion);
                consulta.Parameters.AddWithValue("@user", LoginName);
                consulta.Parameters.AddWithValue("@pass", Password);

                MySqlDataReader resultado = consulta.ExecuteReader();

                if (resultado.Read())
                {
                    return true;
                }

                conexion.Close();
                return false;
            }
            catch (MySqlException e)
            {
                return false;
            }
        }
        public String insertaUsuario(String LoginName, String Password, String Name)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                new MySqlCommand("INSERT INTO usuario (ID, LoginName, Password, Name) VALUES (NULL, @DNI, @Nombre, @Name)", conexion);
                consulta.Parameters.AddWithValue("@DNI", LoginName);
                consulta.Parameters.AddWithValue("@Nombre", Password);
                consulta.Parameters.AddWithValue("@Name", Name);

                consulta.ExecuteNonQuery();

                conexion.Close();
                return "ok";
            }
            catch (MySqlException e)
            {
                return "error";
            }
            
           
        }
         


    }
}
    



