using System;
using System.Collections.Generic;
using HanGang.MaterialSystem.Enum;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.Rbac
{
    public class TrialDetailGroup : FullAuditedAggregateRoot<Guid>
    {
       
        /// <summary>
        /// 试验id
        /// </summary>
        public Guid? TrialId{ get; set; }
   
        /// <summary>
        ///组排序
        /// </summary>
        public int? GroupOrder { get; set; }
         /// <summary>
         /// 基础信息
         /// </summary>
        public bool? BaseInfo { get; set; }
        /// <summary>
        /// 试验参数
        /// </summary>
        public bool? TrialParam { get; set; }
        /// <summary>
        /// 试验结果1
        /// </summary>
        public bool? TrialResultOne { get; set; }
        /// <summary>
        /// 试验结果2
        /// </summary>
        public bool? TrialResultTwo { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }





      

     
    }
}
