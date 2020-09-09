using System.Collections.Generic;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 低周疲劳试验数据明细
    /// </summary>
    public class LowCycleFatigueDataDetail : BaseTrialDataDetail
    {
        /// <summary>
        /// 是否使用引伸计
        /// </summary>
        public bool? UseExtensometer { get; set; }

        /// <summary>
        /// 引伸计标距(mm)
        /// </summary>
        public decimal? ExtensometerGaugeDistance { get; set; }
        
        /// <summary>
        /// 表面质量
        /// </summary>
        public string SurfaceQuality { get; set; }

        /// <summary>
        /// 循环应变比
        /// </summary>
        public string CyclicStrainRatio { get; set; }
        
        #region 低周疲劳计算结果参数

        /// <summary>
        /// 低周疲劳 循环强度系数Κ＇/MPa
        /// </summary>
        public decimal? CyclicStrengthParameter { get; set; }

        /// <summary>
        /// 低周疲劳 循环应变硬化指数
        /// </summary>
        public decimal? CyclicStrainHardening { get; set; }

        /// <summary>
        /// 低周疲劳 应力应变相关系数
        /// </summary>
        public decimal? RelatedSressParameter { get; set; }

        /// <summary>
        /// 低周疲劳 疲劳强度系数
        /// </summary>
        public decimal? FatigueStrengthParameter { get; set; }

        /// <summary>
        /// 低周疲劳 疲劳强度指数
        /// </summary>
        public decimal? FatigueStrength { get; set; }

        /// <summary>
        /// 低周疲劳 应变寿命疲劳强度相关系数
        /// </summary>
        public decimal? RelatedLifeFatigueParameter { get; set; }

        /// <summary>
        /// 低周疲劳 疲劳延性系数
        /// </summary>
        public decimal? FatigueStrechParameter { get; set; }

        /// <summary>
        /// 低周疲劳 疲劳延性指数
        /// </summary>
        public decimal? FatigueStrech { get; set; }
        
        /// <summary>
        /// 低周疲劳 应变寿命疲劳延性相关系数
        /// </summary>
        public decimal? RelatedLifeStrechParameter { get; set; }

        #endregion

        /// <summary>
        /// 低周疲劳试验数据结果明细
        /// </summary>
        public virtual HashSet<LowCycleFatigueDataDetailItem> LowCycleFatigueDataDetailItems { get; set; }=new HashSet<LowCycleFatigueDataDetailItem>();
    }
}
