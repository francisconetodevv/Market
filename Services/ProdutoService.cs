using Market.Data;
using Market.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Services
{
    public class ProdutoService
    {

        private readonly DatabaseHelper _dataconnection;

        public ProdutoService()
        {
            _dataconnection = new DatabaseHelper();
        }
            
        // Lógica para Listar todos os Produtos no database
        // Retorna uma lista de produtos
        public List<Produto> ListarProdutos()
        {
            // Variável para armazenar a Lista de produtos
            var produtos = new List<Produto>();

            // 1. Obter a conexão com o banco de dados
            using (var connection = _dataconnection.GetConnection())
            {
                // Abrindo a porta do database
                connection.Open(); 

                // 2. Definindo o script SQL para listar os produtos do database
                string sqlscript = "SELECT Nome, Categoria, Marca, PrecoUnitario FROM [ListaComprasDB].[dbo].[Produtos]";

                // 3. Executando e lendo os dados do database
                using (var command = new SqlCommand(sqlscript, connection))
                {
                    // 4. Lendo os dados retornados pelo database
                    using (var reader = command.ExecuteReader())
                    {
                        // 5. Loop para percorrer todos os registros retornados
                        while (reader.Read())
                        {
                            // 6. Definindo o tipo de objeto que será retornado e armazenado na lista de objetos
                            var produto = new Produto();

                            produto.Nome = reader["Nome"].ToString();
                            produto.Categoria = reader["Categoria"].ToString();
                            produto.Marca = reader["Marca"].ToString();
                            produto.PrecoUnitario = Convert.ToDecimal(reader["PrecoUnitario"]);

                            produtos.Add(produto);
                        }
                    }
                }
            }

            return produtos;
        }
    }
}
