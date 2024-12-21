namespace ToDoList.DTOs
{
    public class DisplayTaskDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly CreatedDate { get; set; }
        public DateOnly DueDate { get; set; }
        public string Status { get; set; }
        public string PriorityLvl { get; set; }
    }
}
