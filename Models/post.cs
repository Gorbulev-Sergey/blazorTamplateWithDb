using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace blazorProject5.Models
{
    [Table(name: "posts")]
    public class post
    {
        public int id { get; set; }
        public DateTime date { get; set; } = DateTime.Now;
        [Required]
        public string title { get; set; }
        public string description { get; set; }
        public string cover_image { get; set; }
        public string cover_video { get; set; }
        public string content { get; set; }

        #region next
        public bool pablished { get; set; } = false;
        public virtual List<tag> tags { get; set; } = new List<tag>();
        public string userId { get; set; }
        #endregion next
    }
}
