using AutoMapper;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeAutomoveis;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeVeiculos.Web.Mapping.Resolvers;

public class GrupoDeAutomoveisValueResolver :
    IValueResolver<object, object, IEnumerable<SelectListItem>?>
{
    private readonly IRepositorioGrupoDeAutomoveis repositorioGrupo;

    public GrupoDeAutomoveisValueResolver(IRepositorioGrupoDeAutomoveis repositorioGrupo)
    {
        this.repositorioGrupo = repositorioGrupo;
    }

    public IEnumerable<SelectListItem> Resolve(
        object source,
        object destination,
        IEnumerable<SelectListItem>? destMember,
        ResolutionContext context
    )
    {
        return repositorioGrupo
            .SelecionarTodos()
            .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));
    }
}
