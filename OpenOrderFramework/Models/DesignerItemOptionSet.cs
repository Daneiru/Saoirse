using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OpenOrderFramework.Models
{
    public class DesignerItemOptionSet
    {
        public DesignerItemOptionSet() {
            DesignerOptions = new HashSet<DesignerOption>();
        }

        [Key]
        [DisplayName("Designer Choiceset ID")]
        public int DesignerItemOptionSetID { get; set; }

        [Required(ErrorMessage = "A Choice Name is required")]
        [StringLength(160)]
        public string Name { get; set; }

        public string Description { get; set; }

        #region 1 : m 
        public virtual ICollection<DesignerOption> DesignerOptions { get; set; }
        #endregion

        #region m : 1
        public int DesignerItemID { get; set; }
        public virtual DesignerItem DesignerItem { get; set; }
        #endregion
    }
}