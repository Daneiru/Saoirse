using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Web;

namespace OpenOrderFramework.Models
{
    public class Image
    {
        public Image() {

        }

        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        [Key]
        [DisplayName("Image ID")]
        public int ImageID { get; set; }

        [Required(ErrorMessage = "An Image Name is required")]
        [StringLength(160)]
        public string Name { get; set; }

        public string Caption { get; set; }

        public byte[] InternalImage { get; set; }

        [Display(Name = "Local file")]
        [NotMapped]
        public HttpPostedFileBase File {
            get { return null; }
            set {
                try {
                    MemoryStream target = new MemoryStream();

                    if (value.InputStream == null)
                        return;

                    value.InputStream.CopyTo(target);
                    InternalImage = target.ToArray();
                } catch (Exception ex) {
                    logger.Error(ex.Message);
                    logger.Error(ex.StackTrace);
                }
            }
        }

        [DisplayName("Item Picture URL")]
        [StringLength(1024)]
        public string ItemPictureUrl { get; set; }

        #region 1 : m 
        #endregion

        #region m : 1
        #endregion
    }
}