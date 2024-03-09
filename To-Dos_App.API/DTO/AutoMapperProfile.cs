using AutoMapper;
using To_Dos_App.Core.Entities;

namespace To_Dos_App.API.DTO
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ToDoTaskDTO, ToDoTask>();
            CreateMap<ToDoTask, ToDoTaskDTOResponse>();
        }
    }
}
