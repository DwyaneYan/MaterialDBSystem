using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using Microsoft.AspNetCore.Http;
using System;

namespace HanGang.MaterialSystem.TrialDataDetails
{
    public class TrialDataDetailImportDto

    {
        public Guid Id { get; set; }

        public IFormFile Excel { get; set; }

    

    }
}