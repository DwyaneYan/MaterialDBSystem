using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Manufactories.Dtos;
using HanGang.MaterialSystem.HighSpeedStrechDataDetails.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.HighSpeedStrechDataDetails
{
    /// <summary>
    ///高速拉伸服务
    /// </summary>
    public class HighSpeedStrechDataDetailAppService : MaterialSystemAppService
    {
        private readonly IRepository<HighSpeedStrechDataDetail, Guid> _highSpeedStrechDataDetailRepository;
        private readonly IRepository<HighSpeedStrechDataDetailStressStrain, Guid> _highSpeedStrechDataDetailStressStrainRepository;
        private readonly IRepository<HighSpeedStrechDataDetailStressStrainExtend, Guid> _highSpeedStrechDataDetailStressStrainExtendRepository;
        public HighSpeedStrechDataDetailAppService(IRepository<HighSpeedStrechDataDetail, Guid> highSpeedStrechDataDetailRepository,
            IRepository<HighSpeedStrechDataDetailStressStrain, Guid> highSpeedStrechDataDetailStressStrainRepository,
            IRepository<HighSpeedStrechDataDetailStressStrainExtend, Guid> highSpeedStrechDataDetailStressStrainExtendRepository
            )
        {
            _highSpeedStrechDataDetailRepository = highSpeedStrechDataDetailRepository;
            _highSpeedStrechDataDetailStressStrainRepository = highSpeedStrechDataDetailStressStrainRepository;
            _highSpeedStrechDataDetailStressStrainExtendRepository = highSpeedStrechDataDetailStressStrainExtendRepository;
        }

        /// <summary>
        /// 添加高速拉伸数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddManufactory(HighSpeedStrechDataDetailDto input)
        {
            var highSpeedStrechDataDetail = new HighSpeedStrechDataDetail
            {
                MaterialTrialDataId = input.MaterialTrialDataId,
                Standard = input.Standard,
              
                SampleCode = input.SampleCode,
             
              
                Thickness = input.Thickness,
             
                GaugeDistance = input.GaugeDistance,
                Remark = input.Remark,
                Direction = input.Direction,
                TestTarget = input.TestTarget,
                YieldStrength = input.YieldStrength,
                TensileStrength = input.TensileStrength,
                Elongation = input.Elongation,
                StretchingSpeed = input.StretchingSpeed,
                #region 新增
                Equipment = input.Equipment,
                FileString = input.FileString,
                
                FormYieldStrength = input.FormYieldStrength,
                FormTensileStrength = input.FormTensileStrength,
                FormElongation = input.FormElongation,
                FormModulusOfElasticity = input.FormModulusOfElasticity,

                TestOrganization = input.TestOrganization,
                TestMethod = input.TestMethod,
                YoungModulu = input.YoungModulu,
                PoissonRatio = input.PoissonRatio
                #endregion
            };
            await _highSpeedStrechDataDetailRepository.InsertAsync(highSpeedStrechDataDetail);
            return highSpeedStrechDataDetail.Id;
        }
        /// <summary>
        /// 添加高速拉伸应力应变
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> HighSpeedStrechDataDetailStressStrain(HighSpeedStrechDataDetailStressStrainDto input)
        {
            var highSpeedStrechDataDetail = new HighSpeedStrechDataDetailStressStrain
            {
                HighSpeedStrechDataDetailId = input.HighSpeedStrechDataDetailId,
                EngineeringStress = input.EngineeringStress,
                EngineeringStrain = input.EngineeringStrain,
                RealStress = input.RealStress,
                RealStrain = input.RealStrain,
                RealPlasticStress = input.RealPlasticStress,
                RealPlasticStrain = input.RealPlasticStrain,
                Remark = input.Remark
            };
            await _highSpeedStrechDataDetailStressStrainRepository.InsertAsync(highSpeedStrechDataDetail);
            return highSpeedStrechDataDetail.Id;
        }
        /// <summary>
        /// 添加高速拉伸应力应变
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> HighSpeedStrechDataDetailStressStrainExtend(HighSpeedStrechDataDetailStressStrainExtendDto input)
        {
            var highSpeedStrechDataDetailExtend = new HighSpeedStrechDataDetailStressStrainExtend
            {
                
               MaterialTrialDataId = input.MaterialTrialDataId,
               RealPlasticTestTarget= input.RealPlasticTestTarget,
                RealPlasticStrainHalf = input.RealPlasticStrainHalf,
                RealPlasticStressHalf = input.RealPlasticStressHalf,
               RealPlasticStrainExtend =input.RealPlasticStrainExtend,
               RealPlasticStressExtend=input.RealPlasticStressExtend,
                Remark = input.Remark
            };
            await _highSpeedStrechDataDetailStressStrainExtendRepository.InsertAsync(highSpeedStrechDataDetailExtend);
            return highSpeedStrechDataDetailExtend.Id;
        }
    }
}