using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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
    }
}