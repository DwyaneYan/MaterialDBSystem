using AutoMapper;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.HighSpeedStrechDataDetails.Dtos;

namespace HanGang.MaterialSystem.Bendings
{
    public class HighSpeedStrechDataDetailDtoMapper : Profile
    {
        public HighSpeedStrechDataDetailDtoMapper()
        {
            CreateMap<HighSpeedStrechDataDetail, HighSpeedStrechDataDetailDto>();
            CreateMap<HighSpeedStrechDataDetailStressStrain, HighSpeedStrechDataDetailStressStrainDto>();
            CreateMap<HighSpeedStrechDataDetailStressStrainExtend, HighSpeedStrechDataDetailStressStrainExtendDto>();
        }
    }
}