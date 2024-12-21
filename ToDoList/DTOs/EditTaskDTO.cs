namespace ToDoList.DTOs
{
    public class EditTaskDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly DueDate { get; set; }
        public string Status { get; set; }
        public string PriorityLvl { get; set; }
    }
}
