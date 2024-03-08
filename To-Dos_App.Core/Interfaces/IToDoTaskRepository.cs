using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Dos_App.Core.Entities;
using To_Dos_App.Core.Results;

namespace To_Dos_App.Core.Interfaces
{
    public interface IToDoTaskRepository
    {
        Task<Result<List<ToDoTask>,Error>> GetAllTasks();
        Task<Result<ToDoTask, Error>> GetTask(Guid Id);

        Task<Result<bool, Error>> UpdateTask(Guid Id, ToDoTask updatedTask);
        Task<Result<bool,Error>> DeleteTask(Guid Id);
        Task<Result<List<ToDoTask>, Error>> GetAllFilterTasks(Func<ToDoTask, bool> filter);
        Task<Result<List<ToDoTask>, Error>> GetAllTaskContaining(string substring);
        Task<Result<List<ToDoTask>, Error>> GetAllFilterTaskContaining(Func<ToDoTask, bool> filter, string substring);
        Task<Result<bool,Error>> AddToDoTaskAsync(ToDoTask task);
    }
}
