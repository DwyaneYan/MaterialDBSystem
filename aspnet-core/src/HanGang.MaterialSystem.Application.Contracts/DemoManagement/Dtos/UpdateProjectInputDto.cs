using System;
using System.ComponentModel.DataAnnotations;

namespace HanGang.MaterialSystem.DemoManagement.Dtos
{
    public class UpdateProjectInputDto
    {
        public Guid ProjectId { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        /// <summary>
        /// 是否同步子单位工程的项目名称
        /// </summary>
        public bool SyncUnitProject { get; set; }
    }
}