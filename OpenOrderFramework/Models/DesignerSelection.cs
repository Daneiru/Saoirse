using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OpenOrderFramework.Models
{
    public class DesignerItemSelection
    {
        [Key]
        public int DesignerItemSelectionID { get; set; }        

        #region 1 : m DesignerItems
        public int OrderDetailID { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }

        public int DesignerOptionID { get; set; }
        public virtual DesignerOption DesignerOption { get; set; }
        #endregion
    }
}