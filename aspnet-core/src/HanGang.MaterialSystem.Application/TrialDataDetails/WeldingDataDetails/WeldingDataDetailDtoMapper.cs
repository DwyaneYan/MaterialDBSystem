using AutoMapper;
using HanGang.MaterialSystem.BakeHardeningDataDetails.Dtos;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.StaticTensionDataDetails.Dtos;
using HanGang.MaterialSystem.WeldingDataDetails.Dtos;

namespace HanGang.MaterialSystem.TrialDataDetails.WeldingDataDetails
{
    public class WeldingDataDetailDtoMapper : Profile
    {
    
        public WeldingDataDetailDtoMapper()
        {
            CreateMap<WeldingDataDetail, WeldingDataDetailDto>();
            CreateMap<WeldingDataDetailItem, WeldingDataDetailItemDto>();
        }
    }
}