using System;
using HanGang.MaterialSystem.Dtos;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;

namespace HanGang.MaterialSystem.DemoManagement.Dtos
{
    public class GetMyProjectsInputDto : PagedInputDto, ITransientDependency
    {
        public string Name { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}