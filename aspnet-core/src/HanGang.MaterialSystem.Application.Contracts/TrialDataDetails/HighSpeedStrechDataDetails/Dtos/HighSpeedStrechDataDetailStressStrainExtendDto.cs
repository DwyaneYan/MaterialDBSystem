using System;

namespace HanGang.MaterialSystem.HighSpeedStrechDataDetails.Dtos
{
    public class HighSpeedStrechDataDetailStressStrainExtendDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public System.Guid Id { get; set; }

        /// <summary>
        /// 材料试验
        /// </summary>
        public Guid? MaterialTrialDataId { get; set; }
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
        /// 真塑性应力
        /// </summary>
        public decimal? RealPlasticStressExtend { get; set; }

        /// <summary>
        /// 真塑性应变
        /// </summary>
        public decimal? RealPlasticStrainExtend { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }
    }
}