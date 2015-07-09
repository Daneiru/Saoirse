using System.Collections.Generic;

namespace OpenOrderFramework.Models
{
    public class OrderDetail
    {
        public OrderDetail() {
            DesignerItemSelections = new HashSet<DesignerItemSelection>();
        }

        public int OrderDetailID { get; set; }        
        
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        #region 1 : m OrderDetails
        public int ItemID { get; set; }
        public virtual Item Item { get; set; }

        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
        #endregion

        #region m : 1
        public virtual ICollection<DesignerItemSelection> DesignerItemSelections { get; set; }
        #endregion
    }
}
