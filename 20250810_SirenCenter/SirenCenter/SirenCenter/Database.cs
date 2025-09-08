using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirenCenter
{
    public class Database
    {
        private readonly string _connectionString;

        public Database()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
