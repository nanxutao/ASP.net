using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcBookList19301330222_0009.Models
{
    public class Book
    {
        public int id { get; set; }
        [DisplayName("ISBN")]
        [Required(ErrorMessage="书号字段必填")]
        public string isbn { get; set; }
        [DisplayName("书名")]
        [Required(ErrorMessage = "书名字段必填")]
        [StringLength(50)]
        public string bookName { get; set; }
        [DisplayName("作者")]
        [Required(ErrorMessage = "作者字段必填")]
        [StringLength(10,MinimumLength=2)]
        public string author{ get; set; }
        [DisplayName("出版社")]
        [Required(ErrorMessage = "出版社字段必填")]
        public string press { get; set; }
        [DisplayName("出版日期")]
        [Required(ErrorMessage = "出版日期字段必填")]
        [DataType(DataType.Date)]
        public DateTime pressDate{ get; set; }
        [Range(0,1000)]
        [DisplayName("单价")]
        [Required(ErrorMessage = "单价字段必填")]
        [DataType(DataType.Currency)]
        public double price{ get; set; }
        [DisplayName("条形码")]
        public string barcode{ get; set; }
        [DisplayName("大小")]
        public string size{ get; set; }
        [DisplayName("重量")]
        public double ? weight{ get; set; }
        [DisplayName("开本")]
        public int ? format{ get; set; }

    }
}