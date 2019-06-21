using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventHandlingApp.Models
{
    public class Customer:Person
    {
        [Display(Name = "کد مشتری")]
        public int CustId { get; set; }

        [Display(Name = "شماره تلفن")]
        public string Phone { get; set; }
    }
}