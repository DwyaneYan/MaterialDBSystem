using System;
namespace HanGang.MaterialSystem.ApplicationCases.Dtos
{
    public class ApplicationCaseDto
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 材料
        /// </summary>
        public Guid? MaterialId { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        public string VehicleType { get; set; }
        /// <summary>
        ///  简况
        /// </summary>
        public string Breif { get; set; }
        /// <summary>
        ///供货零件名称
        /// </summary>
        public string SuppliedPart { get; set; }
        /// <summary>
        ///  要求
        /// </summary>
        public string Requirement { get; set; }
        /// <summary>
        /// 材料样本图片
        /// </summary>
        public string FileString { get; set; }

        /// <summary>
        /// 文档pdf
        /// </summary>
        public string FileKey { get; set; }



    }
}