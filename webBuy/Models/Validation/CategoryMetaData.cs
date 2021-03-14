using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webBuy.Models
{
    public class CategoryMetaData
    {
        public int categoryId { get; set; }
        [Required(ErrorMessage = "Category name must!")]
        public string name { get; set; }
    }
}