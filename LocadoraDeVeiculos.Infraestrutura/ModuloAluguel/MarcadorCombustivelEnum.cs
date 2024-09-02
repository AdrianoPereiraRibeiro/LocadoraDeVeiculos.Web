using System.ComponentModel.DataAnnotations;

namespace LocadoraDeVeiculos.Dominio.ModuloLocacao;

public enum MarcadorCombustivelEnum
{
    Vazio,
    [Display(Name = "Um Quarto")] UmQuarto,
    [Display(Name = "Meio Tanque")] MeioTanque,
    [Display(Name = "Três Quartos")] TresQuartos,
    Completo
}