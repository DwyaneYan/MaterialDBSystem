using AutoMapper;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.LowCycleFatigueDataDetails.Dtos;
using HanGang.MaterialSystem.Materials.Dtos;

namespace HanGang.MaterialSystem.MaterialManagement
{
    public class MaterialDtoMapper : Profile
    {
        public MaterialDtoMapper()
        {
            CreateMap<Material, MaterialDto>()
                .ForMember(m => m.ManufactoryName, option => option.MapFrom(n => n.Manufactory.Name))
                .ForMember(m => m.AppliedVehicleType, option => option.MapFrom(n => n.TypicalPart.AppliedVehicleType))
                .ForMember(m => m.TypicalPartName, option => option.MapFrom(n => n.TypicalPart.Name));
            CreateMap<MaterialRecommendation, MaterialRecommendationDto>();
        }
    }
}