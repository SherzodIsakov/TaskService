using RepositoryBase.Entities;
using System;

namespace TaskService.Entities.Models
{
    public class TextTaskModel : BaseEntity
    {
        public Guid TaskId { get; set; }
        public Guid TextId { get; set; }
        public int FindindWordsCount { get; set; }
    }
}
