using Microsoft.EntityFrameworkCore;
using RepositoryBase.Entities;
using System.ComponentModel.DataAnnotations;

namespace TaskService.Repositories.Entities
{
    [Index(nameof(Name), nameof(Scope))]
    public class TaskTypeEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [MaxLength(128)]
        public string Scope { get; set; }
    }
}
