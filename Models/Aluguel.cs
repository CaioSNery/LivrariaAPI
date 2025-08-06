using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Aluguel
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int DiasLocacao { get; set; }

        public DateTime DataLocacao { get; set; }

        public decimal ValorTotal { get; set; }
    }
}