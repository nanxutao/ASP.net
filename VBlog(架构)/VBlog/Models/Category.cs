using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace VBlog.Models
{
    public class Category
    {
        //主键
        public int ID { get; set; }

        [Required(ErrorMessage = "分类名称字段必须填写")]
        [StringLength(10, MinimumLength = 2)]
        public string Name { get; set; } //分类名称

        //导航属性
        public virtual List<Article> Articles { get; set; }
    }
}
