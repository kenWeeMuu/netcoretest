using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace create.db.Entities.Erp
{
    /// <summary>
    /// 
    /// </summary>
    [Table("TjCustomer")]
    public class TjCustomer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Name { get; set; }

      
        [Column(TypeName = "nvarchar(80)")]
        public string Email { get; set; }

 
        [Column(TypeName = "nvarchar(30)")]
        public string Phone { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Company { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string Region { get; set; }

        public string Location { get; set; }

        public string Industry { get; set; }
        [DefaultValue("newid()")]
        public Guid Owner { get; set; }
        [DefaultValue("newid()")]
        public Guid ServiceBy { get; set; }
 
    }
}
