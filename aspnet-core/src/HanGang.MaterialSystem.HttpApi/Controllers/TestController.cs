using HanGang.MaterialSystem.Models.Test;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HanGang.MaterialSystem.Controllers
{
    [Route("api/test")]
    public class TestController : MaterialSystemController
    {
        [HttpGet]
        [Route("")]
        public async Task<List<TestModel>> GetAsync()
        {
            return await Task.Run(()=> new List<TestModel>
            {
                new TestModel {Name = "John", BirthDate = new DateTime(1942, 11, 18)},
                new TestModel {Name = "Adams", BirthDate = new DateTime(1997, 05, 24)}
            });
        }




    }
}
