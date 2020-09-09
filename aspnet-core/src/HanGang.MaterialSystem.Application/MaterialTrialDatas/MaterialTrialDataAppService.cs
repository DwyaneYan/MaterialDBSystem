using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Materials.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.Enum;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using HanGang.MaterialSystem.MaterialTrialDatas.Dtos;

namespace HanGang.MaterialSystem.Trials
{
    /// <summary>
    /// 材料实验数据服务
    /// </summary>
    public class MaterialTrialDataAppService : MaterialSystemAppService
    {
        private readonly IRepository<Material, Guid> _materialRepository;
        private readonly IRepository<MaterialTrial, Guid> _materialTrialRepository;
        private readonly IRepository<MaterialTrialData, Guid> _materialTrialDataRepository;
        private readonly IRepository<StaticTensionDataDetail, Guid> _staticTensionDataDetailRepository;

        public MaterialTrialDataAppService(
            IRepository<Material, Guid> materialRepository, 
            IRepository<MaterialTrial, Guid> materialTrialRepository,
            IRepository<MaterialTrialData, Guid> materialTrialDataRepository,
            IRepository<StaticTensionDataDetail, Guid> staticTensionDataDetailRepository)
        {
            _materialRepository = materialRepository;
            _materialTrialRepository = materialTrialRepository;
            _materialTrialDataRepository = materialTrialDataRepository;
            _staticTensionDataDetailRepository = staticTensionDataDetailRepository;
        }


        public async Task<Guid> AddMaterialTrialData(MaterialTrialDataDto input)
        {
            var materialTrialData = new MaterialTrialData
            {
                MaterialTrialId = input.MaterialTrialId,
            };
            await _materialTrialDataRepository.InsertAsync(materialTrialData);
            return materialTrialData.Id;
        }


    }
}