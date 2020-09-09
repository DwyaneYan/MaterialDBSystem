using System;

namespace HanGang.MaterialSystem.TypicalParts.Dtos
{
    public class TypicalPartDto
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 车型id
        /// </summary>
        public string ProjectId { get; set; }

        public string CarName { get; set; }

        /// <summary>
        /// 零件id
        /// </summary>
        public string directoryId { get; set; }

        /// <summary>
        /// 材料id
        /// </summary>
        public Guid MaterialId { get; set; }
    }
}