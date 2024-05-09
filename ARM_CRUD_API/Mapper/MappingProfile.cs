using ARM_CRUD_API.Common.DTO;
using ARM_CRUD_API.Entities;
using AutoMapper;

namespace ARM_CRUD_API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Staff, StaffDTO>().ReverseMap();
        }
    }
}
