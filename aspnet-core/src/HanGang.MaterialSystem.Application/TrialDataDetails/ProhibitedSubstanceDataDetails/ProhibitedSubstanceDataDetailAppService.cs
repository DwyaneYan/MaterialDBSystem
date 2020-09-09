using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Manufactories.Dtos;
using HanGang.MaterialSystem.ProhibitedSubstanceDataDetails.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.ProhibitedSubstanceDataDetails
{
    /// <summary>
    ///禁用物质服务
    /// </summary>
    public class ProhibitedSubstanceDataDetailAppService : MaterialSystemAppService
    {
        private readonly IRepository<ProhibitedSubstanceDataDetail, Guid> _prohibitedSubstanceDataDetailRepository;

        public ProhibitedSubstanceDataDetailAppService(IRepository<ProhibitedSubstanceDataDetail, Guid> prohibitedSubstanceDataDetailRepository)
        {
            _prohibitedSubstanceDataDetailRepository = prohibitedSubstanceDataDetailRepository;
        }

        /// <summary>
        /// 添加禁用物质数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddProhibitedSubstanceData(ProhibitedSubstanceDataDetailDto input)
        {
            var prohibitedSubstanceDataDetail = new ProhibitedSubstanceDataDetail
            {
                MaterialTrialDataId = input.MaterialTrialDataId,
                Standard = input.Standard,
              
                SampleCode = input.SampleCode,
               
                Remark = input.Remark,
            
                Element = input.Element,
                ContentRatio = input.ContentRatio,
                #region 新增
                Equipment = input.Equipment,
              
                FileString= input.FileString,
                Requirement = input.Requirement,
                #endregion

            };
            await _prohibitedSubstanceDataDetailRepository.InsertAsync(prohibitedSubstanceDataDetail);
            return prohibitedSubstanceDataDetail.Id;
        }

    }
}