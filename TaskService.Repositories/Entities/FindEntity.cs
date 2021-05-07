using RepositoryBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskService.Repositories.Entities
{
    public class FindEntity
    {
        public Guid Id { get; set; } = new Guid();
        public string FindWord { get; set; }
        public TaskEntity TaskEntity { get; set; }
    }
}
