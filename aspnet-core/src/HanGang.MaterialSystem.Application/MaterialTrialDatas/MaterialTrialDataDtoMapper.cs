using AutoMapper;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.MaterialTrialDatas.Dtos;

namespace HanGang.MaterialSystem.MaterialManagement
{
    public class MaterialTrialDataDtoMapper : Profile
    {
        public MaterialTrialDataDtoMapper()
        {
            CreateMap<MaterialTrialData, MaterialTrialDataDto>();
        }
    }
}