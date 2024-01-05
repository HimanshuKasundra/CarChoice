﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarChoice.Areas.Brand.Models
{
    public class BrandModel
    {
        public int BrandID { get; set; }

        [Required]
        [DisplayName("Brand Name")]
        public string? BrandName { get; set; }

        [Required]
        [DisplayName("Brand Logo")]
        public string? BrandLogo { get; set; }

        public IFormFile Logo { get; set; } 
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }

   
}
