using System;

namespace TaskService.Entities.Models
{
    public class TextTaskModel
    {
        public Guid TaskId { get; set; }
        public Guid TextId { get; set; }
        public int FindindWordsCount { get; set; }
    }
}
