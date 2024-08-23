using AutoMapper;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Web.Models;


namespace LocadoraDeVeiculos.Web.Mapping;

public class VeiculoProfile : Profile
{
    public VeiculoProfile()
    {
        CreateMap<InserirVeiculoViewModel, Veiculo>();
        CreateMap<EditarVeiculoViewModel, Veiculo>();

        CreateMap<Veiculo, ListarVeiculoViewModel>()
            .ForMember(
                dest => dest.GrupoDeAutomoveis,
                opt => opt.MapFrom(src => src.GrupoDeAutomoveis!.Nome)
            );

        CreateMap<Veiculo, DetalhesVeiculoViewModel>()
            .ForMember(
                dest => dest.GrupoDeAutomoveis,
                opt => opt.MapFrom(src => src.GrupoDeAutomoveis!.Nome)
            );

        CreateMap<Veiculo, EditarVeiculoViewModel>();
    }
}
