
using HanGang.MaterialSystem.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace HanGang.MaterialSystem.Rbac.Dtos
{
    public class UserDto  
    {
        public Guid? Id { get; set; }

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