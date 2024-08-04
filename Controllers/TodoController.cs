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
        private int assigneeId;
        private object _context;

        // Assuming you have a PersonService to manage Person entities

        public TodoController(TodoService todoService, PeopleService peopleService)
        {
            _todoService = new TodoService();
            _peopleService = new PeopleService();
        }
        public IActionResult Index()
        {
            var todos = _todoService.FindAll();
            var people = _peopleService.FindAll();
            ViewBag.People = people.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.FirstName + " " + p.LastName
            }).ToList();
            return View(todos);
        }
        //public IActionResult Index()
        //{
        //    var todos = _todoService.FindAll();
        //    return View(todos);
        //}
        [HttpGet]
        public IActionResult Create()
        {
            var people = _peopleService.FindAll();
            ViewBag.People = people;
            return View();
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    var people = _peopleService.FindAll();
        //    ViewBag.People = new SelectList(people, "Id", "FirstName");
        //    return View();
        //}
        [HttpPost]
        public IActionResult Create(string description, bool done, int assigneeId)
        {
            var assignee = _peopleService.FindById(assigneeId);
            if (assignee == null)
            {
                ModelState.AddModelError("", "Invalid assignee.");
                var people = _peopleService.FindAll();
                //ViewBag.People = people;
                ViewBag.People = new SelectList(people, "Id", "FirstName");
                return View();
            }

            _todoService.CreateTodoItem(description, done, assignee);
            return RedirectToAction(nameof(Index));
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
   
            ViewBag.People = new SelectList(people, "Id", "FirstName", todo.Assignee?.Id);
            return View(todo);
        }

        [HttpPost]
        public IActionResult Edit(Todo model)
        {
            if (ModelState.IsValid)
            {
                var assignee = _peopleService.FindById(model.Assignee.Id);
                if (assignee == null)
                {
                    ModelState.AddModelError("", "Invalid assignee.");
                    var people = _peopleService.FindAll();
                    ViewBag.People = new SelectList(people, "Id", "FirstName", model.Assignee?.Id);
                    return View(model);
                }

                _todoService.UpdateTodoItem(model.Id, model.Description, model.Done, assignee);
                return RedirectToAction(nameof(Index));
            }

            var allPeople = _peopleService.FindAll();
            ViewBag.People = new SelectList(allPeople, "Id", "FirstName", model.Assignee?.Id);
            return View(model);
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

        // New methods for filtering todos
        public IActionResult ByDoneStatus(bool doneStatus)
        {
            var todos = _todoService.FindByDoneStatus(doneStatus);
            return View("Index", todos); // Assuming you use the same view to display the filtered list
        }

        public IActionResult ByAssignee(int personId)
        {
            var todos = _todoService.FindByAssignee(personId);
            return View("Index", todos);
        }

    }
}
