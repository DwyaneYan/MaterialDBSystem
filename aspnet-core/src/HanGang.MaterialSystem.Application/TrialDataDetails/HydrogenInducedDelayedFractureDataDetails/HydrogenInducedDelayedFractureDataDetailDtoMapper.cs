using AutoMapper;
using HanGang.MaterialSystem.BakeHardeningDataDetails.Dtos;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.HydrogenInducedDelayedFractureDataDetails.Dtos;
using HanGang.MaterialSystem.StaticTensionDataDetails.Dtos;

namespace HanGang.MaterialSystem.TrialDataDetails.HydrogenInducedDelayedFractureDataDetails
{
    public class HydrogenInducedDelayedFractureDataDetailDtoMapper : Profile
    {
       
        public HydrogenInducedDelayedFractureDataDetailDtoMapper()
        {
            CreateMap<HydrogenInducedDelayedFractureDataDetail, HydrogenInducedDelayedFractureDataDetailDto>();
            CreateMap<HydrogenInducedDelayedFractureDataDetailItem, HydrogenInducedDelayedFractureDataDetailItemDto>();
        }
    }
}