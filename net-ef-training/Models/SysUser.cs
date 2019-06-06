using System.Collections;
using System.Collections.Generic;

namespace net_ef_training.Models
{
    public class SysUser
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public virtual  ICollection<SysUserRole> SysUserRoles { get; set; }
    }

    public class SysRole
    {
        public int ID { get; set; }

        public string RoleName { get; set; }

        public string RoleDesc  { get; set; }

        public virtual ICollection<SysUserRole> SysUserRoles { get; set; }
    }

    public class SysUserRole    
    {

        public int ID { get; set; }

        public int SysUserID { get; set; }

        public int SysRoleID { get; set; }

        public virtual SysUser SysUser { get; set; }

        public virtual SysRole SysRole { get; set; }
    }
}