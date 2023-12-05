using TodoApi.Model;

namespace TodoApi.Services
{
    /// <summary>
    /// Service interface for managing Todo items.
    /// </summary>
    public interface ITodoService
    {
        /// <summary>
        /// Gets a list of all Todo items asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation. The result contains the list of Todo items.</returns>
        Task<List<Todo>> GetTodosAsync();
        /// <summary>
        /// Gets a specific Todo item by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the Todo item to retrieve.</param>
        /// <returns>A task representing the asynchronous operation. The result contains the Todo item.</returns>
        Task<Todo> GetTodoAsync(int id);
        /// <summary>
        /// Creates a new Todo item asynchronously.
        /// </summary>
        /// <param name="todo">The Todo item to create.</param>
        /// <returns>A task representing the asynchronous operation. The result contains the created Todo item.</returns>
        Task<Todo> CreateTodoAsync(Todo todo);

        /// <summary>
        /// Updates a specific Todo item by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the Todo item to update.</param>
        /// <param name="todo">The updated Todo item.</param>
        /// <returns>A task representing the asynchronous operation. The result contains the updated Todo item.</returns>
        Task<Todo> UpdateTodoAsync(int id, Todo todo);

        /// <summary>
        /// Deletes a specific Todo item by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the Todo item to delete.</param>
        /// <returns>A task representing the asynchronous operation. The result contains the deleted Todo item.</returns>
        Task<Todo> DeleteTodoAsync(int id);

    }
}
