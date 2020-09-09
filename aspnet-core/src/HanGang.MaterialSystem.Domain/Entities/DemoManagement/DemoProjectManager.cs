using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace HanGang.MaterialSystem.DemoManagement
{
    /// <summary>
    /// 领域服务
    /// </summary>
    public class DemoProjectManager : DomainService
    {
        private readonly IRepository<DemoProject, Guid> _demoProjectRepository;
        private readonly IRepository<DemoUnitProject, Guid> _demoUnitProjectRepository;

        public DemoProjectManager(IRepository<DemoProject, Guid> demoProjectRepository, IRepository<DemoUnitProject, Guid> demoUnitProjectRepository)
        {
            _demoProjectRepository = demoProjectRepository;
            _demoUnitProjectRepository = demoUnitProjectRepository;
        }

        /*
         * 领域对象建议通过领域服务来创建，而不是在application应用层创建，领域根对象的构造方法建议声明为internal来保护
         */
        /// <summary>
        /// 通过领域服务创建项目
        /// </summary>
        /// <param name="projectName"></param>
        /// <returns></returns>
        public async Task<DemoProject> CreateProject(string projectName)
        {
            var project = new DemoProject(Guid.NewGuid(), projectName);
            return await _demoProjectRepository.InsertAsync(project);
        }


    }
}