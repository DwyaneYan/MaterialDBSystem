using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Manufactories.Dtos;
using HanGang.MaterialSystem.SecondaryWorkingEmbrittlementDataDetails.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.TrialDataDetails.SecondaryWorkingEmbrittlementDataDetails
{
    /// <summary>
    /// 二次加工服务
    /// </summary>
    public class SecondaryWorkingEmbrittlementDataDetailAppService : MaterialSystemAppService
    {
        private readonly IRepository<SecondaryWorkingEmbrittlementDataDetail, Guid> _secondaryWorkingEmbrittlementDataDetailRepository;
        private readonly IRepository<SecondaryWorkingEmbrittlementDataDetailItem, Guid> _secondaryWorkingEmbrittlementDataDetailItemRepository;

        public SecondaryWorkingEmbrittlementDataDetailAppService(
            IRepository<SecondaryWorkingEmbrittlementDataDetail, Guid> secondaryWorkingEmbrittlementDataDetailRepository,
            IRepository<SecondaryWorkingEmbrittlementDataDetailItem, Guid> secondaryWorkingEmbrittlementDataDetailItemRepository)
        {
            _secondaryWorkingEmbrittlementDataDetailRepository = secondaryWorkingEmbrittlementDataDetailRepository;
            _secondaryWorkingEmbrittlementDataDetailItemRepository = secondaryWorkingEmbrittlementDataDetailItemRepository;
        }

        /// <summary>
        /// 添加二次加工数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddSecondaryWorkingEmbrittlementDataDetail(SecondaryWorkingEmbrittlementDataDetailDto input)
        {
            var secondaryWorkingEmbrittlementDataDetail = new SecondaryWorkingEmbrittlementDataDetail
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
            await _secondaryWorkingEmbrittlementDataDetailRepository.InsertAsync(secondaryWorkingEmbrittlementDataDetail);
            return secondaryWorkingEmbrittlementDataDetail.Id;
        }
      
        /// <summary>
        /// 添加二次加工项目数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddSecondaryWorkingEmbrittlementDataDetailItem(SecondaryWorkingEmbrittlementDataDetailItemDto input)
        {
            var secondaryWorkingEmbrittlementDataDetail = new SecondaryWorkingEmbrittlementDataDetailItem
            {
                Temperature = input.Temperature,
                Swet = input.Swet,
                SecondaryWorkingEmbrittlementDataDetailId = input.SecondaryWorkingEmbrittlementDataDetailId,
                SerialNumber = input.SerialNumber,
                ExpansionType = input.ExpansionType,
                Remark = input.Remark

            };
            await _secondaryWorkingEmbrittlementDataDetailItemRepository.InsertAsync(secondaryWorkingEmbrittlementDataDetail);
            return secondaryWorkingEmbrittlementDataDetail.Id;
        }
    }
}