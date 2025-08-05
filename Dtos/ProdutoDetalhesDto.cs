using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Dtos
{
    public class ProdutoDetalhesDto
    {
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public decimal ValorVenda { get; set; }
    }
}