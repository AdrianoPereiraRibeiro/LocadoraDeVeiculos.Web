using AutoMapper;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloTaxaEServico;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Service.Servicos;
using LocadoraDeVeiculos.Web.Dominio.ModuloUsuario;
using LocadoraDeVeiculos.Web.Models;
using LocadoraDeVeiculos.WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;

namespace LocadoraDeVeiculos.Web.Mapping;


public class AluguelProfile : Profile
{
    public AluguelProfile()
    {
        CreateMap<InserirAluguelViewModel, Aluguel>()
            .ForMember(l => l.TaxasEServicos, opt => opt.MapFrom<TaxasSelecionadasValueResolver>());

        CreateMap<RealizarDevolucaoViewModel, Aluguel>()
            .ForMember(l => l.TaxasEServicos, opt => opt.MapFrom<TaxasSelecionadasValueResolver>());

        CreateMap<Aluguel, ListarAluguelViewModel>()
            .ForMember(l => l.Veiculo, opt => opt.MapFrom(src => src.Veiculo!.Modelo))
            .ForMember(l => l.Condutor, opt => opt.MapFrom(src => src.Condutor.Nome))
            .ForMember(l => l.TipoPlano, opt => opt.MapFrom(src => src.Plano.ToString()));

        CreateMap<Aluguel, RealizarDevolucaoViewModel>()
            .ForMember(l => l.Condutores, opt => opt.MapFrom<CondutoresValueResolver>())
            .ForMember(l => l.Clientes, opt => opt.MapFrom<ClientesValueResolver>())
            .ForMember(l => l.Veiculos, opt => opt.MapFrom<VeiculosValueResolver>())
            .ForMember(l => l.Taxas, opt => opt.MapFrom<TaxasValueResolver>())
            .ForMember(l => l.TaxasSelecionadas,
                opt => opt.MapFrom(src => src.TaxasEServicos.Select(tx => tx.Id))); ;
    }
}

public class CondutoresValueResolver : IValueResolver<Aluguel, FormularioAluguelViewModel, IEnumerable<SelectListItem>?>
{
    private readonly IRepositorioCondutor _repositorioCondutor;

    public CondutoresValueResolver(IRepositorioCondutor repositorioCondutor)
    {
        _repositorioCondutor = repositorioCondutor;
    }

    public IEnumerable<SelectListItem>? Resolve(Aluguel source, FormularioAluguelViewModel destination, IEnumerable<SelectListItem>? destMember,
        ResolutionContext context)
    {
        return _repositorioCondutor
            .SelecionarTodos()
            .Select(c => new SelectListItem(c.Nome, c.Id.ToString()));
    }
}

public class ClientesValueResolver : IValueResolver<Aluguel, FormularioAluguelViewModel, IEnumerable<SelectListItem>?>
{
    private readonly IRepositorioCliente _repositorioCliente;

    public ClientesValueResolver(IRepositorioCliente repositorioCliente)
    {
        _repositorioCliente = repositorioCliente;
    }

    public IEnumerable<SelectListItem>? Resolve(Aluguel source, FormularioAluguelViewModel destination,
        IEnumerable<SelectListItem>? destMember,
        ResolutionContext context)
    {
        return _repositorioCliente
            .SelecionarTodos()
            .Select(c => new SelectListItem(c.Nome, c.Id.ToString()));
    }

}

public class
        VeiculosValueResolver : IValueResolver<Aluguel, FormularioAluguelViewModel, IEnumerable<SelectListItem>?>
    {
        private readonly VeiculoService _servicoVeiculo;

        public VeiculosValueResolver(VeiculoService servicoVeiculo)
        {
            _servicoVeiculo = servicoVeiculo;
        }

        public IEnumerable<SelectListItem>? Resolve(Aluguel source, FormularioAluguelViewModel destination,
            IEnumerable<SelectListItem>? destMember,
            ResolutionContext context)
        {
            if (destination is RealizarDevolucaoViewModel)
            {
                var veiculoSelecionado = source.Veiculo;

                return [new SelectListItem(veiculoSelecionado!.Modelo, veiculoSelecionado.Id.ToString())];
            }

            return _servicoVeiculo
                .SelecionarTodos(source.Veiculo.UsuarioId)
                .Value
                .Select(v => new SelectListItem(v.Modelo, v.Id.ToString()));
        }
    }

public class TaxasValueResolver : IValueResolver<Aluguel, FormularioAluguelViewModel, IEnumerable<SelectListItem>?>
{
    private readonly IRepositorioTaxaEServico repositorioTaxaEServico;

    public TaxasValueResolver(IRepositorioTaxaEServico repositorioTaxaEServico)
    {
        this.repositorioTaxaEServico = repositorioTaxaEServico;
    }

    public IEnumerable<SelectListItem>? Resolve(Aluguel source, FormularioAluguelViewModel destination,
        IEnumerable<SelectListItem>? destMember,
        ResolutionContext context)
    {

        return repositorioTaxaEServico
            .SelecionarTodos()
            .Select(t => new SelectListItem(t.Nome, t.Id.ToString()));
    }
}

public class
        TaxasSelecionadasValueResolver : IValueResolver<FormularioAluguelViewModel, Aluguel, List<TaxaEServico>>
    {
        private readonly IRepositorioTaxaEServico repositorioTaxaEServico;

        public TaxasSelecionadasValueResolver(IRepositorioTaxaEServico repositorioTaxaEServico)
        {
            this.repositorioTaxaEServico = repositorioTaxaEServico;
        }

        public List<TaxaEServico> Resolve(
            FormularioAluguelViewModel source,
            Aluguel destination,
            List<TaxaEServico> destMember,
            ResolutionContext context
        )
        {
            var idsTaxasSelecionadas = source.TaxasSelecionadas.ToList();

            return repositorioTaxaEServico.SelecionarTodos()
                .Where(taxa => idsTaxasSelecionadas.Contains(taxa.Id))
                .ToList();
            ;

        }
    }

