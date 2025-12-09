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

        public void Connection()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Conexão bem-sucedida ao banco de dados.");
                    Console.ReadKey();
                }
            } catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
                Console.ReadKey();
            }
        }
    }
}
