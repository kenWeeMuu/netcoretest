﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using ErpDb.Entitys;
using ErpDb.Entitys.Enums;
using Newtonsoft.Json;
using TjWebApi.Auth;
using TjWebApi.Extensions;

namespace TjWebApi.Controllers.Auth
{
    /// <summary>
    /// 
    /// </summary>
    // [EnableCors(origins: "*", headers: "*", methods: "*")]
    [ApiAuthorize]
    public class AccountController : ApiController
    {
        private readonly ErpDbContext _dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public AccountController()
        {
            _dbContext = new ErpDbContext();
        }

        //  [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/v1/account/Profile")]
        [HttpGet]
        public IHttpActionResult Profile()
        {
            var user2 = Thread.CurrentPrincipal;
            var usr = HttpContext.Current.User;
            var response = ResponseModelFactory.CreateInstance;
            using (_dbContext)
            {
                var json = this.ActionContext.getToken();
                Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                var userid = int.Parse(dic["UserId"].ToString());

                var user = _dbContext.Users.FirstOrDefault(x => x.UserId == userid);

                var menus = _dbContext.Menus.Where(x =>
                    x.IsDeleted == CommonEnum.IsDeleted.No && x.Status == CommonEnum.Status.Normal).ToList();

                //查询当前登录用户拥有的权限集合(非超级管理员)
                var sqlPermission =
                    @"SELECT P.Code AS PermissionCode,P.ActionCode AS PermissionActionCode,P.Name AS PermissionName,P.Type AS PermissionType,M.Name AS MenuName,M.Guid AS MenuGuid,M.Alias AS MenuAlias,M.IsDefaultRouter FROM DncRolePermissionMapping AS RPM 
LEFT JOIN DncPermission AS P ON P.Code = RPM.PermissionCode
INNER JOIN DncMenu AS M ON M.Guid = P.MenuGuid
WHERE P.IsDeleted=0 AND P.Status=1 AND EXISTS (SELECT 1 FROM DncUserRoleMapping AS URM WHERE URM.UserGuid={0} AND URM.RoleCode=RPM.RoleCode)";
                if (user.UserType == UserType.SuperAdministrator)
                {
                    //如果是超级管理员
                    sqlPermission =
                        @"SELECT P.Code AS PermissionCode,P.ActionCode AS PermissionActionCode,P.Name AS PermissionName,P.Type AS PermissionType,M.Name AS MenuName,M.Guid AS MenuGuid,M.Alias AS MenuAlias,M.IsDefaultRouter FROM Permission AS P 
INNER JOIN Menu AS M ON M.Guid = P.MenuGuid
WHERE P.IsDeleted=0 AND P.Status=1";
                }

                var permissions = _dbContext.Database.SqlQuery<PermissionWithMenu>(sqlPermission, user.UserId).ToList();

                var pagePermissions = permissions.GroupBy(x => x.MenuAlias)
                    .ToDictionary(g => g.Key, g => g.Select(x => x.PermissionActionCode).Distinct());
                response.SetData(new
                {
                    access = new string[] { },
                    avator = user.Avatar,
                    user_guid = user.UserId,
                    user_name = user.DisplayName,
                    user_type = user.UserType,
                    permissions = pagePermissions

                });
            }

            return Ok(response);
        }

        //        private List<string> FindParentMenuAlias(List<DncMenu> menus, Guid? parentGuid)
        //        {
        //            var pages = new List<string>();
        //            var parent = menus.FirstOrDefault(x => x.Guid == parentGuid);
        //            if (parent != null)
        //            {
        //                if (!pages.Contains(parent.Alias))
        //                {
        //                    pages.Add(parent.Alias);
        //                }
        //                else
        //                {
        //                    return pages;
        //                }
        //
        //                if (parent.ParentGuid != Guid.Empty)
        //                {
        //                    pages.AddRange(FindParentMenuAlias(menus, parent.ParentGuid));
        //                }
        //            }
        //
        //            return pages.Distinct().ToList();
        //        }

        // <summary>
        // 
        // </summary>
        // <returns></returns>

        [Route("api/v1/account/menu")]
        [HttpGet]
        public IHttpActionResult Menu()
        {
            var strSql = @"SELECT M.* FROM DncRolePermissionMapping AS RPM 
LEFT JOIN DncPermission AS P ON P.Code = RPM.PermissionCode
INNER JOIN DncMenu AS M ON M.Guid = P.MenuGuid
WHERE P.IsDeleted=0 AND P.Status=1 AND P.Type=0 AND M.IsDeleted=0 AND M.Status=1 AND EXISTS (SELECT 1 FROM DncUserRoleMapping AS URM WHERE URM.UserGuid=@p0 AND URM.RoleCode=RPM.RoleCode)";
            var user = this.ActionContext.CurrentUser(_dbContext);
            if (user.UserType == UserType.SuperAdministrator) {
                //如果是超级管理员
                strSql = @"SELECT * FROM Menu WHERE IsDeleted=0 AND Status=1";
            }
            var menus = _dbContext.Database.SqlQuery<Menu>(strSql, user.UserId).ToList();
            var rootMenus = _dbContext.Menus.Where(x =>
                x.IsDeleted == CommonEnum.IsDeleted.No && x.Status == CommonEnum.Status.Normal &&
                x.ParentId == -1).ToList();
            foreach (var root in rootMenus)
            {
                if (menus.Exists(x => x.Guid == root.Guid))
                {
                    continue;
                }

                menus.Add(root);
            }

            var menu = MenuItemHelper.LoadMenuTree(menus,-1);
            return Ok(menu);
        }
    }


    
    /// <summary>
    /// 
    /// </summary>
    public static class MenuItemHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menus"></param>
        /// <param name="selectedGuid"></param>
        /// <returns></returns>
        public static List<MenuItem> BuildTree(this List<MenuItem> menus, int selectedGuid = 0) {
            var lookup = menus.ToLookup(x => x.ParentId);
 
            List<MenuItem> Build(int pid) {
                return lookup[pid]
                    .Select(x => new MenuItem()
                    {
                        MenuItemId=x.MenuItemId,
                        Guid = x.MenuItemId.ToString(),
                        ParentId = x.ParentId,
                        Children = Build(x.MenuItemId),
                        Component = x.Component ?? "Main",
                        Name = x.Name,
                        Path = x.Path,
                        Meta = new MenuMeta
                        {
                            BeforeCloseFun = x.Meta.BeforeCloseFun,
                            HideInMenu = x.Meta.HideInMenu,
                            Icon = x.Meta.Icon,
                            NotCache = x.Meta.NotCache,
                            Title = x.Meta.Title,
                            Permission = x.Meta.Permission
                        }
                    }).ToList();
            }
 
            var result = Build(selectedGuid);
            return result;
        }
 
        public static List<MenuItem> LoadMenuTree(List<Menu> menus, int selectedGuid = 0) {
            var temp = menus.Select(x => new MenuItem
            {
                MenuItemId = x.MenuId,
                ParentId = x.ParentId,
                Name = x.Alias,
                Path = $"/{x.Url}",
                Component = x.Component,
                Meta = new MenuMeta
                {
                    BeforeCloseFun = x.BeforeCloseFun ?? "",
                    HideInMenu = x.HideInMenu == CommonEnum.YesOrNo.Yes,
                    Icon = x.Icon,
                    NotCache = x.NotCache == CommonEnum.YesOrNo.Yes,
                    Title = x.Name
                }
            }).ToList();
            var tree = temp.BuildTree(selectedGuid);
            return tree;
        }
    }
}

 
 
 