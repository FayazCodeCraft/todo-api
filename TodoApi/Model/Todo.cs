using System.ComponentModel.DataAnnotations;
using TodoApi.Utilities;

namespace TodoApi.Model
{
    public class Todo
    {
        [Range(1, int.MaxValue, ErrorMessage = "Id must be a positive integer")]
        public int Id { get; set; } = 1;

        [Required(ErrorMessage = "Title is required")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 10 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(200, ErrorMessage = "Description must be at most 200 characters long")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Due date is required")]
        [DueDateValidation]
        public string DueDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public bool Completed { get; set; } = false;
    }
}
