using System;
using Xunit;
using TodoAPI.Models;

namespace TodoAPI.Tests.Models
{
    public class TodoTests: IDisposable
    {
        Todo _todo;

        public TodoTests() 
        {
            _todo = new Todo {
                Title = "Todo TItle",
                Description = "Todo Description"
            };
        }

        public void Dispose() 
        {
            _todo = null;
        }

        [Fact]
        public void CanChangeTitle()
        {

            _todo.Title = "updated title";
            Assert.Equal("updated title", _todo.Title);
        }

        [Fact]
        public void CanChangeDescription()
        {
            _todo.Description = "Updated Description";
            Assert.Equal("Updated Description", _todo.Description);
        }
    }
}