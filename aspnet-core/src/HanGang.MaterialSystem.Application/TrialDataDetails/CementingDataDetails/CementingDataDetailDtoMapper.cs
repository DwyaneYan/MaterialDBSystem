using AutoMapper;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.CementingDataDetails.Dtos;

namespace HanGang.MaterialSystem.TrialDataDetails.CementingDataDetails
{
    public class CementingDataDetailDtoMapper : Profile
    {
        public CementingDataDetailDtoMapper()
        {
             CreateMap<CementingDataDetail, CementingDataDetailDto>();
        }
    }
}