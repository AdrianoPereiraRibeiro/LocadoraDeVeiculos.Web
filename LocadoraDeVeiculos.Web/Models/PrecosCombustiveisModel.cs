using System.ComponentModel.DataAnnotations;

namespace LocadoraDeVeiculos.Web.Models
{


    public class EditarPrecosCombustiveisViewModel
    {
        public int Id { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal PrecoGasolina { get; set; }
       
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal PrecoDiesel{ get; set; }
        
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal PrecoGas { get; set; }
        
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal PrecoAlcool { get; set; }
    }

    public class ListarPrecosCombustiveisViewModel
    {
        public int Id { get; set; }
        public decimal PrecoGasolina { get; set; }
        public decimal PrecoDiesel { get; set; }
        public decimal PrecoGas { get; set; }
        public decimal PrecoAlcool { get; set; }
    }

    public class DetalhesPrecosCombustiveisViewModel
    {
        public int Id { get; set; }
        public decimal PrecoGasolina { get; set; }
        public decimal PrecoDiesel { get; set; }
        public decimal PrecoGas { get; set; }
        public decimal PrecoAlcool { get; set; }
    }
}
