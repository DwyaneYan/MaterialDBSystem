using System;
using System.Collections.Generic;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 氢致延迟断裂试验数据明细
    /// </summary>
    public class HydrogenInducedDelayedFractureDataDetail : BaseTrialDataDetail
    {
        /// <summary>
        /// 试验名称
        /// </summary>
        public string TestName { get; set; }

        /// <summary>
        /// 试验设备
        /// </summary>
        public string Device { get; set; }

        /// <summary>
        /// 溶液类别
        /// </summary>
        public string LiquorType { get; set; }


        /// <summary>
        /// 试验时间
        /// </summary>
        public decimal? TestTime { get; set; }

        /// <summary>
        /// 氢致延迟断裂应变试验数据明细
        /// </summary>
        public virtual HashSet<HydrogenInducedDelayedFractureDataDetailItem> HydrogenInducedDelayedFractureDataDetailItems
        { get; set; } = new HashSet<HydrogenInducedDelayedFractureDataDetailItem>();
    }
}
