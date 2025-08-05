using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Models;

namespace Biblioteca.Dtos
{
    public class VendaDTO
    {
        public int IdProduto { get; set; }
        public int QuantidadeVendida { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}