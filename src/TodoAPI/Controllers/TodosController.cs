using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Models;
using TodoAPI.Services;

namespace TodoAPI.Controllers 
{
    [Route("api/todos")]
    [ApiController]
    public class TodosController: ControllerBase
    {
        private readonly TodoService _todoService;

        public TodosController(TodoService todoService) => _todoService = todoService;

        [HttpGet]   
        public ActionResult<IEnumerable<Todo>> GetTodos() 
        {
            return Ok(_todoService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Todo> GetTodoItem(string id) {
            var todoItem = _todoService.Get(id);

            if(todoItem == null) 
            {
                return NotFound();
            }
            return Ok(todoItem);
        }

        [HttpPost]
        public ActionResult<Todo> CreateTodo(Todo todo) 
        {
            _todoService.Create(todo);
            return CreatedAtAction("GetTodoItem", new Todo{Id = todo.Id}, todo);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTodoItem(string id, Todo todo) 
        {
            if(id != todo.Id)
            {
                return BadRequest();
            }

            _todoService.Update(id, todo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Todo> DeleteTodo(string id) 
        {
            var todoItem = _todoService.Get(id);

            if(todoItem == null)
            {
                return NotFound();
            }
            _todoService.Delete(id);
            return todoItem;
        }
    }
}