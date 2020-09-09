using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.CementingDataDetails.Dtos;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
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

namespace HanGang.MaterialSystem.TrialDataDetails.CementingDataDetails
{
    /// <summary>
    /// 胶接性能服务
    /// </summary>
    public class CementingDataDetailAppService : MaterialSystemAppService
    {
        private readonly IRepository<CementingDataDetail, Guid> _cementingDataDetailRepository;

        public CementingDataDetailAppService(IRepository<CementingDataDetail, Guid> cementingDataDetailRepository)
        {
            _cementingDataDetailRepository = cementingDataDetailRepository;
        }

        /// <summary>
        /// 添加胶接性能数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddCementingDataDetail(CementingDataDetailDto input)
        {
            var cementingDataDetail = new CementingDataDetail
            {
                MaterialTrialDataId = input.MaterialTrialDataId,
                Standard = input.Standard,
           
                SampleCode = input.SampleCode,
                Length = input.Length,
                Width = input.Width,
              
                Remark = input.Remark,
                CementingWidth = input.CementingWidth,
                MPA = input.MPA,
                FailureMode = input.FailureMode,
                #region 新增
                Equipment = input.Equipment,
                FileString = input.FileString,
               
                #endregion
            };
            await _cementingDataDetailRepository.InsertAsync(cementingDataDetail);
            return cementingDataDetail.Id;
        }

    }
}