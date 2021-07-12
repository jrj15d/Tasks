using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Tasks.Models;

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
            Task task = new Task();
            return Enumerable.Range(1, 5).Select(index => new Task
            {
                Id = new Guid(),
                Title = "Example Title",
                Description = "Example Desc",
                Completed = false
            })
            .ToArray();
        }
    }
}
