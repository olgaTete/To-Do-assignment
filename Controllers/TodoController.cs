using Console_core.Date;
using Console_core.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Console_core.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoService _todoService;
        
        private readonly PeopleService _peopleService;
        private int assigneeId;

        // Assuming you have a PersonService to manage Person entities

        public TodoController(TodoService todoService,PeopleService peopleService)
        {
            _todoService = new TodoService();
            _peopleService = new PeopleService();
        }
        public IActionResult Index()
        {
            var todos = _todoService.FindAll();
            return View(todos);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var people = _peopleService.FindAll();
            ViewBag.People = people;
            return View();
        }

        [HttpPost]
    public IActionResult Create(string description, bool done, int assigneeId)
    {
            var assignee = _peopleService.FindById(assigneeId);
             if (assignee == null)
             {
                 ModelState.AddModelError("", "Invalid assignee.");
                 var people = _peopleService.FindAll();
                 ViewBag.People = people;
                 return View();
             }

             _todoService.CreateTodoItem(description, done, assignee);
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
