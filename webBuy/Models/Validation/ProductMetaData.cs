using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webBuy.Models
{
    public class ProductMetaData
    {
        public int productId { get; set; }
        [Required(ErrorMessage = "Name must be given"), MinLength(3, ErrorMessage = "Name length should be at least 3 charachter")]
        public string name { get; set; }
        public int shopId { get; set; }
        [Required(ErrorMessage = "Unit Price should be given"), Range(0, double.MaxValue, ErrorMessage = "Please enter valid Price")]
        public Nullable<double> unitPrice { get; set; }
        [Required(ErrorMessage = "Quantity Mus need")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Quantity")]
        public Nullable<int> quantity { get; set; }
        [Required()]
        public string date { get; set; }
        //[Required(ErrorMessage = "Image should be added")]
        public string image { get; set; }
        public Nullable<int> productStatus { get; set; }
        [Required(ErrorMessage = "Category Name must need")]
        public int categoryId { get; set; }
    }
}