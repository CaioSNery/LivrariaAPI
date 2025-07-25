using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class VendaDTO
    {
        public int LivrariaId { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataVenda{get; set;} = DateTime.Now;


    }
}