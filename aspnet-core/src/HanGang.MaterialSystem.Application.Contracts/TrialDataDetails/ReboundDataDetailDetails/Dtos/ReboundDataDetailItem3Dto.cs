using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.ReboundDataDetails.Dtos
{
    public class ReboundDataDetailItem3Dto
    {

       
        /// <summary>
        /// 回弹试验数据明细
        /// </summary>
        public Guid? ReboundDataDetailId { get; set; }

       

        /// <summary>
        /// 方向（沿轧向或者垂直轧向）
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// 厚度 t/mm
        /// </summary>
        public decimal? Thickness { get; set; }

        /// <summary>
        /// R/t=0.5
        /// </summary>
        public string Rt1 { get; set; }

        /// <summary>
        /// R/t=1
        /// </summary>
        public string Rt2 { get; set; }

        /// <summary>
        /// R/t=1.5
        /// </summary>
        public string Rt3 { get; set; }

        /// <summary>
        /// R/t=2
        /// </summary>
        public string Rt4 { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }



    }
}