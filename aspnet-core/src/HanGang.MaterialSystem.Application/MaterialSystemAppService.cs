using HanGang.MaterialSystem.Localization;
using Volo.Abp.Application.Services;
using Volo.Abp.AutoMapper;

namespace HanGang.MaterialSystem
{
    public abstract class MaterialSystemAppService : ApplicationService
    {
        private IMapperAccessor _mapperAccessor;

        public AutoMapper.IConfigurationProvider Configuration => MapperAccessor.Mapper.ConfigurationProvider;

        public IMapperAccessor MapperAccessor => LazyGetRequiredService(ref _mapperAccessor);
        protected MaterialSystemAppService()
        {
            LocalizationResource = typeof(MaterialSystemResource);
        }
    }
}
