using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.PaintingDataDetails.Dtos
{
    public class PaintingDataDetailHardnessItemDto
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
        /// 厚度
        /// </summary>
        public string PointHardness { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }




    }
}