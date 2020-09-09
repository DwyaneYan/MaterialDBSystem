using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;
using Volo.Abp.Users;

namespace HanGang.MaterialSystem
{
    //todo 方便在单元测试中替换当前登陆用户的UserId
    [Dependency(ReplaceServices = true)]
    public class TestCurrentUser : ICurrentUser, ISingletonDependency
    {
        private static readonly Claim[] EmptyClaimsArray = new Claim[0];
        private readonly ICurrentPrincipalAccessor _principalAccessor;

        public virtual bool IsAuthenticated
        {
            get
            {
                return this.Id.HasValue;
            }
        }

        private Guid _id;

        public virtual Guid? Id
        {
            get { return _id; }
        }

        public virtual string UserName
        {
            get
            {
                return this.FindClaimValue(AbpClaimTypes.UserName);
            }
        }

        public virtual string PhoneNumber
        {
            get
            {
                return this.FindClaimValue(AbpClaimTypes.PhoneNumber);
            }
        }

        public virtual bool PhoneNumberVerified
        {
            get
            {
                return string.Equals(this.FindClaimValue(AbpClaimTypes.PhoneNumberVerified), "true", StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public virtual string Email
        {
            get
            {
                return this.FindClaimValue(AbpClaimTypes.Email);
            }
        }

        public virtual bool EmailVerified
        {
            get
            {
                return string.Equals(this.FindClaimValue(AbpClaimTypes.EmailVerified), "true", StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public virtual Guid? TenantId
        {
            get
            {
                ClaimsPrincipal principal = this._principalAccessor.Principal;
                if (principal == null)
                    return new Guid?();
                return principal.FindTenantId();
            }
        }

        private string[] _roles;

        public virtual string[] Roles
        {
            get { return _roles; }
        }

        public TestCurrentUser(ICurrentPrincipalAccessor principalAccessor)
        {
            this._principalAccessor = principalAccessor;
        }

        public virtual Claim FindClaim(string claimType)
        {
            ClaimsPrincipal principal = this._principalAccessor.Principal;
            if (principal == null)
                return (Claim)null;
            return principal.Claims.FirstOrDefault<Claim>((Func<Claim, bool>)(c => c.Type == claimType));
        }

        public virtual Claim[] FindClaims(string claimType)
        {
            ClaimsPrincipal principal = this._principalAccessor.Principal;
            return (principal != null ? principal.Claims.Where<Claim>((Func<Claim, bool>)(c => c.Type == claimType)).ToArray<Claim>() : (Claim[])null) ?? TestCurrentUser.EmptyClaimsArray;
        }

        public virtual Claim[] GetAllClaims()
        {
            ClaimsPrincipal principal = this._principalAccessor.Principal;
            return (principal != null ? principal.Claims.ToArray<Claim>() : (Claim[])null) ?? TestCurrentUser.EmptyClaimsArray;
        }

        public bool IsInRole(string roleName)
        {
            return ((IEnumerable<Claim>)this.FindClaims(AbpClaimTypes.Role)).Any<Claim>((Func<Claim, bool>)(c => c.Value == roleName));
        }

        public void SetId(Guid id)
        {
            _id = id;
        }

        public void SetRoles(string[] roles)
        {
            _roles = roles;
        }
    }
}