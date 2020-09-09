using AutoMapper;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.ProhibitedSubstanceDataDetails.Dtos;

namespace HanGang.MaterialSystem.ProhibitedSubstances
{
    public class ProhibitedSubstanceDataDetailDtoMapper : Profile
    {
        public ProhibitedSubstanceDataDetailDtoMapper()
        {
            CreateMap<ProhibitedSubstanceDataDetail, ProhibitedSubstanceDataDetailDto>();
        }
    }
}
