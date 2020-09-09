using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Manufactories.Dtos;
using HanGang.MaterialSystem.CompressDataDetails.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.CompressDataDetails
{
    /// <summary>
    /// 压缩服务
    /// </summary>
    public class CompressDataDetailAppService : MaterialSystemAppService
    {
        private readonly IRepository<CompressDataDetail, Guid> _compressDataDetailRepository;

        public CompressDataDetailAppService(IRepository<CompressDataDetail, Guid> compressDataDetailRepository)
        {
            _compressDataDetailRepository = compressDataDetailRepository;
        }

        /// <summary>
        /// 添加压缩数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddCompressData(CompressDataDetailDto input)
        {
            var compressDataDetail = new CompressDataDetail
            {
                MaterialTrialDataId = input.MaterialTrialDataId,
                Standard = input.Standard,
              
                SampleCode = input.SampleCode,
                Length = input.Length,
                Width = input.Width,
                Thickness = input.Thickness,
                Diameter = input.Diameter,
               
                Remark = input.Remark,
                CompressiveStrength = input.CompressiveStrength,
                NonProportionalCompressStrenth = input.NonProportionalCompressStrenth,
                CompressOfElasticity = input.CompressOfElasticity,
                #region 新增
                Equipment = input.Equipment,
                FileString = input.FileString,
               
                #endregion
            };
            await _compressDataDetailRepository.InsertAsync(compressDataDetail);
            return compressDataDetail.Id;
        }

    }
}