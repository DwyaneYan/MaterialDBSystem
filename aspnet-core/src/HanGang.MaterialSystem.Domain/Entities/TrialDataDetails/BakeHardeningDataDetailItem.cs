using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 烘烤硬化试验数据结果明细
    /// </summary>
    public class BakeHardeningDataDetailItem : FullAuditedAggregateRoot<Guid>
    {
        #region 关联材料烘烤硬化试验数据

        /// <summary>
        /// 烘烤硬化试验数据明细
        /// </summary>
        public Guid? BakeHardeningDataDetailId { get; set; }

        /// <summary>
        /// 烘烤硬化试验数据明细
        /// </summary>
        public virtual BakeHardeningDataDetail BakeHardeningDataDetail { get; set; }

        #endregion

        /// <summary>
        /// 烘烤温度及时间
        /// </summary>
        public string TemperatureTimes { get; set; }

        /// <summary>
        /// Rt2.0(MPa)
        /// </summary>
        public decimal? Rt { get; set; }

        /// <summary>
        /// Rp0.2(MPa)
        /// </summary>
        public decimal? Rp { get; set; }

        /// <summary>
        /// Rm(MPa)
        /// </summary>
        public decimal? Rm { get; set; }

        /// <summary>
        /// BH2(MPa)
        /// </summary>
        public decimal? BH2 { get; set; }

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
