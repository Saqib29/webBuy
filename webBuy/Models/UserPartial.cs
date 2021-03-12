using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webBuy.Models
{
    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
        [Required(ErrorMessage = "Confirm messaeg required")]
        [StringLength(50, ErrorMessage = "Must be at least 6 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Password doesn't match")]
        public string confirmPassword { get; set; }
    }
}