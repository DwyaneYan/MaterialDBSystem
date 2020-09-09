using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.SecondaryWorkingEmbrittlementDataDetails.Dtos
{
    public class SecondaryWorkingEmbrittlementDataDetailItemDto
    {
      
        /// <summary>
        /// Id
        /// </summary>
        public System.Guid Id { get; set; }
       
        /// <summary>
        /// 二次加工脆化试验数据明细
        /// </summary>
        public Guid? SecondaryWorkingEmbrittlementDataDetailId { get; set; }

        /// <summary>
        /// 温度（℃）
        /// </summary>
        public decimal? Temperature { get; set; }

        /// <summary>
        /// SWET（℃）
        /// </summary>
        public string? Swet { get; set; }


        /// <summary>
        /// 杯子编号
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// 扩张属性
        /// </summary>
        public string ExpansionType { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }


    }
}