using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using LocadoraDeVeiculos.Web.Extensions;
using LocadoraDeVeiculos.WebApp.Models;

namespace LocadoraDeVeiculos.Web.Controllers;

public abstract class AuthController : Controller
{
    protected int? UsuarioId
    {
        get
        {
            var usuarioAutenticado = User.FindFirst(ClaimTypes.NameIdentifier);

            if (usuarioAutenticado is null)
                return null;

            return int.Parse(usuarioAutenticado.Value);
        }
    }

    protected IActionResult MensagemRegistroNaoEncontrado(int idRegistro)
    {
        TempData.SerializarMensagemViewModel(new MensagemViewModel
        {
            Titulo = "Erro",
            Mensagem = $"Não foi possível encontrar o registro ID [{idRegistro}]!"
        });

        return RedirectToAction("Index", "Home");
    }
}