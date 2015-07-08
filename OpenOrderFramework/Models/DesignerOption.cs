using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OpenOrderFramework.Models
{
    public class DesignerOption
    {
        public DesignerOption() {

        }

        [Key]
        [DisplayName("Designer Choice ID")]
        public int ID { get; set; }

        [Required(ErrorMessage = "A Choice Name is required")]
        [StringLength(160)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.00, 999.99, ErrorMessage = "Price must be between 0.00 and 999.99")]
        public decimal Price { get; set; }

        #region 1 : m 
        [DisplayName("Image Group")]
        public int ImageGroupID { get; set; }
        public virtual ImageGroup ImageGroup { get; set; }

        [DisplayName("Designer Choice")]
        public int DesignerItemChoiceID { get; set; }
        public virtual DesignerItemChoice DesignerItemChoice { get; set; }
        #endregion

        #region m : 1
        #endregion
    }
}