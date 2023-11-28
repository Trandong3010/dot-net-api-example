using API.Entities;
using AutoMapper;

namespace API.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeModel>();
            CreateMap<EmployeeModel, Employee>();
        }
    }
}
