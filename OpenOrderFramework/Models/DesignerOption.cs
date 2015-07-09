using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OpenOrderFramework.Models
{
    public class DesignerOption
    {
        public DesignerOption() {

        }

        [Key]
        [DisplayName("Designer Choice ID")]
        public int DesignerOptionID { get; set; }

        [Required(ErrorMessage = "A Choice Name is required")]
        [StringLength(160)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.00, 999.99, ErrorMessage = "Price must be between 0.00 and 999.99")]
        public decimal Price { get; set; }

        #region Shipping Modifications
        // Added to totals.
        public int Pounds { get; set; }
        public int Ounces { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        #endregion

        #region 1 : m 
        [DisplayName("Image Group")]
        public int ImageGroupID { get; set; }
        public virtual ImageGroup ImageGroup { get; set; }

        [DisplayName("Designer Choiceset")]
        public int DesignerItemOptionSetID { get; set; }
        public virtual DesignerItemOptionSet DesignerItemOptionSet { get; set; }
        #endregion

        #region m : 1
        #endregion
    }
}