using AutoMapper;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.BendingDataDetails.Dtos;

namespace HanGang.MaterialSystem.Bendings
{
    public class BendingDataDetailDtoMapper : Profile
    {
        public BendingDataDetailDtoMapper()
        {
            CreateMap<BendingDataDetail, BendingDataDetailDto>();
        }
    }
}