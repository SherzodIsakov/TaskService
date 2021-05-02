using RepositoryBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskService.Repositories.Entities
{
    public class FindEntity : BaseEntity
    {
        public string FindValue { get; set; }
    }
}
