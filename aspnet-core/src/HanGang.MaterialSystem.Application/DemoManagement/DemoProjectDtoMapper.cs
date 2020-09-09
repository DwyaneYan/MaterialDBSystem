using AutoMapper;
using HanGang.MaterialSystem.DemoManagement.Dtos;
using System.Linq;

namespace HanGang.MaterialSystem.DemoManagement
{
    public class DemoProjectDtoMapper : Profile
    {
        public DemoProjectDtoMapper()
        {
            CreateMap<DemoProject, DemoProjectItemDto>()
                .ForMember(x => x.UnitProjectCount, opt => opt.MapFrom(x => x.DemoUnitProjects.Count()));
            CreateMap<DemoProject, DemoProjectDto>()
                .ForMember(x => x.UnitProjectCount, opt => opt.MapFrom(x => x.DemoUnitProjects.Count()));
            CreateMap<DemoUnitProject, DemoUnitProjectItemDto>();
        }
    }
}