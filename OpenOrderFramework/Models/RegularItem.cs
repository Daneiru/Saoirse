using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Web.Mvc.Html;

namespace OpenOrderFramework.Models
{
    public class RegularItem : Item
    {
        public RegularItem() {
            OrderDetails = new HashSet<OrderDetail>();
        }

        #region 1 : m RegularItems
        [DisplayName("Catagorie")]
        public int CatagorieId { get; set; }
        public virtual Catagorie Catagorie { get; set; }
        #endregion

        #region 1 RegularItem : m
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        #endregion
    }
}