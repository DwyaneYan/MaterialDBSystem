using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.PaintingDataDetails.Dtos
{
    public class PaintingDataDetailPhosphatingItemDto
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
        /// 磷化膜结晶尺寸
        /// </summary>
        public string SizeText { get; set; }

        /// <summary>
        /// 磷化膜覆盖率
        /// </summary>
        public decimal? CoverRatio { get; set; }

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