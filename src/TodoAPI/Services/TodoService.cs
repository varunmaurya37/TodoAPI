using TodoAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace TodoAPI.Services
{
    public class TodoService
    {
        private readonly IMongoCollection<Todo> _todos;

        public TodoService(IDatabaseSettings settings) 
        {   
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _todos = database.GetCollection<Todo>(settings.TodoCollectionName);
        }

        public IEnumerable<Todo> GetAll()
        {
            return _todos.Find(todo => true).ToList();
        }

        public Todo Get(string id)
        {
            return _todos.Find<Todo>(todo => todo.Id == id).FirstOrDefault();
        }

        public Todo Create(Todo todo) 
        {
            _todos.InsertOne(todo);
            return todo;
        }

        public void Update(string id, Todo updatedTodo)
        {
            _todos.ReplaceOne(todo => todo.Id == id, updatedTodo);
            return;
        }

        public void Delete(string id)
        {
            _todos.DeleteOne(todo => todo.Id == id);
            return;
        }

        
    }
}