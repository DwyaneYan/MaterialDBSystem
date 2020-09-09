using System.Collections.Generic;

namespace HanGang.MaterialSystem.DemoManagement.Dtos
{
    public class DemoProjectDto : DemoProjectItemDto
    {
        public List<DemoUnitProjectItemDto> DemoUnitProjects { get; set; }
    }
}