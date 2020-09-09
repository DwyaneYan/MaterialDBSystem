using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Manufactories.Dtos;
using HanGang.MaterialSystem.PhysicalPerformanceDataDetails.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.PhysicalPerformanceDataDetails
{
    /// <summary>
    ///物理性能服务 
    /// </summary>
    public class PhysicalPerformanceDataDetailAppService : MaterialSystemAppService
    {
        private readonly IRepository<PhysicalPerformanceDataDetail, Guid> _physicalPerformanceDataDetailRepository;
        private readonly IRepository<PhysicalPerformanceDataDetailThermalConductivity, Guid> _physicalPerformanceDataDetailThermalConductivityRepository;
        private readonly IRepository<PhysicalPerformanceDataDetailThermalExpansion, Guid> _physicalPerformanceDataDetailThermalExpansionRepository;

        public PhysicalPerformanceDataDetailAppService(IRepository<PhysicalPerformanceDataDetail, Guid> physicalPerformanceDataDetailRepository,
            IRepository<PhysicalPerformanceDataDetailThermalConductivity, Guid> physicalPerformanceDataDetailThermalConductivityRepository,
            IRepository<PhysicalPerformanceDataDetailThermalExpansion, Guid> physicalPerformanceDataDetailThermalExpansionRepository
            )
        {
            _physicalPerformanceDataDetailRepository = physicalPerformanceDataDetailRepository;
            _physicalPerformanceDataDetailThermalConductivityRepository = physicalPerformanceDataDetailThermalConductivityRepository;
            _physicalPerformanceDataDetailThermalExpansionRepository = physicalPerformanceDataDetailThermalExpansionRepository;
        }

        /// <summary>
        /// 添加物理性能数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddPhysicalPerformanceData(PhysicalPerformanceDataDetailDto input)
        {
            var physicalPerformanceDataDetail = new PhysicalPerformanceDataDetail
            {
                MaterialTrialDataId = input.MaterialTrialDataId,
                Standard = input.Standard,
               
                Remark = input.Remark,
                HV = input.HV,
                HBW = input.HBW,
                HRC = input.HRC,
                Density = input.Density,
                Resistivity = input.Resistivity,
                #region 新增
                Equipment = input.Equipment,
                FileString = input.FileString,
              
                #endregion
            };
            await _physicalPerformanceDataDetailRepository.InsertAsync(physicalPerformanceDataDetail);
            return physicalPerformanceDataDetail.Id;
        }
        
        /// <summary>
        /// 添加物理性能导热系数数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddPhysicalPerformanceDataDetailThermalConductivity(PhysicalPerformanceDataDetailThermalConductivityDto input)
        {
            var physicalPerformanceDataDetail = new PhysicalPerformanceDataDetailThermalConductivity
            {
                PhysicalPerformanceDataDetailId = input.PhysicalPerformanceDataDetailId,
                Temperature = input.Temperature,
                ThermalConductivity = input.ThermalConductivity,
                Remark = input.Remark,
            };
            await _physicalPerformanceDataDetailThermalConductivityRepository.InsertAsync(physicalPerformanceDataDetail);
            return physicalPerformanceDataDetail.Id;
        }
        
        /// <summary>
        /// 添加物理性能热膨胀数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddPhysicalPerformanceDataDetailThermalExpansion(PhysicalPerformanceDataDetailThermalExpansionDto input)
        {
            var physicalPerformanceDataDetail = new PhysicalPerformanceDataDetailThermalExpansion
            {
                PhysicalPerformanceDataDetailId = input.PhysicalPerformanceDataDetailId,
                TemperatureRange = input.TemperatureRange,
                ThermalExpansion  = input.ThermalExpansion,
                Remark = input.Remark
            };
            await _physicalPerformanceDataDetailThermalExpansionRepository.InsertAsync(physicalPerformanceDataDetail);
            return physicalPerformanceDataDetail.Id;
        }
    }
}