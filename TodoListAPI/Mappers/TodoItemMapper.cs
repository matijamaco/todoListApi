using Microsoft.VisualBasic;
using TodoListAPI.DTOs;
using TodoListAPI.Models;

namespace TodoListAPI.Mappers
{
    public static class TodoItemMapper
    {
        public static TodoItemDto ToDto(TodoItem item)
        {
            return new TodoItemDto
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                IsCompleted = item.IsCompleted,
                DueDate = item.DueDate ?? DateTime.MinValue,
                CreatedById = item.CreatedById
            };
        }

        public static TodoItem ToEntity(TodoItemDto itemDto)
        {
            return new TodoItem()
            {
                Id = itemDto.Id,
                Title = itemDto.Title,
                Description = itemDto.Description,
                IsCompleted = itemDto.IsCompleted,
                DueDate = itemDto.DueDate,
                CreatedById = itemDto.CreatedById
            };
        }
    }
}
