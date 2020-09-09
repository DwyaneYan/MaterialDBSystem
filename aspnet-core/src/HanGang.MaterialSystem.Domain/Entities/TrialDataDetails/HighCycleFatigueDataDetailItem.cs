using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 高周疲劳试验数据结果明细
    /// </summary>
    public class HighCycleFatigueDataDetailItem : FullAuditedAggregateRoot<Guid>
    {
        #region 关联高周疲劳试验数据明细

        /// <summary>
        /// 高周疲劳试验数据明细
        /// </summary>
        public Guid? HighCycleFatigueDataDetailId { get; set; }

        /// <summary>
        /// 高周疲劳试验数据明细
        /// </summary>
        public virtual HighCycleFatigueDataDetail HighCycleFatigueDataDetail { get; set; }

        #endregion
        /// <summary>
        /// 编号 
        /// </summary>
        public string ItemSampleCode { get; set; }
        /// <summary>
        /// 最大应力/MPa
        /// </summary>
        public decimal? MaximumStress { get; set; }

        /// <summary>
        /// 应力幅/MPa
        /// </summary>
        public decimal? StressAmplitude { get; set; }

        /// <summary>
        /// 试验循环周次
        /// </summary>
        public decimal? TestFrequency { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 插入顺序
        /// </summary>
        public int InsertOrder { get; set; }
    }
}
