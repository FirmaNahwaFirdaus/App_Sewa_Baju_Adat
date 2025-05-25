using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace App_Sewa_Baju_Adat
{
    public static class Database
    {
        private static readonly string connectionString = "server=localhost; port=3306; database=sewa_baju_adat; uid=root; pwd=;";
        private static MySqlConnection connection;

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public static void CloseConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
