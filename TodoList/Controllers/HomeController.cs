using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        private static List<TodoItem> todoItems = new List<TodoItem>();

        public IActionResult Index()
        {
            return View("Index", todoItems);
        }


        [HttpPost]
        public IActionResult Create(TodoItem newItem)
        {
            newItem.Id = todoItems.Count + 1;
            todoItems.Add(newItem);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var itemToEdit = todoItems.FirstOrDefault(item => item.Id == id);
            return View(itemToEdit);
        }

        [HttpPost]
        public IActionResult Update(TodoItem updatedItem)
        {
            var existingItem = todoItems.FirstOrDefault(item => item.Id == updatedItem.Id);
            if (existingItem != null)
            {
                existingItem.Task = updatedItem.Task;
                existingItem.IsDone = updatedItem.IsDone;
            }

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var itemToDelete = todoItems.FirstOrDefault(item => item.Id == id);
            if (itemToDelete != null)
            {
                todoItems.Remove(itemToDelete);
            }

            return RedirectToAction("Index");
        }
    }
}
