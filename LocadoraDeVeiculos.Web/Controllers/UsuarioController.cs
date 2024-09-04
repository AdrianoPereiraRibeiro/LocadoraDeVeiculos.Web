using LocadoraDeVeiculos.Web.Dominio.ModuloUsuario;
using LocadoraDeVeiculos.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeVeiculos.Web.Controllers;

public class UsuarioController : Controller
{
    private readonly UserManager<Usuario> userManager;
    private readonly SignInManager<Usuario> signInManager;
    private readonly RoleManager<Perfil> roleManager;

    public UsuarioController(
        UserManager<Usuario> userManager,
        SignInManager<Usuario> signInManager,
        RoleManager<Perfil> roleManager
    )
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.roleManager = roleManager;
    }

    public IActionResult Registrar()
    {
        return View(new RegistrarViewModel());
    }


    [HttpPost]
    public async Task<IActionResult> Registrar(RegistrarViewModel registrarVm)
    {
        if (!ModelState.IsValid)
            return View(registrarVm);

        var usuario = new Usuario()
        {
            UserName = registrarVm.Usuario,
            Email = registrarVm.Email
        };

        var resultadoCriacaoUsuario =
            await userManager.CreateAsync(usuario, registrarVm.Senha!);

        var resultadoCriacaoTipoUsuario =
            await roleManager.FindByNameAsync(registrarVm.Tipo);

        if (resultadoCriacaoTipoUsuario is null)
        {
            var cargo = new Perfil()
            {
                Name = registrarVm.Tipo,
                NormalizedName = registrarVm.Tipo!.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            await roleManager.CreateAsync(cargo);
        }

        await userManager.AddToRoleAsync(usuario, registrarVm.Tipo);

        if (resultadoCriacaoUsuario.Succeeded)
        {
            await signInManager.SignInAsync(usuario, isPersistent: false);

            return RedirectToAction("Index", "Home");
        }

        foreach (var erro in resultadoCriacaoUsuario.Errors)
            ModelState.AddModelError(string.Empty, erro.Description);

        return View(registrarVm);
    }


    public IActionResult Login(string? returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;

        if (!ModelState.IsValid)
            return View(model);

        var resultadoLogin = await signInManager.PasswordSignInAsync(
            model.Usuario,
            model.Senha,
            false,
            false
        );

        if (resultadoLogin.Succeeded)
            return LocalRedirect(returnUrl ?? "/");

        ModelState.AddModelError(string.Empty, "Login ou senha inválidos");

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();

        return RedirectToAction(nameof(Login));
    }

    public IActionResult AcessoNegado()
    {
        return View();
    }
}