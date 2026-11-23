using System.ComponentModel.DataAnnotations;

namespace ExerciciosMVC.Models
{
    public class Evento
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "Nome deve ter entre 5 e 80 caracteres")]
        public string Nome { get; set; } = string.Empty;


        [StringLength(5000, MinimumLength = 10, ErrorMessage = "Descrição deve ter no mínimo 10 caracteres")]
        public string? Descricao { get; set; }


        [Required(ErrorMessage = "O local é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Local deve ter entre 3 e 100 caracteres")]
        public string? Local { get; set; }


        [Required(ErrorMessage = "A data do evento é obrigatória")]
        public DateTime DataEvento { get; set; }


        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Quantidade de vagas deve ter entre 1 e 1000 caracteres")]
        public int QuantidadeVagas { get; set; }


        //*https://learn.microsoft.com/pt-br/dotnet/api/system.componentmodel.dataannotations.rangeattribute?view=net-11.0 
        //*peguei essa parte da documentação
        [Range(0, double.MaxValue, ErrorMessage = "O valor do ingresso deve ser maior ou igual a zero")]
        public decimal ValorIngresso { get; set; }

    }
}