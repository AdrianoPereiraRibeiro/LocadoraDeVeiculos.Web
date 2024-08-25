using AutoMapper;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Service.Servicos;
using LocadoraDeVeiculos.Web.Aplicacao.Servicos;
using LocadoraDeVeiculos.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeVeiculos.Web.Controllers
{
    public class ClienteController : WebControllerBase
    {
        private readonly ClienteService servico;
        private readonly IMapper mapeador;

        public ClienteController(
            ClienteService servico, IMapper mapeador
        )
        {
            this.servico = servico;
            this.mapeador = mapeador;
        }

        public IActionResult Listar()
        {
            var resultado = servico.SelecionarTodos();

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction("Index", "Home");
            }

            var clientes = resultado.Value;

            var listarClientesVm = mapeador.Map<IEnumerable<ListarClienteViewModel>>(clientes);

            return View(listarClientesVm);
        }

        public IActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Inserir(InserirClienteViewModel inserirVm)
        {
            if (!ModelState.IsValid)
                return View();

            var cliente = mapeador.Map<Cliente>(inserirVm);

            cliente.TipoPessoa = (TipoPessoa)inserirVm.TipoDePessoa;

            var resultado = servico.Inserir(cliente);


            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{cliente.Id}] foi inserido com sucesso!");

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

            var cliente = resultado.Value;

            var editarVm = mapeador.Map<EditarClienteViewModel>(cliente);

            return View(editarVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarClienteViewModel editarVm)
        {
            if (!ModelState.IsValid)
                return View();

            var cliente = mapeador.Map<Cliente>(editarVm);

            var resultado = servico.Editar(cliente);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{cliente.Id}] foi editado com sucesso!");

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

            var cliente = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesClienteViewModel>(cliente);

            return View(detalhesVm);
        }

        [HttpPost]
        public IActionResult Excluir(DetalhesClienteViewModel detalhesVm)
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

            var cliente = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesClienteViewModel>(cliente);

            return View(detalhesVm);
        }

      
    }

}
