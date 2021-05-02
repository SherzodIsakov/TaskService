using AutoMapper;
using System;
using System.Threading.Tasks;
using TaskService.Repositories.Entities;
using TaskService.Repositories.Interfaces;
using TaskService.Services.Models;

namespace TaskService.Services.TextDapperService
{
    public class TaskDapperService : ITaskDapperService
    {
        private readonly ITextTaskDapperRepository  _textTaskDapperRepository;
        private readonly IMapper _mapper;

        public TaskDapperService(ITextTaskDapperRepository  textTaskDapperRepository,
        IMapper mapper)
        {
            _textTaskDapperRepository = textTaskDapperRepository;
            _mapper = mapper;
        }

        public async Task<TextTaskModel> AddFile(string text)
        {
            var textFile = new TextTaskEntity();
            //textFile.Text = text;

            textFile = await _textTaskDapperRepository.CreateAsync(textFile);
            //textFile.Text = null;

            return _mapper.Map<TextTaskModel>(textFile);
        }

        public async Task<TextTaskModel> GetById(Guid id)
        {
            var text = await _textTaskDapperRepository.GetByIdAsync(id);
            return _mapper.Map<TextTaskModel>(text);
        }
    }
}