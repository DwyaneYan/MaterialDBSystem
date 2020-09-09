using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.FLDDataDetailDetails.Dtos
{
    public class FLDDataDetailItemDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public System.Guid Id { get; set; }
       
        /// <summary>
        /// FLD试验数据明细
        /// </summary>
        public Guid? FLDDataDetailId { get; set; }

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

       


    }
}