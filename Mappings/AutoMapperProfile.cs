using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Biblioteca.Dtos;
using Biblioteca.Models;

namespace Biblioteca.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();

            CreateMap<Produto, ProdutoDetalhesDto>().ReverseMap();

            CreateMap<Vendas, VendaDTO>().ReverseMap();

            CreateMap<Vendas, VendaResponseDTO>().ReverseMap();
        }
    }
}