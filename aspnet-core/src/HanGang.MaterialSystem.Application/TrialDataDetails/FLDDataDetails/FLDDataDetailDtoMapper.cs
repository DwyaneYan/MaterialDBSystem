using AutoMapper;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.FLDDataDetailDetails.Dtos;


namespace HanGang.MaterialSystem.TrialDataDetails.FLDDataDetails
{
    public class FLDDataDetailDtoMapper : Profile
    {
      
        public FLDDataDetailDtoMapper()
        {
            CreateMap<FLDDataDetail, FLDDataDetailDto>();
            CreateMap<FLDDataDetailItem, FLDDataDetailItemDto>();
        }
    }
}