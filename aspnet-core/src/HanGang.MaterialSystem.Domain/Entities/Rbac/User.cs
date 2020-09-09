using System;
using System.Collections.Generic;
using HanGang.MaterialSystem.Enum;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.Rbac
{
    public class User: FullAuditedAggregateRoot<Guid>
    {
       
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string PassWord { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }





      

     
    }
}
