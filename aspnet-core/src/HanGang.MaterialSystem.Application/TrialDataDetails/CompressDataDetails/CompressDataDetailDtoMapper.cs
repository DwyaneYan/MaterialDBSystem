using AutoMapper;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.CompressDataDetails.Dtos;

namespace HanGang.MaterialSystem.Compress
{
    public class CompressDataDetailDtoMapper : Profile
    {
        public CompressDataDetailDtoMapper()
        {
            CreateMap<CompressDataDetail, CompressDataDetailDto>();
        }
    }
}