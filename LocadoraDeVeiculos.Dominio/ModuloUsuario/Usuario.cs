using Microsoft.AspNetCore.Identity;

namespace LocadoraDeVeiculos.Web.Dominio.ModuloUsuario;

public class Usuario : IdentityUser<int>
{
    public Usuario()
    {
        EmailConfirmed = true;
    }
}