using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Livraria
    {
        public int Id { get; set; }
        public required string Tipo { get; set; }
        public required string Nome{ get; set; }
        public int Ano { get; set; }
        public int Estoque { get; set; }

        public decimal ValorCompra { get; set; }
        public decimal ValorVenda { get; set; }

    }
}