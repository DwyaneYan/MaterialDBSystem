using AutoMapper;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.HighCycleFatigueDataDetails.Dtos;


namespace HanGang.MaterialSystem.HighCycleFatigues
{
    public class HighCycleFatigueDataDetailDtoMapper : Profile
    {
        public HighCycleFatigueDataDetailDtoMapper()
        {
            CreateMap<HighCycleFatigueDataDetail, HighCycleFatigueDataDetailDto>();
            CreateMap<HighCycleFatigueDataDetailItem, HighCycleFatigueDataDetailItemDto>();
                   // .ForMember(m => m.SampleCode, option => option.MapFrom(n => n.HighCycleFatigueDataDetail.SampleCode));
        }
    }
}