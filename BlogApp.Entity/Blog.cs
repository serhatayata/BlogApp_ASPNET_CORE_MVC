using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        [Required(ErrorMessage ="Title cannot be empty!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description cannot be empty!")]
        public string Description { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        [BindNever]
        public DateTime AddedTime { get; set; }
        public bool isApproved { get; set; }
        public bool isHome { get; set; }
        public bool isSlider { get; set; }
        [Required(ErrorMessage = "Category cannot be empty!")]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "Please select a value")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
