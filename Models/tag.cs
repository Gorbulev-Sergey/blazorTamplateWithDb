using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace blazorProject5.Models
{
    [Table(name: "tags")]
    public class tag
    {
        public int id { get; set; }
        public DateTime date { get; set; } = DateTime.Now;
        [Required]
        public string name { get; set; }
        public string description { get; set; }
        public int position { get; set; }

        #region addons
        public virtual List<post>? posts { get; set; } = new List<post>();
        #endregion
    }
}
