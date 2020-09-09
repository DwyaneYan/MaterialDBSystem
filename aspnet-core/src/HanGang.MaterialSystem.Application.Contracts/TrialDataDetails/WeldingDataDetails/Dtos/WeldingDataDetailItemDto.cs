using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.WeldingDataDetails.Dtos
{
    public class WeldingDataDetailItemDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public System.Guid Id { get; set; }
       

        /// <summary>
        /// 材料焊接试验数据明细
        /// </summary>
        public Guid? WeldingDataDetailId { get; set; }



        /// <summary>
        /// 焊接电流区间
        /// </summary>
        public decimal? WeldingCurrentInterval { get; set; }
        /// <summary>
        /// 左边界电流（kA）
        /// </summary>
        public decimal? LeftBoundaryElectric { get; set; }

        /// <summary>
        /// 右边界电流（kA）
        /// </summary>
        public decimal? RightBoundaryElectric { get; set; }

        /// <summary>
        /// 焊接时间
        /// </summary>
        public int? WeldingTimes { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }


    }
}