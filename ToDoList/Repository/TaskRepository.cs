using Microsoft.OpenApi.Extensions;
using ToDoList.Models;
using Task = ToDoList.Models.Task;

namespace ToDoList
{
    public class TaskRepository
    {
        public ToDoListContext DB { get; set; }
        public TaskRepository(ToDoListContext db)
        {
            DB = db;
        }

        public List<Task> SelectAll()
        {
            return DB.Tasks.ToList();
        }

        public Task SelectById(int id) 
        { 
            return DB.Tasks.FirstOrDefault(n => n.Id == id);
        }

        public List<Task> SelectByStatus(bool? status)
        {
            if ((bool)status)
                return DB.Tasks.Where(n => n.Status == "Completed").ToList();
            else
                return DB.Tasks.Where(n => n.Status == "Incomplete").ToList();
        }
        public List<Task> SelectByDueDate(DateOnly? duedate)
        {
            return DB.Tasks.Where(n => n.DueDate == duedate).ToList();
        }
        public List<Task> SelectByPriority(string? priority)
        {
            return DB.Tasks.Where(n => n.PriorityLvl == priority).ToList();
        }

        public void Add(Task task)
        {
            DB.Tasks.Add(task);
        }

        public void Edit(int id)
        {
            Task task = SelectById(id);
            DB.Entry(task).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Task task = SelectById(id);
            DB.Set<Task>().Remove(task);
        }

        public void save()
        {
            DB.SaveChanges();
        }
    }
}
