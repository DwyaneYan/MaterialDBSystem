using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace HanGang.MaterialSystem.DemoManagement.Dtos
{
    public class DemoProjectItemDto : AuditedEntityDto<Guid?>
    {
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string OldName { get; set; }

        public int UnitProjectCount { get; set; }
    }
}