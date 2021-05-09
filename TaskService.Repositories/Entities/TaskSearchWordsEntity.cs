using System;

namespace TaskService.Repositories.Entities
{
    public class TaskSearchWordsEntity
    {
        public Guid Id { get; set; } = new Guid();
        public string FindWord { get; set; }
        public TaskEntity TaskEntity { get; set; }
    }
}
