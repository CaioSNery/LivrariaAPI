using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class VendaResponseDTO
    {
        public string Mensagem { get; set; }
        public string NomeProduto { get; set; }
        public int QuantidadeVendida { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataVenda { get; set; } = DateTime.Now;
    }
}