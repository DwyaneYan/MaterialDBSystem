using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Manufactories.Dtos;
using HanGang.MaterialSystem.StaticTensionDataDetails.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spire.Xls;
using System;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;


namespace HanGang.MaterialSystem.TrialDataDetails.StaticTensionDataDetails
{
    /// <summary>
    /// 静态拉伸服务
    /// </summary>
    public class StaticTensionDataDetailAppService : MaterialSystemAppService
    {
        private readonly IRepository<StaticTensionDataDetail, Guid> _staticTensionDataDetailRepository;
        private readonly IRepository<StaticTensionDataDetailRequirement> _staticTensionDataDetailRequirementRepository;
        private readonly IRepository<StaticTensionDataDetailStressStrain, Guid> _staticTensionDataDetailStressStrainRepository;

        public StaticTensionDataDetailAppService(
            IRepository<StaticTensionDataDetail, Guid> staticTensionDataDetailRepository,
            IRepository<StaticTensionDataDetailStressStrain, Guid> staticTensionDataDetailStressStrainRepository,
            IRepository<StaticTensionDataDetailRequirement, Guid> staticTensionDataDetailRequirementRepository
            )
        {
            _staticTensionDataDetailRepository = staticTensionDataDetailRepository;
            _staticTensionDataDetailStressStrainRepository = staticTensionDataDetailStressStrainRepository;
            _staticTensionDataDetailRequirementRepository = staticTensionDataDetailRequirementRepository;
        }

        /// <summary>
        /// 添加静态拉伸数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddstaticTensionDataDetail(StaticTensionDataDetailDto input)
        {
            var staticTensionDataDetail = new StaticTensionDataDetail
            {
                MaterialTrialDataId = input.MaterialTrialDataId,
                Standard = input.Standard,
               
                SampleCode = input.SampleCode,
                
                Thickness = input.Thickness,
            
                GaugeDistance = input.GaugeDistance,
                Remark = input.Remark,
                NonProportionalExtendRatio = input.NonProportionalExtendRatio,
                YieldStrength = input.YieldStrength,
                TensileStrength = input.TensileStrength,
                StrainHardening = input.StrainHardening,
                Elongation = input.Elongation,
                PlasticStrainRatio = input.PlasticStrainRatio,
                ModulusOfElasticity = input.ModulusOfElasticity,
                PoissonRatio = input.PoissonRatio,
                MaximumForce = input.MaximumForce,
                #region 新增
                Equipment = input.Equipment,
                FileString=input.FileString,
                
                Direction=input.Direction,
                BHValue=input.BHValue,
                IndenterDiameter=input.IndenterDiameter,
                VImpactTemperature=input.VImpactTemperature,
                VImpactEnergy=input.VImpactEnergy,


                TestOrganization = input.TestOrganization,
                TestMethod = input.TestMethod
                #endregion
            };
            await _staticTensionDataDetailRepository.InsertAsync(staticTensionDataDetail);
            return staticTensionDataDetail.Id;
        }
        /// <summary>
        /// 添加静态拉伸数据Requirement
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddstaticTensionDataDetailRequirement(StaticTensionDataDetailRequirementDto input)
        {
            var staticTensionDataDetail = new StaticTensionDataDetailRequirement
            {
                MaterialTrialDataId = input.MaterialTrialDataId,
               

                SampleCode = input.SampleCode,

                Thickness = input.Thickness,
                Direction = input.Direction,

                NonProportionalExtendRatio = input.NonProportionalExtendRatio,
                YieldStrength = input.YieldStrength,
                TensileStrength = input.TensileStrength,
                StrainHardening = input.StrainHardening,
                Elongation = input.Elongation,
                PlasticStrainRatio = input.PlasticStrainRatio,
                ModulusOfElasticity = input.ModulusOfElasticity,
                PoissonRatio = input.PoissonRatio,
                MaximumForce = input.MaximumForce,
               

               
                BHValue = input.BHValue,
                IndenterDiameter = input.IndenterDiameter,
                VImpactTemperature = input.VImpactTemperature,
                VImpactEnergy = input.VImpactEnergy,


               
            };
            await _staticTensionDataDetailRequirementRepository.InsertAsync(staticTensionDataDetail);
            return staticTensionDataDetail.Id;
        }
        /// <summary>
        /// 添加静态拉伸应力应变数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddStaticTensionDataDetailStressStrain(StaticTensionDataDetailStressStrainDto input)
        {
            var staticTensionDataDetail = new StaticTensionDataDetailStressStrain
            {
                StaticTensionDataDetailId = input.StaticTensionDataDetailId,
                Stress = input.Stress,
                Strain = input.Strain,
                RealStress = input.RealStress,
                RealStrain = input.RealStrain,
                Remark = input.Remark
            };
            await _staticTensionDataDetailStressStrainRepository.InsertAsync(staticTensionDataDetail);
            return staticTensionDataDetail.Id;
        }
     

    }
}