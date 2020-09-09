using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Manufactories.Dtos;
using HanGang.MaterialSystem.SurfacePropertyDataDetails.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.TrialDataDetails.SurfacePropertyDataDetails
{
    /// <summary>
    /// 表面性能服务 
    /// </summary>
    public class SurfacePropertyDataDetailAppService : MaterialSystemAppService
    {
        private readonly IRepository<SurfacePropertyDataDetail, Guid> _surfacePropertyDataDetailRepository;

        private readonly IRepository<SurfacePropertyCoatingWeight, Guid> _surfacePropertyCoatingWeightRepository;
        private readonly IRepository<SurfacePropertyRoughness, Guid> _surfacePropertyRoughnessRepository;
        private readonly IRepository<SurfacePropertyRoughnessAndPeakDensity> _surfacePropertyRoughnessAndPeakDensityRepository;
        private readonly IRepository<SurfacePropertySizeTolerance> _surfacePropertySizeToleranceRepository;

        public SurfacePropertyDataDetailAppService(
            IRepository<SurfacePropertyDataDetail, Guid> surfacePropertyDataDetailRepository,
             IRepository<SurfacePropertyCoatingWeight, Guid> surfacePropertyCoatingWeightRepository,
             IRepository<SurfacePropertyRoughness, Guid> surfacePropertyRoughnessRepository,
             IRepository<SurfacePropertyRoughnessAndPeakDensity> surfacePropertyRoughnessAndPeakDensityRepository,
             IRepository<SurfacePropertySizeTolerance> surfacePropertySizeToleranceRepository

            )
        {
            _surfacePropertyDataDetailRepository = surfacePropertyDataDetailRepository;
            _surfacePropertyCoatingWeightRepository = surfacePropertyCoatingWeightRepository;
            _surfacePropertyRoughnessRepository = surfacePropertyRoughnessRepository;
            _surfacePropertyRoughnessAndPeakDensityRepository = surfacePropertyRoughnessAndPeakDensityRepository;
            _surfacePropertySizeToleranceRepository = surfacePropertySizeToleranceRepository;
        }

        /// <summary>
        /// 添加表面性能试验数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddSurfacePropertyDataDetail(SurfacePropertyDataDetailDto input)
        {
            var surfacePropertyDataDetail = new SurfacePropertyDataDetail
            {
                MaterialTrialDataId = input.MaterialTrialDataId,
                Standard = input.Standard,
                SurfaceQualityGrade = input.SurfaceQualityGrade,
                Remark = input.Remark,
                #region 新增
                TestOrganization= input.TestOrganization,
                TestMethod= input.TestMethod,
                Equipment = input.Equipment,
                FileString = input.FileString,
               TestItem= input.TestItem,
                #endregion


            };
            await _surfacePropertyDataDetailRepository.InsertAsync(surfacePropertyDataDetail);
            return surfacePropertyDataDetail.Id;
        }
        /// <summary>
        /// 添加表面性能镀层重量
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddSurfacePropertyCoatingWeight(SurfacePropertyCoatingWeightDto input)
        {
            var surfacePropertyDataDetail = new SurfacePropertyCoatingWeight
            {
                SurfacePropertyDataDetailId = input.SurfacePropertyDataDetailId,
                Area = input.Area,
                OriginalWeight = input.OriginalWeight,
                AfterWeight = input.AfterWeight,
                MembraneWeight = input.MembraneWeight,
                WeightRequirement = input.WeightRequirement,
                Remark = input.Remark


            };
            await _surfacePropertyCoatingWeightRepository.InsertAsync(surfacePropertyDataDetail);
            return surfacePropertyDataDetail.Id;
        }
        
        /// <summary>
        /// 添加表面性能粗造度
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddSurfacePropertyRoughness(SurfacePropertyRoughnessDto input)
        {
            var surfacePropertyDataDetail = new SurfacePropertyRoughness
            {
                SurfacePropertyDataDetailId = input.SurfacePropertyDataDetailId,
                RaOne = input.RaOne,
                RaTwo = input.RaTwo,
                RPCOne = input.RPCOne,
                RPCTwo = input.RPCTwo,

                Remark = input.Remark


            };
            await _surfacePropertyRoughnessRepository.InsertAsync(surfacePropertyDataDetail);
            return surfacePropertyDataDetail.Id;
        }
        /// <summary>
        /// 添加表面性能粗造度和峰值密度
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddSSurfacePropertyRoughnessAndPeakDensity(SurfacePropertyRoughnessAndPeakDensityDto input)
        {
            var surfacePropertyDataDetail = new SurfacePropertyRoughnessAndPeakDensity
            {
                SurfacePropertyDataDetailId = input.SurfacePropertyDataDetailId,
               RaRequirement = input.RaRequirement,
               Position = input.Position,
                AboveRoughness = input.AboveRoughness,
                AbovePeakDensity = input.AbovePeakDensity,
                BelowRoughness = input.BelowRoughness,
                BelowPeakDensity= input.BelowPeakDensity,
              

                Remark = input.Remark


            };
            await _surfacePropertyRoughnessAndPeakDensityRepository.InsertAsync(surfacePropertyDataDetail);
            return surfacePropertyDataDetail.Id;
        }
        /// <summary>
        /// 添加表面性能尺寸公差
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddSurfacePropertySizeTolerance(SurfacePropertySizeToleranceDto input)
        {
            var surfacePropertyDataDetail = new SurfacePropertySizeTolerance
            {
                SurfacePropertyDataDetailId = input.SurfacePropertyDataDetailId,
               SizeRequirement= input.SizeRequirement,
                TestCode = input.TestCode,
                EdgeThickness1 = input.EdgeThickness1,
                EdgeThickness2 = input.EdgeThickness2,
                EdgeThickness3 = input.EdgeThickness3,

                Remark = input.Remark


            };
            await _surfacePropertySizeToleranceRepository.InsertAsync(surfacePropertyDataDetail);
            return surfacePropertyDataDetail.Id;
        }
    }
}