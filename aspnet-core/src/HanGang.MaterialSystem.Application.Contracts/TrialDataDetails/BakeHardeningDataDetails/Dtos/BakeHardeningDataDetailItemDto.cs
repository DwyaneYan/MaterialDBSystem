using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.BakeHardeningDataDetails.Dtos
{
    public class BakeHardeningDataDetailItemDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public System.Guid Id { get; set; }
        /// <summary>
        /// 烘烤硬化试验数据明细
        /// </summary>
        public Guid? BakeHardeningDataDetailId { get; set; }

        /// <summary>
        /// 烘烤温度及时间
        /// </summary>
        public string TemperatureTimes { get; set; }

        /// <summary>
        /// Rt2.0(MPa)
        /// </summary>
        public decimal? Rt { get; set; }

        /// <summary>
        /// Rp0.2(MPa)
        /// </summary>
        public decimal? Rp { get; set; }

        /// <summary>
        /// Rm(MPa)
        /// </summary>
        public decimal? Rm { get; set; }

        /// <summary>
        /// BH2(MPa)
        /// </summary>
        public decimal? BH2 { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }



    }
}