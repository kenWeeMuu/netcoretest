namespace CodeFirstExistingDatabaseSample
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DncRole")]
    public partial class DncRole
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DncRole()
        {
            DncRolePermissionMapping = new HashSet<DncRolePermissionMapping>();
            DncUserRoleMapping = new HashSet<DncUserRoleMapping>();
        }

        [Key]
        [StringLength(50)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public int IsDeleted { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get; set; }

        public Guid CreatedByUserGuid { get; set; }

        public string CreatedByUserName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ModifiedOn { get; set; }

        public Guid? ModifiedByUserGuid { get; set; }

        public string ModifiedByUserName { get; set; }

        public bool IsSuperAdministrator { get; set; }

        public bool IsBuiltin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DncRolePermissionMapping> DncRolePermissionMapping { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DncUserRoleMapping> DncUserRoleMapping { get; set; }
    }
}
