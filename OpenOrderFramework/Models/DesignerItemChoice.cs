using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenOrderFramework.Models
{
    public class DesignerItemChoice
    {
        public DesignerItemChoice() {
            DesignerOptions = new HashSet<DesignerOption>();
        }

        [Key]
        [DisplayName("Designer Choice ID")]
        public int ID { get; set; }

        [Required(ErrorMessage = "A Choice Name is required")]
        [StringLength(160)]
        public string Name { get; set; }

        public string Description { get; set; }

        #region 1 : m 
        public virtual ICollection<DesignerOption> DesignerOptions { get; set; }
        #endregion

        #region m : 1
        public int? ImageID { get; set; }
        public virtual Image Image { get; set; }
        #endregion
    }
}