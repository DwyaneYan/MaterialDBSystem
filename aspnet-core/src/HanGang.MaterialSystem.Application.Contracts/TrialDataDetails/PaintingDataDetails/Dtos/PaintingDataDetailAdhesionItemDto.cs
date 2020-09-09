using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.PaintingDataDetails.Dtos
{
    public class PaintingDataDetailAdhesionItemDto
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
        /// 附着力1
        /// </summary>
        public decimal? PointAdhesionOne { get; set; }

        /// <summary>
        /// 附着力2
        /// </summary>
        public decimal? PointAdhesionTwo { get; set; }

        /// <summary>
        /// 附着力3
        /// </summary>
        public decimal? PointAdhesionThree { get; set; }

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