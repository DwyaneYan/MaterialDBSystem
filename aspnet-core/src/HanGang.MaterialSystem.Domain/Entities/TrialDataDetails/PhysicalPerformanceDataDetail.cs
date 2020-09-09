using System.Collections.Generic;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 物理性能试验数据明细
    /// </summary>
    public class PhysicalPerformanceDataDetail: BaseTrialDataDetail
    {
        /// <summary>
        /// 维氏硬度（HV）
        /// </summary>
        public decimal? HV { get; set; }

        /// <summary>
        /// 布氏硬度（HBW）
        /// </summary>
        public decimal? HBW { get; set; }

        /// <summary>
        /// 洛氏硬度（HRC）
        /// </summary>
        public decimal? HRC { get; set; }

        /// <summary>
        /// 密度ρ（g/cm3）
        /// </summary>
        public decimal? Density { get; set; }
        
        /// <summary>
        /// 电阻率ρ（Ω·m）
        /// </summary>
        public decimal? Resistivity { get; set; }

        /// <summary>
        /// 物理性能-热膨胀系数明细
        /// </summary>
        public virtual HashSet<PhysicalPerformanceDataDetailThermalExpansion> PhysicalPerformanceDataDetailThermalExpansions { get; set; } = new HashSet<PhysicalPerformanceDataDetailThermalExpansion>();

        /// <summary>
        /// 物理性能-导热系数明细
        /// </summary>
        public virtual HashSet<PhysicalPerformanceDataDetailThermalConductivity> PhysicalPerformanceDataDetailThermalConductivities { get; set; } = new HashSet<PhysicalPerformanceDataDetailThermalConductivity>();

    }
}
