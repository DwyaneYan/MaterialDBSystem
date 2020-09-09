using System.Collections.Generic;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// FLD试验数据明细
    /// </summary>
    public class FLDDataDetail : BaseTrialDataDetail
    {
        /// <summary>
        /// 应变点
        /// </summary>
        public decimal? LimitStrain { get; set; }

        /// <summary>
        /// FLD试验数据应力应变明细
        /// </summary>
        public virtual HashSet<FLDDataDetailItem> FLDDataDetailItems { get; set; }=new HashSet<FLDDataDetailItem>();
    }
}
