using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty; // It is used to avoid null reference issues
        public string Categoria { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}
