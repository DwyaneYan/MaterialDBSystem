using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities
{
    /// <summary>
    /// 典型零部件
    /// </summary>
    public class TypicalPart: FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 车型名称
        /// </summary>
        public string CarName { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// VIM中的车型ID
        /// </summary>
        public string ProjectId { get; set; }

        public Guid MaterialId { get; set; }

        /// <summary>
        /// VIM中零件的Id
        /// </summary>
        public string directoryId { get; set; }

        /// <summary>
        /// 应用车型
        /// </summary>
        public string AppliedVehicleType { get; set; }
        

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 材料
        /// </summary>
        public virtual HashSet<Material> Materials { get; set; } = new HashSet<Material>();
    }
}
