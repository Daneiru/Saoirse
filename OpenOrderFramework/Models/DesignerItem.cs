using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenOrderFramework.Models
{
    public class DesignerItem : Item
    {
        public DesignerItem() {
            DesignerItemOptionSets = new HashSet<DesignerItemOptionSet>();
        }

        #region 1 : m DesignerItems            
        [ForeignKey("DesignerCatagorieID")]
        public virtual DesignerCatagorie DesignerCatagorie { get; set; }
        public int DesignerCatagorieID { get; set; }
        #endregion

        #region 1 DesignerItem : m
        public virtual ICollection<DesignerItemOptionSet> DesignerItemOptionSets { get; set; }
        #endregion
    }
}