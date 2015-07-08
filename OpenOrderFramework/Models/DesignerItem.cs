using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;

namespace OpenOrderFramework.Models
{
    public class DesignerItem
    {
        public DesignerItem() {
            DesignerOptions = new HashSet<DesignerOption>();
        }

        [Key]
        [DisplayName("Designer Item ID")]
        public int ID { get; set; }        

        [Required(ErrorMessage = "An Item Name is required")]
        [StringLength(160)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 999.99, ErrorMessage = "Price must be between 0.01 and 999.99")]
        public decimal CorePrice { get; set; }

        #region 1 : m DesignerItems
        [DisplayName("Image Group")]
        public int ImageGroupID { get; set; }
        public virtual ImageGroup ImageGroup { get; set; }

        [DisplayName("Catagorie")]
        public int DesignerCatagorieID { get; set; }
        public virtual DesignerCatagorie DesignerCatagorie { get; set; }
        #endregion

        #region 1 DesignerItem : m
        public virtual ICollection<DesignerOption> DesignerOptions { get; set; }
        #endregion
    }
}