using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 表面性能镀层重量
    /// </summary>
    public class SurfacePropertyCoatingWeight: FullAuditedAggregateRoot<Guid>
    {
        #region 关联材料表面性能试验数据明细

        /// <summary>
        /// 材料表面性能试验
        /// </summary>
        public Guid? SurfacePropertyDataDetailId { get; set; }

        /// <summary>
        /// 材料表面性能试验
        /// </summary>
        public virtual SurfacePropertyDataDetail SurfacePropertyDataDetail { get; set; }

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
        /// 重量要求
        /// </summary>
        public string WeightRequirement { get; set; }
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
