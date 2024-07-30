using Console_core.Date;
using Console_core.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Console_core.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoService _todoService;
        
        private readonly PeopleService _peopleService;
        // Assuming you have a PersonService to manage Person entities

        public TodoController(TodoService todoService,PeopleService peopleService)
        {
            _todoService = new TodoService();
            _peopleService = peopleService;
        }
        public IActionResult Index()
        {
            var todos = _todoService.FindAll();
            return View(todos);
        }
        public IActionResult Create()
        {
            var todos = _todoService.FindAll();
            return View();
        }

        [HttpPost]
        public IActionResult CreateTodoItem(string description, bool done, Person assignee)
        {

            _todoService.CreateTodoItem(description,done,assignee);
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Details(int id)
        {
            var todos = _todoService.FindById(id);
            if (todos == null)
            {
                return NotFound();
            }

            return View(todos);
        }
        public IActionResult Delete(int id)
        {
            var todos = _todoService.FindById(id);
            if (todos == null)
            {
                return NotFound();
            }

            return View(todos);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            _todoService.RemoveTodoItem(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
