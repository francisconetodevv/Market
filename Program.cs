using Market.Data;
using Market.Services;

ProdutoService produtoService = new ProdutoService();
var produtos = produtoService.ListarProdutos();

foreach(var produto in produtos)
{
    Console.WriteLine(produto.Nome + " - " + produto.Categoria + " - " + produto.Marca + " - " + produto.PrecoUnitario);    
}

Console.ReadKey();