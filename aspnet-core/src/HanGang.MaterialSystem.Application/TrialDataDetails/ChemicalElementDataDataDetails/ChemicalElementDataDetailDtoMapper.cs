using AutoMapper;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.ChemicalElementDataDetails.Dtos;

namespace HanGang.MaterialSystem.ChemicalElements
{
    public class ChemicalElementDataDetailDtoMapper : Profile
    {
        public ChemicalElementDataDetailDtoMapper()
        {
            CreateMap<ChemicalElementDataDetail, ChemicalElementDataDetailDto>();
          
        }
    }
}