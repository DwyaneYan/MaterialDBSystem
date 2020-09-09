using System;
using System.Collections.Generic;
using HanGang.MaterialSystem.Enum;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.Rbac
{
    public class UserRole : FullAuditedAggregateRoot<Guid>
    {

        /// <summary>
        /// RoleId
        /// </summary>
        public Guid? RoleId { get; set; }
        /// <summary>
        /// RoleId
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }





      

     
    }
}
