using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.HydrogenInducedDelayedFractureDataDetails.Dtos
{
    public class HydrogenInducedDelayedFractureDataDetailItemDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public System.Guid Id { get; set; }
       
        /// <summary>
        /// 氢致延迟断裂试验数据明细
        /// </summary>
        public Guid? HydrogenInducedDelayedFractureDataDetailId { get; set; }

        /// <summary>
        /// 弯曲跨度
        /// </summary>
        public decimal? Span { get; set; }

        /// <summary>
        /// 弯曲应变
        /// </summary>
        public decimal? Strain { get; set; }

        /// <summary>
        /// 应力（MPa）
        /// </summary>
        public decimal? Stress { get; set; }

        /// <summary>
        /// 开裂时间
        /// </summary>
        public decimal? Hour { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }



    }
}