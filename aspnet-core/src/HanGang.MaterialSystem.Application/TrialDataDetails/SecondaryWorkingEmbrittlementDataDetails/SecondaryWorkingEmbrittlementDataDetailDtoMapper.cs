using AutoMapper;
using HanGang.MaterialSystem.BakeHardeningDataDetails.Dtos;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.SecondaryWorkingEmbrittlementDataDetails.Dtos;
using HanGang.MaterialSystem.StaticTensionDataDetails.Dtos;

namespace HanGang.MaterialSystem.TrialDataDetails.SecondaryWorkingEmbrittlementDataDetails
{
    public class SecondaryWorkingEmbrittlementDataDetailDtoMapper : Profile
    {
        
        public SecondaryWorkingEmbrittlementDataDetailDtoMapper()
        {
            CreateMap<SecondaryWorkingEmbrittlementDataDetail, SecondaryWorkingEmbrittlementDataDetailDto>();
            CreateMap<SecondaryWorkingEmbrittlementDataDetailItem, SecondaryWorkingEmbrittlementDataDetailItemDto>();
            
        }
    }
}