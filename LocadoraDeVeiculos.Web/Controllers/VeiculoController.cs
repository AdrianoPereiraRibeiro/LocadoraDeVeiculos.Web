using AutoMapper;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Service.Servicos;
using LocadoraDeVeiculos.Web.Aplicacao.Servicos;
using LocadoraDeVeiculos.Web.Controllers;
using LocadoraDeVeiculos.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeVeiculos.WebApp.Controllers;

public class VeiculoController : WebControllerBase
{
    private readonly VeiculoService servico;
    private readonly GrupoDeAutomoveisService servicoGrupos;
    private readonly IMapper mapeador;

    public VeiculoController(
        VeiculoService servico,
        GrupoDeAutomoveisService servicoGrupos,
        IMapper mapeador
    )
    {
        this.servico = servico;
        this.servicoGrupos = servicoGrupos;
        this.mapeador = mapeador;
    }

    public IActionResult Listar()
    {
        var resultado = servico.SelecionarTodos(UsuarioId.GetValueOrDefault());

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction("Index", "Home");
        }

        var veiculos = resultado.Value;

        var listarVeiculosVm = mapeador.Map<IEnumerable<ListarVeiculoViewModel>>(veiculos);

        return View(listarVeiculosVm);
    }

    public IActionResult Inserir()
    {
        return View(CarregarDadosFormulario());
    }

    [HttpPost]
    public IActionResult Inserir(InserirVeiculoViewModel inserirVm)
    {
        if (!ModelState.IsValid)
            return View(CarregarDadosFormulario(inserirVm));

        var veiculo = mapeador.Map<Veiculo>(inserirVm);

        veiculo.UsuarioId = UsuarioId.GetValueOrDefault();

        var resultado = servico.Inserir(veiculo);


        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{veiculo.Id}] foi inserido com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Editar(int id)
    {
        var resultado = servico.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var resultadoGrupos = servicoGrupos.SelecionarTodos(1);

        if (resultadoGrupos.IsFailed)
        {
            ApresentarMensagemFalha(resultadoGrupos.ToResult());

            return null;
        }

        var veiculo = resultado.Value;

        var editarVm = mapeador.Map<EditarVeiculoViewModel>(veiculo);

        var gruposDisponiveis = resultadoGrupos.Value;

        editarVm.GrupoDeAutomoveis = gruposDisponiveis
            .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));

        return View(editarVm);
    }

    [HttpPost]
    public IActionResult Editar(EditarVeiculoViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(CarregarDadosFormulario(editarVm));

        var veiculo = mapeador.Map<Veiculo>(editarVm);

        var resultado = servico.Editar(veiculo);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{veiculo.Id}] foi editado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Excluir(int id)
    {
        var resultado = servico.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var veiculo = resultado.Value;

        var detalhesVm = mapeador.Map<DetalhesVeiculoViewModel>(veiculo);

        return View(detalhesVm);
    }

    [HttpPost]
    public IActionResult Excluir(DetalhesVeiculoViewModel detalhesVm)
    {
        var resultado = servico.Excluir(detalhesVm.Id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{detalhesVm.Id}] foi excluído com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Detalhes(int id)
    {
        var resultado = servico.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var veiculo = resultado.Value;

        var detalhesVm = mapeador.Map<DetalhesVeiculoViewModel>(veiculo);

        return View(detalhesVm);
    }

    private FormularioVeiculoViewModel? CarregarDadosFormulario(
        FormularioVeiculoViewModel? dadosPrevios = null)
    {
        var resultadoGrupos = servicoGrupos.SelecionarTodos(1);

        if (resultadoGrupos.IsFailed)
        {
            ApresentarMensagemFalha(resultadoGrupos.ToResult());

            return null;
        }

        var gruposDisponiveis = resultadoGrupos.Value;

        if (dadosPrevios is null)
        {
            var formularioVm = new FormularioVeiculoViewModel
            {
                GrupoDeAutomoveis = gruposDisponiveis
                    .Select(g => new SelectListItem(g.Nome, g.Id.ToString()))
            };

            return formularioVm;
        }

        dadosPrevios.GrupoDeAutomoveis = gruposDisponiveis
            .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));

        return dadosPrevios;
    }
}
