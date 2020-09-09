using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Manufactories.Dtos;
using HanGang.MaterialSystem.FlangingClaspDataDetails.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.TrialDataDetails.FlangingClaspDataDetails
{
    /// <summary>
    /// 翻边扣合服务
    /// </summary>
    public class FlangingClaspDataDetailAppService : MaterialSystemAppService
    {
        private readonly IRepository<FlangingClaspDataDetail, Guid> _flangingClaspDataDetailRepository;

        public FlangingClaspDataDetailAppService(IRepository<FlangingClaspDataDetail, Guid> flangingClaspDataDetailRepository)
        {
            _flangingClaspDataDetailRepository = flangingClaspDataDetailRepository;
        }

        /// <summary>
        /// 添加翻边扣合数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddFlangingClaspDataDetail(FlangingClaspDataDetailDto input)
        {
            var flangingClaspDataDetail = new FlangingClaspDataDetail
            {
                MaterialTrialDataId = input.MaterialTrialDataId,
                Standard = input.Standard,
                
                Remark = input.Remark,
                FlangingLevel = input.FlangingLevel,
                #region 新增
                Equipment = input.Equipment,
                FileString = input.FileString,
               
                #endregion

            };
            await _flangingClaspDataDetailRepository.InsertAsync(flangingClaspDataDetail);
            return flangingClaspDataDetail.Id;
        }

    }
}