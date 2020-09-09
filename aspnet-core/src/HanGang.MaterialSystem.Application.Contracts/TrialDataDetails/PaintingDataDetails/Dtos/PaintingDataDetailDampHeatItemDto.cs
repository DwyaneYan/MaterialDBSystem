using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.PaintingDataDetails.Dtos
{
    public class PaintingDataDetailDampHeatItemDto
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
        /// 湿热1
        /// </summary>
        public decimal? PointOne { get; set; }

        /// <summary>
        /// 湿热2
        /// </summary>
        public decimal? PointTwo { get; set; }

        /// <summary>
        /// 湿热3
        /// </summary>
        public decimal? PointThree { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string FileString { get; set; }



    }
}