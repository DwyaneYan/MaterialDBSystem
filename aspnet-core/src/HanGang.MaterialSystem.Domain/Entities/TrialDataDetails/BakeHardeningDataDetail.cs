using System.Collections.Generic;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 烘烤硬化试验数据明细
    /// </summary>
    public class BakeHardeningDataDetail : BaseTrialDataDetail
    {
        /// <summary>
        /// BH值
        /// </summary>
        public int? BH { get; set; }

        /// <summary>
        /// 烘烤硬化试验数据结果明细
        /// </summary>
        public virtual HashSet<BakeHardeningDataDetailItem> BakeHardeningDataDetailItems { get; set; } = new HashSet<BakeHardeningDataDetailItem>();

    }
}
