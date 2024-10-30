using TodoListAPI.Models;

namespace TodoListAPI.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<TodoItem?> GetByIdAsync(int id);
        Task AddAsync(TodoItem item);
        Task UpdateAsync(TodoItem item);
        Task DeleteAsync(int id);
        Task<IEnumerable<TodoItem>> GetByCreatedByIdAsync(int createdById);
    }
}
