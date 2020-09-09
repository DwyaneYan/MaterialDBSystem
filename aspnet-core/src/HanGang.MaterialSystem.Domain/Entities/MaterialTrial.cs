using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities
{
    /// <summary>
    /// 材料试验 (导入材料试验数据基于此表)
    /// </summary>
    public class MaterialTrial: FullAuditedAggregateRoot<Guid>
    {
        #region 材料试验 基础字段

        /// <summary>
        /// 冗余材料试验名称=试验名称(试验名称保持不变,方便查询)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 材料试验编码(暂无需求)
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 材料
        /// </summary>
        public Guid? MaterialId { get; set; }

        /// <summary>
        /// 材料
        /// </summary>
        public virtual Material Material { get; set; }

        /// <summary>
        /// 试验
        /// </summary>
        public Guid? TrialId { get; set; }

        /// <summary>
        /// 试验
        /// </summary>
        public virtual Trial Trial { get; set; }

        #endregion

        #region 材料试验数据
        
        /// <summary>
        /// 材料试验数据
        /// </summary>
        public virtual HashSet<MaterialTrialData> TrialDatas { get; set; } = new HashSet<MaterialTrialData>();
        
        #endregion
    }
}
