using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HanGang.MaterialSystem.DemoManagement.Dtos
{
    public class AddProjectInputDto : IValidatableObject
    {
        public const int MaximumProjectCount = 10;

        /// <summary>
        /// 项目名称
        /// </summary>
        [Required(ErrorMessage = "项目名称必填")]
        [Display(Name = "项目名称")]
        public string ProjectName { get; set; }

        /// <summary>
        /// 子项目集合
        /// </summary>
        public List<DemoUnitProjectItemDto> ProjectItems { get; set; } = new List<DemoUnitProjectItemDto>();

        #region Implementation of IValidatableObject

        /// <summary>
        /// 自定义基础数据验证。演示对较为麻烦的基础数据的后端验证
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!ProjectItems.Any())
            {
                yield break;
            }

            if (ProjectItems.Count > MaximumProjectCount)
            {
                yield return new ValidationResult($"最多允许创建{MaximumProjectCount}个子项目");
            }
        }

        #endregion
    }
}