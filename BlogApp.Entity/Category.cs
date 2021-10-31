using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Entity
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required(ErrorMessage ="This place cannot be empty!")]
        [MaxLength(1000,ErrorMessage = "You cannot enter more than 1000 characters !")]
        public string Name { get; set; }
        public virtual List<Blog> Blogs { get; set; }
    }
}
