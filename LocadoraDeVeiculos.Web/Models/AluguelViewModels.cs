using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;

namespace LocadoraDeVeiculos.Web.Models;

public class FormularioAluguelViewModel
{
    [Required(ErrorMessage = "O cliente é obrigatório")]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "O veículo é obrigatório")]
    public int VeiculoId { get; set; }

    [Required(ErrorMessage = "O condutor é obrigatório")]
    public int CondutorId { get; set; }

    [Required(ErrorMessage = "O tipo de plano é obrigatório")]
    public TipoPlanoCobrancaEnum TipoPlano { get; set; }

    [Required(ErrorMessage = "O marcador de combustível é obrigatório")]
    public MarcadorCombustivelEnum MarcadorCombustivel { get; set; }

    [Required(ErrorMessage = "A quilometragem percorrida é obrigatória")]
    [Range(0, int.MaxValue, ErrorMessage = "A quilometragem percorrida deve ser maior ou igual a 0")]
    public int QuilometragemPercorrida { get; set; }

    [Required(ErrorMessage = "A data da locação é obrigatória")]
    [DataType(DataType.Date)]
    public DateTime DataLocacao { get; set; }

    [Required(ErrorMessage = "A data prevista de devolução é obrigatória")]
    [DataType(DataType.Date)]
    public DateTime DevolucaoPrevista { get; set; }

    public IEnumerable<int> TaxasSelecionadas { get; set; }

    public IEnumerable<SelectListItem>? Clientes { get; set; }
    public IEnumerable<SelectListItem>? Veiculos { get; set; }
    public IEnumerable<SelectListItem>? Condutores { get; set; }
    public IEnumerable<SelectListItem>? Taxas { get; set; }

    public FormularioAluguelViewModel()
    {
        DataLocacao = DateTime.Now;
        DevolucaoPrevista = DateTime.Now.AddDays(1);
       
    }
}

public class InserirAluguelViewModel : FormularioAluguelViewModel
{
}

public class EditarAluguelViewModel : FormularioAluguelViewModel
{
    public int Id { get; set; }
}

public class RealizarDevolucaoViewModel : FormularioAluguelViewModel
{
    public int Id { get; set; }
}

public class ListarAluguelViewModel
{
    public int Id { get; set; }
    public string Cliente { get; set; }
    public string Veiculo { get; set; }
    public string Condutor { get; set; }
    public string TipoPlano { get; set; }
    public int QuilometragemPercorrida { get; set; }
    public DateTime DataLocacao { get; set; }
    public DateTime DevolucaoPrevista { get; set; }
    public DateTime? DataDevolucao { get; set; }
}

public class DetalhesAluguelViewModel
{
    public int Id { get; set; }
    public string Cliente { get; set; }
    public string Veiculo { get; set; }
    public string Condutor { get; set; }
    public string TipoPlano { get; set; }
    public string MarcadorCombustivel { get; set; }
    public int QuilometragemPercorrida { get; set; }
    public DateTime DataLocacao { get; set; }
    public DateTime DevolucaoPrevista { get; set; }
    public DateTime? DataDevolucao { get; set; }
}