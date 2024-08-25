using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;

namespace LocadoraDeVeiculos.Web.Models
{
    public class FormularioClienteViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve conter ao menos 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O tipo de pessoa é obrigatório")]
        public int TipoDePessoa { get; set; }

        public string? CPF  { get; set; }

        public string? CNPJ { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O cidade é obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A rua é obrigatória")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "O número é obrigatório")]
        public string Numero { get; set; }
    }

    public class InserirClienteViewModel : FormularioClienteViewModel { }

    public class EditarClienteViewModel : FormularioClienteViewModel
    {
        public int Id { get; set; }
    }

    public class ListarClienteViewModel
    {
        public int Id { get; set; }
        public string Nome{ get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string TipoDePessoa { get; set; }
        public string? CPF { get; set; }
        public string? CNPJ { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
    }

    public class DetalhesClienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int TipoDePessoa { get; set; }
        public string? CPF { get; set; }
        public string? CNPJ { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
    }
}
