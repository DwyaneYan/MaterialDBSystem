using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 物理性能-热膨胀系数
    /// </summary>
    public class PhysicalPerformanceDataDetailThermalExpansion: FullAuditedAggregateRoot<Guid>
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

        #region 热膨胀系数

        /// <summary>
        /// 温度范围（℃）
        /// </summary>
        public string TemperatureRange { get; set; }

        /// <summary>
        /// 热膨胀系数α（1/℃）
        /// </summary>
        public decimal? ThermalExpansion { get; set; }

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
