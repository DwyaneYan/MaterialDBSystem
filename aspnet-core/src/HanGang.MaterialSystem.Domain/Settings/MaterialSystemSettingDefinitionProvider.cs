using Volo.Abp.Settings;

namespace HanGang.MaterialSystem.Settings
{
    public class MaterialSystemSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(MaterialSystemSettings.MySetting1));
        }
    }
}
