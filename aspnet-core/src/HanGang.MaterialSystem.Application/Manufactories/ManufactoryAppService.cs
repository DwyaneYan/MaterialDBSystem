using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Manufactories.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.Manufactories
{
    /// <summary>
    /// 生产厂家服务
    /// </summary>
    public class ManufactoryAppService : MaterialSystemAppService
    {
        private readonly IRepository<Manufactory, Guid> _manufactoryRepository;

        public ManufactoryAppService(IRepository<Manufactory, Guid> manufactoryRepository)
        {
            _manufactoryRepository = manufactoryRepository;
        }

        /// <summary>
        /// 获取所有生产厂家
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<IPagedResult<ManufactoryDto>> GetManufactories(GetManufactoryListInputDto input)
        {
            return _manufactoryRepository
                .AsNoTracking()
                .WhereIf(!string.IsNullOrEmpty(input.Name), x => x.Name.Contains(input.Name))
                .OrderBy(input.Sorting)
                .ProjectTo<ManufactoryDto>(Configuration)
                .ToPageResultAsync(input);
        }

        /// <summary>
        /// 根据生产厂家Id获取某个厂家信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ManufactoryDto> GetManufactoryById(Guid id)
        {
            var manufactory = await _manufactoryRepository.GetAsync(id);
            return ObjectMapper.Map<Manufactory, ManufactoryDto>(manufactory);
        }

        /// <summary>
        /// 添加生产厂家
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddManufactory(AddManufactoryInputDto input)
        {
            var manufactory = new Manufactory
            {
                Name = input.Name,
                TelePhone = input.TelePhone,
                Address = input.Address,
                Remark = input.Remark
            };
            await _manufactoryRepository.InsertAsync(manufactory);
            return manufactory.Id;
        }

        /// <summary>
        /// 更新某个厂家信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateManufactory(ManufactoryDto input)
        {
            var manufactory = await _manufactoryRepository.GetAsync(input.Id);
            manufactory.Name = input.Name;
            manufactory.Address = input.Address; 
            manufactory.TelePhone = input.TelePhone;
            manufactory.Remark = input.Remark; ;
            return manufactory.Id;
        }

        /// <summary>
        /// 根据生产厂家Id删除某个厂家信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(Guid id)
        {
            //var manufactory = await _manufactoryRepository.GetAsync(id);
            await _manufactoryRepository.DeleteAsync(m => m.Id == id);
        }
    }
}