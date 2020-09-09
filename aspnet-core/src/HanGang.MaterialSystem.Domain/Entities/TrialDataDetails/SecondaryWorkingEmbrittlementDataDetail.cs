using System.Collections.Generic;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 二次加工脆化试验数据明细
    /// </summary>
    public class SecondaryWorkingEmbrittlementDataDetail : BaseTrialDataDetail
    {
        

        /// <summary>
        /// 二次加工脆化试验杯具数据明细
        /// </summary>
        public virtual HashSet<SecondaryWorkingEmbrittlementDataDetailItem> SecondaryWorkingEmbrittlementDataDetailItems { get; set; }=new HashSet<SecondaryWorkingEmbrittlementDataDetailItem>();
    }
}
