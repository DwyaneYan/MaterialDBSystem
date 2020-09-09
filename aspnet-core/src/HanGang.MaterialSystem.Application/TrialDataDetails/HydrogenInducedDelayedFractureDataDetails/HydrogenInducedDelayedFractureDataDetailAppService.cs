using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Manufactories.Dtos;
using HanGang.MaterialSystem.BakeHardeningDataDetails.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using HanGang.MaterialSystem.HydrogenInducedDelayedFractureDataDetails.Dtos;

namespace HanGang.MaterialSystem.TrialDataDetails.HydrogenInducedDelayedFractureDataDetails
{
    /// <summary>
    ///氢致延迟开裂服务
    /// </summary>
    public class HydrogenInducedDelayedFractureDataDetailAppService : MaterialSystemAppService
    {
        private readonly IRepository<HydrogenInducedDelayedFractureDataDetail, Guid> _hydrogenInducedDelayedFractureDataDetailRepository;
        private readonly IRepository<HydrogenInducedDelayedFractureDataDetailItem, Guid> _hydrogenInducedDelayedFractureDataDetailItemRepository;

        public HydrogenInducedDelayedFractureDataDetailAppService(
            IRepository<HydrogenInducedDelayedFractureDataDetail, Guid> hydrogenInducedDelayedFractureDataDetailRepository,
             IRepository<HydrogenInducedDelayedFractureDataDetailItem, Guid> hydrogenInducedDelayedFractureDataDetailItemRepository
            )
        {
            _hydrogenInducedDelayedFractureDataDetailRepository = hydrogenInducedDelayedFractureDataDetailRepository;
            _hydrogenInducedDelayedFractureDataDetailItemRepository = hydrogenInducedDelayedFractureDataDetailItemRepository;
        }

        /// <summary>
        /// 添加氢致延迟开裂数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddHydrogenInducedDelayedFractureDataDetail(HydrogenInducedDelayedFractureDataDetailDto input)
        {
            var hydrogenInducedDelayedFractureDataDetail = new HydrogenInducedDelayedFractureDataDetail
            {
                MaterialTrialDataId = input.MaterialTrialDataId,
                Standard = input.Standard,
              
                Remark = input.Remark,
                TestName = input.TestName,
         
                LiquorType = input.LiquorType,
                TestTime = input.TestTime,
                #region 新增
                Equipment = input.Equipment,
                FileString = input.FileString,
                TestOrganization = input.TestOrganization,
               TestMethod =input.TestMethod
               
                #endregion


            };
            await _hydrogenInducedDelayedFractureDataDetailRepository.InsertAsync(hydrogenInducedDelayedFractureDataDetail);
            return hydrogenInducedDelayedFractureDataDetail.Id;
        }
        
        /// <summary>
        /// 添加氢致延迟开裂项目数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddHydrogenInducedDelayedFractureDataDetailItem(HydrogenInducedDelayedFractureDataDetailItemDto input)
        {
            var hydrogenInducedDelayedFractureDataDetail = new HydrogenInducedDelayedFractureDataDetailItem
            {
                HydrogenInducedDelayedFractureDataDetailId = input.HydrogenInducedDelayedFractureDataDetailId,
                Stress = input.Stress,
                Hour = input.Hour,
                Remark = input.Remark,
                Span=input.Span,
                Strain =input.Strain


            };
            await _hydrogenInducedDelayedFractureDataDetailItemRepository.InsertAsync(hydrogenInducedDelayedFractureDataDetail);
            return hydrogenInducedDelayedFractureDataDetail.Id;
        }
    }
}