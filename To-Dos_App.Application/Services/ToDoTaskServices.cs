using Microsoft.AspNetCore.Http;
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
        private readonly IToDoTaskRepository _taskRepo;
        public ToDoTaskServices(IToDoTaskRepository taskRepo)
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

        public async Task<Result<bool, Error>> EditTaskMessage(Guid Id, string message)
        {
            var result = await _taskRepo.GetTask(Id);
            if (result._isSuccess)
            {
                var task = result.Value;
                if (!task.Completed)
                {
                    task.TaskMessage = message;
                    await _taskRepo.UpdateTask(Id, task);
                    return true;
                }
                return new Error("To-Do task already marked as finished", StatusCodes.Status400BadRequest);
            }
            else
                return result.Error;
        }

        public async Task<Result<List<ToDoTask>, Error>> GetAll()
        {
            var result = await _taskRepo.GetAllTasks();
            return result;
        }
        public async Task<Result<List<ToDoTask>, Error>> GetAll(string substring)
        {
            var result = await _taskRepo.GetAllTaskContaining(substring);
            return result;
        }
        public async Task<Result<List<ToDoTask>, Error>> GetAllCompleted(bool completed)
        {
            var result = await _taskRepo.GetAllFilterTasks(t => t.Completed == completed);
            return result;
        }


        public async Task<Result<List<ToDoTask>, Error>> GetAllCompleted(bool completed, string substring)
        {
            var result = await _taskRepo.GetAllFilterTaskContaining(t => t.Completed == completed, substring);
            return result;
        }

        public async Task<Result<int, Error>> GetToDoTasksLenght()
        {
            var result = await _taskRepo.GetToDoTasksLenght();
            return result;
        }

        public async Task<Result<bool, Error>> MarkCompleteTask(Guid Id)
        {
            var result = await _taskRepo.GetTask(Id);
            if (result._isSuccess)
            {
                var task = result.Value;
                if (!task.Completed)
                {
                    task.Completed = true;
                    task.FinishDate = DateTime.Now;
                    await _taskRepo.UpdateTask(Id, task);
                }
                return true;
            }
            else
                return result.Error;
        }
    }
}
