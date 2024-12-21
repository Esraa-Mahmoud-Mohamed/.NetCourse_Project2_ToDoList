using AutoMapper;
using ToDoList.DTOs;
using ToDoList.Models;
using Task = ToDoList.Models.Task;

namespace ToDoList.MppingConfigs
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<Task, AddTaskDTO>().ReverseMap();
            CreateMap<Task, DisplayTaskDTO>().ReverseMap();
            CreateMap<Task, EditTaskDTO>().ReverseMap();
        }
    }
}
