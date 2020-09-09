using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Manufactories.Dtos;
using HanGang.MaterialSystem.DentResistanceDataDetails.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.TrialDataDetails.DentResistanceDataDetails
{
    /// <summary>
    /// 抗凹性能服务DentResistanceDataDetailLimitStrain
    /// </summary>
    public class DentResistanceDataDetailAppService : MaterialSystemAppService
    {
        private readonly IRepository<DentResistanceDataDetail, Guid> _dentResistanceDataDetailRepository;
       
        public DentResistanceDataDetailAppService(IRepository<DentResistanceDataDetail, Guid> dentResistanceDataDetailRepository
           )
        {
            _dentResistanceDataDetailRepository = dentResistanceDataDetailRepository;
           
        }

        /// <summary>
        /// 添加抗凹性能数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddDentResistanceDataDetail(DentResistanceDataDetailDto input)
        {
            var dentResistanceDataDetail = new DentResistanceDataDetail
            {
                MaterialTrialDataId = input.MaterialTrialDataId,
                Standard = input.Standard,
                
                Remark = input.Remark,
                OriginalRigidity = input.OriginalRigidity,

                VisibleDentLoad = input.VisibleDentLoad,
               
                #region 新增
                Equipment = input.Equipment,
                FileString = input.FileString,
               
                #endregion

            };
            await _dentResistanceDataDetailRepository.InsertAsync(dentResistanceDataDetail);
            return dentResistanceDataDetail.Id;
        }
       
        
    }
}