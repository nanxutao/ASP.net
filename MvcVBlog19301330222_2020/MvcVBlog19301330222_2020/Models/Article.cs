using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcVBlog19301330222_2020.Models
{
    public class Article
    {
        //主键
        public int ID { get; set; }

        [Required(ErrorMessage = "文章标题必填")]
        [StringLength(50, ErrorMessage = "文章标题太长了，长度不要超过50")]
        public string Title { get; set; } //文章标题

        [Required(ErrorMessage = "文章内容必填")]
        public string Content { get; set; } //文章内容

        [DataType(DataType.Date)]
        public DateTime addDate { get; set; } //发布日期

        public int Hit { get; set; } //浏览次数

        //外键
        [Required(ErrorMessage = "分类必填")]
        public int CategoryID { get; set; }

        //导航属性
        public virtual Category Category { get; set; }
    }
}