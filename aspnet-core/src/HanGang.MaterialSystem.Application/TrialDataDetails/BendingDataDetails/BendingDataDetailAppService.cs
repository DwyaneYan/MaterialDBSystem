using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Manufactories.Dtos;
using HanGang.MaterialSystem.BendingDataDetails.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.BendingDataDetails
{
    /// <summary>
    ///弯曲服务
    /// </summary>
    public class BendingDataDetailAppService : MaterialSystemAppService
    {
        private readonly IRepository<BendingDataDetail, Guid> _bendingDataDetailRepository;

        public BendingDataDetailAppService(IRepository<BendingDataDetail, Guid> bendingDataDetailRepository)
        {
            _bendingDataDetailRepository = bendingDataDetailRepository;
        }

        /// <summary>
        /// 添加弯曲数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddBendingData(BendingDataDetailDto input)
        {
            var bendingDataDetail = new BendingDataDetail
            {
                MaterialTrialDataId = input.MaterialTrialDataId,
                Standard = input.Standard,
                
                SampleCode = input.SampleCode,
                Length = input.Length,
                Width = input.Width,
                Thickness = input.Thickness,
                Diameter = input.Diameter,
                
                Remark = input.Remark,

               
                BendingStrength = input.BendingStrength,
                NonProportionalBendingStrenth = input.NonProportionalBendingStrenth,
                BendingOfElasticity = input.BendingOfElasticity,
                #region 新增
                Equipment = input.Equipment,
                FileString  = input.FileString ,
               
                Span=input.Span
                #endregion
            };
            await _bendingDataDetailRepository.InsertAsync(bendingDataDetail);
            return bendingDataDetail.Id;
        }

    }
}