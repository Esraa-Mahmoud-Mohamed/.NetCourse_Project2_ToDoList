using System.ComponentModel.DataAnnotations;

namespace ToDoList.DTOs
{
    public class AddTaskDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly CreatedDate { get; set; }
        public DateOnly DueDate { get; set; }
        [RegularExpression("^(Completed|Incomplete)$", ErrorMessage = "Status must be Completed, or Incomplete.")]
        public string Status { get; set; }
        [RegularExpression("^(Low|Medium|High)$", ErrorMessage = "Priority level must be Low, Medium, or High.")]
        public string PriorityLvl { get; set; }
    }
}
