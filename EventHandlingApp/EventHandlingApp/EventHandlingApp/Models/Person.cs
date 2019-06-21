using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventHandlingApp.Models
{
    public class Person
    {
        
        public int Id{ get; set; }
        [Display(Name = "نام")]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string Family { get; set; }

        [Display(Name = "کد ملی")]
        public int NationalCode { get; set; }
      
        public virtual ApplicationUser applicationUser { get; set; }
    }
}