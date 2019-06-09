using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erpdbtest.Entities.Erp
{
    public class Fuck
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(80)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(80)")]
        public string NickName { get; set; }
    }
}