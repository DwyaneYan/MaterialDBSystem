using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.ReboundDataDetails.Dtos
{
    public class ReboundDataDetailItemDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public System.Guid Id { get; set; }
        
        /// <summary>
        /// 烘烤硬化试验数据明细
        /// </summary>
        public Guid? ReboundDataDetailId { get; set; }

       

        /// <summary>
        /// 凸模圆角半径R(mm)
        /// </summary>
        public string PunchFilletRadius { get; set; }

        /// <summary>
        /// 弯曲角度
        /// </summary>
        public decimal? BendingAngle { get; set; }

        /// <summary>
        /// 回弹角度
        /// </summary>
        public decimal? ReboundAngle { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 方向（沿轧向或者垂直轧向）
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// 厚度 t/mm
        /// </summary>
        public decimal? Thickness { get; set; }
        /// <summary>
        /// 测量角度
        /// </summary>
        public decimal? MeasuringAngle { get; set; }


    }
}