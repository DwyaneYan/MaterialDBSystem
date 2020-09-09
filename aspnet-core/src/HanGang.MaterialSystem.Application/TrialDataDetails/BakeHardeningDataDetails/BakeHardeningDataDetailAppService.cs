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

namespace HanGang.MaterialSystem.TrialDataDetails.BakeHardeningDataDetails
{
    /// <summary>
    /// 烘烤硬化服务
    /// </summary>
    public class BakeHardeningDataDetailAppService : MaterialSystemAppService
    {
        private readonly IRepository<BakeHardeningDataDetail, Guid> _bakeHardeningDataDetailRepository;
        private readonly IRepository<BakeHardeningDataDetailItem, Guid> _bakeHardeningDataDetailItemRepository;

        public BakeHardeningDataDetailAppService(IRepository<BakeHardeningDataDetail, Guid> bakeHardeningDataDetailRepository,
            IRepository<BakeHardeningDataDetailItem, Guid> bakeHardeningDataDetailItemRepository
            )
        {
            _bakeHardeningDataDetailRepository = bakeHardeningDataDetailRepository;
            _bakeHardeningDataDetailItemRepository = bakeHardeningDataDetailItemRepository;
        }

        /// <summary>
        /// 添加烘烤硬化数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddbakeHardeningDataDetail(BakeHardeningDataDetailDto input)
        {
            var bakeHardeningDataDetail = new BakeHardeningDataDetail
            {
                MaterialTrialDataId = input.MaterialTrialDataId,
                Standard = input.Standard,
          
                Remark = input.Remark,
        
                 #region 新增
                Equipment = input.Equipment,
                FileString = input.FileString,
            
                #endregion
            };
            await _bakeHardeningDataDetailRepository.InsertAsync(bakeHardeningDataDetail);
            return bakeHardeningDataDetail.Id;
        }
       
        /// <summary>
        /// 添加烘烤硬化项目数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddBakeHardeningDataDetailItem(BakeHardeningDataDetailItemDto input)
        {
            var bakeHardeningDataDetail = new BakeHardeningDataDetailItem
            {
                BakeHardeningDataDetailId = input.BakeHardeningDataDetailId,
                TemperatureTimes = input.TemperatureTimes,
                Rt = input.Rt,
                Rp = input.Rp,
                Rm = input.Rm,
                BH2 = input.BH2,
               
                Remark = input.Remark

            };
            await _bakeHardeningDataDetailItemRepository.InsertAsync(bakeHardeningDataDetail);
            return bakeHardeningDataDetail.Id;
        }
    }
}