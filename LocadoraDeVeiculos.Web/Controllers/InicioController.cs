using AutoMapper;
using LocadoraDeVeiculos.Web.Aplicacao.Servicos;
using LocadoraDeVeiculos.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeVeiculos.Web.Controllers;

public class InicioController : WebControllerBase
{
 
    private readonly GrupoDeAutomoveisService servicoGrupoDeAutomoveis;
    private readonly IMapper mapeador;

    public InicioController(
        GrupoDeAutomoveisService servicoGrupoDeAutomoveis,
        IMapper mapeador
    )
    {
 
        this.servicoGrupoDeAutomoveis = servicoGrupoDeAutomoveis;
        this.mapeador = mapeador;
    }

    public ViewResult Index()
    {

        //if (UsuarioId.HasValue)
        //{
        //    ViewBag.QuantidadeFilmes = servicoFilme.SelecionarTodos(UsuarioId.Value).Value.Count;
        //    ViewBag.QuantidadeGeneros = servicoGenero.SelecionarTodos(UsuarioId.Value).Value.Count;
        //    ViewBag.QuantidadeSalas = servicoGrupoDeAutomoveis.SelecionarTodos(UsuarioId.Value).Value.Count;
        //    ViewBag.QuantidadeSessoes = servicoSessao.SelecionarTodos(UsuarioId.Value).Value.Count;
        //    ViewBag.QuantidadeIngressos = servicoSessao.SelecionarTodosIngressos(UsuarioId.Value).Value.Count;
        //}

       ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();

        return View();
    }

}