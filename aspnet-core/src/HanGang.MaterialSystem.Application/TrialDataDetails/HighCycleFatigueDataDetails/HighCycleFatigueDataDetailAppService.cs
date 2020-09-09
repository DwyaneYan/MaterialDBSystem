using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Manufactories.Dtos;
using HanGang.MaterialSystem.HighCycleFatigueDataDetails.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.HighCycleFatigueDataDetails
{
    /// <summary>
    ///高周疲劳服务
    /// </summary>
    public class HighCycleFatigueDataDetailAppService : MaterialSystemAppService
    {
        private readonly IRepository<HighCycleFatigueDataDetail, Guid> _highCycleFatigueDataDetailRepository;
        private readonly IRepository<HighCycleFatigueDataDetailItem, Guid> _highCycleFatigueDataDetailItemRepository;
        public HighCycleFatigueDataDetailAppService(IRepository<HighCycleFatigueDataDetail, Guid> highCycleFatigueDataDetailRepository,
            IRepository<HighCycleFatigueDataDetailItem, Guid> highCycleFatigueDataDetailItemRepository)
        {
            _highCycleFatigueDataDetailRepository = highCycleFatigueDataDetailRepository;
            _highCycleFatigueDataDetailItemRepository = highCycleFatigueDataDetailItemRepository;
        }

        /// <summary>
        /// 添加高周疲劳数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddHighCycleFatigueData(HighCycleFatigueDataDetailDto input)
        {
            var highCycleFatigueDataDetail = new HighCycleFatigueDataDetail
            {
                MaterialTrialDataId = input.MaterialTrialDataId,
                Standard = input.Standard,
               
               
                Remark = input.Remark,
                UseExtensometer = input.UseExtensometer,
                ExtensometerGaugeDistance = input.ExtensometerGaugeDistance,
                SurfaceQuality = input.SurfaceQuality,
                CyclicStressRatio = input.CyclicStressRatio,
                SNAParameter = input.SNAParameter,
                SNBParameter = input.SNBParameter,
                SNRelatedParameter = input.SNRelatedParameter,
                FatigueLimitStrength = input.FatigueLimitStrength,
                StandardDeviation = input.StandardDeviation,
                #region 新增
                Equipment = input.Equipment,
                
                FileString = input.FileString,
                FormYieldStrength = input.FormYieldStrength,
                FormTensileStrength = input.FormTensileStrength,
              
                FormModulusOfElasticity = input.FormModulusOfElasticity,
                Formula=input.Formula
                #endregion
            };
            await _highCycleFatigueDataDetailRepository.InsertAsync(highCycleFatigueDataDetail);
            return highCycleFatigueDataDetail.Id;
        }
      
        /// <summary>
        /// 添加高周疲劳项目
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddHighCycleFatigueDataDetailItem(HighCycleFatigueDataDetailItemDto input)
        {
            var highCycleFatigueDataDetail = new HighCycleFatigueDataDetailItem
            {
                ItemSampleCode= input.ItemSampleCode,
                HighCycleFatigueDataDetailId = input.HighCycleFatigueDataDetailId,
                MaximumStress = input.MaximumStress,
                StressAmplitude = input.StressAmplitude,
                TestFrequency = input.TestFrequency,
                Remark = input.Remark
            };
            await _highCycleFatigueDataDetailItemRepository.InsertAsync(highCycleFatigueDataDetail);
            return highCycleFatigueDataDetail.Id;
        }

    }
}