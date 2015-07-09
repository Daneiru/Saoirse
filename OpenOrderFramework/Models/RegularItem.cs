using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenOrderFramework.Models
{
    public class RegularItem : Item
    {
        public RegularItem() {
            OrderDetails = new HashSet<OrderDetail>();
        }

        #region 1 : m RegularItems        
        [ForeignKey("CatagorieID")]
        public virtual Catagorie Catagorie { get; set; }
        public int CatagorieID { get; set; }
        #endregion

        #region 1 RegularItem : m
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        #endregion
    }
}