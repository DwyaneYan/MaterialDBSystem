using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Trials.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.Trials
{
    /// <summary>
    /// 生产厂家服务
    /// </summary>
    public class TrialAppService : MaterialSystemAppService
    {
        private readonly IRepository<Trial, Guid> _trialRepository;

        public TrialAppService(IRepository<Trial, Guid> trialRepository)
        {
            _trialRepository = trialRepository;
        }

        /// <summary>
        /// 获取所有试验
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<IPagedResult<TrialDto>> GetTrials(GetTrialListInputDto input)
        {
            return _trialRepository
                .AsNoTracking()
                .WhereIf(!string.IsNullOrEmpty(input.Name), x => x.Name.Contains(input.Name))
                .OrderBy(input.Sorting)
                .ProjectTo<TrialDto>(Configuration)
                .ToPageResultAsync(input);
        }

        /// <summary>
        /// 根据试验Id获取某个试验信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TrialDto> GetTrialById(Guid id)
        {
            var trial = await _trialRepository.GetAsync(id);
            return ObjectMapper.Map<Trial, TrialDto>(trial);
        }

        /// <summary>
        /// 添加试验
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddTrial(AddTrialDto input)
        {
            var trial = new Trial
            {
                Name = input.Name,
                TrialType = input.TrialType,
                Code = input.Code,
                Remark = input.Remark,
                ParentId = input.ParentId,
            };
            await _trialRepository.InsertAsync(trial);
            return trial.Id;
        }

        /// <summary>
        /// 更新某个试验信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateTrial(TrialDto input)
        {

            var trial = await _trialRepository.GetAsync(input.Id);
            trial.Name = input.Name;
            trial.TrialType = input.TrialType;
            trial.Code = input.Code;
            trial.Remark = input.Remark;
            return trial.Id;
        }

        /// <summary>
        /// 根据生产厂家Id删除某个厂家信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(Guid id)
        {
            //var manufactory = await _manufactoryRepository.GetAsync(id);
            await _trialRepository.DeleteAsync(t => t.Id == id);
        }
    }
}