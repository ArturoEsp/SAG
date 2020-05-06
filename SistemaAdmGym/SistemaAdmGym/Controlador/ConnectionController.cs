using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SistemaAdmGym.Controlador
{
    public class ConnectionController
    {
        public static bool CheckConnection()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.Connection);
            try
            {
                con.Open();               
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
