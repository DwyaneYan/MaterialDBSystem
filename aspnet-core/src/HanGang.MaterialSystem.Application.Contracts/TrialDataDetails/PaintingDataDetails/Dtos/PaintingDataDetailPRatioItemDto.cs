using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.PaintingDataDetails.Dtos
{
    public class PaintingDataDetailPRatioItemDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public System.Guid Id { get; set; }
       
        /// <summary>
        /// 涂装性能试验数据明细
        /// </summary>
        public Guid? PaintingDataDetailId { get; set; }

     

        /// <summary>
        /// Ip（s-1）
        /// </summary>
        public decimal? Ip { get; set; }

        /// <summary>
        /// IH（s-1）
        /// </summary>
        public decimal? IH { get; set; }

        /// <summary>
        /// P比
        /// </summary>
        public decimal? Ratio { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }



    }
}