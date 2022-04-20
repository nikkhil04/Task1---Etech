using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WEBAPPMVC.Models
{
    public class MODEL1
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Display(Name = "Name")]
        public string itemName { get; set; }

        [Range(9999,99999)]
        [Display(Name = "Price")]
        public int itemPrice { get; set; }

        [Display(Name = "Image")]
        public string itemImagestring { get; set; }

        [NotMapped]
        public HttpPostedFileBase itemImage { get; set; }
    }
}