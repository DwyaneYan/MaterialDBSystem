using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.TypicalParts.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.TypicalParts
{
    /// <summary>
    /// 零部件服务
    /// </summary>
    public class TypicalPartAppService : MaterialSystemAppService
    {
        private readonly IRepository<TypicalPart, Guid> _typicalpartRepository;

        public TypicalPartAppService(IRepository<TypicalPart, Guid> typicalpartRepository)
        {
            _typicalpartRepository = typicalpartRepository;
        }

        /// <summary>
        /// 获取所有零部件
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<IPagedResult<TypicalPartDto>> GetTypicalParts(GetTypicalPartListInputDto input)
        {
            return _typicalpartRepository
                .AsNoTracking()
                .WhereIf(!string.IsNullOrEmpty(input.Name), x => x.Name.Contains(input.Name))
                .OrderBy(input.Sorting)
                .ProjectTo<TypicalPartDto>(Configuration)
                .ToPageResultAsync(input);
        }

        /// <summary>
        /// 根据零部件Id获取某个零部件信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TypicalPartDto> GetTypicalPartById(Guid id)
        {
            var typicalpart = await _typicalpartRepository.GetAsync(id);
            return ObjectMapper.Map<TypicalPart, TypicalPartDto>(typicalpart);
        }

        ///// <summary>
        ///// 添加零部件
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //public async Task<Guid> AddTypicalPart(AddTypicalPartInputDto input)
        //{
        //    var typicalpart = new TypicalPart
        //    {
        //        Name = input.Name,
        //        Code = input.Code,
        //        AppliedVehicleType = input.AppliedVehicleType,
        //        Remark = input.Remark
        //    };
        //    await _typicalpartRepository.InsertAsync(typicalpart);
        //    return typicalpart.Id;
        //}

        ///// <summary>
        ///// 更新某个零部件信息
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //public async Task<Guid> UpdateTypicalPart(TypicalPartDto input)
        //{
        //    var typicalpart = await _typicalpartRepository.GetAsync(input.Id);
        //    typicalpart.Name = input.Name;
        //    typicalpart.Code = input.Code;
        //    typicalpart.AppliedVehicleType = input.AppliedVehicleType;
        //    typicalpart.Remark = input.Remark;

        //    return typicalpart.Id;
        //}

        /// <summary>
        /// 根据生产厂家Id删除某个零部件信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(Guid id)
        {
            
            await _typicalpartRepository.DeleteAsync(m => m.Id == id);
        }
    }
}