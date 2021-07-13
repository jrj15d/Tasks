using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Tasks.Models;
using Newtonsoft.Json;

namespace TasksWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ILogger<TasksController> _logger;

        public TasksController(ILogger<TasksController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Task> Get()
        {
            _logger.LogInformation("Getting all tasks");
            return TaskList.Tasks;
        }

        [HttpPost("{task}")]
        public Task Post(string task)
        {
            TaskDTO dto = JsonConvert.DeserializeObject<TaskDTO>(task);
            _logger.LogInformation($"Adding new task: {dto.Title}");

            Task t = new Task(dto.Title, dto.Description);
            TaskList.Add(t);
            return t;
            
        }
    }
}