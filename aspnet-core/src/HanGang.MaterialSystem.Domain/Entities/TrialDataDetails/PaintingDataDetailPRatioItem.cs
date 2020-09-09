using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 涂装性能-P比试验数据结果明细
    /// </summary>
    public class PaintingDataDetailPRatioItem : FullAuditedAggregateRoot<Guid>
    {
        #region 关联材料涂装性能试验数据

        /// <summary>
        /// 涂装性能试验数据明细
        /// </summary>
        public Guid? PaintingDataDetailId { get; set; }

        /// <summary>
        /// 涂装性能试验数据明细
        /// </summary>
        public virtual PaintingDataDetail PaintingDataDetail { get; set; }

        #endregion

        /// <summary>
        /// Ip（s-1）
        /// </summary>
        public decimal? Ip { get; set; }

        /// <summary>
        /// IH（s-1）
        /// </summary>
        public decimal? IH { get; set; }

        /// <summary>
        /// P比
        /// </summary>
        public decimal? Ratio { get; set; }

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
