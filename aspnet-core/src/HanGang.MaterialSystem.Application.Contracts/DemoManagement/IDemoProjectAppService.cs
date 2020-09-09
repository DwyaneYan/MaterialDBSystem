using System;
using System.Threading.Tasks;
using HanGang.MaterialSystem.DemoManagement.Dtos;
using Volo.Abp.Application.Dtos;

namespace HanGang.MaterialSystem.DemoManagement
{
    /// <summary>
    /// 示例接口
    /// </summary>
    public interface IDemoProjectAppService
    {

        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[Authorize]
        Task<Guid> AddProject(AddProjectInputDto input);

        /// <summary>
        /// 获取项目
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<IPagedResult<DemoProjectItemDto>> GetProjects(GetMyProjectsInputDto input);

        /// <summary>
        /// 更新项目
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateProject(UpdateProjectInputDto input);

        /// <summary>
        /// 获取项目详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DemoProjectDto> GetProject(Guid id);
    }
}