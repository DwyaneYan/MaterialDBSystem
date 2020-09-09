using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Manufactories.Dtos;
using HanGang.MaterialSystem.MetallographicDataDetails.Dtos;
using HanGang.MaterialSystem.TrialDataDetails.MetallographicDataDetails;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.MetallographicDataDetails
{
    /// <summary>
    ///金相服务
    /// </summary>
    public class MetallographicDataDetailAppService : MaterialSystemAppService,IMetallographicDataDetailAppService
    {
        private readonly IRepository<MetallographicDataDetail, Guid> _metallographicDataDetailRepository;

        public MetallographicDataDetailAppService(IRepository<MetallographicDataDetail, Guid> metallographicDataDetailRepository)
        {
            _metallographicDataDetailRepository = metallographicDataDetailRepository;
        }

        /// <summary>
        /// 添加金相数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddMetallographicData(MetallographicDataDetailDto input)
        {
            var metallographicDataDetail = new MetallographicDataDetail
            {
                MaterialTrialDataId = input.MaterialTrialDataId,
                Standard = input.Standard,
               
                Remark = input.Remark,
                Structure = input.Structure,
                NonMetallicInclusionLevel = input.NonMetallicInclusionLevel,
                GrainSize = input.GrainSize,
                DepthDecarburization = input.DepthDecarburization,
                
                #region 新增
                Equipment = input.Equipment,
                FileString = input.FileString,
               
                #endregion
            };
            await _metallographicDataDetailRepository.InsertAsync(metallographicDataDetail);
            return metallographicDataDetail.Id;
        }

    }
}