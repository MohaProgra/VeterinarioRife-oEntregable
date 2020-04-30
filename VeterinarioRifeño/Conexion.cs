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
            conexion = new MySqlConnection("Server = 192.168.71.187; Database = veterinario; Uid = root; Pwd =; Port = 3306");
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

        //esto es para el data grid view de la peluquería
        public DataTable getpeluqueria()
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                    new MySqlCommand("SELECT * FROM peluqueria", conexion);
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

        ////esto es para el data grid view de la agenda
        public DataTable getagenda()
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                    new MySqlCommand("SELECT * FROM agenda", conexion);
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

        ////esto es para el data grid view de la guarderia
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
                return "ENORANUENA: EL REGISTRO SE GUARDO CORRECTAMENTE";
            }
            catch (MySqlException e)
            {
                return "error";
            }
            
           
        }
        public String guardarmascota(String Nombre, String Especie, String Raza, String FechaNacimiento, String Propietario)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                new MySqlCommand("INSERT INTO mascota (Nombre, Especie, Raza, FechaNacimiento, Propietario) VALUES (@Nombre, @Especie, @Raza, @FechaNacimiento, @Propietario)", conexion);
                consulta.Parameters.AddWithValue("@Nombre", Nombre);
                consulta.Parameters.AddWithValue("@Especie", Especie);
                consulta.Parameters.AddWithValue("@Raza", Raza);
                consulta.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
                consulta.Parameters.AddWithValue("@Propietario", Propietario);
                
                consulta.ExecuteNonQuery();

                conexion.Close();
                return "ENORANUENA: EL REGISTRO SE GUARDO CORRECTAMENTE";
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
                return "ENORANUENA: EL REGISTRO SE GUARDO CORRECTAMENTE";
            }
            catch (MySqlException e)
            {
                return "error";
            }
        }
        public String registrarpeluqueria(String Nombre_Mascota, String Tipo_Corte, String Nombre_Peluquero, String Propietario)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                new MySqlCommand("INSERT INTO peluqueria (Nombre_Mascota, Tipo_Corte, Nombre_Peluquero, Propietario) VALUES (@Nombre_Mascota, @Tipo_Corte, @Nombre_Peluquero, @Propietario)", conexion);
                consulta.Parameters.AddWithValue("@Nombre_Mascota", Nombre_Mascota);
                consulta.Parameters.AddWithValue("@Tipo_Corte", Tipo_Corte);
                consulta.Parameters.AddWithValue("@Nombre_Peluquero", Nombre_Peluquero);
                consulta.Parameters.AddWithValue("@Propietario", Propietario);


                consulta.ExecuteNonQuery();

                conexion.Close();
                return "ENORANUENA: EL REGISTRO SE GUARDO CORRECTAMENTE";
            }
            catch (MySqlException e)
            {
                return "error";
            }
        }
           
        public String registrarcita(String Nombre_Mascota, String Dia, String Hora, String Propietario)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                new MySqlCommand("INSERT INTO agenda (Nombre_Mascota, Dia, Hora, Propietario) VALUES (@Nombre_Mascota, @Dia, @Hora, @Propietario)", conexion);
                consulta.Parameters.AddWithValue("@Nombre_Mascota", Nombre_Mascota);
                consulta.Parameters.AddWithValue("@Dia", Dia);
                consulta.Parameters.AddWithValue("@Hora", Hora);
                consulta.Parameters.AddWithValue("@Propietario", Propietario);


                consulta.ExecuteNonQuery();

                conexion.Close();
                return "ENORANUENA: EL REGISTRO SE GUARDO CORRECTAMENTE";
            }
            catch (MySqlException e)
            {
                return "error";
            }


        }
        public String registrarguarderia(String Nombre_Mascota, String Hora_Entrada, String Hora_Salida, String Responsable)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                new MySqlCommand("INSERT INTO guarderia (Nombre_Mascota, Hora_Entrada, Hora_Salida, Responsable) VALUES (@Nombre_Mascota, @Hora_Entrada, @Hora_Salida, @Responsable)", conexion);
                consulta.Parameters.AddWithValue("@Nombre_Mascota", Nombre_Mascota);
                consulta.Parameters.AddWithValue("@Hora_Entrada", Hora_Entrada);
                consulta.Parameters.AddWithValue("@Hora_Salida", Hora_Salida);
                consulta.Parameters.AddWithValue("@Responsable", Responsable);


                consulta.ExecuteNonQuery();

                conexion.Close();
                return "ENORANUENA: EL REGISTRO SE GUARDO CORRECTAMENTE";
            }
            catch (MySqlException e)
            {
                return "error";
            }


        }


    }
}
    



