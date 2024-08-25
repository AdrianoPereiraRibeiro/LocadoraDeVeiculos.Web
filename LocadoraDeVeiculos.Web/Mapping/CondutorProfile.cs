using AutoMapper;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Web.Models;

namespace LocadoraDeVeiculos.Web.Mapping
{
    public class CondutorProfile : Profile
    {
        public CondutorProfile()
        {
            CreateMap<InserirCondutorViewModel, Condutor>();
            CreateMap<EditarCondutorViewModel, Condutor>();

            CreateMap<Condutor, ListarCondutorViewModel>()
                .ForMember(
                    dest => dest.Cliente,
                    opt => opt.MapFrom(src => src.Cliente!.Nome)
                );

            CreateMap<Condutor, DetalhesCondutorViewModel>()
                .ForMember(
                    dest => dest.Cliente,
                    opt => opt.MapFrom(src => src.Cliente!.Nome)
                );

            CreateMap<Condutor, EditarCondutorViewModel>();
        }
    }
}
