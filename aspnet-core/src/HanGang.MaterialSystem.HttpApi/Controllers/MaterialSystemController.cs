using HanGang.MaterialSystem.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace HanGang.MaterialSystem.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class MaterialSystemController : AbpController
    {
        protected MaterialSystemController()
        {
            LocalizationResource = typeof(MaterialSystemResource);
        }
    }
}