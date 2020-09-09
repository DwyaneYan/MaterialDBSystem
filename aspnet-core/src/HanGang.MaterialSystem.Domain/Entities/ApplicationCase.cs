using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities
{
    /// <summary>
    /// 材料试验 (导入材料试验数据基于此表)
    /// </summary>
    public class ApplicationCase: FullAuditedAggregateRoot<Guid>
    {
   

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 材料
        /// </summary>
        public Guid? MaterialId { get; set; }

        /// <summary>
        /// 材料
        /// </summary>
        public virtual Material Material { get; set; }


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
