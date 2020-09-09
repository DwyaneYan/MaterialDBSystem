using AutoMapper;
using HanGang.MaterialSystem.DentResistanceDataDetails.Dtos;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.StaticTensionDataDetails.Dtos;

namespace HanGang.MaterialSystem.TrialDataDetails.DentResistanceDataDetails
{
    public class DentResistanceDataDetailDtoMapper : Profile
    {
        
        public DentResistanceDataDetailDtoMapper()
        {
            CreateMap<DentResistanceDataDetail, DentResistanceDataDetailDto>();
           
        }
    }
}