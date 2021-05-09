﻿using AutoMapper;
using TaskService.Entities.Models;
using TaskService.Repositories.Entities;

namespace TaskService.Configuration
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<TaskSearchWordsEntity, TaskSearchWordsModel>().ReverseMap();
            CreateMap<TaskEntity, TaskModel>().ReverseMap();
            CreateMap<TextTaskEntity, TextTaskModel>().ReverseMap();
        }
    }
}