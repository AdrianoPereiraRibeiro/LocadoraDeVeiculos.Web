using AutoMapper;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Service.Servicos;
using LocadoraDeVeiculos.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeVeiculos.Web.Controllers
{
    public class CondutorController : WebControllerBase
    {
        private readonly CondutorService servico;
        private readonly ClienteService servicoClientes;
        private readonly IMapper mapeador;

        public CondutorController(
            CondutorService servico,
            ClienteService servicoGrupos,
            IMapper mapeador
        )
        {
            this.servico = servico;
            this.servicoClientes = servicoGrupos;
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

            var condutors = resultado.Value;

            var listarCondutorViewModels = mapeador.Map<IEnumerable<ListarCondutorViewModel>>(condutors);

            return View(listarCondutorViewModels);
        }

        public IActionResult Inserir()
        {
            return View(CarregarDadosFormulario());
        }

        [HttpPost]
        public IActionResult Inserir(InserirCondutorViewModel inserirVm)
        {
            if (!ModelState.IsValid)
                return View(CarregarDadosFormulario(inserirVm));

            var condutor = mapeador.Map<Condutor>(inserirVm);

            condutor.UsuarioId = UsuarioId.GetValueOrDefault();

            var resultado = servico.Inserir(condutor);


            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{condutor.Id}] foi inserido com sucesso!");

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

            var resultadoClientes = servicoClientes.SelecionarTodos(UsuarioId.GetValueOrDefault());

            if (resultadoClientes.IsFailed)
            {
                ApresentarMensagemFalha(resultadoClientes.ToResult());

                return null;
            }

            var condutor = resultado.Value;

            var editarVm = mapeador.Map<EditarCondutorViewModel>(condutor);

            var clientesDisponiveis = resultadoClientes.Value;

            editarVm.Cliente = clientesDisponiveis
                .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));

            return View(editarVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarCondutorViewModel editarVm)
        {
            if (!ModelState.IsValid)
                return View(CarregarDadosFormulario(editarVm));

            var condutor = mapeador.Map<Condutor>(editarVm);

            var resultado = servico.Editar(condutor);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{condutor.Id}] foi editado com sucesso!");

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

            var condutor = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesCondutorViewModel>(condutor);

            return View(detalhesVm);
        }

        [HttpPost]
        public IActionResult Excluir(DetalhesCondutorViewModel detalhesVm)
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

            var condutor = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesCondutorViewModel>(condutor);

            return View(detalhesVm);
        }

        private FormularioCondutorViewModel? CarregarDadosFormulario(
            FormularioCondutorViewModel? dadosPrevios = null)
        {
            var resutadoClientes = servicoClientes.SelecionarTodos(UsuarioId.GetValueOrDefault());

            if (resutadoClientes.IsFailed)
            {
                ApresentarMensagemFalha(resutadoClientes.ToResult());

                return null;
            }

            var clientesDisponiveis = resutadoClientes.Value;

            if (dadosPrevios is null)
            {
                var formularioVm = new FormularioCondutorViewModel()
                {
                    Cliente = clientesDisponiveis
                        .Select(g => new SelectListItem(g.Nome, g.Id.ToString()))
                };

                return formularioVm;
            }

            dadosPrevios.Cliente = clientesDisponiveis
                .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));

            return dadosPrevios;
        }
    }


}
