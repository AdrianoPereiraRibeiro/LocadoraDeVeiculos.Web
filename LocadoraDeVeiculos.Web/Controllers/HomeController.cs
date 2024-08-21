using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeVeiculos.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}