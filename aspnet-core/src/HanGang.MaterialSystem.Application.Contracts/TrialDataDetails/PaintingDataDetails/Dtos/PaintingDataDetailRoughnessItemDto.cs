using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.PaintingDataDetails.Dtos
{
    public class PaintingDataDetailRoughnessItemDto
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
        /// Ra（μm）1
        /// </summary>
        public decimal? RaOne { get; set; }

        /// <summary>
        /// Ra（μm）2
        /// </summary>
        public decimal? RaTwo { get; set; }

        /// <summary>
        /// Ra（μm）3
        /// </summary>
        public decimal? RaThree { get; set; }

      
        /// <summary>
        /// Rz（μm）1
        /// </summary>
        public decimal? RzOne { get; set; }

        /// <summary>
        /// Rz（μm）2
        /// </summary>
        public decimal? RzTwo { get; set; }

        /// <summary>
        /// Rz（μm）3
        /// </summary>
        public decimal? RzThree { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }



    }
}