using System;
using System.Collections.Generic;
using TaskService.Repositories.Entities;

namespace TaskService.Entities.Models
{
    public class TaskModel
    {
        public int TaskInterval { get; set; } = 10;
        public DateTime TaskStartTime { get; set; } = DateTime.Now;
        public DateTime TaskEndTime { get; set; } = DateTime.Now.AddHours(2);
        public IEnumerable<FindModel> FindModels { get; set; }
    }
}
