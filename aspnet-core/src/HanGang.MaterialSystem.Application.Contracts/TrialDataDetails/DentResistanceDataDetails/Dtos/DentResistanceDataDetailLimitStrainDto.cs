using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.DentResistanceDataDetails.Dtos
{
    public class DentResistanceDataDetailLimitStrainDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public System.Guid Id { get; set; }
        
        /// <summary>
        /// 抗凹性能试验数据明细
        /// </summary>
        public Guid? DentResistanceDataDetailId { get; set; }

        
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

    }
}