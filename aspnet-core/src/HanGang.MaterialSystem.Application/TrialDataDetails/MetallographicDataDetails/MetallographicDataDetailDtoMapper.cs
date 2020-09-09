using AutoMapper;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.MetallographicDataDetails.Dtos;

namespace HanGang.MaterialSystem.Metallographics
{
    public class MetallographicDataDetailDtoMapper : Profile
    {
        public MetallographicDataDetailDtoMapper()
        {
            CreateMap<MetallographicDataDetail, MetallographicDataDetailDto>();
           
        }
    }
}