using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.SurfacePropertyDataDetails.Dtos
{
    public class SurfacePropertySizeToleranceDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public System.Guid Id { get; set; }
       
        /// <summary>
        /// 材料表面性能试验
        /// </summary>
        public Guid? SurfacePropertyDataDetailId { get; set; }

        /// <summary>
        /// Size要求值
        /// </summary>
        public string SizeRequirement { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string TestCode { get; set; }
        /// <summary>
        /// 距边部40mm厚度
        /// </summary>
        public decimal? EdgeThickness1 { get; set; }
        /// <summary>
        /// 距左边部1/4厚度
        /// </summary>
        public decimal? EdgeThickness2 { get; set; }

        /// <summary>
        /// 板宽1/2厚度
        /// </summary>
        public decimal? EdgeThickness3 { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }

    }
}