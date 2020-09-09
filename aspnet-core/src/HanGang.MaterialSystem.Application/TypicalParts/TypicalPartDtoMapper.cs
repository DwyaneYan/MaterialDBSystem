using AutoMapper;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.TypicalParts.Dtos;

namespace HanGang.MaterialSystemTypicalParts
{
    public class TypicalPartDtoMapper : Profile
    {
        public TypicalPartDtoMapper()
        {
            CreateMap<TypicalPart, TypicalPartDto>();
        }
    }
}