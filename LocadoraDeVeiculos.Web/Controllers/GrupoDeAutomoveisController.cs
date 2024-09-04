using AutoMapper;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeVeiculos.Web.Aplicacao.Servicos;
using LocadoraDeVeiculos.Web.Controllers;
using LocadoraDeVeiculos.Web.Extensions;
using LocadoraDeVeiculos.Web.Models;
using Microsoft.AspNetCore.Mvc;


namespace LocadoraDeVeiculos.Web;

//[Authorize(Roles = "Empresa")]
public class GrupoDeAutomoveisController : WebControllerBase
{
    private readonly GrupoDeAutomoveisService servicoGrupoDeAutomoveis;
    private readonly IMapper mapeador;

    public GrupoDeAutomoveisController(GrupoDeAutomoveisService servicoGrupoDeAutomoveis, IMapper mapeador)
    {
        this.servicoGrupoDeAutomoveis = servicoGrupoDeAutomoveis;
        this.mapeador = mapeador;
    }

    public IActionResult Listar()
    {
        var resultado = 
            servicoGrupoDeAutomoveis.SelecionarTodos(UsuarioId.GetValueOrDefault());

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction("Index", "Home");
        }

        var grupoDeAutomoveis = resultado.Value;

        var listarGrupoDeAutomoveisViewModels
            = mapeador.Map<IEnumerable<ListarGrupoAutomoveisViewModel>>(grupoDeAutomoveis);

        ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();

        return View(listarGrupoDeAutomoveisViewModels);
    }

    public IActionResult Inserir()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Inserir(InserirGrupoAutomoveisViewModel inserirGrupoDeAutomoveisVm)
    {
        if (!ModelState.IsValid)
            return View(inserirGrupoDeAutomoveisVm);

        var novoGrupoDeAutomoveis = mapeador.Map<GrupoDeAutomoveis>(inserirGrupoDeAutomoveisVm);

        novoGrupoDeAutomoveis.UsuarioId = UsuarioId.GetValueOrDefault();

        var resultado = servicoGrupoDeAutomoveis.Inserir(novoGrupoDeAutomoveis);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{novoGrupoDeAutomoveis.Id}] foi inserido com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Editar(int id)
    {
        var resultado = servicoGrupoDeAutomoveis.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var GrupoDeAutomoveis = resultado.Value;

        var editarGrupoDeAutomoveisVm = mapeador.Map<EditarGrupoAutomoveisViewModel>(GrupoDeAutomoveis);

        return View(editarGrupoDeAutomoveisVm);
    }

    [HttpPost]
    public IActionResult Editar(EditarGrupoAutomoveisViewModel editarSalaVm)
    {
        if (!ModelState.IsValid)
            return View(editarSalaVm);

        var sala = mapeador.Map<GrupoDeAutomoveis>(editarSalaVm);

        var resultado = servicoGrupoDeAutomoveis.Editar(sala);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{sala.Id}] foi editado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Excluir(int id)
    {
        var resultado = servicoGrupoDeAutomoveis.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var GrupoDeAutomoveis = resultado.Value;

        var detalhesGrupoDeAutomoveisViewModel = mapeador.Map<DetalhesGrupoAutomoveisViewModel>(GrupoDeAutomoveis);

        return View(detalhesGrupoDeAutomoveisViewModel);
    }

    [HttpPost]
    public IActionResult Excluir(DetalhesGrupoAutomoveisViewModel detalhesGrupoDeAutomoveisViewModel)
    {
        var resultado = servicoGrupoDeAutomoveis.Excluir(detalhesGrupoDeAutomoveisViewModel.Id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado);

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{detalhesGrupoDeAutomoveisViewModel.Id}] foi excluído com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Detalhes(int id)
    {
        var resultado = servicoGrupoDeAutomoveis.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var GrupoDeAutomoveis = resultado.Value;

        var detalhesGrupoDeAutomoveisViewModel = mapeador.Map<DetalhesGrupoAutomoveisViewModel>(GrupoDeAutomoveis);

        return View(detalhesGrupoDeAutomoveisViewModel);
    }
}