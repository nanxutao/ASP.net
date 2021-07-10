using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcFlight.Models
{
    public class GuestBook
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "昵称字段必须填写")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "昵称长度必须大于4，并小于20")]
        public String Nickname { get; set; } 

        [Required(ErrorMessage = "留言字段必须填写")]
        [StringLength(150)]
        public String Message { get; set; } 

        public DateTime AddDate { get; set; } 

        public String Reply { get; set; }
    }
}