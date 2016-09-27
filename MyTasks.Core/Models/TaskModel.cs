using System;

namespace MyTasks.Core.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime AddedOn { get; set; }

        public DateTime CompleteBy { get; set; }

        public DateTime CompletedOn { get; set; }

        public bool Completed { get; set; }
    }
}
