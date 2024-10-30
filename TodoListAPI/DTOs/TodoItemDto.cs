using System.ComponentModel.DataAnnotations;

namespace TodoListAPI.DTOs
{
    public class TodoItemDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public bool IsCompleted { get; set; }
        public string Description { get; set; } = "";
        public DateTime DueDate { get; set; }
        public int CreatedById { get; set; }
    }
}
