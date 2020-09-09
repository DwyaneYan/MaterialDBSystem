using HanGang.MaterialSystem.Enum;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities
{
    /// <summary>
    /// 试验
    /// </summary>
    public class Trial: FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 试验类型
        /// </summary>
        public TrialType TrialType { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 父级试验项目
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 父级试验项目
        /// </summary>
        public virtual Trial Parent { get; set; }

        /// <summary>
        /// 子级试验项目
        /// </summary>
        public virtual HashSet<Trial> Children { get; set; } = new HashSet<Trial>();

        #region 材料试验项目
        
        /// <summary>
        /// 材料试验项目
        /// </summary>
        public virtual HashSet<MaterialTrial> MaterialTrials { get; set; } = new HashSet<MaterialTrial>();

        #endregion
    }
}
