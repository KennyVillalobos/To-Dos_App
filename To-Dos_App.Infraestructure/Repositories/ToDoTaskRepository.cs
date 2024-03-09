using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Dos_App.Core.Entities;
using To_Dos_App.Core.Interfaces;
using To_Dos_App.Core.Results;
using To_Dos_App.Infraestructure.Data;

namespace To_Dos_App.Infraestructure.Repositories
{
    public class ToDoTaskRepository : IToDoTaskRepository
    {
        private readonly DataContext _dataContext;
        public ToDoTaskRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Result<ToDoTask, Error>> GetTask(Guid Id)
        {
            ToDoTask task = await _dataContext.ToDoTasks.FirstOrDefaultAsync(t => t.Id == Id);
            if (task is null)
            {
                return new Error("Task not Found", StatusCodes.Status404NotFound);
            }
            return task;
        }
        public async Task<Result<List<ToDoTask>, Error>> GetAllTasks()
        {
            try
            {
                List<ToDoTask> toDoTasks = await _dataContext.ToDoTasks.ToListAsync();
                return toDoTasks;
            }
            catch
            {
                return new Error("Repository Error", 500);
            }

        }

        public async Task<Result<int,Error>> GetToDoTasksLenght()
        {
            try
            {
                int toDoTasks = await _dataContext.ToDoTasks.CountAsync();
                return toDoTasks;
            }
            catch
            {
                return new Error("Repository Error", 500);
            }
        }
        public async Task<Result<bool,Error>> AddToDoTaskAsync(ToDoTask task)
        {
            try
            {
                await _dataContext.ToDoTasks.AddAsync(task);
                await _dataContext.SaveChangesAsync();
                return true;
            } 
            catch  
            {
                return new Error("Repository Error", 500);
            }
        }

        public async Task<Result<bool, Error>> DeleteTask(Guid Id)
        {
            ToDoTask task = await _dataContext.ToDoTasks.FirstOrDefaultAsync(t=> t.Id == Id);
            if (task is null)
            {
                return new Error("Task not Found", StatusCodes.Status404NotFound);
            }
            try
            {
                _dataContext.ToDoTasks.Remove(task);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return new Error("Repository Error", 500);
            }
        }
        public async Task<Result<bool, Error>> UpdateTask(Guid Id, ToDoTask updatedTask)
        {
            ToDoTask task = await _dataContext.ToDoTasks.FirstOrDefaultAsync(t => t.Id == Id);
            if (task is null)
            {
                return new Error("Task not Found", StatusCodes.Status404NotFound);
            }
            try
            {
                task.TaskMessage = updatedTask.TaskMessage;
                task.Completed = updatedTask.Completed;
                task.FinishDate = updatedTask.FinishDate;
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return new Error("Repository Error", 500);
            }
        }

        public async Task<Result<List<ToDoTask>, Error>> GetAllFilterTasks(Func<ToDoTask, bool> filter)
        {
            try
            {
                List<ToDoTask> toDoTasks = _dataContext.ToDoTasks.Where(filter).ToList();
                return toDoTasks;
            }
            catch
            {
                return new Error("Repository Error", 500);
            }

        }

        public async Task<Result<List<ToDoTask>, Error>> GetAllTaskContaining(string substring)
        {
            try
            {
                List<ToDoTask> toDoTasks = _dataContext.ToDoTasks.Where(td => td.TaskMessage.Contains(substring)).ToList();
                return toDoTasks;
            }
            catch
            {
                return new Error("Repository Error", 500);
            }
        }
        public async Task<Result<List<ToDoTask>, Error>> GetAllFilterTaskContaining(Func<ToDoTask, bool> filter, string substring)
        {
            try
            {
                List<ToDoTask> toDoTasks = _dataContext.ToDoTasks.Where(td => td.TaskMessage.Contains(substring)).Where(filter).ToList();
                return toDoTasks;
            }
            catch
            {
                return new Error("Repository Error", 500);
            }
        }



    }
}
