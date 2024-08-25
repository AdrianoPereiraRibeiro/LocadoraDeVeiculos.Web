using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LocadoraDeVeiculos.Web.Models
{
    public class FormularioCondutorViewModel
    {
        [Required(ErrorMessage = "O grupo de veículos é obrigatório")]
        public int ClienteId { get; set; }

        public IEnumerable<SelectListItem>? Cliente { get; set; }

       public bool ClienteEqualsCondutor { get; set; }
        
        
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve conter ao menos 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "A CNH é obrigatória")]
        public string CNH { get; set; }

        [Required(ErrorMessage = "A válidade é obrigatória")]
        public DateTime Validade { get; set; }

    }


    public class InserirCondutorViewModel : FormularioCondutorViewModel { }

    public class EditarCondutorViewModel : FormularioCondutorViewModel
    {
        public int Id { get; set; }
    }
    public class ListarCondutorViewModel
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public bool ClienteEqualsCondutor { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public string CNH { get; set; }
        public string Validade { get; set; }
    }

    public class DetalhesCondutorViewModel
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public bool ClienteEqualsCondutor { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public string CNH { get; set; }
        public string Validade { get; set; }
    }
}
