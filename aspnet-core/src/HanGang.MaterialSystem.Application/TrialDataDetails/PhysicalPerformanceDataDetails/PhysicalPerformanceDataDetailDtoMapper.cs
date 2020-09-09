using AutoMapper;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.PhysicalPerformanceDataDetails.Dtos;

namespace HanGang.MaterialSystem.PhysicalPerformances
{
    
    public class PhysicalPerformanceDataDetailDtoMapper : Profile
    {
       
        public PhysicalPerformanceDataDetailDtoMapper()
        {
            CreateMap<PhysicalPerformanceDataDetail, PhysicalPerformanceDataDetailDto>();
            CreateMap<PhysicalPerformanceDataDetailThermalConductivity, PhysicalPerformanceDataDetailThermalConductivityDto>();
            CreateMap<PhysicalPerformanceDataDetailThermalExpansion, PhysicalPerformanceDataDetailThermalExpansionDto>();
        }
    }
}