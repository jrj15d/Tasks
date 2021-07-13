using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksWeb
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
