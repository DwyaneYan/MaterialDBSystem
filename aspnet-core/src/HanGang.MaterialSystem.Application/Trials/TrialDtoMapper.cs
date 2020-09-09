using AutoMapper;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Trials.Dtos;

namespace HanGang.MaterialSystem.MaterialManagement
{
    public class TrialDtoMapper : Profile
    {
        public TrialDtoMapper()
        {
            CreateMap<Trial, TrialDto>()
                .ForMember(m=>m.ParentName, option=>option.MapFrom(n=>n.Parent.Name))
                ;
        }
    }
}