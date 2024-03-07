using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Dos_App.Core;
using To_Dos_App.Core.Entities;
using To_Dos_App.Core.Interfaces;
using To_Dos_App.Core.Results;
using To_Dos_App.Infraestructure.Repositories;

namespace To_Dos_App.Application.Services
{
    public class ToDoTaskServices : IToDoTaskServices
    {
        private readonly ToDoTaskRepository _taskRepo;
        public ToDoTaskServices(ToDoTaskRepository taskRepo)
        {
            _taskRepo = taskRepo;
        }

        public async Task<Result<bool, Error>> AddToDoTask(ToDoTask task)
        {
            var result = await _taskRepo.AddToDoTaskAsync(task);
            return result;
        }

        public async Task<Result<bool, Error>> Delete(Guid Id)
        {
            var result = await _taskRepo.DeleteTask(Id);
            return result;
        }

        public Task<Result<bool, Error>> EditTaskMessage(Guid Id, string message)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<ToDoTask>, Error>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<ToDoTask>, Error>> GetAllCompleted()
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<ToDoTask>, Error>> GetAllCompleted(string substring)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<ToDoTask>, Error>> GetAllIncompleted()
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<ToDoTask>, Error>> GetAllIncompleted(string substring)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool, Error>> MarkCompleteTask(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
