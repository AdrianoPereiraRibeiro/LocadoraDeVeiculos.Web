using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LocadoraDeVeiculos.Web.Models;

public class FormularioPlanoCobrancaViewModel
{
    [Required(ErrorMessage = "O grupo de veículos é obrigatório")]
    public int GrupoDeAutomoveisId { get; set; }

    [Required(ErrorMessage = "O preço diário do plano diário é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço diário do plano diário deve ser maior que 0")]
    public decimal PrecoDiarioPlanoDiario { get; set; }

    [Required(ErrorMessage = "O preço por quilômetro do plano diário é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço por quilômetro do plano diário deve ser maior que 0")]
    public decimal PrecoQuilometroPlanoDiario { get; set; }

    [Required(ErrorMessage = "Os quilômetros disponíveis no plano controlado são obrigatórios")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Os quilômetros disponíveis no plano controlado devem ser maiores que 0")]
    public decimal QuilometrosDisponiveisPlanoControlado { get; set; }

    [Required(ErrorMessage = "O preço diário do plano controlado é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço diário do plano controlado deve ser maior que 0")]
    public decimal PrecoDiarioPlanoControlado { get; set; }

    [Required(ErrorMessage = "O preço por quilômetro extrapolado no plano controlado é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço por quilômetro extrapolado no plano controlado deve ser maior que 0")]
    public decimal PrecoQuilometroExtrapoladoPlanoControlado { get; set; }

    [Required(ErrorMessage = "O preço diário do plano livre é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço diário do plano livre deve ser maior que 0")]
    public decimal PrecoDiarioPlanoLivre { get; set; }

    public IEnumerable<SelectListItem>? GruposDeAutomoveis { get; set; }
}

public class InserirPlanoCobrancaViewModel : FormularioPlanoCobrancaViewModel
{

}

public class EditarPlanoCobrancaViewModel : FormularioPlanoCobrancaViewModel
{
    public int Id { get; set; }
}

public class ListarPlanoCobrancaViewModel
{
    public int Id { get; set; }
    public string GrupoDeAutomoveis { get; set; }
    public decimal PrecoDiarioPlanoDiario { get; set; }
    public decimal PrecoQuilometroPlanoDiario { get; set; }
    public decimal QuilometrosDisponiveisPlanoControlado { get; set; }
    public decimal PrecoDiarioPlanoControlado { get; set; }
    public decimal PrecoQuilometroExtrapoladoPlanoControlado { get; set; }
    public decimal PrecoDiarioPlanoLivre { get; set; }
}

public class DetalhesPlanoCobrancaViewModel
{
    public int Id { get; set; }
    public string GrupoDeAutomoveis { get; set; }
    public decimal PrecoDiarioPlanoDiario { get; set; }
    public decimal PrecoQuilometroPlanoDiario { get; set; }
    public decimal QuilometrosDisponiveisPlanoControlado { get; set; }
    public decimal PrecoDiarioPlanoControlado { get; set; }
    public decimal PrecoQuilometroExtrapoladoPlanoControlado { get; set; }
    public decimal PrecoDiarioPlanoLivre { get; set; }
}
