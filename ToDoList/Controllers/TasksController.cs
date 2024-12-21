using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.DTOs;
using Task = ToDoList.Models.Task;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        TaskRepository taskRepository;
        IMapper mapper;
        public TasksController(TaskRepository taskRepository, IMapper mapper)
        {
            this.taskRepository = taskRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Task> tasks = taskRepository.SelectAll();
            List<DisplayTaskDTO> tasksDTO = mapper.Map<List<DisplayTaskDTO>>(tasks);
            if (tasksDTO.Count == 0) return NotFound();
            else return Ok(tasksDTO);
        }
        [HttpPost]
        public IActionResult Add(AddTaskDTO taskDTO)
        {
            if (ModelState.IsValid)
            {
                Task task = mapper.Map<Task>(taskDTO);
                taskRepository.Add(task);
                taskRepository.save();
                return Ok(task);
            }
            else return BadRequest(ModelState);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Task task = taskRepository.SelectById(id);
            if(task == null) return NotFound();
            else
            {
                DisplayTaskDTO taskDTO = mapper.Map<DisplayTaskDTO>(task);
                return Ok(taskDTO);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, EditTaskDTO taskDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Task existingTask = taskRepository.SelectById(id);

            if (existingTask == null)
            {
                return NotFound();
            }
            mapper.Map(taskDTO, existingTask);
            taskRepository.save();
            return Ok(existingTask);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            taskRepository.Delete(id);
            taskRepository.save();
            return Ok();
        }
        [HttpPut("Completed")]
        public IActionResult CompleteStatus(int id)
        {
            Task task = taskRepository.SelectById(id);
            if(task == null) return NotFound();
            task.Status = "Completed";
            taskRepository.save();
            return Ok(mapper.Map<DisplayTaskDTO>(task));
        }

        [HttpPut("Incomplete")]
        public IActionResult IncompleteStatus(int id)
        {
            Task task = taskRepository.SelectById(id);
            if (task == null) return NotFound();
            task.Status = "Incomplete";
            taskRepository.save();
            return Ok(mapper.Map<DisplayTaskDTO>(task));
        }

    }
}
