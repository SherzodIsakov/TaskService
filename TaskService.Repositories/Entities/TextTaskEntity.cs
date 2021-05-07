﻿using RepositoryBase.Entities;
using System;

namespace TaskService.Repositories.Entities
{
    public class TextTaskEntity : BaseEntity
    {
        public Guid TaskId { get; set; }
        public Guid TextId { get; set; }
        public int FindindWordsCount { get; set; }
    }
}
