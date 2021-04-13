using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Models;

namespace TodoAPI.Controllers 
{
    [Route("api/todos")]
    [ApiController]
    public class TodosController: ControllerBase
    {
        private readonly TodoContext _context;

        public TodosController(TodoContext context) => _context = context;

        [HttpGet]   
        public ActionResult<IEnumerable<Todo>> GetTodos() 
        {
            return Ok(_context.TodoItems);
        }

        [HttpGet("{id}")]
        public ActionResult<Todo> GetTodoItem(int id) {
            var todoItem = _context.TodoItems.Find(id);

            if(todoItem == null) 
            {
                return NotFound();
            }
            return Ok(todoItem);
        }

        [HttpPost]
        public ActionResult<Todo> CreateTodo(Todo todo) 
        {
            _context.TodoItems.Add(todo);
            _context.SaveChanges();

            return CreatedAtAction("GetTodoItem", new Todo{Id = todo.Id}, todo);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTodoItem(int id, Todo todo) 
        {
            if(id != todo.Id)
            {
                return BadRequest();
            }

            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Todo> DeleteTodo(int id) 
        {
            var todoItem = _context.TodoItems.Find(id);

            if(todoItem == null)
            {
                return NotFound();
            }
            _context.TodoItems.Remove(todoItem);
            _context.SaveChanges();

            return todoItem;
        }
    }
}