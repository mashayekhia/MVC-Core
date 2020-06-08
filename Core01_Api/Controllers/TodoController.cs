using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core01_Api.Infrastarcture;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Core01_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        public TodoController(IRepository IRepository)
        {
            ITodo = IRepository;
        }

        public IRepository ITodo { get; set; }

        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            //return Enumerable.Range(1, 5).Select(index => new TodoItem()
            //{
            //    Name = "item" + index
            //}).ToArray();
            return ITodo.GetAll();
            //return new string[] { "Item1", "Item2" };
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            var item = ITodo.Find(id);
            if (item == null)
            {
                return NotFound("ID : " + id);
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
            {
                BadRequest("Item is Null");
            }
            ITodo.Add(item);
            return CreatedAtRoute("GetTodo", new { id = item.Key }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TodoItem item)
        {
            if (item == null || item.Key != id)
            {
                BadRequest();
            }
            ITodo.Update(item);
            return new NoContentResult();
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromBody] TodoItem item, string id)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var todo = ITodo.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            item.Key = todo.Key;
            ITodo.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var todo = ITodo.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            ITodo.Remove(id);
            return new NoContentResult();
        }
    }
}
