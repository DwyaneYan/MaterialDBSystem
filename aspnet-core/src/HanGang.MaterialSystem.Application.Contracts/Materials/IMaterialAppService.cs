using HanGang.MaterialSystem.Materials.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace HanGang.MaterialSystem.Materials
{
    /// <summary>
    /// 材料服务接口
    /// </summary>
    public interface IMaterialAppService
    {
        /// <summary>
        /// 获取所有材料
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<IPagedResult<MaterialDto>> GetMaterials(GetMaterialListInputDto input);

        /// <summary>
        /// 添加材料
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>between types 'System.String' and 'System.Nullable`1[System.Guid]'.”

        Task<Guid> AddMaterial(MaterialDto input);

        /// <summary>
        /// 更新某个材料信息
        /// </summary>
        /// <param name="input"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Guid> UpdateTrial(MaterialDto input, Guid id);

        /// <summary>
        /// 根据材料Id删除某个材料信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(List<Guid> ids);
        /// <summary>
        /// 根据材料id添加材料推荐表
        /// </summary>
        /// <param name="id"></param>        
        /// <returns></returns>between types 'System.String' and 'System.Nullable`1[System.Guid]'.”

        Task<Guid?> AddMaterialRecommendations(Guid? id);
        /// <summary>
        /// 材料的应用案例自动导出
        /// </summary>
        /// <param name="id"></param>

        /// <returns></returns>
        string ApplicationCaseExport(Guid id);
    }
}
