
using HanGang.MaterialSystem.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace HanGang.MaterialSystem.Rbac.Dtos
{
    public class UserRoleDto  
    {
        public Guid? Id { get; set; }
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