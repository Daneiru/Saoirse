using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OpenOrderFramework.Models
{
    public class DesignerCatagorie
    {
        public DesignerCatagorie() {
            Children = new HashSet<DesignerCatagorie>();
            Items = new HashSet<Item>();
        }

        [Key]
        public int DesignerCatagorieID { get; set; }
        
        public string Name { get; set; }

        public int SortOrder { get; set; }

        #region 1 Catagorie : m
        public virtual ICollection<Item> Items { get; set; }
        #endregion

        #region Recursion for Parent/Child Relationship
        public int? ParentID { get; set; }
        public virtual DesignerCatagorie Parent { get; set; }

        public virtual ICollection<DesignerCatagorie> Children { get; set; }        
        #endregion 
    }
}