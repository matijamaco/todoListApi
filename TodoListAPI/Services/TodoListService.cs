using TodoListAPI.DTOs;
using TodoListAPI.Mappers;
using TodoListAPI.Models;
using TodoListAPI.Repositories;

namespace TodoListAPI.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly ITodoRepository _repository;

        public TodoListService(ITodoRepository repository) {
            _repository = repository;
        }

        public async Task<IEnumerable<TodoItemDto>> GetTodoList()
        {
            IEnumerable<TodoItem> items = await _repository.GetAllAsync();

            return items.Select(TodoItemMapper.ToDto);
        }

        public async Task<TodoItemDto?> GetTodoItem(int id)
        {
            TodoItem? item = await _repository.GetByIdAsync(id);
            return item != null ? TodoItemMapper.ToDto(item) : null;
        }

        public async Task<IEnumerable<TodoItemDto>> CreateTodoItem(TodoItemDto todoItemDto)
        {
            // TODO Add validation for todoItemDto

            TodoItem todoItem = TodoItemMapper.ToEntity(todoItemDto);

            await _repository.AddAsync(todoItem);

            IEnumerable<TodoItem> allItems = await _repository.GetAllAsync();
            return allItems.Select(TodoItemMapper.ToDto);
        }

        public async Task<IEnumerable<TodoItemDto>?> DeleteTodoItem(int id)
        {
            TodoItem? item = await _repository.GetByIdAsync(id);

            if (item == null) {
                return null; 
            } 

            await _repository.DeleteAsync(item.Id);

            IEnumerable<TodoItem> remainingItems = await _repository.GetAllAsync();
            return remainingItems.Select(TodoItemMapper.ToDto);
        }

        public async Task<IEnumerable<TodoItemDto>?> UpdateTodoItem(int id, TodoItemDto todoItemDto)
        {
            // TODO Add validation for todoItemDto

            TodoItem? existingItem = await _repository.GetByIdAsync(id);

            if (existingItem == null) {
                return null; 
            }

            existingItem.Update(todoItemDto);

            await _repository.UpdateAsync(existingItem);

            var allItems = await _repository.GetAllAsync();
            return allItems.Select(TodoItemMapper.ToDto);
        }

        public async Task<IEnumerable<TodoItemDto>> GetByCreatedByIdAsync(int createdById)
        {
            IEnumerable<TodoItem> items = await _repository.GetByCreatedByIdAsync(createdById);

            return items.Select(TodoItemMapper.ToDto);
        }
    }
}
