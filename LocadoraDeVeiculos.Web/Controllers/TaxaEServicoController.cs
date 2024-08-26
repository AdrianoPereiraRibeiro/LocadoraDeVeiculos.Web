using AutoMapper;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeVeiculos.Dominio.ModuloTaxaEServico;
using LocadoraDeVeiculos.Service.Servicos;
using LocadoraDeVeiculos.Web.Aplicacao.Servicos;
using LocadoraDeVeiculos.Web.Extensions;
using LocadoraDeVeiculos.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeVeiculos.Web.Controllers
{
    public class TaxaEServicoController : WebControllerBase
    {
        private readonly TaxaEServicoService servicoTaxaEServico;
        private readonly IMapper mapeador;

        public TaxaEServicoController(TaxaEServicoService servicoTaxaEServico, IMapper mapeador)
        {
            this.servicoTaxaEServico = servicoTaxaEServico;
            this.mapeador = mapeador;
        }

        public IActionResult Listar()
        {
            var resultado =
                servicoTaxaEServico.SelecionarTodos(1);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction("Index", "Inicio");
            }

            var taxaEServicos = resultado.Value;

            var listarTaxasEServicoViewModel
                = mapeador.Map<IEnumerable<ListarTaxaEServicoViewModel>>(taxaEServicos);

            ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();

            return View(listarTaxasEServicoViewModel);
        }

        public IActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Inserir(InserirTaxaEServicoViewModel inserirTaxaEServicoVm)
        {
            if (!ModelState.IsValid)
                return View(inserirTaxaEServicoVm);

            var novaTaxaEServico = mapeador.Map<TaxaEServico>(inserirTaxaEServicoVm);

            //novaSala.UsuarioId = UsuarioId.GetValueOrDefault();

            var resultado = servicoTaxaEServico.Inserir(novaTaxaEServico);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{novaTaxaEServico.Id}] foi inserido com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Editar(int id)
        {
            var resultado = servicoTaxaEServico.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var taxaEServico = resultado.Value;

            var editarTaxaEServicoVm = mapeador.Map<EditarTaxaEServicoViewModel>(taxaEServico);

            return View(editarTaxaEServicoVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarTaxaEServicoViewModel editarTaxaEServicoVm)
        {
            if (!ModelState.IsValid)
                return View(editarTaxaEServicoVm);

            var taxaEServico = mapeador.Map<TaxaEServico>(editarTaxaEServicoVm);

            var resultado = servicoTaxaEServico.Editar(taxaEServico);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{taxaEServico.Id}] foi editado com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Excluir(int id)
        {
            var resultado = servicoTaxaEServico.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var taxaEServico = resultado.Value;

            var detalhesTaxaEServicoViewModel = mapeador.Map<DetalhesTaxaEServicoViewModel>(taxaEServico);

            return View(detalhesTaxaEServicoViewModel);
        }

        [HttpPost]
        public IActionResult Excluir(DetalhesTaxaEServicoViewModel detalhesTaxaEServicoViewModel)
        {
            var resultado = servicoTaxaEServico.Excluir(detalhesTaxaEServicoViewModel.Id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado);

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{detalhesTaxaEServicoViewModel.Id}] foi excluído com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Detalhes(int id)
        {
            var resultado = servicoTaxaEServico.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var taxaEServico = resultado.Value;

            var detalhesTaxaEServicoViewModel = mapeador.Map<DetalhesTaxaEServicoViewModel>(taxaEServico);

            return View(detalhesTaxaEServicoViewModel);
        }
    }
}
