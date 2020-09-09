using AutoMapper;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.ReboundDataDetails.Dtos;
using HanGang.MaterialSystem.StaticTensionDataDetails.Dtos;

namespace HanGang.MaterialSystem.TrialDataDetails.ReboundDataDetails
{
    public class ReboundDataDetailDtoMapper : Profile
    {
    
        public ReboundDataDetailDtoMapper()
        {
            CreateMap<ReboundDataDetail, ReboundDataDetailDto>();
            CreateMap<ReboundDataDetailItem, ReboundDataDetailItemDto>();
            CreateMap<ReboundDataDetailItem2, ReboundDataDetailItem2Dto>();
            CreateMap<ReboundDataDetailItem3, ReboundDataDetailItem3Dto>();
        }
    }
}