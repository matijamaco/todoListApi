using Microsoft.AspNetCore.Mvc;
using TodoListAPI.DTOs;
using TodoListAPI.Models;
using TodoListAPI.Services;

namespace TodoListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoListController : ControllerBase
    {
        private readonly ILogger<TodoListController> _logger;
        private readonly ITodoListService _todoListService;

        public TodoListController(ILogger<TodoListController> logger, ITodoListService todoListService)
        {
            _logger = logger;
            _todoListService = todoListService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetTodoList()
        {
            var result = await _todoListService.GetTodoList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDto>> GetTodoItem(int id)
        {
            var result = await _todoListService.GetTodoItem(id);

            if (result is null) {
                _logger.LogError("TodoListController => GetTodoItem: TodoItem not found");
                return NotFound("TodoItem not found");
            }
                

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> CreateTodoItem([FromBody] TodoItemDto todoItem)
        {
            var result = await _todoListService.CreateTodoItem(todoItem);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> UpdateTodoItem(int id, [FromBody] TodoItemDto todoItem)
        {
            var result = await _todoListService.UpdateTodoItem(id, todoItem);

            if (result is null) {
                _logger.LogError("TodoListController => UpdateTodoItem: TodoItem not found");
                return NotFound("TodoItem not found");
            }    

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> DeleteTodoItem(int id)
        {
            var result = await _todoListService.DeleteTodoItem(id);

            if (result is null) {
                _logger.LogError("TodoListController => DeleteTodoItem: TodoItem not found");
                return NotFound("TodoItem not found");
            }
            
            return NoContent();
        }

        [HttpGet("byUser/{createdById}")]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetByCreatedById(int createdById)
        {
            var result = await _todoListService.GetByCreatedByIdAsync(createdById);
            return Ok(result);
        }
    }
}
