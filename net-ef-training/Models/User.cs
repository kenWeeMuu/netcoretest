using System;
using System.ComponentModel.DataAnnotations;

namespace net_ef_training.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string DisplayName { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public int Age { get; set; }

    }
}