//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webBuy.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ShopDiscount
    {
        public int shopDiscountId { get; set; }
        public int shopId { get; set; }
        public string promoCode { get; set; }
        public Nullable<int> percentage { get; set; }
    }
}
