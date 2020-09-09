using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Manufactories.Dtos;
using HanGang.MaterialSystem.LowCycleFatigueDataDetails.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.LowCycleFatigueDetails
{
    /// <summary>
    ///低周疲劳服务
    /// </summary>
    public class LowCycleFatigueDataDetailAppService : MaterialSystemAppService
    {
        private readonly IRepository<LowCycleFatigueDataDetail, Guid> _lowCycleFatigueDataDetailRepository;
        private readonly IRepository<LowCycleFatigueDataDetailItem, Guid> _lowCycleFatigueDataDetailItemRepository;
        public LowCycleFatigueDataDetailAppService(IRepository<LowCycleFatigueDataDetail, Guid> lowCycleFatigueDataDetailRepository,
            IRepository<LowCycleFatigueDataDetailItem, Guid> lowCycleFatigueDataDetailItemRepository)
        {
            _lowCycleFatigueDataDetailRepository = lowCycleFatigueDataDetailRepository;
            _lowCycleFatigueDataDetailItemRepository = lowCycleFatigueDataDetailItemRepository;
        }

        /// <summary>
        /// 添加低周疲劳数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddLowCycleFatigueData(LowCycleFatigueDataDetailDto input)
        {
            var lowCycleFatigueDataDetail = new LowCycleFatigueDataDetail
            {
                MaterialTrialDataId = input.MaterialTrialDataId,
                Standard = input.Standard,
               
                Remark = input.Remark,

                
                ExtensometerGaugeDistance = input.ExtensometerGaugeDistance,
                SurfaceQuality = input.SurfaceQuality,
                CyclicStrainRatio = input.CyclicStrainRatio,
                CyclicStrengthParameter = input.CyclicStrengthParameter,
                CyclicStrainHardening = input.CyclicStrainHardening,
                RelatedSressParameter = input.RelatedSressParameter,
                FatigueStrengthParameter = input.FatigueStrengthParameter,
                FatigueStrength = input.FatigueStrength,
                RelatedLifeFatigueParameter = input.RelatedLifeFatigueParameter,
                FatigueStrechParameter = input.FatigueStrechParameter,
                FatigueStrech = input.FatigueStrech,
                RelatedLifeStrechParameter = input.RelatedLifeStrechParameter,
                #region 新增
                Equipment = input.Equipment,
                FileString = input.FileString,
               
                FormYieldStrength = input.FormYieldStrength,
                FormTensileStrength = input.FormTensileStrength,
               
                FormModulusOfElasticity = input.FormModulusOfElasticity,

                TestOrganization = input.TestOrganization,
                TestMethod = input.TestMethod
                #endregion
            };
            await _lowCycleFatigueDataDetailRepository.InsertAsync(lowCycleFatigueDataDetail);
            return lowCycleFatigueDataDetail.Id;
        }
        
        /// <summary>
        /// 添加低周疲劳项目数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddLowCycleFatigueDataDetailItem(LowCycleFatigueDataDetailItemDto input)
        {
            var lowCycleFatigueDataDetail = new LowCycleFatigueDataDetailItem
            {
                SampleCode= input.SampleCode,
                LowCycleFatigueDataDetailId = input.LowCycleFatigueDataDetailId,
                TotalStrainAmplitude = input.TotalStrainAmplitude,
                PlasticStrainAmplitude = input.PlasticStrainAmplitude,
                ElasticStrainAmplitude = input.ElasticStrainAmplitude,
                FailureCycleTimes = input.FailureCycleTimes,
                CycleStressAmplitude = input.CycleStressAmplitude,
                TestFrequency = input.TestFrequency,
                Remark = input.Remark
            };
            await _lowCycleFatigueDataDetailItemRepository.InsertAsync(lowCycleFatigueDataDetail);
            return lowCycleFatigueDataDetail.Id;
        }
    }
}