using AutoMapper;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Web.Models;

namespace LocadoraDeVeiculos.Web.Mapping
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<InserirClienteViewModel, Cliente>();
            CreateMap<EditarClienteViewModel, Cliente>();
            CreateMap<Cliente, ListarClienteViewModel>();
            CreateMap<Cliente, DetalhesClienteViewModel>();
            CreateMap<Cliente, EditarClienteViewModel>();
        }
    }

}
