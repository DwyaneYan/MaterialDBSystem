using AutoMapper;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.Rbac;
using HanGang.MaterialSystem.Rbac.Dtos;
using HanGang.MaterialSystem.Trials.Dtos;

namespace HanGang.MaterialSystem.MaterialManagement
{
    public class RbacDtoMapper : Profile
    {
        public RbacDtoMapper()
        {
            CreateMap<Role, RoleDto>()  ;
            CreateMap<RoleResource, RoleResourceDto>(); 
            CreateMap<TrialCategory, TrialCategoryDto>(); 
            CreateMap<TrialDetailGroup, TrialDetailGroupDto>();
            CreateMap<TrialDetailShowType, TrialDetailShowTypeDto>();
            CreateMap<User, UserDto>();
            CreateMap<UserRole, UserRoleDto>();
        }
    }
}