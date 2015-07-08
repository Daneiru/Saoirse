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

        }

        [Key]
        [DisplayName("Image Group ID")]
        public int ID { get; set; }

        [Required(ErrorMessage = "An Item Name is required")]
        [StringLength(160)]
        public string Name { get; set; }

        #region 1 : m 
        #endregion

        #region m : 1
        #endregion
    }
}