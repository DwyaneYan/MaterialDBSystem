using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 物理性能-导热系数
    /// </summary>
    public class PhysicalPerformanceDataDetailThermalConductivity: FullAuditedAggregateRoot<Guid>
    {
        #region 关联物理性能试验数据明细

        /// <summary>
        /// 物理性能数据明细
        /// </summary>
        public Guid? PhysicalPerformanceDataDetailId { get; set; }

        /// <summary>
        /// 物理性能数据明细
        /// </summary>
        public virtual PhysicalPerformanceDataDetail PhysicalPerformanceDataDetail { get; set; }

        #endregion
        
        #region 导热系数
        
        /// <summary>
        /// 温度（℃）
        /// </summary>
        public decimal? Temperature { get; set; }

        /// <summary>
        /// 导热系数λ（W/(cm゜C)）
        /// </summary>
        public decimal? ThermalConductivity { get; set; }

        #endregion
        
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
