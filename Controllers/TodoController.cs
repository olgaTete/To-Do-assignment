using Console_core.Date;
using Console_core.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Console_core.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoService _todoService;
        private readonly PeopleService _peopleService;

        public TodoController(TodoService todoService, PeopleService peopleService)
        {
            _todoService = todoService;
            _peopleService = peopleService;
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
            var todo = _todoService.FindById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        public IActionResult Delete(int id)
        {
            var todo = _todoService.FindById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            _todoService.RemoveTodoItem(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ByDoneStatus(bool doneStatus)
        {
            var todos = _todoService.FindAll().Where(todo => todo.Done == doneStatus).ToArray();
            return View("Index", todos);
        }

        public IActionResult ByAssignee(int personId)
        {
            var todos = _todoService.FindAll().Where(todo => todo.Assignee.Id == personId).ToArray();
            return View("Index", todos);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var todo = _todoService.FindById(id);
            if (todo == null)
            {
                return NotFound();
            }
            var people = _peopleService.FindAll();
            ViewBag.People = people;
            return View(todo);
        }

        [HttpPost]
        public IActionResult Edit(int id, string description, bool done, int assigneeId)
        {
            var todo = _todoService.FindById(id);
            if (todo == null)
            {
                return NotFound();
            }

            var assignee = _peopleService.FindById(assigneeId);
            if (assignee == null)
            {
                ModelState.AddModelError("", "Invalid assignee.");
                var people = _peopleService.FindAll();
                ViewBag.People = people;
                return View(todo);
            }

            todo.Description = description;
            todo.Done = done;
            todo.Assignee = assignee;

            _todoService.UpdateTodoItem(todo);
            return RedirectToAction(nameof(Index));
        }
    }
}
