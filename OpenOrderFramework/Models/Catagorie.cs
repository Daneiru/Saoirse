using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OpenOrderFramework.Models
{
    public class Catagorie
    {
        public Catagorie() {
            Children = new HashSet<Catagorie>();
        }

        [Key]
        [DisplayName("Catagorie ID")]
        public int ID { get; set; }

        [DisplayName("Catagorie")]
        public string Name { get; set; }

        public int SortOrder { get; set; }

        #region 1 Catagorie : m
        public virtual ICollection<Item> Items { get; set; }
        #endregion

        #region Recursion for Parent/Child Relationship
        public int? ParentID { get; set; }
        public virtual Catagorie Parent { get; set; }

        public virtual ICollection<Catagorie> Children { get; set; }        
        #endregion 
    }
}