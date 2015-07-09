using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("ItemID")]
        public virtual Item Item { get; set; }
        public int ItemID { get; set; }
        #endregion
    }
}