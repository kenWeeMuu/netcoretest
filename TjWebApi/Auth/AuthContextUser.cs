﻿using System;
using ErpDb.Entitys;

namespace TjWebApi.Auth
{
    public class AuthContextUser
    {
        /// <summary>
        /// 用户GUID
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// 显示名
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public UserType UserType { get; set; }

        /// <summary>
        /// 头像地址
        /// </summary>
        public string Avator { get; set; }
    }
}