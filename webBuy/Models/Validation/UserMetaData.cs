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
        [Required(ErrorMessage = "The Email Address is required"), EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }
        [Required(ErrorMessage = "Username must required"), StringLength(50, MinimumLength = 3)]
        public string name { get; set; }
        [Required(ErrorMessage = "Password must required")]
        [StringLength(50, ErrorMessage = "Must be at least 6 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string password { get; set; }


        public string phone { get; set; }
        public string address { get; set; }
        [Required(ErrorMessage = "Must select type")]
        public string role { get; set; }
        public Nullable<int> userStatus { get; set; }
    }
}