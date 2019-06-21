using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventHandlingApp.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Display(Name = "نوع مراسم")]
        public  EventType Type { get; set; }

        [Display(Name = " شرح مراسم")]
        public string Description{ get; set; }

        [Display(Name = "تاریخ " )]
        public DateTime Time { get; set; }

        [Display(Name = "بازه زمانی")]
        public int Duration { get; set; }

        [Display(Name = "پکیج پدیرایی")]
        public ReceptionPackage receptionPackage { get; set; }
        [Display(Name = "تعداد مهمانان")]
        public int Participants { get; set; }
        [Display(Name = " آدرس")]
        public EventLocation Location { get; set; }
    }
}