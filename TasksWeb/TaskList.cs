using System;
using System.Collections.Generic;
using System.Linq;
using Tasks.Models;

namespace TasksWeb
{
    public class TaskList
    {
        public static List<Task> Tasks { get; private set; }
        static TaskList()
        {
            Tasks = new List<Task>();
            Tasks.Add(new Task { 
                Id = new Guid(),
                Title = "Clean my room",
                Description = "Make my bed, dust the furniture, and sweep the floor",
                Completed = false
            });
        }
    }
}
