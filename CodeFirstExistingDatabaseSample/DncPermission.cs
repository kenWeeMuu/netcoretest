namespace CodeFirstExistingDatabaseSample
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DncPermission")]
    public partial class DncPermission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DncPermission()
        {
            DncRolePermissionMapping = new HashSet<DncRolePermissionMapping>();
        }

        [Key]
        [StringLength(20)]
        public string Code { get; set; }

        public Guid MenuGuid { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(80)]
        public string ActionCode { get; set; }

        public string Icon { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public int IsDeleted { get; set; }

        public int Type { get; set; }

        public Guid CreatedByUserGuid { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get; set; }

        public string CreatedByUserName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ModifiedOn { get; set; }

        public Guid? ModifiedByUserGuid { get; set; }

        public string ModifiedByUserName { get; set; }

        public virtual DncMenu DncMenu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DncRolePermissionMapping> DncRolePermissionMapping { get; set; }
    }
}
