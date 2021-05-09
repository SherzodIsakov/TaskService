using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskService.Entities.Models
{
    public class TaskSearchWordsModel
    {
        public Guid Id { get; set; }
        public string FindWord { get; set; }
        public TaskModel TaskModel { get; set; }
    }
}
