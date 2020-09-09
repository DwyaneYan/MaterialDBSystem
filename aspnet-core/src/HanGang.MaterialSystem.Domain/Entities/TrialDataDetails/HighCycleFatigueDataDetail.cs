using System.Collections.Generic;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 高周疲劳试验数据明细
    /// </summary>
    public class HighCycleFatigueDataDetail : BaseTrialDataDetail
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
        /// 循环应力比
        /// </summary>
        public string CyclicStressRatio { get; set; }

        #region 高周疲劳计算结果参数 S-N曲线
        /// <summary>
        /// 公式
        /// </summary>
        public string Formula { get; set; }

        /// <summary>
        /// 高周疲劳 S-N曲线参数a
        /// </summary>
        public decimal? SNAParameter { get; set; }

        /// <summary>
        /// 高周疲劳 S-N曲线参数b
        /// </summary>
        public decimal? SNBParameter { get; set; }

        /// <summary>
        /// 高周疲劳 S-N曲线相关系数
        /// </summary>
        public decimal? SNRelatedParameter { get; set; }

        /// <summary>
        /// 高周疲劳 疲劳极限强度/MPa
        /// </summary>
        public decimal? FatigueLimitStrength { get; set; }

        /// <summary>
        /// 高周疲劳 标准偏差/MPa
        /// </summary>
        public decimal? StandardDeviation { get; set; }

        #endregion

        /// <summary>
        /// 高周疲劳试验数据结果明细
        /// </summary>
        public virtual HashSet<HighCycleFatigueDataDetailItem> HighCycleFatigueDataDetailItems { get; set; }=new HashSet<HighCycleFatigueDataDetailItem>();

    }
}
