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
            Tasks.Add(new Task("Clean my room", "Make my bed, dust the furniture, and sweep the floor"));
        }

        public static Task Add(Task task)
        {
            Task t = new Task(task.Title, task.Description);
            Tasks.Add(t);
            return t;
        }
    }
}
