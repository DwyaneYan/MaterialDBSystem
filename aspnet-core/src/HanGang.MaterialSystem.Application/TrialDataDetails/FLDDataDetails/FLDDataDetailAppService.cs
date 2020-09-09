using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.FLDDataDetailDetails.Dtos;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Manufactories.Dtos;
using HanGang.MaterialSystem.StaticTensionDataDetails.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.TrialDataDetails.FLDDataDetails
{
    /// <summary>
    /// 成形极限服务 
    /// </summary>
    public class FLDDataDetailAppService : MaterialSystemAppService
    {
        private readonly IRepository<FLDDataDetail, Guid> _fLDDataDetailRepository;
        private readonly IRepository<FLDDataDetailItem, Guid> _fLDDataDetailItemRepository;

        public FLDDataDetailAppService(IRepository<FLDDataDetail, Guid> fLDDataDetailRepository,
            IRepository<FLDDataDetailItem, Guid> fLDDataDetailItemRepository)
        {
            _fLDDataDetailRepository = fLDDataDetailRepository;
            _fLDDataDetailItemRepository = fLDDataDetailItemRepository;
        }

        /// <summary>
        /// 添加成形极限数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddfLDDataDetail(FLDDataDetailDto input)
        {
            var fLDDataDetail = new FLDDataDetail
            {
                MaterialTrialDataId = input.MaterialTrialDataId,
                Standard = input.Standard,
               
                Remark = input.Remark,
              
                #region 新增
                Equipment = input.Equipment,
                FileString = input.FileString,

                TestOrganization = input.TestOrganization,
                TestMethod = input.TestMethod
                #endregion

            };
            await _fLDDataDetailRepository.InsertAsync(fLDDataDetail);
            return fLDDataDetail.Id;
        }
        
        /// <summary>
        /// 添加成形极限项目
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddFLDDataDetailItem(FLDDataDetailItemDto input)
        {
            var fLDDataDetail = new FLDDataDetailItem
            {
                SpecimenWidth=input.SpecimenWidth,
                FLDDataDetailId = input.FLDDataDetailId,
                MainStrain = input.MainStrain,
                SecondaryStrain = input.SecondaryStrain,
                Remark = input.Remark,
              

            };
            await _fLDDataDetailItemRepository.InsertAsync(fLDDataDetail);
            return fLDDataDetail.Id;
        }

    }
}