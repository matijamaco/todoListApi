using Microsoft.EntityFrameworkCore;
using TodoListAPI.Data;
using TodoListAPI.Models;

namespace TodoListAPI.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _context;

        public TodoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem?> GetByIdAsync(int id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public async Task<IEnumerable<TodoItem>> GetByCreatedByIdAsync(int createdById)
        {
            return await _context.TodoItems
                .Where(item => item.CreatedById == createdById)
                .ToListAsync();
        }

        public async Task AddAsync(TodoItem item) 
        { 
            await _context.TodoItems.AddAsync(item); 
            await _context.SaveChangesAsync(); 
        }

        public async Task UpdateAsync(TodoItem item) 
        { 
            _context.Entry(item).State = EntityState.Modified; 
            await _context.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(TodoItem item) 
        {
            _context.TodoItems.Remove(item); 
            await _context.SaveChangesAsync(); 
        }
    }
}
