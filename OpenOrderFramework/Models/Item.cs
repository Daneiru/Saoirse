using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Web.Mvc.Html;

namespace OpenOrderFramework.Models
{
    public class Item
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ItemID { get; set; }

        
        [StringLength(160)]
        [Required(ErrorMessage = "An Item Name is required")]
        public string Name { get; set; }

        public string ShortDescription { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.00, 999.99,ErrorMessage = "Price must be between 0.01 and 999.99")]
        public decimal Price { get; set; }

        public int AvailableQuantity { get; set; }

        #region Shipping Info
        public int Pounds { get; set; }
        public int Ounces { get; set; }
        //public string Size { get; set; } // NOTE: USPS Defines REGULAR or LARGE, large is any item more than 12" in one dimension.

        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        #endregion
        
        [ForeignKey("ImageGroupID")]
        public virtual ImageGroup ImageGroup { get; set; }
        public int? ImageGroupID { get; set; }
    }
}