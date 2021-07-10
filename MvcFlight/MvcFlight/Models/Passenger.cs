using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace MvcFlight.Models
{
    public class Passenger
    {
        public int id { get; set; }
        [Required(ErrorMessage = "姓名字段必填")]
        public string Name { get; set; }
        [Required(ErrorMessage = "性别字段必填")]
        public string Sex { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "生日字段必填")]
        public DateTime BirthDay { get; set; }
        public string Phone { get; set; }
    }
}