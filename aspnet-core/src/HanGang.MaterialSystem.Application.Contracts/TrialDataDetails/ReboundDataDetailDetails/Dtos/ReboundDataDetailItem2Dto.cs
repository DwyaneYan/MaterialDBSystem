using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.ReboundDataDetails.Dtos
{
    public class ReboundDataDetailItem2Dto
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
        /// 弯曲角度
        /// </summary>
        public decimal? BendingAngle { get; set; }

        /// <summary>
        /// R=t
        /// </summary>
        public string Rt1 { get; set; }

        /// <summary>
        /// R=1.5t
        /// </summary>
        public string Rt2 { get; set; }

        /// <summary>
        /// R=1.67t
        /// </summary>
        public string Rt3 { get; set; }

        /// <summary>
        /// R=2t
        /// </summary>
        public string Rt4 { get; set; }

        /// <summary>
        /// R=2.3t
        /// </summary>
        public string Rt5 { get; set; }

        /// <summary>
        /// R=2.67t
        /// </summary>
        public string Rt6 { get; set; }

        /// <summary>
        /// 最小弯曲角度
        /// </summary>
        public string RtMin { get; set; }






        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }


    }
}