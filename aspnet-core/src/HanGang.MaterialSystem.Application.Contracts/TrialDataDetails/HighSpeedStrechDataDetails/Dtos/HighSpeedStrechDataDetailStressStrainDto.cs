using System;

namespace HanGang.MaterialSystem.HighSpeedStrechDataDetails.Dtos
{
    public class HighSpeedStrechDataDetailStressStrainDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public System.Guid Id { get; set; }

        /// <summary>
        /// 材料高速拉伸试验
        /// </summary>
        public Guid? HighSpeedStrechDataDetailId { get; set; }

     

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
    }
}