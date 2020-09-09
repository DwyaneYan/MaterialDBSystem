using AutoMapper;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.LowCycleFatigueDataDetails.Dtos;

namespace HanGang.MaterialSystem.LowCycleFatigues
{
    public class LowCycleFatigueDataDetailDtoMapper : Profile
    {
        public LowCycleFatigueDataDetailDtoMapper()
        {
            CreateMap<LowCycleFatigueDataDetail, LowCycleFatigueDataDetailDto>();
            CreateMap<LowCycleFatigueDataDetailItem, LowCycleFatigueDataDetailItemDto>()
                ;
        }
    }
}