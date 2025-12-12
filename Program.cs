using Market.Services;
using Market.Models; // Importante para usar a classe Produto
using System;

namespace Market
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instanciamos os serviços uma única vez no início
            ProdutoService produtoService = new ProdutoService();
            CarrinhoService carrinhoService = new CarrinhoService();

            bool executando = true;

            while (executando)
            {
                // Limpa a tela para o menu ficar sempre no topo
                Console.Clear();
                Console.WriteLine("=== MERCADINHO DO JÚNIOR ===");
                Console.WriteLine("1. Listar Produtos");
                Console.WriteLine("2. Cadastrar Novo Produto");
                Console.WriteLine("3. Adicionar ao Carrinho");
                Console.WriteLine("4. Ver Carrinho");
                Console.WriteLine("5. Finalizar Compra");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                // Lê a tecla pressionada
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        // Lógica de Listar
                        Console.WriteLine("\n--- LISTA DE PRODUTOS ---");
                        var produtos = produtoService.ListarProdutos();
                        foreach (var p in produtos)
                        {
                            Console.WriteLine($"ID: {p.Id} | {p.Nome} | R$ {p.PrecoUnitario}");
                        }
                        Console.ReadKey(); // Espera o usuário ler
                        break;

                    case "2":
                        // DESAFIO PARA VOCÊ (Vou pedir no próximo passo)
                        Console.WriteLine("Implementar Cadastro aqui...");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.WriteLine("Implementar Adicionar ao Carrinho aqui...");
                        Console.ReadKey();
                        break;

                    case "4":
                        // Já vou te dar essa de presente pra você ver o carrinho funcionando
                        Console.WriteLine("\n--- SEU CARRINHO ---");
                        var itens = carrinhoService.ListarItens();
                        decimal totalGeral = 0;

                        foreach (var item in itens)
                        {
                            decimal totalItem = item.Quantidade * item.Produto.PrecoUnitario;
                            totalGeral += totalItem;
                            Console.WriteLine($"{item.Produto.Nome} | Qtd: {item.Quantidade} | Total: {totalItem:C}");
                        }
                        Console.WriteLine($"\nTOTAL DA COMPRA: {totalGeral:C}");
                        Console.ReadKey();
                        break;

                    case "5":
                        // Lógica de Finalizar
                        carrinhoService.LimparCarrinho();
                        Console.WriteLine("Compra finalizada com sucesso! Volte sempre.");
                        Console.ReadKey();
                        break;

                    case "0":
                        executando = false;
                        break;

                    default:
                        Console.WriteLine("Opção Inválida!");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}