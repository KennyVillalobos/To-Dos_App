using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using To_Dos_App.API.DTO;
using To_Dos_App.Application.Services;
using To_Dos_App.Core.Entities;
using To_Dos_App.Core.Interfaces;
using To_Dos_App.Core.Results;

namespace To_Dos_App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoTaskController : ControllerBase
    {
        private readonly IToDoTaskServices _todoTaskService;
        private readonly IMapper _mapper;
        public ToDoTaskController(IToDoTaskServices todoTaskService, IMapper mapper)
        {
            _todoTaskService = todoTaskService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsyinc(ToDoTaskDTO toDoTaskDTO)
        { 
            ToDoTask toDoTask = _mapper.Map<ToDoTask>(toDoTaskDTO);
            toDoTask.Completed = false;
            toDoTask.CreationDateTime = DateTime.Now;
            var result = await _todoTaskService.AddToDoTask(toDoTask);
            if (result._isSuccess)
            {
                return Ok();
            }
            else
                return StatusCode(result.Error.statusCode, result.Error.message);
        }
        [HttpGet]
        public async Task<ActionResult> GetCompleteTaskList()
        {
            var result = await _todoTaskService.GetAll();
            if (result._isSuccess)
            {
            var list = result.Value;
                list.Sort(new ToDoTaskComparer());
                return Ok(list);
            }
            else return StatusCode(result.Error.statusCode, result.Error.message);
        }

        [HttpPut]
        [Route("mark/{id}")]
        public async Task<ActionResult> MarkToDoTask(Guid id)
        {
            var result = await _todoTaskService.MarkCompleteTask(id);
            if (result._isSuccess)
            {
                return Ok();
            }
            else return StatusCode(result.Error.statusCode, result.Error.message);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateToDoMessage(Guid id, string message)
        {
            var result = await _todoTaskService.EditTaskMessage(id,message);
            if (result._isSuccess)
            {
                return Ok();
            }
            else return StatusCode(result.Error.statusCode, result.Error.message);
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> RemoveToDoTask(Guid id)
        {
            var result = await _todoTaskService.Delete(id);
            if (result._isSuccess)
            {
                return Ok();
            }
            else return StatusCode(result.Error.statusCode, result.Error.message);
        }


    }
}
