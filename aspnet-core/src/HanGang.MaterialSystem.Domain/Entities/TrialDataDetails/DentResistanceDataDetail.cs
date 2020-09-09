using System.Collections.Generic;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 抗凹性能试验数据明细
    /// </summary>
    public class DentResistanceDataDetail : BaseTrialDataDetail
    {
        /// <summary>
        /// 初始刚度(N/mm)
        /// </summary>
        public decimal? OriginalRigidity { get; set; }

        /// <summary>
        /// 0.1mm可见凹痕载荷(N)
        /// </summary>
        public decimal? VisibleDentLoad { get; set; }

        
        #region 一次加载曲线图片

        /// <summary>
        /// 一次加载曲线图片/base64图片
        /// </summary>
        public string PrimaryLoadingCurveString { get; set; }

        /// <summary>
        /// 一次加载曲线文件服务key
        /// </summary>
        public string PrimaryLoadingCurveKey { get; set; }

        #endregion

        #region 循环加载曲线图片

        /// <summary>
        /// 晶粒度图片/base64图片
        /// </summary>
        public string CyclicLoadingCurveString { get; set; }

        /// <summary>
        /// 晶粒度文件服务key
        /// </summary>
        public string CyclicLoadingCurveKey { get; set; }

        #endregion

        #region 凹痕深度载荷曲线

        /// <summary>
        /// 凹痕深度载荷图片/base64图片
        /// </summary>
        public string DentDpthLoadCurveString { get; set; }

        /// <summary>
        /// 凹痕深度载荷文件服务key
        /// </summary>
        public string DentDpthLoadCurveKey { get; set; }

        #endregion

        
    }
}
