using System.ComponentModel.DataAnnotations;

namespace LocadoraDeVeiculos.Web.Models
{
    public class InserirTaxaEServicoViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve conter ao menos 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A seleção de cobrança é obrigatório")]
        public string FixoOuDiario { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Preco { get; set; }
    }

    public class EditarTaxaEServicoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve conter ao menos 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A seleção de cobrança é obrigatório")]
        public string FixoOuDiario { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Preco { get; set; }
    }

    public class ListarTaxaEServicoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string FixoOuDiario { get; set; }
        public decimal Preco { get; set; }
    }

    public class DetalhesTaxaEServicoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string FixoOuDiario { get; set; }
        public decimal Preco { get; set; }
    }
}
