using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SistemaAdmGym.Controlador
{
    public class UsuarioController
    {
        public static bool Nuevo(Modelo.Usuario oUsuario)
        {
            bool check = false;

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "spr_NuevoUsuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", oUsuario.UsuarioName);
                cmd.Parameters.AddWithValue("@Contrasena", Encrypt(oUsuario.Contrasenia));
                cmd.Parameters.AddWithValue("@Tipo", oUsuario.Tipo);
                cmd.Parameters.AddWithValue("@Nombre", oUsuario.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", oUsuario.Telefono);
                cmd.Parameters.AddWithValue("@Email", oUsuario.Email);
                cmd.Parameters.AddWithValue("@FechaCreacion", DateTime.Now);

                cmd.ExecuteNonQuery();
                check = true;
            }

            return check;
        }

        public static DataTable ListarUsuarios()
        {
            DataTable dt;
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection))
            {
                con.Open();
                dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "spr_ListarUsuarios";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;

        }

        public static bool VerificarUsuario(string _usuario, string _contrasena)
        {
            int Count = 0;
            SqlDataReader da;
            bool CheckLogin = false;
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "spr_Login";
                cmd.Parameters.AddWithValue("@Username", _usuario);
                cmd.Parameters.AddWithValue("@Password", Encrypt(_contrasena));
                da = cmd.ExecuteReader();

                if (da.HasRows)
                {
                    while (da.Read())
                    { Count = Convert.ToInt32(da[0].ToString()); }
                    RegistroAcceso(Count);
                    CheckLogin = true;
                }
                else
                    CheckLogin = false;

            }

            return CheckLogin;

        }

        private static string Encrypt(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            string key = "r?o.1w^#`))nj2od&gsC7V>YQk7'gt";
            stream = sha256.ComputeHash(encoding.GetBytes(str + key));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        private static Task RegistroAcceso(int tipo)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (tipo == 1)
                config.AppSettings.Settings["isAdmin"].Value = "true";
            else
                config.AppSettings.Settings["isAdmin"].Value = "false";

            return Task.Run(() =>
            {
                config.Save(ConfigurationSaveMode.Modified);
                System.Configuration.ConfigurationManager.RefreshSection("appSettings");
            });


        }

        public static bool isAdmin()
        {
            return Convert.ToBoolean(ConfigurationManager.AppSettings["isAdmin"]);
        }

        public static Modelo.Usuario GetDatos(int Id)
        {
            Modelo.Usuario oUsuario = new Modelo.Usuario();

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection))
            {
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Usuarios WHERE IdUsuario = @Id";
                cmd.Parameters.AddWithValue("@Id", Id);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        oUsuario.UsuarioName = dr[1].ToString();
                        oUsuario.Contrasenia = dr[2].ToString();
                        oUsuario.Tipo = Convert.ToInt32(dr[3].ToString());
                        oUsuario.Nombre = dr[4].ToString();
                        oUsuario.Telefono = dr[5].ToString();
                        oUsuario.Email = dr[6].ToString();
                    }
                }

            }

            return oUsuario;
        }

        public static bool UpdateUsuario(Modelo.Usuario oUsuario)
        {
            bool isGood = false;

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Usuarios SET Usuario = @Usuario, Contrasena = @Contrasena, Tipo = @Tipo," +
                    "Nombre = @Nombre, Telefono = @Telefono, Email = @Email WHERE IdUsuario = @Id";
                cmd.Parameters.AddWithValue("@Usuario", oUsuario.UsuarioName);
                cmd.Parameters.AddWithValue("@Contrasena", Encrypt(oUsuario.Contrasenia));
                cmd.Parameters.AddWithValue("@Tipo", oUsuario.Tipo);
                cmd.Parameters.AddWithValue("@Nombre", oUsuario.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", oUsuario.Telefono);
                cmd.Parameters.AddWithValue("@Email", oUsuario.Email);
                cmd.Parameters.AddWithValue("@Id", oUsuario.Id);
                cmd.ExecuteNonQuery();
                isGood = true;
            }

            return isGood;
        }

        public static bool PermisosAdministrador(int Id,int Tipo)
        {
            bool isGood = false;

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                if(Tipo == 0)
                    cmd.CommandText = "UPDATE Usuarios SET Tipo = 1 WHERE IdUsuario = @Id";
                if(Tipo == 1)
                    cmd.CommandText = "UPDATE Usuarios SET Tipo = 0 WHERE IdUsuario = @Id";
                cmd.Parameters.AddWithValue("@Id",Id);
                cmd.ExecuteNonQuery();
                isGood = true;

            }

            return isGood;
        }


    }
}
