using TodoListAPI.DTOs;

namespace TodoListAPI.Services
{
    public interface ITodoListService
    {
        Task<IEnumerable<TodoItemDto>> GetTodoList();
        Task<TodoItemDto?> GetTodoItem(int id);
        Task<IEnumerable<TodoItemDto>> CreateTodoItem(TodoItemDto todoItem);
        Task<IEnumerable<TodoItemDto>?> UpdateTodoItem(int id, TodoItemDto todoItem);
        Task<IEnumerable<TodoItemDto>?> DeleteTodoItem(int id);
        Task<IEnumerable<TodoItemDto>> GetByCreatedByIdAsync(int createdById);
    }
}
