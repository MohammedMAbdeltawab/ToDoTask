using Microsoft.AspNetCore.Mvc;
using ToDoTask.Models;

namespace ToDoTask.Controllers
{
    public class ToDoController : Controller
    {
        private static int _counter = 0;
        private static readonly List<ToDoEntity> toDoList = new();
        public IActionResult Index()
        {
            return View(toDoList);
        }
        [HttpPost]
        public IActionResult AddToDo(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                var newToDo = new ToDoEntity
                {
                    Id = _counter++,
                    Text = text,
                    IsCompleted = false
                };
                toDoList.Add(newToDo);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ToggleCompletion(int id)
        {
            var toDo = toDoList.FirstOrDefault(t => t.Id == id);
            if (toDo != null)
            {
                toDo.IsCompleted = !toDo.IsCompleted;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteToDo(int id)
        {
            var toDo = toDoList.FirstOrDefault(t => t.Id == id);
            if (toDo != null)
            {
                toDoList.Remove(toDo);
            }
            return RedirectToAction("Index");
        }
    }
}
