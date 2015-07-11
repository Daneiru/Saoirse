using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OpenOrderFramework.Models
{
    public class ImageGroup
    {
        public ImageGroup() {
            Images = new HashSet<Image>();
        }

        [Key]
        [DisplayName("Image Group ID")]
        public int ImageGroupID { get; set; }

        [Required(ErrorMessage = "An Item Name is required")]
        [StringLength(160)]
        public string Name { get; set; }

        #region 1 : m 
        public virtual ICollection<Image> Images { get; set; }
        #endregion

        #region m : 1
        #endregion
    }
}