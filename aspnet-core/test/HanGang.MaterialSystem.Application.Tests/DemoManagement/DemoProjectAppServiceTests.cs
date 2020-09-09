using HanGang.MaterialSystem.DemoManagement.Dtos;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace HanGang.MaterialSystem.DemoManagement
{
    public class DemoProjectAppServiceTests : MaterialSystemApplicationTestBase
    {
        private readonly IDemoProjectAppService _demoProjectAppService;
        private readonly IRepository<DemoProject, Guid> _demoProjectRepository;
        private Guid _userId1 = Guid.Parse("E0A45EB0-CEDE-4AE4-B01A-50ACF79688A9");

        public DemoProjectAppServiceTests()
        {
            _demoProjectAppService = GetRequiredService<IDemoProjectAppService>();
            _demoProjectRepository = GetRequiredService<IRepository<DemoProject, Guid>>();
        }

        [Fact(DisplayName = "测试创建项目")]
        public async Task<DemoProject> AddProjectTest()
        {
            ReplaceCurrentUser(_userId1);
            var input = new AddProjectInputDto()
            {
                ProjectName = "name1",
                ProjectItems = new List<DemoUnitProjectItemDto>()
                {
                    new DemoUnitProjectItemDto()
                    {
                        Name = "name2",
                        Address = "address1"
                    }
                }
            };
            var projectId = Guid.Empty;
            await WithUnitOfWorkAsync(async () => { projectId = await _demoProjectAppService.AddProject(input); });
            return await WithUnitOfWorkAsync(async () =>
            {
                var project = await _demoProjectRepository.Include(x => x.DemoUnitProjects).FirstOrDefaultAsync(x => x.Id == projectId);
                project.ShouldNotBeNull();
                project.DemoUnitProjects.Count.ShouldBe(1);
                project.DemoUnitProjects.First().Name.ShouldBe(input.ProjectItems[0].Name);
                project.Name.ShouldBe(input.ProjectName);
                return project;
            });
        }

        [InlineData("name1", "E0A45EB0-CEDE-4AE4-B01A-50ACF79688A9")]
        [InlineData("name1", "00000000-0000-0000-0000-000000000000")]
        [InlineData("name2", "E0A45EB0-CEDE-4AE4-B01A-50ACF79688A9")]
        [Theory(DisplayName = "获取当前用户所创建的用户列表")]
        public async Task GetMyProjectsTest(string name, string userIdStr)
        {
            await AddProjectTest();
            var userId = Guid.Parse((ReadOnlySpan<char>)userIdStr);
            ReplaceCurrentUser(userId);
            var input = new GetMyProjectsInputDto()
            {
                Name = name
            };
            await WithUnitOfWorkAsync(async () =>
            {
                var myProjects = await _demoProjectAppService.GetProjects(input);
                if (name == "name1")
                {
                    if (userId == _userId1)
                    {
                        myProjects.Items.Count.ShouldBe(1);
                    }
                    else
                    {
                        myProjects.Items.Count.ShouldBe(0);
                    }
                }
                else
                {
                    myProjects.Items.Count.ShouldBe(0);
                }
            });
        }

        [InlineData("NewName2", true)]
        [InlineData("NewName1", false)]
        [Theory(DisplayName = "更新项目测试")]
        public async Task UpdateProjectTest(string name, bool syncUnitProject)
        {
            var project = await AddProjectTest();
            var input = new UpdateProjectInputDto()
            {
                ProjectId = project.Id,
                Name = name,
                SyncUnitProject = syncUnitProject
            };
            await WithUnitOfWorkAsync(async () => { await _demoProjectAppService.UpdateProject(input); });
            await WithUnitOfWorkAsync(async () =>
            {
                var projectUpdated = await _demoProjectRepository.Include(x => x.DemoUnitProjects).FirstOrDefaultAsync(x => x.Id == project.Id);
                projectUpdated.ShouldNotBeNull();
                projectUpdated.Name.ShouldBe(name);
                if (syncUnitProject)
                {
                    projectUpdated.DemoUnitProjects.Any().ShouldBeTrue();
                    projectUpdated.DemoUnitProjects.First().Name.ShouldBe(name);
                }
            });
        }
    }
}