using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_ef_training.Models.Erp
{
    [Table("DncUserRoleMapping")]
    public partial class DncUserRoleMapping
    {
        [Key]
        [Column(Order = 0)]
        public Guid UserGuid { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string RoleCode { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get; set; }

        public virtual DncRole DncRole { get; set; }

        public virtual DncUser DncUser { get; set; }
    }
}
