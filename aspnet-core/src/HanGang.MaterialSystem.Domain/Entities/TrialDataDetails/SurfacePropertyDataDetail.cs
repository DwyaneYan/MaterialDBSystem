using System.Collections.Generic;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 表面性能试验数据明细
    /// </summary>
    public class SurfacePropertyDataDetail : BaseTrialDataDetail
    {
        /// <summary>
        /// 表面性能试验项目
        /// </summary>
        public string TestItem { get; set; }
        
        /// <summary>
        /// 表面质量等级
        /// </summary>
        public string SurfaceQualityGrade { get; set; }
        /// <summary>
        /// 表面性能试验粗造度数据明细
        /// </summary>
        public virtual HashSet<SurfacePropertyCoatingWeight> SurfacePropertyCoatingWeights { get; set; } = new HashSet<SurfacePropertyCoatingWeight>();

        /// <summary>
        /// 表面性能试验粗造度数据明细
        /// </summary>
        public virtual HashSet<SurfacePropertyRoughness> SurfacePropertyRoughnesses { get; set; } = new HashSet<SurfacePropertyRoughness>();
        /// <summary>
        /// 表面性能试验粗糙度和峰值密度数据明细
        /// </summary>
        public virtual HashSet<SurfacePropertyRoughnessAndPeakDensity> SurfacePropertyRoughnessAndPeakDensitys { get; set; } = new HashSet<SurfacePropertyRoughnessAndPeakDensity>();
        /// <summary>
        /// 表面性能试验尺寸公差数据明细
        /// </summary>
        public virtual HashSet<SurfacePropertySizeTolerance> SurfacePropertySizeTolerances { get; set; } = new HashSet<SurfacePropertySizeTolerance>();
    }
}
