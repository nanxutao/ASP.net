using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcFlight.Models
{
    public class Flight
    {
        public int id { get; set; }
        [Required(ErrorMessage="班次字段必填")]
        public string FlightName { get; set; }
        [Required(ErrorMessage = "起点字段必填")]
        public string Start { get; set; }
        [Required(ErrorMessage = "终点字段必填")]
        public string Destination { get; set; }
        [Required(ErrorMessage = "起飞时间字段必填")]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = "结束时间字段必填")]
        public DateTime EndTime { get; set; }
        [Required(ErrorMessage = "价格字段必填")]
        [DataType(DataType.Currency)]
        public double price { get; set; }
    }
}