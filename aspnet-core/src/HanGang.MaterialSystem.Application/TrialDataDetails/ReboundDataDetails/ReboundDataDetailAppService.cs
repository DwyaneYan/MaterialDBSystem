using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Manufactories.Dtos;
using HanGang.MaterialSystem.ReboundDataDetails.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.TrialDataDetails.ReboundDataDetails
{
    /// <summary>
    ///回弹性能服务     
    /// </summary>
    public class ReboundDataDetailAppService : MaterialSystemAppService
    {
        private readonly IRepository<ReboundDataDetail, Guid> _reboundDataDetailRepository;
        private readonly IRepository<ReboundDataDetailItem, Guid> _reboundDataDetailItemRepository;
        private readonly IRepository<ReboundDataDetailItem2, Guid> _reboundDataDetailItem2Repository;
        private readonly IRepository<ReboundDataDetailItem3, Guid> _reboundDataDetailItem3Repository;

        public ReboundDataDetailAppService(IRepository<ReboundDataDetail, Guid> reboundDataDetailRepository,
             IRepository<ReboundDataDetailItem, Guid> reboundDataDetailItemRepository,
             IRepository<ReboundDataDetailItem2, Guid> reboundDataDetailItem2Repository,
             IRepository<ReboundDataDetailItem3, Guid> reboundDataDetailItem3Repository
             )
        {
            _reboundDataDetailRepository =  reboundDataDetailRepository;
            _reboundDataDetailItemRepository = reboundDataDetailItemRepository;
            _reboundDataDetailItem2Repository= reboundDataDetailItem2Repository;
            _reboundDataDetailItem3Repository = reboundDataDetailItem3Repository;
        }

        /// <summary>
        /// 添加回弹性能数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddReboundDataDetail(ReboundDataDetailDto input)
        {
            var reboundDataDetail = new ReboundDataDetail
            {
                MaterialTrialDataId = input.MaterialTrialDataId,
                Standard = input.Standard,
               
                Remark = input.Remark,

                SampleSize = input.SampleSize,
                BendingAngleRange = input.BendingAngleRange,
                TestSpeed = input.TestSpeed,
                HoldStress = input.HoldStress,
                HoldTimes = input.HoldTimes,
                PunchFilletRadiusRange = input.PunchFilletRadiusRange,
                #region 新增
                Equipment = input.Equipment,
                FileString= input.FileString,


                TestOrganization = input.TestOrganization,
                TestMethod = input.TestMethod
                #endregion

            };
            await _reboundDataDetailRepository.InsertAsync(reboundDataDetail);
            return reboundDataDetail.Id;
        }
        /// <summary>
        ///添加回弹性能子表1数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
            public async Task<Guid> AddReboundDataDetailItem(ReboundDataDetailItemDto input)
        {
            var reboundDataDetail = new ReboundDataDetailItem
            {
                ReboundDataDetailId = input.ReboundDataDetailId,
                
                PunchFilletRadius = input.PunchFilletRadius,
                BendingAngle = input.BendingAngle,
                ReboundAngle = input.ReboundAngle,
                Remark = input.Remark,
                Direction=input.Direction,
                Thickness=input.Thickness,
                MeasuringAngle=input.MeasuringAngle


            };
            await _reboundDataDetailItemRepository.InsertAsync(reboundDataDetail);
            return reboundDataDetail.Id;
        }
        /// <summary>
        /// 添加回弹性能子表2数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddReboundDataDetailItem2(ReboundDataDetailItem2Dto input)
        {
            var reboundDataDetail = new ReboundDataDetailItem2
            {
                ReboundDataDetailId = input.ReboundDataDetailId,
                Direction=input.Direction,
                Thickness=input.Thickness,
                BendingAngle=input.BendingAngle,
                Rt1=input.Rt1,
                Rt2 = input.Rt2,
                Rt3 = input.Rt3,
                Rt4 = input.Rt4,
                Rt5 = input.Rt5,
                Rt6 = input.Rt6,
                RtMin = input.RtMin,
                Remark=input.Remark


            };
            await _reboundDataDetailItem2Repository.InsertAsync(reboundDataDetail);
            return reboundDataDetail.Id;
        }
        /// <summary>
        /// 添加回弹性能子表3数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddReboundDataDetailItem3(ReboundDataDetailItem3Dto input)
        {
            var reboundDataDetail = new ReboundDataDetailItem3
            {
                ReboundDataDetailId = input.ReboundDataDetailId,
                Direction = input.Direction,
                Thickness = input.Thickness,
                
                Rt1 = input.Rt1,
                Rt2 = input.Rt2,
                Rt3 = input.Rt3,
                Rt4 = input.Rt4,
               
                Remark = input.Remark
              


            };
            await _reboundDataDetailItem3Repository.InsertAsync(reboundDataDetail);
            return reboundDataDetail.Id;
        }
    }
}