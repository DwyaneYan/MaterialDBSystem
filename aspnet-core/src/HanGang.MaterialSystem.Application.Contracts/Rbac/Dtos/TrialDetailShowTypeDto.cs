
using HanGang.MaterialSystem.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace HanGang.MaterialSystem.Rbac.Dtos
{
    public class TrialDetailShowTypeDto 
    {
        public Guid? Id { get; set; }
        /// <summary>
        /// 试验id
        /// </summary>
        public Guid? TrialId { get; set; }
        /// <summary>
        /// 试验名称
        /// </summary>
        public string TrialName { get; set; }
        /// <summary>
        ///类型排序
        /// </summary>
        public int? TypeOrder { get; set; }
        /// <summary>
        /// 表格
        /// </summary>
        public bool? Table { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public bool? Picture { get; set; }
        /// <summary>
        /// 报告
        /// </summary>
        public bool? Report { get; set; }
        /// <summary>
        /// 典型零部件
        /// </summary>
        public bool? TypicalPart { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }



    }
}