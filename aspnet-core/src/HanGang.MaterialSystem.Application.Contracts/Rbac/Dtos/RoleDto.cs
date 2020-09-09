
using HanGang.MaterialSystem.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace HanGang.MaterialSystem.Rbac.Dtos
{
    public class RoleDto 
    {
        public Guid? Id { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }


    }
}