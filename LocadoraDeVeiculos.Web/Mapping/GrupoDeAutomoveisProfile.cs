using AutoMapper;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeVeiculos.Web.Models;
using LocadoraDeVeiculos.WebApp.Models;

namespace LocadoraDeVeiculos.WebApp.Mapping;

public class GrupoDeAutomoveisProfile : Profile
{
    public GrupoDeAutomoveisProfile()
    {
        CreateMap<InserirGrupoAutomoveisViewModel, GrupoDeAutomoveis>();
        CreateMap<EditarGrupoAutomoveisViewModel, GrupoDeAutomoveis>();

        CreateMap<GrupoDeAutomoveis, ListarGrupoAutomoveisViewModel>();
        CreateMap<GrupoDeAutomoveis, DetalhesGrupoAutomoveisViewModel>();
        CreateMap<GrupoDeAutomoveis, EditarGrupoAutomoveisViewModel>();
    }
}