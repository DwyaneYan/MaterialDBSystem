using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.PaintingDataDetails.Dtos
{
    public class PaintingDataDetailMembraneWeightItemDto
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
        /// 面积（m2）
        /// </summary>
        public decimal? Area { get; set; }

        /// <summary>
        /// 初始重量（g）
        /// </summary>
        public decimal? OriginalWeight { get; set; }

        /// <summary>
        /// 试验后重量（g）
        /// </summary>
        public decimal? AfterWeight { get; set; }

        /// <summary>
        /// 膜重（g/mm2）
        /// </summary>
        public decimal? MembraneWeight { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }



    }
}