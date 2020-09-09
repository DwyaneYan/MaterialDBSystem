using System;
using Volo.Abp.Users;

namespace HanGang.MaterialSystem
{
    public abstract class MaterialSystemApplicationTestBase : MaterialSystemTestBase<MaterialSystemApplicationTestModule> 
    {
        protected readonly ICurrentUser CurrentUser;

        protected MaterialSystemApplicationTestBase()
        {
            CurrentUser = GetRequiredService<ICurrentUser>();
        }

        /// <summary>
        /// 替换当前登陆用户的Id
        /// </summary>
        /// <param name="userId"></param>
        protected void ReplaceCurrentUser(Guid userId)
        {
            var user = (TestCurrentUser)CurrentUser;
            user.SetId(userId);
        }
    }
}
