using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webBuy.Models
{
    public class ShopMetaData
    {
        public int shopId { get; set; }
        [Required(ErrorMessage = "Shop name must required"), MinLength(3, ErrorMessage = "Name consist atleast 3 characters")]
        public string name { get; set; }
        [Required(ErrorMessage = "Email must need")]
        public string email { get; set; }
        public Nullable<int> shopStatus { get; set; }
        public Nullable<double> balance { get; set; }
        public Nullable<int> setComission { get; set; }
    }
}