using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erpdbtest.Entities.Erp
{
    public class Sleep
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(80)")] public string Name { get; set; }

        [Column(TypeName = "nvarchar(80)")] public string NickName { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
    public class Post
    {
        public Post()
        {
            PostTags = new HashSet<PostTag>();
        }
        [Required]
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public ICollection<PostTag> PostTags { get; set; }
    }

    public class Tag
    {
        public Tag()
        {
            PostTags = new List<PostTag>();
        }
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagId { get; set; }



        public List<PostTag> PostTags { get; set; }
    }

    public class PostTag
    {
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }

}