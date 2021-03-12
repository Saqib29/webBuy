using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webBuy.Models
{
    public class UserMetaData
    {
        public int userId { get; set; }
        [Required]
        public string email { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string role { get; set; }
        public Nullable<int> userStatus { get; set; }
    }
}