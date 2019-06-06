namespace CodeFirstExistingDatabaseSample
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DncRolePermissionMapping")]
    public partial class DncRolePermissionMapping
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string RoleCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string PermissionCode { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get; set; }

        public virtual DncPermission DncPermission { get; set; }

        public virtual DncRole DncRole { get; set; }
    }
}
