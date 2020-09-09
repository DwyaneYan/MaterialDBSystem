
using HanGang.MaterialSystem.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace HanGang.MaterialSystem.Rbac.Dtos
{
    public class TrialCategoryDto  
    {
        public Guid? Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
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