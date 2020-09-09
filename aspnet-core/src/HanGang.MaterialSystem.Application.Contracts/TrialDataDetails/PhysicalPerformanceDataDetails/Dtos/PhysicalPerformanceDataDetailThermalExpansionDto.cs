using System;

namespace HanGang.MaterialSystem.PhysicalPerformanceDataDetails.Dtos
{
    public class PhysicalPerformanceDataDetailThermalExpansionDto
    {
        /// <summary>
        /// 材料试验数据id
        /// </summary>
        public Guid Id { get; set; }


        /// <summary>
        /// 物理性能数据明细
        /// </summary>
        public Guid? PhysicalPerformanceDataDetailId { get; set; }

       

        

        /// <summary>
        /// 温度范围（℃）
        /// </summary>
        public string TemperatureRange { get; set; }

        /// <summary>
        /// 热膨胀系数α（1/℃）
        /// </summary>
        public decimal? ThermalExpansion { get; set; }



        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }
    }
}