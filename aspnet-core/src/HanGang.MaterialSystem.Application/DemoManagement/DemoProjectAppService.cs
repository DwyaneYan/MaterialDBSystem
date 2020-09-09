using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.DemoManagement.Dtos;
using HanGang.MaterialSystem.LinqExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.DemoManagement
{
    /// <summary>
    /// 演示代码
    /// </summary>
    public class DemoProjectAppService : MaterialSystemAppService, IDemoProjectAppService
    {
        private readonly IRepository<DemoProject, Guid> _demoProjectRepository;

        private readonly DemoProjectManager _demoProjectManager;

        public DemoProjectAppService(IRepository<DemoProject, Guid> demoProjectRepository, DemoProjectManager demoProjectManager)
        {
            _demoProjectRepository = demoProjectRepository;
            _demoProjectManager = demoProjectManager;
        }

        #region Implementation of IDemoProjectAppService

        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[Authorize]
        public async Task<Guid> AddProject(AddProjectInputDto input)
        {
            var project = await _demoProjectManager.CreateProject(input.ProjectName);
            //foreach (var unitProjectItem in input.ProjectItems)
            //{
            //    await _demoProjectManager.CreateUnitProjectToProject(unitProjectItem.Name, unitProjectItem.Address, project.Id);
            //}
            return project.Id;
        }

        /// <summary>
        /// 获取项目
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<IPagedResult<DemoProjectItemDto>> GetProjects(GetMyProjectsInputDto input)
        {
            return _demoProjectRepository
                .AsNoTracking()
                .WhereIf(!string.IsNullOrEmpty(input.Name), x => x.Name.Contains(input.Name))
                .OrderBy(input.Sorting)
                .ProjectTo<DemoProjectItemDto>(Configuration) //需在ProjectDtoMapper中进行映射配置
                .ToPageResultAsync(input);
        }

        /// <summary>
        /// 更新项目
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task UpdateProject(UpdateProjectInputDto input)
        {
            var project = await _demoProjectRepository
                .IncludeIf(input.SyncUnitProject, x => x.DemoUnitProjects)
                .Include(x => x.DemoUnitProjects)
                .GetAsync(input.ProjectId);
            if (project == null)
            {
                throw new UserFriendlyException("未找到指定的项目");
            }
            if (input.SyncUnitProject)
            {
                project.SynchronizationUnitProjectName(input.Name);
            }
            else
            {
                project.UpdateName(input.Name);
            }
        }

        /// <summary>
        /// 获取项目详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DemoProjectDto> GetProject(Guid id)
        {
            var project = await _demoProjectRepository.GetAsync(id);
            return ObjectMapper.Map<DemoProject, DemoProjectDto>(project);
        }

        #endregion
    }
}