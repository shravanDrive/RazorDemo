using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorModels.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Display Order")]
        [Range(1, 100, ErrorMessage = "Display order must be in range of 1-100!!!")]
        public int DisplayOrder { get; set; }
    }
}
