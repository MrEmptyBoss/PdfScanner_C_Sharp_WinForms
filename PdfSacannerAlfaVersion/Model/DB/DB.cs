using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfSacannerAlfaVersion.Model.DB
{
    class DB
    {
        MySqlConnection connection = new MySqlConnection("server=sql4.freesqldatabase.com; username=sql4480218; password=VNhx3r9tYc; database=sql4480218");
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
