namespace CodeFirstExistingDatabaseSample
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DncMenu")]
    public partial class DncMenu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DncMenu()
        {
            DncPermission = new HashSet<DncPermission>();
        }

        [Key]
        public Guid Guid { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Url { get; set; }

        [StringLength(255)]
        public string Alias { get; set; }

        [StringLength(128)]
        public string Icon { get; set; }

        public Guid? ParentGuid { get; set; }

        public string ParentName { get; set; }

        public int Level { get; set; }

        [StringLength(800)]
        public string Description { get; set; }

        public int Sort { get; set; }

        public int Status { get; set; }

        public int IsDeleted { get; set; }

        public int IsDefaultRouter { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get; set; }

        public Guid CreatedByUserGuid { get; set; }

        public string CreatedByUserName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ModifiedOn { get; set; }

        public Guid? ModifiedByUserGuid { get; set; }

        public string ModifiedByUserName { get; set; }

        [StringLength(255)]
        public string Component { get; set; }

        public int? HideInMenu { get; set; }

        public int? NotCache { get; set; }

        [StringLength(255)]
        public string BeforeCloseFun { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DncPermission> DncPermission { get; set; }
    }
}
