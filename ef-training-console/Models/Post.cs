namespace ef_training_console.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual Blog Blog { get; set; }
    }
}