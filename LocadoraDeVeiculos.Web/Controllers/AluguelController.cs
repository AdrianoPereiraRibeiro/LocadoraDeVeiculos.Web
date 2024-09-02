using AutoMapper;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloTaxaEServico;
using LocadoraDeVeiculos.Infraestrutura.ModuloTaxaEServico;
using LocadoraDeVeiculos.Service.Servicos;
using LocadoraDeVeiculos.Web.Controllers;
using LocadoraDeVeiculos.Web.Models;
using LocadoraDeVeiculos.Web.Service.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeVeiculos.WebApp.Controllers;

public class AluguelController : WebControllerBase
{
    private readonly AluguelService AluguelService;
    private readonly VeiculoService VeiculoService;
    private readonly CondutorService CondutorService;
    private readonly TaxaEServicoService TaxaEServicoService;
    private readonly ClienteService ClienteService;
    private readonly IMapper mapeador;

    public AluguelController(
        AluguelService AluguelService,
        VeiculoService VeiculoService,
        CondutorService CondutorService,
        TaxaEServicoService TaxaEServicoService,
        ClienteService ClienteService,
        IMapper mapeador
    )
    {
        this.AluguelService = AluguelService;
        this.VeiculoService = VeiculoService;
        this.CondutorService = CondutorService;
        this.TaxaEServicoService = TaxaEServicoService;
        this.ClienteService = ClienteService;
        this.mapeador = mapeador;
    }

    public IActionResult Listar()
    {
        var resultado = AluguelService.SelecionarTodos(UsuarioId.GetValueOrDefault());

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction("Index", "Home");
        }

        var locacoes = resultado.Value;

        var listarLocacoesVm = mapeador.Map<IEnumerable<ListarAluguelViewModel>>(locacoes);

        return View(listarLocacoesVm);
    }

    public IActionResult Inserir()
    {
        return View(CarregarDadosFormulario());
    }

    [HttpPost]
    public IActionResult Inserir(InserirAluguelViewModel inserirVm)
    {

        if (!ModelState.IsValid)
            return View(CarregarDadosFormulario(inserirVm));
        
        var aluguel = mapeador.Map<Aluguel>(inserirVm);


        var resultado = AluguelService.Inserir(aluguel);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{aluguel.Id}] foi inserido com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult RealizarDevolucao(int id)
    {
        var resultado = AluguelService.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var locacao = resultado.Value;

        var devolucaoVm = mapeador.Map<RealizarDevolucaoViewModel>(locacao);

        return View(devolucaoVm);
    }

    [HttpPost]
    public IActionResult RealizarDevolucao(RealizarDevolucaoViewModel devolucaoVm)
    {
        var locacaoOriginal = AluguelService.SelecionarPorId(devolucaoVm.Id).Value;

        var locacaoAtualizada = mapeador.Map<RealizarDevolucaoViewModel, Aluguel>(devolucaoVm, locacaoOriginal);

        var resultado = AluguelService.RealizarDevolucao(locacaoAtualizada);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"A locação ID [{locacaoAtualizada.Id}] foi concluída com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    private InserirAluguelViewModel CarregarDadosFormulario(InserirAluguelViewModel? formularioVm = null)
    {
        var condutores = CondutorService.SelecionarTodos(UsuarioId.GetValueOrDefault()).Value;
        var veiculos = VeiculoService.SelecionarTodos(UsuarioId.GetValueOrDefault()).Value;
        var taxas = TaxaEServicoService.SelecionarTodos(UsuarioId.GetValueOrDefault()).Value;
        var clientes = ClienteService.SelecionarTodos(UsuarioId.GetValueOrDefault()).Value;

        if (formularioVm is null)
            formularioVm = new InserirAluguelViewModel();

        formularioVm.Condutores =
            condutores.Select(c => new SelectListItem(c.Nome, c.Id.ToString()));

        formularioVm.Veiculos =
            veiculos.Select(c => new SelectListItem(c.Modelo, c.Id.ToString()));

        formularioVm.Taxas =
            taxas.Select(c => new SelectListItem(c.Nome, c.Id.ToString()));

        formularioVm.Clientes =
            clientes.Select(c => new SelectListItem(c.Nome, c.Id.ToString()));

        return formularioVm;
    }
}
