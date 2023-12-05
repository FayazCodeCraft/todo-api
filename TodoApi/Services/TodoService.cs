using Microsoft.EntityFrameworkCore;
using TodoApi.Database;
using TodoApi.Model;

namespace TodoApi.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoContext _todoContext;
        public TodoService(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public async Task<List<Todo>> GetTodosAsync()
        {
            return await _todoContext.Todos.ToListAsync();
        }

        public async Task<Todo> GetTodoAsync(int id)
        {
            var todo = await _todoContext.Todos.FindAsync(id);

            if (todo == null)
            {
                throw new Exception($"Todo with {id} doesn't exist");
            }

            return todo;
        }

        public async Task<Todo> CreateTodoAsync(Todo todoData)
        {
            var newTodo = new Todo
            {
                Title = todoData.Title,
                Description = todoData.Description,
                DueDate = todoData.DueDate,
                Completed = todoData.Completed

            };
            _todoContext.Add(newTodo);
            await _todoContext.SaveChangesAsync();
            return newTodo;
        }

        public async Task<Todo> UpdateTodoAsync(int id, Todo todoData)
        {
            var existingTodo = await _todoContext.Todos.FindAsync(id);

            if (existingTodo != null)
            {
                existingTodo.Title = todoData.Title;
                existingTodo.Description = todoData.Description;
                existingTodo.DueDate = todoData.DueDate;
                existingTodo.Completed = todoData.Completed;
                existingTodo.UpdatedAt = DateTime.Now;
                await _todoContext.SaveChangesAsync();
                return existingTodo;
            }
            else
            {
                throw new Exception($"Todo with {id} doesn't exist");
            }

        }


        public async Task<Todo> DeleteTodoAsync(int id)
        {
            var todo = await _todoContext.Todos.FindAsync(id);

            if (todo != null)
            {
                _todoContext.Todos.Remove(todo);
                await _todoContext.SaveChangesAsync();
                return todo;
            }
            else
            {
                throw new Exception($"Todo with {id} doesn't exist");
            }
        }

    }
}
