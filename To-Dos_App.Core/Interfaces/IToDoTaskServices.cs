using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Dos_App.Core.Entities;
using To_Dos_App.Core.Results;

namespace To_Dos_App.Core.Interfaces
{
    public interface IToDoTaskServices
    {
        Task<Result<bool, Error>> AddToDoTask(ToDoTask task);
        Task<Result<bool, Error>> MarkCompleteTask(Guid Id);
        Task<Result<bool, Error>> EditTaskMessage(Guid Id, string message);
        Task<Result<List<ToDoTask>, Error>> GetAll();
        Task<Result<bool, Error>> Delete(Guid Id);
        Task<Result<List<ToDoTask>, Error>> GetAllCompleted();
        Task<Result<List<ToDoTask>, Error>> GetAllIncompleted();
        Task<Result<List<ToDoTask>, Error>> GetAllCompleted(string substring);
        Task<Result<List<ToDoTask>, Error>> GetAllIncompleted(string substring);







    }
}
