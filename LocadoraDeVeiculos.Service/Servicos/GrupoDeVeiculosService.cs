using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeAutomoveis;

namespace LocadoraDeVeiculos.Web.Aplicacao.Servicos;

public class GrupoDeAutomoveisService
{
    private readonly IRepositorioGrupoDeAutomoveis repositorioGrupoDeAutomoveis;

    public GrupoDeAutomoveisService(IRepositorioGrupoDeAutomoveis repositorioGrupoDeAutomoveis)
    {
        this.repositorioGrupoDeAutomoveis = repositorioGrupoDeAutomoveis;
    }

    public Result<GrupoDeAutomoveis> Inserir(GrupoDeAutomoveis GrupoDeAutomoveis)
    {
        repositorioGrupoDeAutomoveis.Inserir(GrupoDeAutomoveis);

        return Result.Ok(GrupoDeAutomoveis);
    }

    public Result<GrupoDeAutomoveis> Editar(GrupoDeAutomoveis grupoDeAutomoveisAtualizado)
    {
        var GrupoDeAutomoveis = repositorioGrupoDeAutomoveis.SelecionarPorId(grupoDeAutomoveisAtualizado.Id);

        if (GrupoDeAutomoveis is null)
            return Result.Fail("O Grupo De Automoveis não foi encontrado!");

        GrupoDeAutomoveis.Nome = grupoDeAutomoveisAtualizado.Nome;


        repositorioGrupoDeAutomoveis.Editar(GrupoDeAutomoveis);

        return Result.Ok(GrupoDeAutomoveis);
    }

    public Result Excluir(int salaId)
    {
        var GrupoDeAutomoveis = repositorioGrupoDeAutomoveis.SelecionarPorId(salaId);

        if (GrupoDeAutomoveis is null)
            return Result.Fail("O Grupo De Automoveis não foi encontrado!");

        repositorioGrupoDeAutomoveis.Excluir(GrupoDeAutomoveis);

        return Result.Ok();
    }

    public Result<GrupoDeAutomoveis> SelecionarPorId(int salaId)
    {
        var GrupoDeAutomoveis = repositorioGrupoDeAutomoveis.SelecionarPorId(salaId);

        if (GrupoDeAutomoveis is null)
            return Result.Fail("O Grupo De Automoveis não foi encontrado!");

        return Result.Ok(GrupoDeAutomoveis);
    }

    public Result<List<GrupoDeAutomoveis>> SelecionarTodos(int usuarioId)
    {
        var GrupoDeAutomoveis = repositorioGrupoDeAutomoveis.SelecionarTodos();
        //var salas = repositorioGrupoDeAutomoveis
        //    .Filtrar(f => f.UsuarioId == usuarioId);

        return Result.Ok(GrupoDeAutomoveis);
    }
}