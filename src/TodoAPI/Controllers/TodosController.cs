using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TodoAPI.Controllers 
{
    [Route("api/todos")]
    [ApiController]
    public class TodosController: ControllerBase
    {
        [HttpGet]   
        public IActionResult GetTodos() 
        {
            var todoList = new List<string>{"todo1", "todo2", "todo3"};
            return Ok(todoList);
        }
    }
}