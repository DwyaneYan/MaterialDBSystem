using AutoMapper;
using HanGang.MaterialSystem.BakeHardeningDataDetails.Dtos;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.SurfacePropertyDataDetails.Dtos;

namespace HanGang.MaterialSystem.TrialDataDetails.SurfacePropertyDataDetails
{
    public class SurfacePropertyDataDetailMapper : Profile
    {
        public SurfacePropertyDataDetailMapper()
        {
            CreateMap<SurfacePropertyDataDetail, SurfacePropertyDataDetailDto>();
            CreateMap<SurfacePropertyCoatingWeight, SurfacePropertyCoatingWeightDto>();
            CreateMap<SurfacePropertyRoughness, SurfacePropertyRoughnessDto>();
            CreateMap<SurfacePropertyRoughnessAndPeakDensity, SurfacePropertyRoughnessAndPeakDensityDto>();
            CreateMap<SurfacePropertySizeTolerance, SurfacePropertySizeToleranceDto>();
        }
    }
}