using System.Collections.Generic;

namespace ef_training_console.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual List<Post> Posts { get; set; }
    }
}
