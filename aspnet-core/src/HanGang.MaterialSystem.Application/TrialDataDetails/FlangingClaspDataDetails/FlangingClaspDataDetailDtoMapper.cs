using AutoMapper;
using HanGang.MaterialSystem.BakeHardeningDataDetails.Dtos;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.FlangingClaspDataDetails.Dtos;
using HanGang.MaterialSystem.StaticTensionDataDetails.Dtos;

namespace HanGang.MaterialSystem.TrialDataDetails.FlangingClaspDataDetails
{
    public class FlangingClaspDataDetailDtoMapper : Profile
    {
        public FlangingClaspDataDetailDtoMapper()
        {
            CreateMap<FlangingClaspDataDetail, FlangingClaspDataDetailDto>();
        }
    }
}