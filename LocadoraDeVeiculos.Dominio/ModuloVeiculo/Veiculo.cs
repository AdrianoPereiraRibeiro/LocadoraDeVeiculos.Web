using System.Net;
using System.Net.Mime;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeAutomoveis;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo;

public class Veiculo : EntidadeBase
{
    public string Modelo { get; set; }
    public string Marca { get; set; }
    public TipoCombustivel TipoCombustivel { get; set; }
    public int CapacidadeTanque { get; set; }
    public int GrupoDeAutomoveisId { get; set; }
    public GrupoDeAutomoveis? GrupoDeAutomoveis { get; set; }


    protected Veiculo() { }

    public Veiculo(
        string modelo,
        string marca,
        TipoCombustivel tipoCombustivel,
        int capacidadeTanque,
        int grupoDeAutomoveisId
    )
    {
        Modelo = modelo;
        Marca = marca;
        TipoCombustivel = tipoCombustivel;
        CapacidadeTanque = capacidadeTanque;
        GrupoDeAutomoveisId = grupoDeAutomoveisId;

    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (string.IsNullOrEmpty(Modelo))
            erros.Add("O modelo é obrigatório");

        if (string.IsNullOrEmpty(Marca))
            erros.Add("A marca é obrigatória");

        if (CapacidadeTanque == 0)
            erros.Add("A capacidade do tanque precisa ser informada");

        if (GrupoDeAutomoveisId == 0)
            erros.Add("O grupo de veículos é obrigatório");

        return erros;
    }
}