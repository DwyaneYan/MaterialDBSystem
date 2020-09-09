using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 高速拉伸试验数据明细
    /// </summary>
    public class HighSpeedStrechDataDetailStressStrain : FullAuditedAggregateRoot<Guid>
    {
        #region 关联高速拉伸试验数据

        /// <summary>
        /// 材料高速拉伸试验
        /// </summary>
        public Guid? HighSpeedStrechDataDetailId { get; set; }

        /// <summary>
        /// 材料高速拉伸试验
        /// </summary>
        public virtual HighSpeedStrechDataDetail HighSpeedStrechDataDetail { get; set; }

        #endregion
        
        /// <summary>
        /// 工程应力
        /// </summary>
        public decimal? EngineeringStress { get; set; }

        /// <summary>
        /// 工程应变
        /// </summary>
        public decimal? EngineeringStrain { get; set; }

        /// <summary>
        /// 真应力
        /// </summary>
        public decimal? RealStress { get; set; }

        /// <summary>
        /// 真应变
        /// </summary>
        public decimal? RealStrain { get; set; }

        /// <summary>
        /// 真塑性应力
        /// </summary>
        public decimal? RealPlasticStress { get; set; }

        /// <summary>
        /// 真塑性应变
        /// </summary>
        public decimal? RealPlasticStrain { get; set; }

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
