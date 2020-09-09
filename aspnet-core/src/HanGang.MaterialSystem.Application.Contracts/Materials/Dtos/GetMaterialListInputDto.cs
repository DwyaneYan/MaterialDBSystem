using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.Materials.Dtos
{
    public class GetMaterialListInputDto : PagedInputDto
    {
        public Guid? Id { get; set; }
        /// <summary>
        /// 材料标准
        /// </summary>
        public string MaterialStandard { get; set; }
        /// <summary>
        /// 材料名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 卷号
        /// </summary>
        public decimal? ReelNumber { get; set; }
        /// <summary>
        /// 型号规格 
        /// </summary>
        public decimal? Model { get; set; }
        /// <summary>
        /// 型号规格 
        /// </summary>
        public decimal? MinModel { get; set; }
        /// <summary>
        /// 型号规格 
        /// </summary>
        public decimal? MaxModel { get; set; }



        /// <summary>
        /// 强度
        /// </summary>
        public decimal? Strength { get; set; }

        /// <summary>
        /// 材料类型
        /// </summary>
        public MaterialType? MaterialType { get; set; }

        /// <summary>
        /// 送检日期
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// 应用车型
        /// </summary>
        public string AppliedVehicleType { get; set; }

        /// <summary>
        /// 典型零部件
        /// </summary>
        public Guid? TypicalPartId { get; set; }

        /// <summary>
        /// 生产厂家
        /// </summary>
        public Guid? ManufactoryId { get; set; }

       

        /// <summary>
        /// 材料强度范围
        /// </summary>
        public decimal? MinStrenth { get; set; }
        public decimal? MaxStrenth { get; set; }
    }
}