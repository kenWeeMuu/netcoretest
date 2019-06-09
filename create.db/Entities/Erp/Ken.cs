using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace create.db.Entities.Erp
{
    public class Ken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        [Column(TypeName = "nvarchar(80)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(80)")]
        public string NickName { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
