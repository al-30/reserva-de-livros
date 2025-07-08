using AutoMapper;
using EmprestimoLivro.API.DTOs;
using EmprestimoLivro.API.Models;

namespace EmprestimoLivro.API.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile() { 
        CreateMap<Cliente, ClienteDTO>().ReverseMap();  
        }
    }
}
