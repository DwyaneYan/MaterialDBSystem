using System;

namespace HanGang.MaterialSystem.PhysicalPerformanceDataDetails.Dtos
{
    public class PhysicalPerformanceDataDetailThermalConductivityDto
    {
       
        public Guid Id { get; set; }

    

        /// <summary>
        /// 物理性能数据明细
        /// </summary>
        public Guid? PhysicalPerformanceDataDetailId { get; set; }

        

        /// <summary>
        /// 温度（℃）
        /// </summary>
        public decimal? Temperature { get; set; }

        /// <summary>
        /// 导热系数λ（W/(cm゜C)）
        /// </summary>
        public decimal? ThermalConductivity { get; set; }


        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }
    }
}