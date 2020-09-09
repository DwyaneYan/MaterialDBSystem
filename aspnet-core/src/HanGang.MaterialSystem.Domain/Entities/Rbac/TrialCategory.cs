using System;
using System.Collections.Generic;
using HanGang.MaterialSystem.Enum;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.Rbac
{
    public class TrialCategory : FullAuditedAggregateRoot<Guid>
    {
       
        /// <summary>
        /// 名称
        /// </summary>
        public string Name{ get; set; }
        /// <summary>
        /// 试验
        /// </summary>
        public bool? Trial { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }





      

     
    }
}
