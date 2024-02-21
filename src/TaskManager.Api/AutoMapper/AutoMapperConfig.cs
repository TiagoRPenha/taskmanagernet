using AutoMapper;
using TaskManager.Api.ViewModels;
using TaskManager.Business.Models;

namespace TaskManager.Api.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<Project, ProjectInputModel>().ReverseMap();
            CreateMap<TaskJob, TaskJobInputModel>().ReverseMap();
            CreateMap<TaskJob, TaskJobInputUpdateModel>().ReverseMap();
        }
    }
}
