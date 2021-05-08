using AutoMapper;
using System.Collections.Generic;
using TaskService.Entities.Models;
using TaskService.Repositories.Entities;

namespace TaskService.Configuration
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<FindEntity, FindModel>().ReverseMap();
            CreateMap<TaskEntity, TaskModel>().ReverseMap();
            CreateMap<TextTaskEntity, TextTaskModel>().ReverseMap();

            //CreateMap<IEnumerable<FindEntity>, IEnumerable<FindModel>>().ReverseMap();
            
        }
    }
}
