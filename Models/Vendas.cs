using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Vendas
    {
        public int Id { get; set; }
        public required string NomeProduto { get; set; }
        public int IdProduto { get; set; }
        public int QuantidadeVendida { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataVenda { get; set; } = DateTime.Now;
        
    }
}