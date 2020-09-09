using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 二次加工脆化杯具试验数据明细
    /// </summary>
    public class SecondaryWorkingEmbrittlementDataDetailItem : FullAuditedAggregateRoot<Guid>
    {
        #region 关联材料二次加工脆化试验数据

        /// <summary>
        /// 二次加工脆化试验数据明细
        /// </summary>
        public Guid? SecondaryWorkingEmbrittlementDataDetailId { get; set; }

        /// <summary>
        /// 二次加工脆化试验数据明细
        /// </summary>
        public virtual SecondaryWorkingEmbrittlementDataDetail SecondaryWorkingEmbrittlementDataDetail { get; set; }

        #endregion
        /// <summary>
        /// 温度（℃）
        /// </summary>
        public decimal? Temperature { get; set; }

        /// <summary>
        /// SWET（℃）
        /// </summary>
        public string Swet { get; set; }
        /// <summary>
        /// 杯子编号
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// 扩张属性
        /// </summary>
        public string ExpansionType { get; set; }
        
        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 插入顺序
        /// </summary>
        public int InsertOrder { get; set; }
    }
}
