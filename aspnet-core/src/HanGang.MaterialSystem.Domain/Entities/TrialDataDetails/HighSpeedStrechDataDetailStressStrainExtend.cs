using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 高速拉伸试验数据StressStrainExtend明细
    /// </summary>
    public class HighSpeedStrechDataDetailStressStrainExtend : FullAuditedAggregateRoot<Guid>
    {
        #region 关联材料试验数据

        /// <summary>
        /// 材料试验
        /// </summary>
        public Guid? MaterialTrialDataId { get; set; }


        /// <summary>
        /// 材料试验
        /// </summary>
        public virtual MaterialTrialData MaterialTrialData { get; set; }

        #endregion
        /// <summary>
        /// 真塑性拉伸速率
        /// </summary>
        public string RealPlasticTestTarget { get; set; }
        /// <summary>
        /// 真塑性应力
        /// </summary>
        public decimal? RealPlasticStressHalf { get; set; }

        /// <summary>
        /// 真塑性应变
        /// </summary>
        public decimal? RealPlasticStrainHalf { get; set; }

        /// <summary>
        /// 真塑性应力Extend
        /// </summary>
        public decimal? RealPlasticStressExtend { get; set; }

        /// <summary>
        /// 真塑性应变Extend
        /// </summary>
        public decimal? RealPlasticStrainExtend { get; set; }

        /// <summary>
        /// 插入顺序
        /// </summary>
        public int InsertOrder { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }
    }
}
