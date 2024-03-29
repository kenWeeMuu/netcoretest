namespace CodeFirstExistingDatabaseSample
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DncUser")]
    public partial class DncUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DncUser()
        {
            DncUserRoleMapping = new HashSet<DncUserRoleMapping>();
        }

        [Key]
        public Guid Guid { get; set; }

        [Required]
        [StringLength(50)]
        public string LoginName { get; set; }

        [StringLength(50)]
        public string DisplayName { get; set; }

        [StringLength(255)]
        public string Password { get; set; }

        [StringLength(255)]
        public string Avatar { get; set; }

        public int UserType { get; set; }

        public int IsLocked { get; set; }

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

        [StringLength(800)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DncUserRoleMapping> DncUserRoleMapping { get; set; }
    }
}
