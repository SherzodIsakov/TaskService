using RepositoryBase.Entities;
using System;
using System.Collections.Generic;

namespace TaskService.Entities.Models
{
    public class TaskModel : BaseEntity
    {
        public int TaskInterval { get; set; } = 10;
        public DateTime TaskStartTime { get; set; } = DateTime.Now;
        public DateTime TaskEndTime { get; set; } = DateTime.Now.AddHours(2);
        public IEnumerable<TaskSearchWordsModel> TaskSearchWordsModels { get; set; }
    }
}
