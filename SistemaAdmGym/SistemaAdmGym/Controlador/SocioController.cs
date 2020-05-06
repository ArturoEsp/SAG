using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAdmGym.Controlador
{
    class SocioController
    {
        public static bool NuevoSocio(Modelo.Socio Socio)
        {
            bool check = false;
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "spr_NuevoSocio";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", Socio.Nombre);
                cmd.Parameters.AddWithValue("@Edad", Socio.Edad);
                cmd.Parameters.AddWithValue("@Sexo", Socio.Sexo);
                cmd.Parameters.AddWithValue("@Telefono", Socio.Telefono);
                cmd.Parameters.AddWithValue("@Email", Socio.Email);
                cmd.Parameters.AddWithValue("@Observaciones", Socio.Observaciones);
                cmd.Parameters.AddWithValue("@FechaAlta", DateTime.Now);
                cmd.Parameters.AddWithValue("@Estado", "Activo");

                cmd.ExecuteNonQuery();
                check = true;
            }

            return check;
        }

        private static int getUltimoID()
        {
            int Count;
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT COUNT(*) FROM Socios";
                Count = Convert.ToInt32(cmd.ExecuteScalar()) + 1;

            }
            return Count;

        }

        public static string getIDFormat()
        {
            return getUltimoID().ToString("0000-0000");
        }

        public static async Task<DataTable> ListarSocios()
        {
            DataTable dt;
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection))
            {
                con.Open();
                dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "spr_ListarSocios";
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                await Task.Run(() => da.Fill(dt));
            }
            return dt;

        }

        public static Modelo.Socio getDatosSocio(int Id)
        {
            Modelo.Socio oSocio = new Modelo.Socio();
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Socios WHERE IdSocio = @Id";
                cmd.Parameters.AddWithValue("@Id", Id);

                SqlDataReader da = cmd.ExecuteReader();

                if (da.HasRows)
                {
                    while (da.Read())
                    {
                        oSocio.Nombre = da[1].ToString();
                        oSocio.Edad = Convert.ToInt32(da[2].ToString());
                        oSocio.Sexo = da[3].ToString();
                        oSocio.Telefono = da[4].ToString();
                        oSocio.Email = da[5].ToString();
                        oSocio.Observaciones = da[6].ToString();
                        oSocio.FechaAlta = Convert.ToDateTime(da[7].ToString());
                        oSocio.Estado = da[8].ToString();

                    }
                }
            }

            return oSocio;
        }

        public static bool UpdateSocio(Modelo.Socio Socio)
        {

            bool isGood = false;

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Socios SET Nombre = @Nombre, Edad = @Edad, Sexo = @Sexo, Telefono = @Telefono," +
                    " Email = @Email, Observaciones = @Observaciones, Estado = @Estado WHERE IdSocio = @Id";
                cmd.Parameters.AddWithValue("@Nombre", Socio.Nombre);
                cmd.Parameters.AddWithValue("@Edad", Socio.Edad);
                cmd.Parameters.AddWithValue("@Sexo", Socio.Sexo);
                cmd.Parameters.AddWithValue("@Telefono", Socio.Telefono);
                cmd.Parameters.AddWithValue("@Email", Socio.Email);
                cmd.Parameters.AddWithValue("@Observaciones", Socio.Observaciones);
                cmd.Parameters.AddWithValue("@Estado", Socio.Estado);
                cmd.Parameters.AddWithValue("@Id", Socio.Id);
                cmd.ExecuteNonQuery();
                isGood = true;
            }

            return isGood;
        }


        public static bool EliminarSocio(int Id)
        {
            bool isGood = false;
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Socios WHERE IdSocio = @Id";
                cmd.Parameters.AddWithValue("@Id",Id);
                cmd.ExecuteNonQuery();
                isGood = true;
            }

            return isGood;
        }

        public static async Task<int> TotalSociosActivos()
        {
            int totalSocios = 0;
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT COUNT(*) FROM Socios WHERE Estado = 'Activo'";
                await Task.Run(() => totalSocios = Convert.ToInt32(cmd.ExecuteScalar()));               
            }

            return totalSocios;
        }

        public static async Task<int> TotalSociosInactivos()
        {
            int totalSocios = 0;
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT COUNT(*) FROM Socios WHERE Estado = 'Inactivo'";
                await Task.Run(() => totalSocios = Convert.ToInt32(cmd.ExecuteScalar()));
            }

            return totalSocios;
        }

    }
}
