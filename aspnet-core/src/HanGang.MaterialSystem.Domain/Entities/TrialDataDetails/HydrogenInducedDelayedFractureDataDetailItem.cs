using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 氢致延迟断裂应变试验数据明细
    /// </summary>
    public class HydrogenInducedDelayedFractureDataDetailItem : FullAuditedAggregateRoot<Guid>
    {
        #region 关联氢致延迟断裂试验数据明细

        /// <summary>
        /// 氢致延迟断裂试验数据明细
        /// </summary>
        public Guid? HydrogenInducedDelayedFractureDataDetailId { get; set; }

        /// <summary>
        /// 氢致延迟断裂试验数据明细
        /// </summary>
        public virtual HydrogenInducedDelayedFractureDataDetail HydrogenInducedDelayedFractureDataDetail { get; set; }

        #endregion

        /// <summary>
        /// 弯曲跨度
        /// </summary>
        public decimal? Span { get; set; }

        /// <summary>
        /// 弯曲应变
        /// </summary>
        public decimal? Strain { get; set; }

        /// <summary>
        /// 应力（MPa）
        /// </summary>
        public decimal? Stress { get; set; }

        /// <summary>
        /// 开裂时间
        /// </summary>
        public decimal? Hour { get; set; }

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
