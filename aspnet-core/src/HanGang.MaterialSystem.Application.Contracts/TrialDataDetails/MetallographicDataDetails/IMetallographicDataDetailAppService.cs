using HanGang.MaterialSystem.MetallographicDataDetails.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HanGang.MaterialSystem.TrialDataDetails.MetallographicDataDetails
{
    /// <summary>
    /// 金相试验服务接口
    /// </summary>
    public interface IMetallographicDataDetailAppService
    {
        /// <summary>
        /// 添加金相数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<Guid> AddMetallographicData(MetallographicDataDetailDto input);
    }
}
