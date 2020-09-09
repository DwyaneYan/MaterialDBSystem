using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.PaintingDataDetails.Dtos
{
    public class PaintingDataDetailElectrophoreticItemDto
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
        /// 厚度1
        /// </summary>
        public decimal? PointThickOne { get; set; }

        /// <summary>
        /// 厚度2
        /// </summary>
        public decimal? PointThickTwo { get; set; }

        /// <summary>
        /// 厚度3
        /// </summary>
        public decimal? PointThickThree { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }


    }
}