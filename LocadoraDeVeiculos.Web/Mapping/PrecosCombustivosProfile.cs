using AutoMapper;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeVeiculos.Dominio.ModuloPrecosCombustiveis;
using LocadoraDeVeiculos.Web.Models;

namespace LocadoraDeVeiculos.Web.Mapping
{
    public class PrecosCombustiveisProfile : Profile
    {
        public PrecosCombustiveisProfile()
        {

            CreateMap<EditarPrecosCombustiveisViewModel, PrecosCombustiveis>();

            CreateMap<PrecosCombustiveis, ListarPrecosCombustiveisViewModel>();
            CreateMap<PrecosCombustiveis, DetalhesPrecosCombustiveisViewModel>();
            CreateMap<PrecosCombustiveis, EditarPrecosCombustiveisViewModel>();
        }
    }
}
