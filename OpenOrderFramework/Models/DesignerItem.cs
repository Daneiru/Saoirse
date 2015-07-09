using System.Collections.Generic;
using System.ComponentModel;

namespace OpenOrderFramework.Models
{
    public class DesignerItem : Item
    {
        public DesignerItem() {
            DesignerItemOptionSets = new HashSet<DesignerItemOptionSet>();
        }

        #region 1 : m DesignerItems
        [DisplayName("Catagorie")]
        public int DesignerCatagorieID { get; set; }
        public virtual DesignerCatagorie DesignerCatagorie { get; set; }
        #endregion

        #region 1 DesignerItem : m
        public virtual ICollection<DesignerItemOptionSet> DesignerItemOptionSets { get; set; }
        #endregion
    }
}