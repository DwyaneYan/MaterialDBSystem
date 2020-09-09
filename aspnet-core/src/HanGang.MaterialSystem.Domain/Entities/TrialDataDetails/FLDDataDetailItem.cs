using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// FLD试验数据应力应变明细
    /// </summary>
    public class FLDDataDetailItem : FullAuditedAggregateRoot<Guid>
    {
        #region 关联FLD试验数据明细

        /// <summary>
        /// FLD试验数据明细
        /// </summary>
        public Guid? FLDDataDetailId { get; set; }

        /// <summary>
        /// FLD试验数据明细
        /// </summary>
        public virtual FLDDataDetail FLDDataDetail { get; set; }

        #endregion
        /// <summary>
        /// 试样宽度
        /// </summary>
        public decimal? SpecimenWidth { get; set; }
        /// <summary>
        /// 主应变
        /// </summary>
        public decimal? MainStrain { get; set; }

        /// <summary>
        /// 次应变
        /// </summary>
        public decimal? SecondaryStrain { get; set; }
       
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
