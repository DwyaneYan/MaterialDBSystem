using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.Trials.Dtos
{
    public class TrialDto
    {

        /// <summary>
        /// 试验Id
        /// </summary>
        public System.Guid Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 试验类型
        /// </summary>
        public TrialType TrialType { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 父级试验项目Id
        /// </summary>
        public Guid? ParentId { get; set; }

        public string ParentName { get; set; }


    }
}