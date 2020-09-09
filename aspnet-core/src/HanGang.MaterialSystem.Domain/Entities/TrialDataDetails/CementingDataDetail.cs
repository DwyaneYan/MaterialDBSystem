using System;
using System.Collections.Generic;
using System.Text;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 胶结试验数据明细
    /// </summary>
    public class CementingDataDetail : BaseTrialDataDetail
    {
        /// <summary>
        /// 胶接宽度
        /// </summary>
        public decimal? CementingWidth { get; set; }

        /// <summary>
        /// 剪切强度Rp(MPa)
        /// </summary>
        public decimal? MPA { get; set; }

        /// <summary>
        /// 失效模式
        /// </summary>
        public string FailureMode { get; set; }
    }
}
