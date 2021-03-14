using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webBuy.Models
{
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
        [Required(ErrorMessage = "Product Picture must need")]
        public HttpPostedFileBase productPicture { get; set; }
    }
}