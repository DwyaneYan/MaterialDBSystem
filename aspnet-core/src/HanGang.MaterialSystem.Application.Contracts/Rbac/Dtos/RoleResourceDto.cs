
using HanGang.MaterialSystem.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace HanGang.MaterialSystem.Rbac.Dtos
{
    public class RoleResourceDto  
    {
        public Guid? Id { get; set; }
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