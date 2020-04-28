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
            conexion = new MySqlConnection("Server = 192.168.71.181; Database = veterinario; Uid = root; Pwd =; Port = 3306");
        }
        //esto es para el data grid view de la mascota
        public DataTable getmascota()
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                    new MySqlCommand("SELECT * FROM mascota", conexion);
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

        //esto es para el data grid view de la vacuna
        public DataTable getvacuna()
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                    new MySqlCommand("SELECT * FROM vacuna", conexion);
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
        public DataTable getpeluquería()
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                    new MySqlCommand("SELECT * FROM peluquería", conexion);
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
        public DataTable getguarderia()
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                    new MySqlCommand("SELECT * FROM guarderia", conexion);
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
        public String guardarmascota(String Nombre, String Especie, String Raza, String AñoNacimiento, String Propietario)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                new MySqlCommand("INSERT INTO mascota (Nombre, Especie, Raza, AñoNacimiento, Propietario) VALUES (@Nombre, @Especie, @Raza, @AñoNacimiento, @Propietario)", conexion);
                consulta.Parameters.AddWithValue("@Nombre", Nombre);
                consulta.Parameters.AddWithValue("@Especie", Especie);
                consulta.Parameters.AddWithValue("@Raza", Raza);
                consulta.Parameters.AddWithValue("@AñoNacimiento", AñoNacimiento);
                consulta.Parameters.AddWithValue("@Propietario", Propietario);
                
                consulta.ExecuteNonQuery();

                conexion.Close();
                return "se guardo correctamente";
            }
            catch (MySqlException e)
            {
                return "error";
            }


        }
        public String registrarvacuna(String Nombre_Mascota, String Tipo_Vacuna, String Semana, String Propietario)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                new MySqlCommand("INSERT INTO vacuna (Nombre_Mascota, Tipo_Vacuna, Semana, Propietario) VALUES (@Nombre_Mascota, @Tipo_Vacuna, @Semana, @Propietario)", conexion);
                consulta.Parameters.AddWithValue("@Nombre_Mascota", Nombre_Mascota);
                consulta.Parameters.AddWithValue("@Tipo_Vacuna", Tipo_Vacuna);
                consulta.Parameters.AddWithValue("@Semana", Semana);
                consulta.Parameters.AddWithValue("@Propietario", Propietario);
                

                consulta.ExecuteNonQuery();

                conexion.Close();
                return "se guardo correctamente";
            }
            catch (MySqlException e)
            {
                return "error";
            }


        }



    }
}
    



