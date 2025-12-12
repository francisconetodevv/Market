using Market.Data;
using Market.Models; // Para usar os Models se precisar
using System.Data.SqlClient;

namespace Market.Services
{
    public class CarrinhoService
    {
        private readonly DatabaseHelper _databaseHelper;

        public CarrinhoService()
        {
            _databaseHelper = new DatabaseHelper();
        }

        public void AdicionarItem(int produtoId, int quantidade)
        {
            using (var connection = _databaseHelper.GetConnection())
            {
                connection.Open();

                // 🧠 Lógica de Sênior: Script SQL Condicional
                // 1. Verifica se já existe aquele ProdutoId na tabela ItensCarrinho
                // 2. Se existe (BEGIN...END), faz UPDATE somando a quantidade atual com a nova
                // 3. Se não existe (ELSE...), faz o INSERT normal
                string sql = @"
                    IF EXISTS (SELECT 1 FROM ItensCarrinho WHERE ProdutoId = @ProdutoId)
                    BEGIN
                        UPDATE ItensCarrinho 
                        SET Quantidade = Quantidade + @Quantidade 
                        WHERE ProdutoId = @ProdutoId
                    END
                    ELSE
                    BEGIN
                        INSERT INTO ItensCarrinho (ProdutoId, Quantidade) 
                        VALUES (@ProdutoId, @Quantidade)
                    END";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ProdutoId", produtoId);
                    command.Parameters.AddWithValue("@Quantidade", quantidade);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<ItemCarrinho> ListarItens()
        {
            var lista = new List<ItemCarrinho>();

            using (var connection = _databaseHelper.GetConnection())
            {
                connection.Open();

                // 🧠 O Pulo do Gato: JOIN
                // Estamos buscando dados da tabela Carrinho (C) E da tabela Produtos (P)
                // Onde o Id do Produto for igual ao ProdutoId do Carrinho.
                string sql = @"
            SELECT 
                c.Id, 
                c.ProdutoId, 
                c.Quantidade, 
                p.Nome, 
                p.PrecoUnitario 
            FROM ItensCarrinho c
            INNER JOIN Produtos p ON c.ProdutoId = p.Id";

                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // 1. Criamos o Item do Carrinho
                            var item = new ItemCarrinho();
                            item.Id = Convert.ToInt32(reader["Id"]);
                            item.ProdutoId = Convert.ToInt32(reader["ProdutoId"]);
                            item.Quantidade = Convert.ToInt32(reader["Quantidade"]);

                            // 2. POPULANDO O PRODUTO DENTRO DO ITEM
                            // Lembra que criamos a propriedade 'public Produto Produto' no modelo?
                            // É agora que ela brilha! Montamos o objeto Produto aqui dentro.
                            item.Produto = new Produto
                            {
                                Id = item.ProdutoId,
                                Nome = reader["Nome"].ToString(),
                                PrecoUnitario = Convert.ToDecimal(reader["PrecoUnitario"])
                            };

                            lista.Add(item);
                        }
                    }
                }
            }

            return lista;
        }

        // Remove um produto específico do carrinho
        public void RemoverProduto(int produtoId)
        {
            using (var connection = _databaseHelper.GetConnection())
            {
                connection.Open();

                string sql = "DELETE FROM ItensCarrinho WHERE ProdutoId = @ProdutoId";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ProdutoId", produtoId);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Limpa o carrinho todo (Finalizar Compra)
        public void LimparCarrinho()
        {
            using (var connection = _databaseHelper.GetConnection())
            {
                connection.Open();

                // SEM WHERE = APAGA TUDO DA TABELA
                string sql = "DELETE FROM ItensCarrinho";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }


}