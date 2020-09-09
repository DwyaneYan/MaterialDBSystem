using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Manufactories.Dtos;
using HanGang.MaterialSystem.WeldingDataDetails.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.TrialDataDetails.WeldingDataDetails
{
    /// <summary>
    /// 焊接性能服务   
    /// </summary>
    public class WeldingDataDetailAppService : MaterialSystemAppService
    {
        private readonly IRepository<WeldingDataDetail, Guid> _weldingDataDetailRepository;
        private readonly IRepository<WeldingDataDetailItem, Guid> _weldingDataDetailItemRepository;

        public WeldingDataDetailAppService(IRepository<WeldingDataDetail, Guid> weldingDataDetailRepository,
            IRepository<WeldingDataDetailItem, Guid> weldingDataDetailItemRepository)
        {
            _weldingDataDetailRepository = weldingDataDetailRepository;
            _weldingDataDetailItemRepository = weldingDataDetailItemRepository;
        }

        /// <summary>
        /// 添加焊接性能数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddWeldingDataDetail(WeldingDataDetailDto input)
        {
            var weldingDataDetail = new WeldingDataDetail
            {
                MaterialTrialDataId = input.MaterialTrialDataId,
                Standard = input.Standard,
            
                Remark = input.Remark,
                TestType = input.TestType,
                WelderType = input.WelderType,
                WelderMode = input.WelderMode,
                HeadDiameter = input.HeadDiameter,
                ElectrodePressure = input.ElectrodePressure,
                PulseTimes = input.PulseTimes,
                PreloadingTimes = input.PreloadingTimes,
                BoostTimes = input.BoostTimes,
                MinimumWeldingTimes = input.MinimumWeldingTimes,
                MiddleWeldingTimes = input.MiddleWeldingTimes,
                MaxmumWeldingTimes = input.MaxmumWeldingTimes,
                HoldingWeldingTimes = input.HoldingWeldingTimes,
                CriticalJointDiameter = input.CriticalJointDiameter,
                #region 新增
                Equipment = input.Equipment,
               
                FileString = input.FileString,

                TestOrganization = input.TestOrganization,
                TestMethod = input.TestMethod
                #endregion


            };
            await _weldingDataDetailRepository.InsertAsync(weldingDataDetail);
            return weldingDataDetail.Id;
        }
        public async Task<Guid> AddWeldingDataDetailItem(WeldingDataDetailItemDto input)
        {
            var weldingDataDetail = new WeldingDataDetailItem
            {
                WeldingDataDetailId = input.WeldingDataDetailId,
                WeldingCurrentInterval=input.WeldingCurrentInterval,
                LeftBoundaryElectric = input.LeftBoundaryElectric,
                RightBoundaryElectric = input.RightBoundaryElectric,
                WeldingTimes = input.WeldingTimes,
                Remark = input.Remark               


            };
            await _weldingDataDetailItemRepository.InsertAsync(weldingDataDetail);
            return weldingDataDetail.Id;
        }
        
    }
}