using AutoMapper;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Manufactories.Dtos;

namespace HanGang.MaterialSystem.Manufactories
{
    public class ManufactoryDtoMapper : Profile
    {
        public ManufactoryDtoMapper()
        {
            CreateMap<Manufactory, ManufactoryDto>();
        }
    }
}