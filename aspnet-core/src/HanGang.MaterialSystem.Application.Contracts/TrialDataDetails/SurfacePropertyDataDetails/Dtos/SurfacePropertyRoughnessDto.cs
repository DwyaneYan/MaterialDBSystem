using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.SurfacePropertyDataDetails.Dtos
{
    public class SurfacePropertyRoughnessDto
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
        /// Ra（μm）
        /// </summary>
        public decimal? RaOne { get; set; }

        /// <summary>
        /// Ra（μm）
        /// </summary>
        public decimal? RaTwo { get; set; }

        /// <summary>
        /// 粗造度 RPC（个/cm）
        /// </summary>
        public decimal? RPCOne { get; set; }

        /// <summary>
        /// 粗造度 RPC（个/cm）
        /// </summary>
        public decimal? RPCTwo { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }

    }
}