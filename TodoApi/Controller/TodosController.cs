using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Model;
using TodoApi.Services;

namespace TodoApi.Controller
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {

        private readonly ITodoService _todoService;
        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        /// <summary>
        /// Gets a list of all Todo items.
        /// </summary>
        /// <returns>An action result containing the list of Todo items.</returns>
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Todo> todos = await _todoService.GetTodosAsync();
                return Ok(todos);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        /// <summary>
        /// Gets a specific Todo item by its ID.
        /// </summary>
        /// <param name="id">The ID of the Todo item to retrieve.</param>
        /// <returns>An action result containing the Todo item.</returns>
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Todo todo = await _todoService.GetTodoAsync(id);
                return Ok(todo);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [HttpPost]
        /// <summary>
        /// Creates a new Todo item.
        /// </summary>
        /// <param name="todoInput">The Todo item to create.</param>
        /// <returns>An action result containing the created Todo item.</returns>
        public async Task<IActionResult> Post([FromBody] Todo todoInput)
        {
            try
            {
                var newTodo = await _todoService.CreateTodoAsync(todoInput);
                return Ok(newTodo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        /// <summary>
        /// Updates a specific Todo item by its ID.
        /// </summary>
        /// <param name="id">The ID of the Todo item to update.</param>
        /// <param name="todoInput">The updated Todo item.</param>
        /// <returns>An action result containing the updated Todo item.</returns>
        public async Task<IActionResult> Put(int id, [FromBody] Todo todoInput)
        {
            try
            {
                var updatedTodo = await _todoService.UpdateTodoAsync(id, todoInput);
                return Ok(updatedTodo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        /// <summary>
        /// Deletes a specific Todo item by its ID.
        /// </summary>
        /// <param name="id">The ID of the Todo item to delete.</param>
        /// <returns>An action result containing the deleted Todo item.</returns>
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deletedTodo = await _todoService.DeleteTodoAsync(id);
                return Ok(deletedTodo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
