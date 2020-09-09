using System;
using System.Collections.Generic;
using HanGang.MaterialSystem.Enum;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.Rbac
{
    public class RoleResource : FullAuditedAggregateRoot<Guid>
    {

        /// <summary>
        /// RoleId
        /// </summary>
        public Guid? RoleId { get; set; }
        /// <summary>
        ///  TrialCategoryId
        /// </summary>
        public Guid? TrialCategoryId { get; set; }
        /// <summary>
        ///  ResourceTypeId
        /// </summary>
        public Guid? ResourceTypeId { get; set; }
        /// <summary>
        ///  ResourceGroupId 
        /// </summary>
        public Guid? ResourceGroupId { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }





      

     
    }
}
