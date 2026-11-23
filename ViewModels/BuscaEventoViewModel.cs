using ExerciciosMVC.Models;

namespace ExerciciosMVC.ViewModels
{
    public class BuscaEventoViewModel
    {
        public string? TermoBusca { get; set; }

        public List<Evento> Resultados { get; set; } = new();
        
    }
}