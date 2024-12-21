using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class ToDoListContext:DbContext
    {
        public ToDoListContext()
        {

        }

        public ToDoListContext(DbContextOptions<ToDoListContext> option) : base(option)
        {

        }
        public virtual DbSet<Task> Tasks { get; set; }

    }
}
