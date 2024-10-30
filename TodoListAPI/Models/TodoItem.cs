using System.ComponentModel.DataAnnotations;
using TodoListAPI.DTOs;

namespace TodoListAPI.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = "";
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int CreatedById { get; set; }

        public TodoItem()
        {
            CreatedDate = DateTime.UtcNow;
            UpdatedDate = DateTime.UtcNow;
        }

        public void Update(TodoItemDto dto)
        {
            Title = dto.Title;
            Description = dto.Description;
            DueDate = dto.DueDate;
            UpdatedDate = DateTime.UtcNow;
            IsCompleted = dto.IsCompleted;
            CreatedById = dto.CreatedById;
        }
    }
}
