using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeAutomoveis;


namespace LocadoraDeVeiculos.Web.Dominio.ModuloPlanoCobranca;

public class PlanoCobranca : EntidadeBase
{
    public int GrupoDeAutomoveisId { get; set; }
    public GrupoDeAutomoveis? GrupoDeAutomoveis { get; set; }

    public decimal PrecoDiarioPlanoDiario { get; set; }
    public decimal PrecoQuilometroPlanoDiario { get; set; }

    public decimal QuilometrosDisponiveisPlanoControlado { get; set; }
    public decimal PrecoDiarioPlanoControlado { get; set; }
    public decimal PrecoQuilometroExtrapoladoPlanoControlado { get; set; }

    public decimal PrecoDiarioPlanoLivre { get; set; }

    protected PlanoCobranca() { }

    public PlanoCobranca(
        int grupoDeAutomoveisId,
        decimal precoDiarioPlanoDiario,
        decimal precoQuilometroPlanoDiario,
        decimal quilometrosDisponiveisPlanoControlado,
        decimal precoDiarioPlanoControlado,
        decimal precoQuilometroExtrapoladoPlanoControlado,
        decimal precoDiarioPlanoLivre
    )
    {
        GrupoDeAutomoveisId = grupoDeAutomoveisId;

        PrecoDiarioPlanoDiario = precoDiarioPlanoDiario;
        PrecoQuilometroPlanoDiario = precoQuilometroPlanoDiario;

        QuilometrosDisponiveisPlanoControlado = quilometrosDisponiveisPlanoControlado;
        PrecoDiarioPlanoControlado = precoDiarioPlanoControlado;
        PrecoQuilometroExtrapoladoPlanoControlado = precoQuilometroExtrapoladoPlanoControlado;

        PrecoDiarioPlanoLivre = precoDiarioPlanoLivre;
    }


    public override List<string> Validar()
    {
        List<string> erros = [];

        if (GrupoDeAutomoveisId == 0)
            erros.Add("O grupo de automóveis é obrigatório");

        return erros;
    }
}
