using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LocadoraDeVeiculos.Web.Models;

public class FormularioVeiculoViewModel
{
    [Required(ErrorMessage = "O modelo é obrigatório")]
    [MinLength(3, ErrorMessage = "O modelo deve conter ao menos 3 caracteres")]
    public string Modelo { get; set; }

    [Required(ErrorMessage = "A marca é obrigatória")]
    [MinLength(2, ErrorMessage = "A marca deve conter ao menos 2 caracteres")]
    public string Marca { get; set; }

    [Required(ErrorMessage = "O tipo de combustível é obrigatório")]
    public int TipoCombustivel { get; set; }

    [Required(ErrorMessage = "A capacidade do tanque é obrigatória")]
    [Range(1, int.MaxValue, ErrorMessage = "A capacidade do tanque deve ser maior que 0")]
    public int CapacidadeTanque { get; set; }

    [Required(ErrorMessage = "O grupo de veículos é obrigatório")]
    public int GrupoDeAutomoveisId { get; set; }

    public IEnumerable<SelectListItem>? GrupoDeAutomoveis { get; set; }
}

public class InserirVeiculoViewModel : FormularioVeiculoViewModel { }

public class EditarVeiculoViewModel : FormularioVeiculoViewModel
{
    public int Id { get; set; }
}

public class ListarVeiculoViewModel
{
    public int Id { get; set; }
    public string Modelo { get; set; }
    public string Marca { get; set; }
    public string TipoCombustivel { get; set; }
    public int CapacidadeTanque { get; set; }
    public string GrupoDeAutomoveis { get; set; }
}

public class DetalhesVeiculoViewModel
{
    public int Id { get; set; }
    public string Modelo { get; set; }
    public string Marca { get; set; }
    public string TipoCombustivel { get; set; }
    public int CapacidadeTanque { get; set; }
    public string GrupoDeAutomoveis { get; set; }
}