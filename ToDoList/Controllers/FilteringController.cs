using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.DTOs;
using ToDoList.Models;
using Task = ToDoList.Models.Task;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilteringController : ControllerBase
    {
        TaskRepository taskRepository;
        IMapper mapper;
        public FilteringController(TaskRepository taskRepository, IMapper mapper)
        {
            this.taskRepository = taskRepository;
            this.mapper = mapper;
        }

        [HttpGet("status")]
        public IActionResult GetCompleted([FromQuery] bool? completed = null)
        {
            List<Task> tasks = taskRepository.SelectByStatus(completed);
            return Ok(mapper.Map<List<DisplayTaskDTO>>(tasks));
        }
        [HttpGet("duedate")]
        public IActionResult GetByDueDate([FromQuery] DateOnly? due_date = null)
        {
            List<Task> tasks = taskRepository.SelectByDueDate(due_date);
            return Ok(mapper.Map<List<DisplayTaskDTO>>(tasks));
        }
        [HttpGet("priority")]
        public IActionResult GetByPriority([FromQuery] string? priority = null)
        {
            List<Task> tasks = taskRepository.SelectByPriority(priority);
            return Ok(mapper.Map<List<DisplayTaskDTO>>(tasks));
        }
        [HttpPut("{id}/priority")]
        public IActionResult EditPriority(int id, [FromQuery] string? priority = null)
        {
            Task task = taskRepository.SelectById(id);
            if(task==null) return NotFound();
            task.PriorityLvl = priority;
            taskRepository.save();
            return Ok(mapper.Map<DisplayTaskDTO>(task));

        }
    }
}
