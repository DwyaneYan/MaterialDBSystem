using System;
using System.Collections.Generic;
using HanGang.MaterialSystem.Enum;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.Rbac
{
    public class Role : FullAuditedAggregateRoot<Guid>
    {
       
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName{ get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }





      

     
    }
}
