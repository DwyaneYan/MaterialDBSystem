using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Manufactories.Dtos;
using HanGang.MaterialSystem.ChemicalElementDataDetails.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.ChemicalElementDataDetails
{
    /// <summary>
    ///化学成分服务
    /// </summary>
    public class ChemicalElementDataDetailAppService : MaterialSystemAppService
    {
        private readonly IRepository<ChemicalElementDataDetail, Guid> _chemicalElementDataDetailRepository;

        public ChemicalElementDataDetailAppService(IRepository<ChemicalElementDataDetail, Guid> chemicalElementDataDetailRepository)
        {
            _chemicalElementDataDetailRepository = chemicalElementDataDetailRepository;
        }

        /// <summary>
        /// 添加化学成分数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddChemicalElementData(ChemicalElementDataDetailDto input)
        {
            var chemicalElementDataDetail = new ChemicalElementDataDetail
            {
                MaterialTrialDataId = input.MaterialTrialDataId,
                Standard = input.Standard,
              
                SampleCode = input.SampleCode,
              
              
                Remark = input.Remark,
                Requirement=input.Requirement,
                Element = input.Element,
                ContentRatio = input.ContentRatio,
                #region 新增
                Equipment = input.Equipment,
    
                FileString = input.FileString,

                TestOrganization = input.TestOrganization,
                TestMethod = input.TestMethod
              
                #endregion

            };
            await _chemicalElementDataDetailRepository.InsertAsync(chemicalElementDataDetail);
            return chemicalElementDataDetail.Id;
        }

    }
}