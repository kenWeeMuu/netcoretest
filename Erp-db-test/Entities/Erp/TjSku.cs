using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erpdbtest.Entities.Erp
{
    public class TjSku
    {
        public TjSku() { }
        public TjSku(TjSku sku)
        {
            this.SkuCode = sku.SkuCode;
            this.SkuType = sku.SkuType;
            this.CName = sku.CName;
            this.EName = sku.EName;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(80)")]
        public string SkuCode { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string SkuType { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string CName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string EName { get; set; }
    }
}
