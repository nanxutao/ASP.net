using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcVBlog19301330222_2020.Models
{
    public class GuestBook
    {
        //主键
        public int ID { get; set; }

        [Required(ErrorMessage = "昵称字段必须填写")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "昵称长度必须大于4，并小于20")]
        public String Nickname { get; set; } //昵称

        [Required(ErrorMessage = "留言字段必须填写")]
        [StringLength(150)]
        public String Message { get; set; } //留言内容

        public DateTime AddDate { get; set; } //留言时间

        public String Reply { get; set; } //回复
    }
}