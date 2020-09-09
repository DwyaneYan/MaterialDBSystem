using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.DemoManagement
{
    /// <summary>
    /// 测试项目
    /// </summary>
    public class DemoProject : FullAuditedAggregateRoot<Guid>
    {
        internal DemoProject(Guid id, string name) : base(id)
        {
            Name = name;
            DemoUnitProjects = new HashSet<DemoUnitProject>();
        }
        [MaxLength(255)] public string Name { get; set; }

        [MaxLength(255)] public string OldName { get; set; }

        public virtual HashSet<DemoUnitProject> DemoUnitProjects { get; set; }


        public DemoProject UpdateName(string name)
        {
            //1.这里可以做一些业务逻辑上的判断
            //...
            //2.执行操作
            if (Name == name)
            {
                return this;
            }

            OldName = Name;
            Name = name;
            return this;
        }


        public DemoProject SynchronizationUnitProjectName(string name)
        {
            UpdateName(name);
            foreach (var demoUnitProject in DemoUnitProjects)
            {
                demoUnitProject.Name = name;
            }
            return this;
        }
    }
}