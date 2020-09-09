using AutoMapper;
using HanGang.MaterialSystem.BakeHardeningDataDetails.Dtos;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.StaticTensionDataDetails.Dtos;

namespace HanGang.MaterialSystem.TrialDataDetails.BakeHardeningDataDetails
{
    public class BakeHardeningDataDetailDtoMapper : Profile
    {
        public BakeHardeningDataDetailDtoMapper()
        {
            CreateMap<BakeHardeningDataDetail, BakeHardeningDataDetailDto>();
            CreateMap<BakeHardeningDataDetailItem, BakeHardeningDataDetailItemDto>();
        }
    }
}