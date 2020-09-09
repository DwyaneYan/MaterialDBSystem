using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;

namespace HanGang.MaterialSystem.DemoManagement.Dtos
{
    public class DemoUnitProjectItemDto : EntityDto<Guid?>, IHasCreationTime
    {
        /// <summary>
        /// 子项目名称
        /// </summary>
        [MaxLength(128)]
        public string Name { get; set; }

        [MaxLength(512)]
        public string Address { get; set; }

        public DateTime CreationTime { get; set; }
    }
}