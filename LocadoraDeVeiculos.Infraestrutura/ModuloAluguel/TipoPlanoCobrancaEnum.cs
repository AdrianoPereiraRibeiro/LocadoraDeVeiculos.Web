using System.ComponentModel.DataAnnotations;

namespace LocadoraDeVeiculos.Dominio.ModuloLocacao;

public enum TipoPlanoCobrancaEnum
{
    [Display(Name = "Diário")] Diario,
    Controlado,
    Livre
}