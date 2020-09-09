using AutoMapper;
using HanGang.MaterialSystem.ApplicationCases.Dtos;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.MaterialTrials.Dtos;

namespace HanGang.MaterialSystem.MaterialTrials
{
    public class MaterialTrialDtoMapper : Profile
    {
        public MaterialTrialDtoMapper()
        {
            CreateMap<MaterialTrial, MaterialTrialDto>();
            CreateMap<ApplicationCase, ApplicationCaseDto>();
        }
    }
}