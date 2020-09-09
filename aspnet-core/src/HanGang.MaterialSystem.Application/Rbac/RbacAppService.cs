using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.Rbac;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Rbac.Dtos;
using HanGang.MaterialSystem.Trials.Dtos;
using Microsoft.EntityFrameworkCore;
using Spire.Pdf.Exporting.XPS.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.Rbac
{
    /// <summary>
    /// 生产厂家服务
    /// </summary>
    public class RbacAppService : MaterialSystemAppService
    {
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<RoleResource> _roleResourceRepository;  
        private readonly IRepository<TrialCategory> _trialCategoryRepository; 
        private readonly IRepository<TrialDetailGroup> _trialDetailGroupRepository;
        private readonly IRepository<TrialDetailShowType> _trialDetailShowTypeRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<UserRole> _userRoleRepository;
        public RbacAppService(
            IRepository<Role> roleRepository,
            IRepository<RoleResource> roleResourceRepository,
            IRepository<TrialCategory> trialCategoryRepository,
            IRepository<TrialDetailGroup> trialDetailGroupRepository,
             IRepository<TrialDetailShowType>  trialDetailShowTypeRepository,
             IRepository<User>  userRepository,
             IRepository<UserRole> userRoleRepository
            )
        {
            _roleRepository = roleRepository;
            _roleResourceRepository = roleResourceRepository;
            _trialCategoryRepository = trialCategoryRepository;
            _trialDetailGroupRepository = trialDetailGroupRepository;
            _trialDetailShowTypeRepository = trialDetailShowTypeRepository;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;

        }
        #region Role
        /// <summary>
        /// 获取Role
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<RoleDto> GetRoles(RoleDto input)
        {
            return _roleRepository
                .AsNoTracking()
                .WhereIf(!string.IsNullOrEmpty(input.RoleName), x => x.RoleName==input.RoleName)
                .WhereIf(input.Id.HasValue, x => x.Id == input.Id )
                .OrderBy(p => p.CreationTime)
                .ProjectTo<RoleDto>(Configuration)
                .ToList();
        }

        /// <summary>
        /// 添加Role
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddRole(RoleDto input)
        {
            var role = new Role
            {
                RoleName = input.RoleName,
               Remark = input.Remark 
            };
            await _roleRepository.InsertAsync(role);
            return role.Id;
        }
        /// <summary>
        /// 更新某个Role信息
        /// </summary>
        /// <param name="input"></param>         
        /// <returns></returns>
        public async Task<Guid> UpdateRole(RoleDto input )
        {           

            var role = await _roleRepository.GetAsync(input.Id.GetValueOrDefault());
            role.RoleName = input.RoleName;
            role.Remark = input.Remark;
          
            return role.Id;
        }

        /// <summary>
        /// 根据Id删除某个Role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteRole(Guid id)
        {
           
            await _roleRepository.DeleteAsync(t => t.Id == id);
        }
        #endregion

        #region RoleResource
        /// <summary>
        /// 获取RoleResources
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<RoleResourceDto> GetRoleResources(RoleResourceDto input)
        {
            return _roleResourceRepository
                .AsNoTracking()
                .WhereIf(input.Id.HasValue, x => x.Id == input.Id)
                .WhereIf(input.RoleId.HasValue, x => x.Id == input.RoleId)
                .WhereIf(input.TrialCategoryId.HasValue, x => x.Id == input.TrialCategoryId)
                .WhereIf(input.ResourceTypeId.HasValue, x => x.Id == input.ResourceTypeId)
                .WhereIf(input.ResourceGroupId.HasValue, x => x.Id == input.ResourceGroupId)


                .OrderBy(p => p.CreationTime)
                .ProjectTo<RoleResourceDto>(Configuration)
                .ToList();
        }

        /// <summary>
        /// 添加RoleResource
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddRoleResource(RoleResourceDto input)
        {
            var role = new RoleResource
            {
                RoleId = input.RoleId,
               TrialCategoryId = input.TrialCategoryId,
                ResourceTypeId = input.ResourceTypeId,
               ResourceGroupId = input.ResourceGroupId,
                Remark = input.Remark
            };
            await _roleResourceRepository.InsertAsync(role);
            return role.Id;
        }
        /// <summary>
        /// 更新某个RoleResource信息
        /// </summary>
        /// <param name="input"></param>         
        /// <returns></returns>
        public async Task<Guid> UpdateRoleResource(RoleResourceDto input)
        {

            var role = await _roleResourceRepository.GetAsync(input.Id.GetValueOrDefault());
            role.RoleId = input.RoleId;
            role.TrialCategoryId = input.TrialCategoryId;
            role.ResourceTypeId = input.ResourceTypeId;
            role.ResourceGroupId = input.ResourceGroupId;
            role.Remark = input.Remark;

            return role.Id;
        }

        /// <summary>
        /// 根据Id删除某个RoleResource
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteRoleResource(Guid id)
        {

            await _roleResourceRepository.DeleteAsync(t => t.Id == id);
        }
        #endregion

        #region TrialCategory
        /// <summary>
        /// 获取TrialCategory
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<TrialCategoryDto> GetTrialCategorys(TrialCategoryDto input)
        {
            return _trialCategoryRepository
                .AsNoTracking()
                .WhereIf(input.Id.HasValue, x => x.Id == input.Id)
                .WhereIf(!string.IsNullOrEmpty(input.Name), x => x.Name == input.Name)
                .WhereIf(input.Trial.HasValue, x => x.Trial == input.Trial)
                .OrderBy(p => p.CreationTime)
                .ProjectTo<TrialCategoryDto>(Configuration)
                .ToList();
        }

        /// <summary>
        /// 添加TrialCategory
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddTrialCategory(TrialCategoryDto input)
        {
            var role = new TrialCategory
            {
                Name = input.Name,
                Trial=input.Trial,
                Remark = input.Remark
            };
            await _trialCategoryRepository.InsertAsync(role);
            return role.Id;
        }
        /// <summary>
        /// 更新某个TrialCategory信息
        /// </summary>
        /// <param name="input"></param>         
        /// <returns></returns>
        public async Task<Guid> UpdateTrialCategory(TrialCategoryDto input)
        {

            var role = await _trialCategoryRepository.GetAsync(input.Id.GetValueOrDefault());
            role.Name = input.Name;
            role.Trial = input.Trial;
            role.Remark = input.Remark;

            return role.Id;
        }

        /// <summary>
        /// 根据Id删除某个TrialCategory
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteTrialCategory(Guid id)
        {

            await _trialCategoryRepository.DeleteAsync(t => t.Id == id);
        }
        #endregion

        #region TrialDetailGroup
        /// <summary>
        /// 获取TrialDetailGroup
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<TrialDetailGroupDto> GetTrialDetailGroups(TrialDetailGroupDto input)
        {
            return _trialDetailGroupRepository
                .AsNoTracking()
                .WhereIf(input.Id.HasValue, x => x.Id == input.Id)
                //.WhereIf(!string.IsNullOrEmpty(input.Name), x => x.Name == input.Name)
                .WhereIf(input.TrialId.HasValue, x => x.TrialId == input.TrialId)
                .WhereIf(input.GroupOrder.HasValue, x => x.GroupOrder == input.GroupOrder)
                .WhereIf(input.BaseInfo.HasValue, x => x.BaseInfo == input.BaseInfo)
                .WhereIf(input.TrialParam.HasValue, x => x.TrialParam == input.TrialParam)
                .WhereIf(input.TrialResultOne.HasValue, x => x.TrialResultOne == input.TrialResultOne)
                .WhereIf(input.TrialResultTwo.HasValue, x => x.TrialResultTwo == input.TrialResultTwo)
                .OrderBy(p => p.CreationTime)
                .ProjectTo<TrialDetailGroupDto>(Configuration)
                .ToList();
        }

        /// <summary>
        /// 添加TrialDetailGroup
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddTrialDetailGroup(TrialDetailGroupDto input)
        {
            var role = new TrialDetailGroup
            {
                TrialId = input.TrialId,
                GroupOrder = input.GroupOrder,
               BaseInfo = input.BaseInfo,
                TrialParam = input.TrialParam,
               TrialResultOne= input.TrialResultOne,
               TrialResultTwo = input.TrialResultTwo,
                Remark = input.Remark
            };
            await _trialDetailGroupRepository.InsertAsync(role);
            return role.Id;
        }
        /// <summary>
        /// 更新某个TrialDetailGroup信息
        /// </summary>
        /// <param name="input"></param>         
        /// <returns></returns>
        public async Task<Guid> UpdateTrialDetailGroup(TrialDetailGroupDto input)
        {

            var role = await _trialDetailGroupRepository.GetAsync(input.Id.GetValueOrDefault());
            role.TrialId = input.TrialId;
            role.GroupOrder = input.GroupOrder;
            role.BaseInfo = input.BaseInfo;
            role.TrialParam = input.TrialParam;
            role.TrialResultOne = input.TrialResultOne;
            role.TrialResultTwo = input.TrialResultTwo;
            role.Remark = input.Remark;

            return role.Id;
        }

        /// <summary>
        /// 根据Id删除某个TrialDetailGroup
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteTrialDetailGroup(Guid id)
        {

            await _trialDetailGroupRepository.DeleteAsync(t => t.Id == id);
        }
        #endregion

        #region TrialDetailShowType
        /// <summary>
        /// 获取TrialDetailGroup
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<TrialDetailShowTypeDto> GetTrialDetailShowTypes(TrialDetailShowTypeDto input)
        {
            return _trialDetailShowTypeRepository
                .AsNoTracking()
                .WhereIf(input.Id.HasValue, x => x.Id == input.Id)
                 .WhereIf(!string.IsNullOrEmpty(input.TrialName), x => x.TrialName == input.TrialName)
                .WhereIf(input.TrialId.HasValue, x => x.TrialId == input.TrialId)
                .WhereIf(input.TypeOrder.HasValue, x => x.TypeOrder == input.TypeOrder)
                .WhereIf(input.Table.HasValue, x => x.Table == input.Table)
                .WhereIf(input.Picture.HasValue, x => x.Picture == input.Picture)
                .WhereIf(input.Report.HasValue, x => x.Report == input.Report)
                .WhereIf(input.TypicalPart.HasValue, x => x.TypicalPart == input.TypicalPart)
                .OrderBy(p => p.CreationTime)
                .ProjectTo<TrialDetailShowTypeDto>(Configuration)
                .ToList();
        }

        /// <summary>
        /// 添加TrialDetailShowType
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddTrialDetailShowType(TrialDetailShowTypeDto input)
        {
            var role = new TrialDetailShowType
            {
                TrialId = input.TrialId,
               TrialName = input.TrialName,
                TypeOrder = input.TypeOrder,
                Table = input.Table,
                Picture = input.Picture,
                Report = input.Report,
                TypicalPart = input.TypicalPart,
                Remark = input.Remark
            };
            await _trialDetailShowTypeRepository.InsertAsync(role);
            return role.Id;
        }
        /// <summary>
        /// 更新某个TrialDetailShowType信息
        /// </summary>
        /// <param name="input"></param>         
        /// <returns></returns>
        public async Task<Guid> UpdateTrialDetailShowType(TrialDetailShowTypeDto input)
        {

            var role = await _trialDetailShowTypeRepository.GetAsync(input.Id.GetValueOrDefault());
            role.TrialId = input.TrialId;
         
            role.TrialName = input.TrialName;
            role.TypeOrder = input.TypeOrder;
            role.Table = input.Table;
            role.Picture = input.Picture;
            role.Report = input.Report;
            role.TypicalPart = input.TypicalPart;
            role.Remark = input.Remark;

            return role.Id;
        }

        /// <summary>
        /// 根据Id删除某个TrialDetailShowType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteTrialDetailShowType(Guid id)
        {

            await _trialDetailShowTypeRepository.DeleteAsync(t => t.Id == id);
        }
        #endregion

        #region User  
        /// <summary>
        /// 获取User
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<UserDto> GetUsers(UserDto input)
        {
            return _userRepository
                .AsNoTracking()
               
                .WhereIf(input.Id.HasValue, x => x.Id == input.Id)
                .WhereIf(!string.IsNullOrEmpty(input.UserName), x => x.UserName == input.UserName)
                .WhereIf(!string.IsNullOrEmpty(input.PassWord), x => x.PassWord == input.PassWord)
                .OrderBy(p => p.CreationTime)
                .ProjectTo<UserDto>(Configuration)
                .ToList();
        }

        /// <summary>
        /// 添加User
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddUser(UserDto input)
        {
            var role = new User
            {
               UserName = input.UserName,
               PassWord=input.PassWord,
                Remark = input.Remark
            };
            await _userRepository.InsertAsync(role);
            return role.Id;
        }
        /// <summary>
        /// 更新某个User信息
        /// </summary>
        /// <param name="input"></param>         
        /// <returns></returns>
        public async Task<Guid> UpdateUser(UserDto input)
        {

            var role = await _userRepository.GetAsync(input.Id.GetValueOrDefault());
            role.UserName = input.UserName;
            role.PassWord = input.PassWord;
            role.Remark = input.Remark;

            return role.Id;
        }

        /// <summary>
        /// 根据Id删除某个User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteUser(Guid id)
        {

            await _userRepository.DeleteAsync(t => t.Id == id);
        }
        #endregion

        #region UserRole  
        /// <summary>
        /// 获取UserRole
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<UserRoleDto> GetUserRoles(UserRoleDto input)
        {
            return _userRoleRepository
                .AsNoTracking()

                .WhereIf(input.Id.HasValue, x => x.Id == input.Id)
                .WhereIf(input.RoleId.HasValue, x => x.RoleId == input.RoleId)
                .WhereIf(input.UserId.HasValue, x => x.UserId == input.UserId)
                .OrderBy(p => p.CreationTime)
                .ProjectTo<UserRoleDto>(Configuration)
                .ToList();
        }

        /// <summary>
        /// 添加UserRole
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddUserRole(UserRoleDto input)
        {
            var role = new UserRole
            {
                RoleId= input.RoleId,
                UserId = input.UserId,
                Remark = input.Remark
            };
            await _userRoleRepository.InsertAsync(role);
            return role.Id;
        }
        /// <summary>
        /// 更新某个UserRole信息
        /// </summary>
        /// <param name="input"></param>         
        /// <returns></returns>
        public async Task<Guid> UpdateUserRole(UserRoleDto input)
        {

            var role = await _userRoleRepository.GetAsync(input.Id.GetValueOrDefault());
            role.RoleId = input.RoleId;
            role.UserId = input.UserId;
            role.Remark = input.Remark;

            return role.Id;
        }

        /// <summary>
        /// 根据Id删除某个UserRole
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteUserRole(Guid id)
        {

            await _userRoleRepository.DeleteAsync(t => t.Id == id);
        }
        #endregion

    }

}