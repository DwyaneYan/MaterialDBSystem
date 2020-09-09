using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 涂装性能-膜重试验数据结果明细
    /// </summary>
    public class PaintingDataDetailMembraneWeightItem : FullAuditedAggregateRoot<Guid>
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
        /// 面积（m2）
        /// </summary>
        public decimal? Area { get; set; }

        /// <summary>
        /// 初始重量（g）
        /// </summary>
        public decimal? OriginalWeight { get; set; }
        
        /// <summary>
        /// 试验后重量（g）
        /// </summary>
        public decimal? AfterWeight { get; set; }
                
        /// <summary>
        /// 膜重（g/mm2）
        /// </summary>
        public decimal? MembraneWeight { get; set; }

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
