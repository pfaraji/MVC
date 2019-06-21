using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventHandlingApp.Models
{
    public class EventLocation
    {
        public int Id { get; set; }

        [Display(Name = "ظرفیت سالن")]
        public int size { get; set; }

        [Display(Name = "نام سالن")]
        public string Name { get; set; }

        [Display(Name = "آدرس سالن")]
        public string Address { get; set; }

        [Display(Name = "مبلغ اجاره")]
        public double Rent { get; set; }
        public Event Event { get; set; }

    }
}