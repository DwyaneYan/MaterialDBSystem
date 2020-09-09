﻿using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace HanGang.MaterialSystem.DemoManagement
{
    /// <summary>
    /// 项目下的子项目
    /// </summary>
    public class DemoUnitProject : Entity<Guid>, IHasCreationTime
    {
        /// <summary>
        /// 子项目名称
        /// </summary>
        public string Name { get; internal set; }

        /*
         * 这里以后建议使用Address值对象表示，后期提供地址区域模块后补充
         */
        public string Address { get; set; }

        public Guid? DemoProjectId { get; set; }

        public virtual DemoProject DemoProject { get; set; }

        #region Implementation of IHasCreationTime

        public DateTime CreationTime { get; set; }

        #endregion
    }
}