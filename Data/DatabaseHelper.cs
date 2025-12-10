using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Market.Data
{
    public class DatabaseHelper
    {

        private readonly string _connectionString = @"Server=DESKTOP-1H81HKV\DBDEVELOPER;Database=ListaComprasDB;Trusted_Connection=True;";

        public SqlConnection GetConnection()
        {
           return new SqlConnection(_connectionString);
        }
    }
}
