using AutoMapper;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.PaintingDataDetails.Dtos;

namespace HanGang.MaterialSystem.TrialDataDetails.PaintingDataDetails
{
    public class PaintingDataDetailDtoMapper : Profile
    {
       
        public PaintingDataDetailDtoMapper()
        {
            CreateMap<PaintingDataDetail, PaintingDataDetailDto>();
            CreateMap<PaintingDataDetailAdhesionItem, PaintingDataDetailAdhesionItemDto>();

            CreateMap<PaintingDataDetailDampHeatItem, PaintingDataDetailDampHeatItemDto>();
            CreateMap<PaintingDataDetailElectrophoreticItem, PaintingDataDetailElectrophoreticItemDto>();
            CreateMap<PaintingDataDetailHardnessItem, PaintingDataDetailHardnessItemDto>();
            CreateMap<PaintingDataDetailHitResistanceItem, PaintingDataDetailHitResistanceItemDto>();

            CreateMap< PaintingDataDetailMembraneWeightItem, PaintingDataDetailMembraneWeightItemDto>();
            CreateMap<PaintingDataDetailPhosphatingItem, PaintingDataDetailPhosphatingItemDto>();
            CreateMap<PaintingDataDetailPRatioItem, PaintingDataDetailPRatioItemDto>();
            CreateMap<PaintingDataDetailRoughnessItem, PaintingDataDetailRoughnessItemDto>();
        }
    }
}