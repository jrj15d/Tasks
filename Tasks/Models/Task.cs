using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Models
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }

        public Task() { }
        public Task(string title, string description, bool completed)
        {
            Id = new Guid();
            Title = title;
            Description = description;
            Completed = completed;
        }
    }
}
