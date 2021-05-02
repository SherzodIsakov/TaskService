using RepositoryBase.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskService.Repositories.Entities
{
    public class TextTaskEntity : BaseEntity
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [NotMapped]
        public int CountOfRepeating { get; set; }
        public IEnumerable<FindEntity> FindEntities { get; set; }
        public TaskTypeEntity  TaskTypeEntity { get; set; }
    }
}
