﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using create.db.Entities.Enums;

namespace create.db.Entities
{
    /// <summary>
    /// 角色实体类
    /// </summary>
    public class DncRole
    {
        /// <summary>
        ///
        /// </summary>
        public DncRole() {
            UserRoles = new HashSet<DncUserRoleMapping>();
            Permissions = new HashSet<DncRolePermissionMapping>();
        }

        /// <summary>
        ///
        /// </summary>
        [Required]
        [Key]
        [Column(TypeName = "nvarchar(50)")]
        public string Code { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        /// <summary>
        ///
        /// </summary>
        public CommonEnum.Status Status { get; set; }

        /// <summary>
        ///
        /// </summary>
        public CommonEnum.IsDeleted IsDeleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        public Guid CreatedByUserGuid { get; set; }

        /// <summary>
        /// 创建者姓名
        /// </summary>
        public string CreatedByUserName { get; set; }

        /// <summary>
        /// 最近修改时间
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// 最近修改者ID
        /// </summary>
        public Guid? ModifiedByUserGuid { get; set; }

        /// <summary>
        /// 最近修改者姓名
        /// </summary>
        public string ModifiedByUserName { get; set; }

        /// <summary>
        /// 是否是超级管理员(超级管理员拥有系统的所有权限)
        /// </summary>
        public bool IsSuperAdministrator { get; set; }

        /// <summary>
        /// 是否是系统内置角色(系统内置角色不允许删除,修改操作)
        /// </summary>
        public bool IsBuiltin { get; set; }

        /// <summary>
        /// 角色拥有的用户集合
        /// </summary>
        public ICollection<DncUserRoleMapping> UserRoles { get; set; }

        /// <summary>
        /// 角色拥有的权限集合
        /// </summary>
        public ICollection<DncRolePermissionMapping> Permissions { get; set; }
    }
}