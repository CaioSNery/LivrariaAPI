using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public int Estoque { get; set; }

        public decimal ValorCompra { get; set; }
        public decimal ValorVenda { get; set; }

    }
}