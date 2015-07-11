using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class ItemViewModel
    {
        [Key]
        public int ItemID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        
        public decimal Price { get; set; }

        public string Catagories { get; set; }

        #region Shipping Info
        public int Pounds { get; set; }
        public int Ounces { get; set; }
        //public string Size { get; set; } // NOTE: USPS Defines REGULAR or LARGE, large is any item more than 12" in one dimension.

        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        #endregion

        public Image Thumbnail { get; set; }
    }
}