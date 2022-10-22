using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Store.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [Display(Name = "List Price")]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }
  
        [ValidateNever]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
      

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever] 
        public Category Category { get; set; }

        [Required]
        [Display(Name = "Sub-Category")]
        public int SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        [ValidateNever]
        public SubCategory SubCategory{ get; set; }
    }
}
