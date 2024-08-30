using AutoMapper;
using LocadoraDeVeiculos.Service.Servicos;
using LocadoraDeVeiculos.Web.Aplicacao.Servicos;
using LocadoraDeVeiculos.Web.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using LocadoraDeVeiculos.Dominio.ModuloCliente;

namespace LocadoraDeVeiculos.Web.Controllers
{
    public class PlanoCobrancaController : WebControllerBase
    {
        private readonly PlanoCobrancaService service;
        private readonly GrupoDeAutomoveisService gruposDeAutomoveisService;
        private readonly IMapper mapeador;

        public PlanoCobrancaController(
            PlanoCobrancaService service,
            GrupoDeAutomoveisService gruposDeAutomoveisService,
            IMapper mapeador)
        {
            this.service = service;
            this.gruposDeAutomoveisService = gruposDeAutomoveisService;
            this.mapeador = mapeador;
        }

        public IActionResult Listar()
        {
            var resultado = service.SelecionarTodos(UsuarioId.GetValueOrDefault());

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction("Index", "Home");
            }

            var planosCobranca = resultado.Value;

            var listarPlanosVm = mapeador.Map<IEnumerable<ListarPlanoCobrancaViewModel>>(planosCobranca);

            return View(listarPlanosVm);
        }

        public IActionResult Inserir()
        {
            return View(CarregarDadosFormulario());
        }

        [HttpPost]
        public IActionResult Inserir(InserirPlanoCobrancaViewModel inserirVm)
        {
            if (!ModelState.IsValid)
                return View(CarregarDadosFormulario(inserirVm));

            var planoCobranca = mapeador.Map<PlanoCobranca>(inserirVm);

            planoCobranca.UsuarioId = UsuarioId.GetValueOrDefault();

            var resultado = service.Inserir(planoCobranca);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{planoCobranca.Id}] foi inserido com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Editar(int id)
        {
            var resultado = service.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var planoCobranca = resultado.Value;

            var editarVm = mapeador.Map<EditarPlanoCobrancaViewModel>(planoCobranca);

            return View(editarVm);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(EditarPlanoCobrancaViewModel editarVm)
        {
            if (!ModelState.IsValid)
                return View(CarregarDadosFormulario(editarVm));

            var planoCobranca = mapeador.Map<PlanoCobranca>(editarVm);

            var resultado = service.Editar(planoCobranca);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{planoCobranca.Id}] foi editado com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Excluir(int id)
        {
            var resultado = service.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var planoCobranca = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesPlanoCobrancaViewModel>(planoCobranca);

            return View(detalhesVm);
        }

        [HttpPost]
        public IActionResult Excluir(DetalhesPlanoCobrancaViewModel detalhesVm)
        {
            var resultado = service.Excluir(detalhesVm.Id);

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
            var resultado = service.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var planoCobranca = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesPlanoCobrancaViewModel>(planoCobranca);

            return View(detalhesVm);
        }

        private FormularioPlanoCobrancaViewModel? CarregarDadosFormulario(FormularioPlanoCobrancaViewModel? dadosPrevios = null)
        {
            var resultadoGrupos = gruposDeAutomoveisService.SelecionarTodos(1);

            if (resultadoGrupos.IsFailed)
            {
                ApresentarMensagemFalha(resultadoGrupos.ToResult());

                return null;
            }

            if (dadosPrevios is null)
                dadosPrevios = new FormularioPlanoCobrancaViewModel();

            dadosPrevios.GruposDeAutomoveis = resultadoGrupos.Value
                .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));

            return dadosPrevios;
        }
    }

}
