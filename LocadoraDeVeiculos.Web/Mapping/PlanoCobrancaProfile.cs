using AutoMapper;
using LocadoraDeVeiculos.Web.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Web.Mapping.Resolvers;
using LocadoraDeVeiculos.Web.Models;


namespace LocadoraDeVeiculos.Web.Mapping
{
    public class PlanoCobrancaProfile : Profile
    {
        public PlanoCobrancaProfile()
        {
            CreateMap<InserirPlanoCobrancaViewModel, PlanoCobranca>();
            CreateMap<EditarPlanoCobrancaViewModel, PlanoCobranca>();

            CreateMap<PlanoCobranca, ListarPlanoCobrancaViewModel>()
                .ForMember(
                    dest => dest.GrupoDeAutomoveis,
                    opt => opt.MapFrom(src => src.GrupoDeAutomoveis!.Nome));

            CreateMap<PlanoCobranca, DetalhesPlanoCobrancaViewModel>()
                .ForMember(
                    dest => dest.GrupoDeAutomoveis,
                    opt => opt.MapFrom(src => src.GrupoDeAutomoveis!.Nome));

            CreateMap<PlanoCobranca, EditarPlanoCobrancaViewModel>().ForMember(dest => dest.GruposDeAutomoveis, 
                opt => opt.MapFrom<GrupoDeAutomoveisValueResolver>()); 
        }
    }
}
