using AutoMapper;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeVeiculos.Dominio.ModuloTaxaEServico;
using LocadoraDeVeiculos.Web.Models;

namespace LocadoraDeVeiculos.Web.Mapping
{
    public class TaxaEServicoProfile : Profile
    {
        public TaxaEServicoProfile()
        {
            CreateMap<InserirTaxaEServicoViewModel, TaxaEServico>();
            CreateMap<EditarTaxaEServicoViewModel, TaxaEServico>();

            CreateMap<TaxaEServico, ListarTaxaEServicoViewModel>();
            CreateMap<TaxaEServico, DetalhesTaxaEServicoViewModel>();
            CreateMap<TaxaEServico, EditarTaxaEServicoViewModel>();
        }
    }
}
