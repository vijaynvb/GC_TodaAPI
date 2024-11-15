using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TodaAPI.Models;

namespace TodaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private static List<Todo> todos = new List<Todo>();

        // GET: api/todos
        [HttpGet]
        public ActionResult<IEnumerable<Todo>> GetTodos()
        {
            return Ok(todos);
        }

        // GET: api/todos/{id}
        [HttpGet("{id}")]
        public ActionResult<Todo> GetTodoById(int id)
        {
            var todo = todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        // POST: api/todos
        [HttpPost]
        public ActionResult<Todo> CreateTodo([FromBody] Todo todo)
        {
            todo.Id = todos.Count > 0 ? todos.Max(t => t.Id) + 1 : 1;
            todos.Add(todo);
            return CreatedAtAction(nameof(GetTodoById), new { id = todo.Id }, todo);
        }

        // PUT: api/todos/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTodo(int id, [FromBody] Todo updatedTodo)
        {
            var todo = todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Name = updatedTodo.Name;
            todo.IsComplete = updatedTodo.IsComplete;
            todo.Description = updatedTodo.Description;
            todo.Updated = DateTime.Now;
            todo.UserId = updatedTodo.UserId;

            return NoContent();
        }

        // DELETE: api/todos/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTodo(int id)
        {
            var todo = todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            todos.Remove(todo);
            return NoContent();
        }
    }
}
