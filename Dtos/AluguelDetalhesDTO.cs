using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Dtos
{
    public class AluguelDetalhesDTO
    {

        public int ClienteId { get; set; }

        public int ProdutoId { get; set; }

        public int DiasLocacao { get; set; }

        public DateTime DataLocacao { get; set; }

        public decimal ValorTotal { get; set; }
    }
}