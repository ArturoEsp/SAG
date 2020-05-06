using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaAdmGym.Modelo;

namespace SistemaAdmGym.Controlador
{
    public class MembresiaController
    {
        public static bool NuevaMembresia(Membresia Membresia)
        {
            bool check = false;
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "spr_NuevaMembresia";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", SetIdMembresia(Membresia.Descripcion));
                cmd.Parameters.AddWithValue("@Descripcion", Membresia.Descripcion);
                cmd.Parameters.AddWithValue("@Dias", Membresia.Dias);
                cmd.Parameters.AddWithValue("@Inscripcion", Membresia.Inscripcion);
                cmd.Parameters.AddWithValue("@Precio", Membresia.Precio);
                cmd.Parameters.AddWithValue("@Estado", Membresia.Estado);
                cmd.ExecuteNonQuery();
                check = true;
            }

            return check;
        }

        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        private static string SetIdMembresia(string NombreMembresia)
        {
            return (NombreMembresia.Substring(0, 4) + RandomNumber(1000, 9999).ToString());
        }

        public static DataTable ListarMembresias()
        {
            DataTable dt;
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection))
            {
                dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spr_ListarMembresias";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public static DataTable DisplayMembresias()
        {
            DataTable dt;
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection))
            {
                dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT IdMembresia, Descripcion FROM Membresias";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }

        public static ArrayList DisplayPreciosDias(string Membresia)
        {
            ArrayList datos;
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection))
            {
                datos = new ArrayList();
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Inscripcion, Precio, Dias FROM Membresias WHERE IdMembresia = @Id";
                cmd.Parameters.AddWithValue("@Id",Membresia);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        datos.Add(dr.GetDecimal(0));
                        datos.Add(dr.GetDecimal(1));
                        datos.Add(dr.GetInt32(2));
                    }
                }

            }

            return datos;
        }
    }
}
