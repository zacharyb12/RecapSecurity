using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ProductModels
{
    public class CreateProductDTOs
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(0.5, 9999)]
        public double Price { get; set; }

        public string? ImageUrl { get; set; }
    }
}
