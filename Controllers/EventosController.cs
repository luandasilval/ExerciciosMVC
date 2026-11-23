
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.Mvc;
using ExerciciosMVC.Models;
using ExerciciosMVC.ViewModels;


namespace PrimeiroProjetoMvc.Controllers
{

    public class EventosController : Controller
    {
        private static List<Evento> _eventos = new()
        {
        //*https://learn.microsoft.com/pt-br/dotnet/api/system.datetime?view=net-11.0 documentação
        new Evento{Id = 1, Nome = "Aniversario1", Descricao = "lalalallalalal", Local = "Sao bernardo", DataEvento = new DateTime(2026, 12, 25), ValorIngresso = 100m},
        new Evento{Id = 2, Nome = "Aniversario2", Descricao = "lalalallalalal", Local = "Sao bernardo", DataEvento = new DateTime(2026, 12, 26), ValorIngresso = 100m},
        // 25 de dezembro de 2026 à 00:00:00 DataEvento = },
        };

        //GET /Eventos  - listar todos os eventos 
        public IActionResult Index()
        {
            return View(_eventos);
        }

        public IActionResult Detalhes(int id)
        {
            var eventos = _eventos.FirstOrDefault(a => a.Id == id);
            if (eventos == null)
            {
                return NotFound();
            }
            return View(eventos);
        }

        // GET  /Eventos/Criar - exibir a view com todos os eventos 
        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }
        // POST Eventos/Criar - receber dados da view por meio de um formulario de cadastro para adicionar um novo evento 
        [HttpPost]
        public IActionResult Criar(Evento evento)
        {
            if (!ModelState.IsValid) //verifica se as validações atribuidas na model foram atendidas
            {
                return View(evento); //retorna com erros de validação
            }

            evento.Id = _eventos.Any() ? _eventos.Max(a => a.Id) + 1 : 1;

            _eventos.Add(evento);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Buscar()
        {
            return View(new BuscaEventoViewModel());
        }

        [HttpPost]
        public IActionResult Buscar(BuscaEventoViewModel vm)
        {
            vm.Resultados = _eventos; //Carrega a lista de eventos na propriedade resultados do objeto vm

            if (!string.IsNullOrEmpty(vm.TermoBusca))
            {
                //se termo busca não for vazio, pesquise o termo na lista de resultados
                vm.Resultados = _eventos.Where(a => a.Nome.Contains(vm.TermoBusca, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                return NotFound();
            }
            return View(vm);
        }
    }
}
