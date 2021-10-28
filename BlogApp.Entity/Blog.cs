using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Entity
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public DateTime AddedTime { get; set; }
        public bool isApproved { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
