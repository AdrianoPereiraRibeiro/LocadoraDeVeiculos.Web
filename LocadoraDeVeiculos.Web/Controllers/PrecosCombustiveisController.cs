using AutoMapper;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeVeiculos.Web.Aplicacao.Servicos;
using LocadoraDeVeiculos.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LocadoraDeVeiculos.Service.Servicos;
using LocadoraDeVeiculos.Web.Extensions;
using LocadoraDeVeiculos.Dominio.ModuloPrecosCombustiveis;
using LocadoraDeVeiculos.Dominio.ModuloCliente;

namespace LocadoraDeVeiculos.Web.Controllers
{
    public class PrecosCombustiveisController : WebControllerBase
    {
        private readonly PrecosCombustiveisService service;
        private readonly IMapper mapeador;

        public PrecosCombustiveisController(PrecosCombustiveisService service, IMapper mapeador)
        {
            this.service = service;
            this.mapeador = mapeador;
        }

        public IActionResult Listar()
        {
            var resultado =
                service.SelecionarTodos(UsuarioId.GetValueOrDefault());

            if (resultado.Value.Count == 0)
            {
                PrecosCombustiveis precosPadrao = new PrecosCombustiveis();
                precosPadrao.PrecoGasolina = 1;
                precosPadrao.PrecoDiesel = 1;
                precosPadrao.PrecoGas = 1;
                precosPadrao.PrecoAlcool = 1;
                precosPadrao.UsuarioId = UsuarioId.GetValueOrDefault();
                service.Inserir(precosPadrao);
            }

            var precosCombustiveisList = resultado.Value;

            var listarCombustiveisViewModel
                = mapeador.Map<IEnumerable<ListarPrecosCombustiveisViewModel>>(precosCombustiveisList);

            ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();

            return View(listarCombustiveisViewModel);
        }


        public IActionResult Editar(int id)
        {
            var resultado = service.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var precosCombustiveis = resultado.Value;

            var editarPrecosDeCombustiveisVm = mapeador.Map<EditarPrecosCombustiveisViewModel>(precosCombustiveis);

            return View(editarPrecosDeCombustiveisVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarPrecosCombustiveisViewModel editarPrecosCombustiveisVm)
        {
            if (!ModelState.IsValid)
                return View(editarPrecosCombustiveisVm);

            var precosCombustiveis = mapeador.Map<PrecosCombustiveis>(editarPrecosCombustiveisVm);

            var resultado = service.Editar(precosCombustiveis);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{precosCombustiveis.Id}] foi editado com sucesso!");

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

            var precosCombustiveis = resultado.Value;

            var detalhesPrecosCombustiveisViewModel =
                mapeador.Map<DetalhesPrecosCombustiveisViewModel>(precosCombustiveis);

            return View(detalhesPrecosCombustiveisViewModel);
        }
    }
}